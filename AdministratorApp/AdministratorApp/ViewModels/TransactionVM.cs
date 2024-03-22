using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AdministratorApp.Helpers.User;
using MailKit.Net.Smtp;
using MimeKit;
using QRCoder;
using TicketingDatabase.Data;
using TicketingDatabase.Models;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using AdministratorApp.Views.Template;
using System.Windows;

namespace AdministratorApp.ViewModels
{
    public partial class TransactionVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;
        private Transaction _transaction;

        public TransactionVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            LoadTransactionsAsync();
        }

        [ObservableProperty] private ObservableCollection<Transaction> transactions;
        [ObservableProperty] private Transaction selectedTransaction;


        public async Task LoadTransactionsAsync()
        {
            Transactions = new ObservableCollection<Transaction>(_context.Transactions.Include(t => t.DigitalTickets).ThenInclude(dt => dt.Ticket).ThenInclude(t => t.EventDate).Include(t => t.DigitalTickets).ThenInclude(dt => dt.Ticket).ThenInclude(t => t.Event));
        }

        [RelayCommand]
        public async Task EmailSenderTask()
        {
            var clientUser = _context.ClientUsers.FirstOrDefault(cu => cu.Id == SelectedTransaction.UserId);

            foreach (DigitalTicket digitalTicket in SelectedTransaction.DigitalTickets)
            {
                try
                {
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
                                    message.Subject = "Confirmation d'achat - Billet #" + digitalTicket.Ticket.SeatNumber;
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
                <td>{digitalTicket.Ticket.Event.Name}</td>
                <td>{digitalTicket.Ticket.Event.ArtistName}</td>
                <td>{digitalTicket.Ticket.EventDate.Date.ToString()}</td>
                <td>{digitalTicket.Ticket.SeatNumber}</td>
                <td>{digitalTicket.Ticket.Price.ToString("C", CultureInfo.GetCultureInfo("fr-CA"))}</td>
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
                }
                catch (Exception e)
                {
                    return;
                }
            }

            var messageWindow = "";
            if (selectedTransaction.DigitalTickets.Count > 1)
            {
                messageWindow = $@"Les billets ont été envoyés au client.";
            }
            else if (selectedTransaction.DigitalTickets.Count == 0)
            {
                messageWindow = $@"Aucun billet disponible.";
            }
            else
            {
                messageWindow = $@"Le billet a été envoyé au client.";
            }
            
            DeleteWindow(messageWindow, false, 450);
        }

        [RelayCommand]
        public void TransactionDetails(object obj)
        {
            selectedTransaction = (Transaction)(obj);
            _nav.TransactionDetails(this);
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
