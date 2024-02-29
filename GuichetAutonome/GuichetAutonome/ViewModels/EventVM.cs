using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace GuichetAutonome.ViewModels
{
    public partial class EventVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;
        private Event _myEvent;

        public EventVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
        }

        public EventVM(TicketingContext context, Event myEvent, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            _myEvent = myEvent;
        }

        [RelayCommand]
        public void EventDetails(object obj) => _nav.EventDetails(_myEvent);

        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count - 1];
        }

    }
}
