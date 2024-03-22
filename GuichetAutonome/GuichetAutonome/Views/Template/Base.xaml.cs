using GuichetAutonome.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GuichetAutonome.Helpers.User;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace GuichetAutonome.Views.Template
{
    /// <summary>
    /// Interaction logic for Base.xaml
    /// </summary>
    public partial class Base : Window
    {
        private TicketingContext _context;
        public Base(TicketingContext context)
        {
            _context = context;
            DbInitializer.Initialize(_context);
            InitializeComponent();
            this.DataContext = new NavigationVM(_context);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (UserService.cart.Count > 0)
            {
                foreach (Ticket ticket in UserService.cart)
                {
                    if (ticket.Status == "Purshasing")
                    {
                        _context.Tickets.FirstOrDefault(t => t.Id == ticket.Id).Status = "Available";
                        _context.Tickets.Update(ticket);
                    }
                }
                _context.SaveChangesAsync();
            }
            Login login = new Login();
            UserService.connected = null;
            UserService.cart = new ObservableCollection<Ticket>();
            login.Show(); 
            this.Close();
        }
    }
}
