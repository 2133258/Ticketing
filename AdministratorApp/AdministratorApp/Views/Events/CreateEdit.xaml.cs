using AdministratorApp.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TicketingDatabase.Data;
using TicketingDatabase.Models;
using Microsoft.Win32;
using System;
using System.Windows.Threading;
using System.Text.RegularExpressions;

namespace AdministratorApp.Views.Events
{
    /// <summary>
    /// Interaction logic for CreateEdit.xaml
    /// </summary>
    public partial class CreateEdit : UserControl
    {
        public CreateEdit(object vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void NumberTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (NumberTextBox.Text == "") return;

            if (!int.TryParse(NumberTextBox.Text, out int value) || value < 0 || value > 500)
            {
                MessageBox.Show("Entrez un nombre entre 0 et 500.");
                NumberTextBox.Text = "";
            }
        }

        private void ValidateNumberInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "[0-9]+");
        }
    }
}
