using GuichetAutonome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace GuichetAutonome.Views.Cart
{
    /// <summary>
    /// Interaction logic for Payments.xaml
    /// </summary>
    public partial class Payments : UserControl
    {
        public Payments(CartVM vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void ValidateNumberInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "[0-9]+");
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string pattern = @"^\w+[\w-\.]+\@\w{2,}(\.\w{2,})+$";
            if (!Regex.IsMatch(EmailTextBox.Text, pattern) && EmailTextBox.Text != "")
            {
                MessageBox.Show("Entrez un adresse courriel valide. (exemple@exemple.ca)");
                EmailTextBox.Text = "";
            }
        }

        private void CreditCardTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string pattern = @"^\d{16}$";
            if (!Regex.IsMatch(CardNumberTextBox.Text, pattern) && CardNumberTextBox.Text != "")
            {
                MessageBox.Show("Entrez un numéro de carte de crédit valide, long de 16 caractères avec aucun espace.");
                CardNumberTextBox.Text = "";
            }
        }

        private void CvvTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string pattern = @"^\d{3}$";
            if (!Regex.IsMatch(CardCvvTextBox.Text, pattern) && CardCvvTextBox.Text != "")
            {
                MessageBox.Show("Entrez un numéro de CVV valide, les trois chiffres en arrière de la carte de crédit.");
                CardCvvTextBox.Text = "";
            }
        }

        private void ExpirationDateTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string pattern = @"^(0[1-9]|1[0-2])\/([0-9]{2})$";
            if (!Regex.IsMatch(ExpirationDateTextBox.Text, pattern) && ExpirationDateTextBox.Text != "")
            {
                MessageBox.Show("Entrez une date d'expiration valide avec le format suivant : MM/AA.");
                ExpirationDateTextBox.Text = "";
            }
        }

        private void PhoneNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string pattern = @"^\+?\d{1,3}?[-. ]?\(?\d{1,3}\)?[-. ]?\d{1,4}[-. ]?\d{1,4}[-. ]?\d{1,9}$";
            if (!Regex.IsMatch(PhoneTextBox.Text, pattern) && PhoneTextBox.Text != "")
            {
                MessageBox.Show("Entez un numéro de téléphone valide avec le format suivant : xxx-xxx-xxxx.");
                PhoneTextBox.Text = "";
            }
        }

        private void PhoneNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only numbers and dash
            e.Handled = !Regex.IsMatch(e.Text, "[0-9-]+");
        }
    }
}
