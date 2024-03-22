using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AdministratorApp;
using AdministratorApp.Helpers.User;
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
            EventList(this);
            User = UserService.connected;
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
        public void EventList(object obj)
        { 
            CurrentViews.Clear();
            CurrentView = new Views.Events.List(_context, this);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- CreateEditView ---- */
        public void EventCreateEdit(EventVM vm)
        {
            CurrentView = new Views.Events.CreateEdit(vm);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- SeatSelection ---- */
        public void EventRowsSelection(EventVM vm)
        {
            CurrentView = new Views.Events.RowsSelection(vm);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- SeatSelection ---- */
        public void EventSeatsSelection(EventVM vm)
        {
            CurrentView = new Views.Events.SeatsSelection(vm);
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
        public void RoomEdit(RoomConfigVM vm)
        {
            CurrentView = new Views.RoomConfig.Edit(vm);
            CurrentViews.Add(CurrentView);
        }
        [RelayCommand] /* ---- CreateEditView ---- */
        public void RowCreateEdit(RoomConfigVM vm)
        {
            CurrentView = new Views.RoomConfig.Row.CreateEdit(vm);
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
        public void SaleDetails(SaleVM vm)
        {
            CurrentView = new Views.Sales.Details(vm);
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
        public void TransactionDetails(TransactionVM vm)
        {
            CurrentView = new Views.Transactions.Details(vm);
            CurrentViews.Add(CurrentView);
        }
        #endregion
    }
}
