using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuichetAutonome.Helpers.User;
using GuichetAutonome.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace GuichetAutonome.ViewModels
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
                    .Where(e => e.UserName == username)
                    .FirstOrDefaultAsync();

                if (matchingUser is not null)
                if (matchingUser.Type == "Client")
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
            // Check if passwords match
            if (addPassword != addPasswordAgain)
            {
                // Provide feedback that the passwords do not match
                return;
            }
            try
            {
                // Create a new Client or User instance
                var newUser = new Client // Or use User if you're not creating a Client specifically
                {
                    UserName = addUsername,
                    Password = CryptographyHelper.HashPassword(addPassword),
                    Email = addEmail,
                    CreationDate = DateTime.UtcNow,
                    Type = "Client",
                    Cart = new ObservableCollection<Ticket>()
                    // Initialize other fields as necessary
                    // For a Client, you might also need FirstName, LastName, etc.
                };

                // Assuming you have a DbContext for Entity Framework Core
                // var dbContext = new YourDbContext();
                // dbContext.Users.Add(newUser); // Adjust for your actual context and DbSet name
                // await dbContext.SaveChangesAsync();
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                // Provide feedback or navigate away upon successful creation
                UserService.connected = newUser;
                LoginSuccessful?.Invoke(this, EventArgs.Empty);
                return;
            }
            catch (Exception) { return; }
        }
    }
}
