using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace GuichetAutonome.ViewModels
{
    public partial class TicketVM : ObservableObject
    {
        TicketingContext _context;
        Event _selectedEvent;

        public TicketVM(TicketingContext context, Event selectedEvent)
        {
            _context = context;
            _selectedEvent = selectedEvent;
            Initializer();
        }

        private async Task Initializer()
        {
            await LoadTicketsAsync();
        }

        [ObservableProperty] private Section selectedSection;
        [ObservableProperty] private ObservableCollection<Section> sections;

        [ObservableProperty] private Row selectedRow;
        [ObservableProperty] private ObservableCollection<Row> rows;
        [ObservableProperty] private bool rowComboboxActive;

        [ObservableProperty] private Seat selectedSeat;
        [ObservableProperty] private ObservableCollection<Seat> seats;
        [ObservableProperty] private bool seatComboboxActive;

        public async Task LoadTicketsAsync()
        {
            var sections = await _context.Sections.Include(s => s.Rows).ThenInclude(r => r.Seats.Where(s => s.IsAvailable)).Where(s => s.RoomId == _selectedEvent.RoomId).ToListAsync();
            var tickets = await _context.Tickets.Where(t => t.EventId == _selectedEvent.Id).Where(t => t.Status == "Available").ToListAsync();
            Sections = new ObservableCollection<Section>(sections);
            Rows = new ObservableCollection<Row>();
            Seats = new ObservableCollection<Seat>();
        }


    }
}
