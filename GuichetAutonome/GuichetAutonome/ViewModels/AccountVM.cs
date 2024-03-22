using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuichetAutonome.Helpers.User;
using TicketingDatabase.Data;
using TicketingDatabase.Models;
using GuichetAutonome.Views.Template;
using System.Windows;

namespace GuichetAutonome.ViewModels
{
    public partial class AccountVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;

        public AccountVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            ConnectedClient = _context.ClientUsers.Find(UserService.connected.Id);
        }

        [ObservableProperty] private Client connectedClient;

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
    }
}
