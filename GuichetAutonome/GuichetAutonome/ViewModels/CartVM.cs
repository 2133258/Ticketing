using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace GuichetAutonome.ViewModels
{
    public partial class CartVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;

        public CartVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
        }

        [ObservableProperty] ObservableCollection<Ticket> _tickets;

        [RelayCommand]
        public void CartPayment()
        {
            _nav.CartPayment(this );
        }

        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count - 1];
        }

    }
}
