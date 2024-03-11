using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            LoadTransactionsAsync();
        }

        [ObservableProperty] private ObservableCollection<Transaction> transactions;
        [ObservableProperty] private Transaction selectedTransaction;


        public async Task LoadTransactionsAsync()
        {
            Transactions = new ObservableCollection<Transaction>(_context.Transactions);
        }

        [RelayCommand]
        public void TransactionDetails(object obj)
        {
            selectedTransaction = (Transaction)(obj);
            _nav.TransactionDetails(this);
        }

        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count - 1];
        }
    }
}
