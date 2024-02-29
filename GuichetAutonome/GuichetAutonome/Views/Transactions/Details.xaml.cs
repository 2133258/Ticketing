using GuichetAutonome.ViewModels;
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

namespace GuichetAutonome.Views.Transactions
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : UserControl
    {
        private TicketingContext _context;
        private Transaction _transaction;
        public Details(TicketingContext context, Transaction transaction, NavigationVM nav)
        {
            _context = context;
            _transaction = transaction;
            InitializeComponent();
            this.DataContext = new TransactionVM(context, nav);
        }
    }
}
