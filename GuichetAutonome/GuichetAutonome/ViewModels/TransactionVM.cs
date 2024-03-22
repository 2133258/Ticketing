using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MimeKit;
using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using TicketingDatabase.Data;
using TicketingDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace GuichetAutonome.ViewModels
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
            Transactions = new ObservableCollection<Transaction>(_context.Transactions.Include(t => t.DigitalTickets).ThenInclude(dt => dt.Ticket).ThenInclude(t => t.EventDate).Include(t => t.DigitalTickets).ThenInclude(dt => dt.Ticket).ThenInclude(t => t.Event));
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
