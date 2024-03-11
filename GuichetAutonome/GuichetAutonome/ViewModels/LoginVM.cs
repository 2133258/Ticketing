using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuichetAutonome.Helpers.User;
using GuichetAutonome.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketingDatabase.Data;

namespace GuichetAutonome.ViewModels
{
    public partial class LoginVM : ObservableObject
    {
        private TicketingContext _context;
        public event EventHandler LoginSuccessful;

        public LoginVM(TicketingContext context)
        {
            _context = context;
            UserService.connectedEmploye = null;
        }

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string addUsername;

        [ObservableProperty]
        string addPassword;

        [RelayCommand]
        public async Task Login()
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) { return; }
            try
            {
                var matchingUser = await _context.Users
                    .Include(x => x.Type)
                    .Where(e => e.UserName == username)
                    .FirstOrDefaultAsync();

                if (matchingUser is not null)
                if (matchingUser.Type == "Client")
                if (CryptographyHelper.ValidateHashedPassword(password, matchingUser.Password))
                {
                    UserService.connectedEmploye = matchingUser;
                    LoginSuccessful?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
            catch (Exception) { return; }
        }
    }
}
