using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace GuichetAutonome.ViewModels
{
    public partial class EventVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;

        public EventVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            LoadEventsAsync();
        }
        
        [ObservableProperty]
        ObservableCollection<Views.Events.Ticket> ticketViews;

        [ObservableProperty] ObservableCollection<Event> events;
        [ObservableProperty] Event selectedEvent;

        [ObservableProperty] int nbBillet;


        public async Task LoadEventsAsync()
        {
            var events = await _context.Events.Where(e => e.IsActive).ToListAsync();
            Events = new ObservableCollection<Event>(events);
            TicketViews = new ObservableCollection<Views.Events.Ticket>();
        }

        [RelayCommand]
        public void EventDetails(object obj)
        {
            SelectedEvent = (Event)(obj);
            _nav.EventDetails(this);
        }

        [RelayCommand]
        public void EventTicketChoice()
        {
            if (nbBillet <= 0 || nbBillet > 4) { return; }
            SetTicketList();
            _nav.EventTicketChoice(this);
        }

        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count - 1];
        }

        private void SetTicketList()
        {
            TicketViews.Clear();
            TicketViews = new ObservableCollection<Views.Events.Ticket>();
            for (int i = 0; i < NbBillet; i++)
            {
                TicketViews.Add(new Views.Events.Ticket(_context, SelectedEvent));
            }
        }

    }
}
