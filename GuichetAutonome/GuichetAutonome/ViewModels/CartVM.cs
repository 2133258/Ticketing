using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuichetAutonome.Helpers.User;
using TicketingDatabase.Data;
using TicketingDatabase.Models;
using System.Globalization;
using MailKit.Net.Smtp;
using MimeKit;
using QRCoder;
using System.IO;
using GuichetAutonome.Views.Template;
using System.Windows;

namespace GuichetAutonome.ViewModels
{
    public partial class CartVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;

        public CartVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            ConnectedClient = _context.ClientUsers.Find(UserService.connected.Id);
            LoadCart();
        }


        [RelayCommand]
        private void SaveChanges()
        {
            if (ConnectedClient != null)
            {
                if (string.IsNullOrWhiteSpace(ConnectedClient.FirstName) ||
                    string.IsNullOrWhiteSpace(ConnectedClient.LastName) ||
                    string.IsNullOrWhiteSpace(ConnectedClient.Email) ||
                    string.IsNullOrWhiteSpace(ConnectedClient.Phone))
                {
                    DeleteWindow("Entrez toutes vos information avant d'enregistrer.", false, 450);
                    return;
                }
                _context.Update(ConnectedClient);
                _context.SaveChanges();
                DeleteWindow("Vos informations ont été sauvegarder.", false, 450);
            }
        }

        [ObservableProperty] private Client connectedClient;

        [ObservableProperty] private string fullNameCard;
        [ObservableProperty] private string cardNumber;
        [ObservableProperty] private int cardCVV;
        [ObservableProperty] private DateTime expirationDate;

        [ObservableProperty] ObservableCollection<Ticket> tickets;

        [ObservableProperty] private double totalPrice;
        [ObservableProperty] private double tPS;
        [ObservableProperty] private double tVQ;
        [ObservableProperty] private double totalPriceTaxes;

        private void LoadCart()
        {
            Tickets = UserService.cart is null ? new ObservableCollection<Ticket>() : new ObservableCollection<Ticket>(UserService.cart);
            TotalPrice = 0;
            foreach (Ticket ticket in Tickets)
            {
                TotalPrice += ticket.Price;
            }

            TPS = TotalPrice * 0.05;
            TVQ = TotalPrice * 0.09975;

            TotalPriceTaxes = TotalPrice + TPS + TVQ;
        }

        [RelayCommand]
        private void ConfirmPayment()
        {
            if (string.IsNullOrWhiteSpace(FullNameCard) ||
                CardCVV <= 0 ||
                string.IsNullOrWhiteSpace(ConnectedClient.FirstName) ||
                string.IsNullOrWhiteSpace(ConnectedClient.LastName) ||
                string.IsNullOrWhiteSpace(ConnectedClient.Email) ||
                string.IsNullOrWhiteSpace(CardNumber) ||
                string.IsNullOrWhiteSpace(ConnectedClient.Phone))
            {
                DeleteWindow("Vous devez entrer vos informations de paiement avant de confirmer l'achat.",false,500);
                return;
            }

            string lastFourDigits = CardNumber.Substring(CardNumber.Length - 4);
            CardNumber = lastFourDigits;

            SuccessPage();

            DateTime now = DateTime.Now;
            int currentYear = now.Year;
            int currentWeek = GetWeekOfYear(now);

            var salesThisYear = _context.Sales
                                        .Where(s => s.Date.Year == currentYear && s.Event == null)
                                        .ToList();

            var existingSale = salesThisYear.FirstOrDefault(s => GetWeekOfYear(s.Date) == currentWeek);

            var clientUser = _context.ClientUsers.FirstOrDefault(cu => cu.Id == UserService.connected.Id);

            if (existingSale == null)
            {
                existingSale = new Sale
                {
                    Date = now,
                    TotalPrice = 0,
                    TPS = 0,
                    TVQ = 0,
                    TotalPriceTax = 0,
                };

                _context.Sales.Add(existingSale);
                
                _context.SaveChanges();
            }

            var transaction = new Transaction
            {
                Date = DateTime.Now,
                TotalPrice = TotalPrice,
                TPS = TPS,              
                TVQ = TVQ,              
                TotalPriceTax = totalPriceTaxes,
                SaleId = existingSale.Id,
                UserId = UserService.connected.Id,
            };

            if (existingSale != null)
            {
                existingSale.TotalPrice += totalPrice;
                existingSale.TPS += TPS;
                existingSale.TVQ += TVQ;
                existingSale.TotalPriceTax += totalPriceTaxes;
            }

            _context.Transactions.Add(transaction);
            
            _context.SaveChanges();

            foreach (var ticket in UserService.cart)
            {
                if (ticket != null)
                {
                    var digitalTicket = new DigitalTicket
                    {
                        UniqueCode = GenerateUniqueCode(),
                        DateSent = DateTime.Now,
                        TicketId = ticket.Id,
                        UserId = UserService.connected.Id,
                        TransactionId = transaction.Id
                    };

                    
                    using (var qrGenerator = new QRCodeGenerator())
                    {
                        var qrData = qrGenerator.CreateQrCode(digitalTicket.UniqueCode, QRCodeGenerator.ECCLevel.Q);
                        using (var qrCode = new QRCode(qrData))
                        {
                            using (var qrCodeImage = qrCode.GetGraphic(20))
                            {
                                using (var ms = new MemoryStream())
                                {
                                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    var qrCodeBytes = ms.ToArray();

                                   
                                    var qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);

                                    // Préparation du message email
                                    var message = new MimeMessage();
                                    message.From.Add(new MailboxAddress("Théatre Chic", "smitypro@gmail.com"));
                                    message.To.Add(new MailboxAddress(clientUser.FirstName + " " + clientUser.LastName, clientUser.Email));
                                    message.Subject = "Confirmation d'achat - Billet #" + ticket.SeatNumber;
                                    CultureInfo ci = CultureInfo.GetCultureInfo("fr-CA");
                                    Thread.CurrentThread.CurrentCulture = ci;
                                    Thread.CurrentThread.CurrentUICulture = ci;
                                    // Construction du tableau HTML pour les détails du ticket
                                    var htmlTicketDetails = $@"
        <table>
            <tr>
                <th>Évènement</th>
                <th>Artiste</th>
                <th>Date</th>
                <th>Siège</th>
                <th>Prix</th>
            </tr>
            <tr>
                <td>{ticket.Event.Name}</td>
                <td>{ticket.Event.ArtistName}</td>
                <td>{ticket.EventDate.Date.ToString()}</td>
                <td>{ticket.SeatNumber}</td>
                <td>{ticket.Price.ToString("C", CultureInfo.GetCultureInfo("fr-CA"))}</td>
            </tr>
        </table>
        <p>Voici votre QR Code :</p>
        <img src=""data:image/png;base64,{qrCodeBase64}"" />
        <p>Veuillez garder ce billet pour l'accès à l'évènement.</p>";

                                    var builder = new BodyBuilder
                                    {
                                        HtmlBody = htmlTicketDetails
                                    };

                                    message.Body = builder.ToMessageBody();

                                    using (var client = new SmtpClient())
                                    {
                                        client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                                        client.Authenticate("smitypro@gmail.com", "sdhk ttqv roky hkgg");
                                        client.Send(message);
                                        client.Disconnect(true);
                                    }
                                }
                            }
                        }
                    }

                    ticket.Status = "Purshased";

                    _context.DigitalTickets.Add(digitalTicket);
                }
            }

            _context.SaveChanges();

            SuccessPage();
        }

        public int GetWeekOfYear(DateTime date)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            int weekNum = ci.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        private string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString();
        }

        [RelayCommand]
        public void CartPayment()
        {
            if (Tickets.Count <= 0)
            {
                DeleteWindow("Vous n'avez aucun billet dans votre panier.",false,450);
                return;
            }
            _nav.CartPayment(this );
        }

        [RelayCommand]
        public void SuccessPage()
        {
            _nav.SuccessPage(this);
        }

        [ObservableProperty] Visibility isDeleteVisibility;
        [ObservableProperty] Visibility isNotDeleteVisibility;
        [ObservableProperty] private string deleteMessage;
        [ObservableProperty] private double width;
        public bool DeleteWindow(string message, bool isDelete, double width)
        {
            if (isDelete)
            {
                IsDeleteVisibility = Visibility.Visible;
                IsNotDeleteVisibility = Visibility.Collapsed;
            }
            else
            {
                IsDeleteVisibility = Visibility.Collapsed;
                IsNotDeleteVisibility = Visibility.Visible;
            }
            DeleteConfirmation view = new DeleteConfirmation(this);
            DeleteMessage = message;
            Width = width;
            view.ShowDialog();
            return view.result;
        }


        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count - 1];
        }

    }
}
