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
    }
}
