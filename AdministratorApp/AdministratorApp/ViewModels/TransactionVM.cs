using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace AdministratorApp.ViewModels
{
    public partial class TransactionVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;
        private Transaction _transaction;

        public TransactionVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
        }

        public TransactionVM(TicketingContext context, Transaction transaction, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            _transaction = transaction;
        }

        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count - 1];
        }
    }
}
