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
using TicketingDatabase.Models;

namespace AdministratorApp.Views.RoomConfig
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : UserControl
    {
        public Edit(RoomConfigVM vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
