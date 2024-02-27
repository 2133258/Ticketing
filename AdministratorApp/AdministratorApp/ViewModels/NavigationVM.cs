using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AdministratorApp;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace AdministratorApp.ViewModels
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

        #region Commandes

        /* ------------------------ Events ------------------------ */
        [RelayCommand] /* ---- MainView ---- */
        private void EventList(object obj)
        { 
            CurrentViews.Clear();
            CurrentView = new Views.Events.List(_context, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- CreateView ---- */
        public void EventCreate(object obj)
        {
            CurrentView = new Views.Events.CreateEdit(_context, false, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- EditView ---- */
        public void EventEdit(object obj)
        {
            CurrentView = new Views.Events.CreateEdit(_context, true, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- SeatSelection ---- */
        public void EventSeatSelection(object obj)
        {
            CurrentView = new Views.Events.SeatsSelection(_context, this);
            CurrentViews.Add(CurrentView);
        }

        /* ------------------------ RoomConfig ------------------------ */
        [RelayCommand] /* ---- MainView ---- */
        private void RoomOverview(object obj)
        {
            CurrentViews.Clear();
            CurrentView = new Views.RoomConfig.FullView(_context, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- MainView ---- */
        public void RoomEdit(object obj)
        {
            CurrentView = new Views.RoomConfig.Edit(_context, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- CreateView ---- */
        public void RowCreate(object obj)
        {
            CurrentView = new Views.RoomConfig.Row.CreateEdit(_context, false, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- EditView ---- */
        public void RowEdit(object obj)
        {
            CurrentView = new Views.RoomConfig.Row.CreateEdit(_context, true, this);
            CurrentViews.Add(CurrentView);
        }
        

        /* ------------------------ Sale ------------------------ */
        [RelayCommand] /* ---- MainView ---- */
        private void SaleList(object obj)
        {
            CurrentViews.Clear();
            CurrentView = new Views.Sales.List(_context, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- DetailsView ---- */
        public void SaleDetails(Sale sale)
        {
            CurrentView = new Views.Sales.Details(_context, sale, this);
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
        public void TransactionDetails(Transaction transaction)
        {
            CurrentView = new Views.Transactions.Details(_context, transaction, this);
            CurrentViews.Add(CurrentView);
        }
        #endregion
    }
}
