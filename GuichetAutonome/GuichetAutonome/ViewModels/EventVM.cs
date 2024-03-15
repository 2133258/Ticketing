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
            Initializer();
        }

        private async Task Initializer()
        {
            await LoadEventsAsync();
        }

        [ObservableProperty] ObservableCollection<Event> events;
        [ObservableProperty] Event selectedEvent;

        [ObservableProperty] int nbBillet;

        [ObservableProperty] private Section selectedSection;
        [ObservableProperty] private ObservableCollection<Section> sections;
        [ObservableProperty] private Row selectedRow;
        [ObservableProperty] private Seat selectedSeat;

        [ObservableProperty] private ObservableCollection<Ticket> chosenTickets;
        [ObservableProperty] private ObservableCollection<Ticket> availableTickets;


        public async Task LoadTicketsAsync()
        {
            var sections = await _context.Sections.Include(s => s.Rows).ThenInclude(r => r.Seats.Where(s => s.IsAvailable)).ThenInclude(s => s.Ticket).Where(s => s.RoomId == selectedEvent.RoomId).ToListAsync();
            var availableTickets = await _context.Tickets.Where(t => t.EventId == selectedEvent.Id).Where(t => t.Status == "Available").ToListAsync();
            Sections = new ObservableCollection<Section>(sections);
            AvailableTickets = new ObservableCollection<Ticket>(availableTickets);
        }

        public async Task LoadEventsAsync()
        {
            var events = await _context.Events.Where(e => e.IsActive).ToListAsync();
            Events = new ObservableCollection<Event>(events);
        }

        [RelayCommand]
        public async Task AddSeatToList(object obj)
        {
            if (obj is not Seat) return;
            Seat seat = (Seat)obj;

            if (AvailableTickets.Contains(seat.Ticket))
            {
                ChosenTickets.Add(seat.Ticket);
                seat.Ticket.Status = "Pending";
            }
        }

        [RelayCommand]
        public void EventDetails(object obj)
        {
            SelectedEvent = (Event)(obj);
            _nav.EventDetails(this);
        }

        [RelayCommand]
        public async Task EventTicketChoice()
        {
            if (nbBillet <= 0 || nbBillet > 4) { return; }
            await LoadTicketsAsync();
            _nav.EventTicketChoice(this);
        }

        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count - 1];
        }
    }
}
