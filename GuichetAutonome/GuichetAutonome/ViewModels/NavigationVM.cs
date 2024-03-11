using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace GuichetAutonome.ViewModels
{
    public partial class NavigationVM : ObservableObject
    {
        TicketingContext _context;

        public NavigationVM(TicketingContext context)
        {
            _context = context;
            currentViews = new List<object>();
        }

        [ObservableProperty]
        object currentView;

        [ObservableProperty]
        List<object> currentViews;

        [ObservableProperty]
        User user;

        [ObservableProperty]
        Visibility adminButtonVisibility;


        /* ------------------------ Events ------------------------ */
        [RelayCommand] /* ---- MainView ---- */
        private void EventList(object obj)
        {
            CurrentViews.Clear();
            CurrentView = new Views.Events.List(_context, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- DetailsView ---- */
        public void EventDetails(EventVM vm)
        {
            CurrentView = new Views.Events.Details(vm);
            CurrentViews.Add(CurrentView);
        }

        /* ------------------------ Events ------------------------ */
        [RelayCommand] /* ---- MainView ---- */
        private void CartDetails(object obj)
        {
            CurrentViews.Clear();
            CurrentView = new Views.Cart.Details(_context, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- PaymentView ---- */
        public void CartPayment(CartVM vm)
        {
            CurrentView = new Views.Cart.Payments(vm);
            CurrentViews.Add(CurrentView);
        }

        /* ------------------------ Transaction ------------------------ */
        [RelayCommand] /* ---- MainView ---- */
        private void TransactionList(object obj)
        {
            CurrentViews.Clear();
            CurrentView = new Views.Transactions.List(_context, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- DetailsView ---- */
        public void TransactionDetails(object vm)
        {
            CurrentView = new Views.Transactions.Details((TransactionVM)vm);
            CurrentViews.Add(CurrentView);
        }

        /* ------------------------ Account ------------------------ */
        [RelayCommand] /* ---- MainView ---- */
        private void AccountDetails(object obj)
        {
            CurrentViews.Clear();
            CurrentView = new Views.AccountInfo(_context, this);
            CurrentViews.Add(CurrentView);
        }
    }
}
