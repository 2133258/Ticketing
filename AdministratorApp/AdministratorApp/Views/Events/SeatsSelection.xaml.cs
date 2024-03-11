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
using TicketingDatabase.Data;

namespace AdministratorApp.Views.Events
{
    /// <summary>
    /// Interaction logic for SeatsSelection.xaml
    /// </summary>
    public partial class SeatsSelection : UserControl
    {
        public SeatsSelection(EventVM vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
