using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using AdministratorApp.Helpers.User;
using AdministratorApp.ViewModels;
using TicketingDatabase.Data;

namespace AdministratorApp.Views.Template
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

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            UserService.connected = null;
            login.Show();
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
