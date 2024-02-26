using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using TicketingDatabase.Data;

namespace AdministratorApp.ViewModels
{
    public partial class EventVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;

        public EventVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
        }

        [RelayCommand]
        public void EventEdit(object obj) => _nav.EventEdit(this);

        [RelayCommand]
        public void EventSelectionSeat(object obj) => _nav.EventSeatSelection(this);

        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count-1];
        }

    }
}
