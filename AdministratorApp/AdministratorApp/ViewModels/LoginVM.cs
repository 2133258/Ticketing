using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AdministratorApp.Helpers.User;
using AdministratorApp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace AdministratorApp.ViewModels
{
    public partial class LoginVM : ObservableObject
    {
        private TicketingContext _context;
        public event EventHandler LoginSuccessful;

        public LoginVM(TicketingContext context)
        {
            _context = context;
            UserService.connected = null;
        }

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string addUsername;

        [ObservableProperty]
        string addPassword;

        [ObservableProperty]
        string addPasswordAgain;

        [ObservableProperty]
        string addEmail;

        [RelayCommand]
        public async Task Login()
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) { return; }
            try
            {
                var matchingUser = await _context.Users
                    .Where(e => e.UserName == username && e.Type == "Administrator")
                    .FirstOrDefaultAsync();

                if (matchingUser is not null)
                if (matchingUser.Type == "Administrator")
                if (CryptographyHelper.ValidateHashedPassword(password, matchingUser.Password))
                {
                    UserService.connected = matchingUser;
                    LoginSuccessful?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }catch (Exception) { return; }
        }

        [RelayCommand]
        public async Task CreateUser()
        {
            if (string.IsNullOrEmpty(addUsername) || string.IsNullOrEmpty(addPassword) || string.IsNullOrEmpty(addPasswordAgain) || string.IsNullOrEmpty(addEmail)) { return; }
            if (addPassword != addPasswordAgain)
            {
                return;
            }
            try
            {
                var newUser = new Administrator() 
                {
                    UserName = addUsername,
                    FirstName = "William",
                    LastName = "Savard",
                    Password = CryptographyHelper.HashPassword(addPassword),
                    Email = addEmail,
                    CreationDate = DateTime.UtcNow,
                    Type = "Administrator",
                };

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                UserService.connected = newUser;
                LoginSuccessful?.Invoke(this, EventArgs.Empty);
                return;
            }
            catch (Exception) { return; }
        }
    }
}
