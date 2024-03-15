using GuichetAutonome.Helpers.User;
using System;
using System.Collections.Generic;
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
using GuichetAutonome.ViewModels;
using GuichetAutonome.Views.Template;
using TicketingDatabase.Data;

namespace GuichetAutonome.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        TicketingContext _context;
        bool dragVerif = true;

        public Login()
        {
            _context = new TicketingContext();
            DbInitializer.Initialize(_context);
            InitializeComponent();
            var vm = new LoginVM(_context);
            this.DataContext = vm;
            vm.LoginSuccessful += ViewModel_LoginSuccessful;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dragVerif)
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            else
            {
                dragVerif = true;
            }
        }

        private void ViewModel_LoginSuccessful(object sender, EventArgs e)
        {
            var mainWindow = new Base(_context);
            mainWindow.Show();

            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameText.Text == "")
            {
                ErrorUserName.Text = "Entrez un utilisateur !";
            }
            else
            {
                ErrorUserName.Text = "";
            }
            if (PassWordText.Password == "")
            {
                ErrorPassWord.Text = "Entrez un mot de passe !";
            }
            else
            {
                ErrorPassWord.Text = "";
            }
            
        }
    }
}
