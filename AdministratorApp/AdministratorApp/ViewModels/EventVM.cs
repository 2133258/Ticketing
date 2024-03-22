using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using TicketingDatabase.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AdministratorApp.Views.Events;
using TicketingDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using AdministratorApp.Views.Template;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using Microsoft.Extensions.Logging;

namespace AdministratorApp.ViewModels
{
    public partial class EventVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;
        private bool _isModify;
        public EventVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            _isModify = false;
            Initializer();
        }

        private async void Initializer()
        {
            await LoadEventsAsync();
            await LoadRoomConfigAsync();
        }

        [ObservableProperty] ObservableCollection<Event> events;
        [ObservableProperty] Event selectedEvent;
        [ObservableProperty] DateTime? startingDateEvent;
        [ObservableProperty] DateTime? endDateEvent;


        [ObservableProperty] string eventName;
        [ObservableProperty] private string artistName;
        [ObservableProperty] int duration;
        [ObservableProperty] string description; 
        [ObservableProperty] bool isActive;

        [ObservableProperty] Section selectedSection;

        [ObservableProperty] Visibility createEditVisibility;
        [ObservableProperty] string createEditButtonName;

        [ObservableProperty] ObservableCollection<EventDate> eventDates; 
        [ObservableProperty] DateTime? selectedDate; 
        [ObservableProperty] EventDate selectedEventDate;
        [ObservableProperty] private int _selectedHour;
        [ObservableProperty] private int _selectedMinute;
        [ObservableProperty] private ObservableCollection<int> hours;
        [ObservableProperty] private ObservableCollection<int> minutes;

        [ObservableProperty] RoomConfig roomConfig;
        [ObservableProperty] Room room;
        [ObservableProperty] private Section selectedSectionRoom;
        [ObservableProperty] private Row selectedRow;

        [ObservableProperty] ObservableCollection<Ticket> tickets;

        public async Task LoadRoomConfigAsync()
        {
            try
            {
                var config = await _context.RoomConfigs
                    .Include(r => r.Sections)
                    .ThenInclude(s => s.Rows)
                    .ThenInclude(r => r.Seats)
                    .FirstOrDefaultAsync();

                RoomConfig = config ?? new RoomConfig { Sections = new ObservableCollection<Section>() };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task LoadEventsAsync()
        {
            var events = await _context.Events.Include(e => e.Room).ThenInclude(r => r.Sections).ThenInclude(s => s.Rows).ThenInclude(r => r.Seats).ToListAsync();
            Events = new ObservableCollection<Event>(events);

            Hours = new ObservableCollection<int>(Enumerable.Range(0, 24));
            Minutes = new ObservableCollection<int>(Enumerable.Range(0, 12).Select(i => i * 5));
            EventDates = new ObservableCollection<EventDate>();
        }

        [RelayCommand]
        public async Task AddOrUpdateTask()
        {
            if (string.IsNullOrEmpty(eventName) || string.IsNullOrEmpty(artistName) || string.IsNullOrEmpty(description) ||
                duration == null || duration <= 0)
            {
                return;
            }
            
            if (_isModify)
            {
                await UpdateEventAsync();
            }
            else
            {
                await AddEventAsync();
            }
        }

        public async Task AddEventAsync()
        {
            Event newEvent = new Event
            {
                Name = eventName,
                ArtistName = artistName,
                Description = description,
                Duration = duration,
                IsActive = isActive,
                EventDates = new ObservableCollection<EventDate>(EventDates.OrderBy(e => e.Date)),
                StartingDate = EventDates.First().Date,
                EndingDate = EventDates.Last().Date,
                Room = Room
            };

            await _context.Events.AddAsync(newEvent);

            await _context.SaveChangesAsync();

            var tickets = new List<Ticket>();
            int sectionCount = 0;
            foreach (Section roomSection in newEvent.Room.Sections)
            {
                sectionCount++;
                int rowCount = 0;
                foreach (Row roomSectionRow in roomSection.Rows)
                {
                    rowCount++;
                    int seatCount = 0;
                    foreach (Seat seat in roomSectionRow.Seats.Where(s => s.IsAvailable))
                    {
                        seatCount++;
                        string seatNumber = $"{sectionCount}{rowCount:D2}{seatCount:D2}";

                        int quoting = sectionCount + rowCount + seatCount;

                        foreach (EventDate eventDate in newEvent.EventDates)
                        {
                            var ticket = new Ticket
                            {
                                EventId = newEvent.Id,
                                SeatId = seat.Id,
                                Price = seat.Price.HasValue ? seat.Price.Value : 0,
                                Status = "Available",
                                SeatNumber = seatNumber,
                                Quoting = quoting,
                                EventDateId = eventDate.Id,
                                EventDate = eventDate,
                            };

                            tickets.Add(ticket);
                        }
                    }
                }
            }

            await _context.Tickets.AddRangeAsync(tickets);

            await _context.SaveChangesAsync();

            _nav.EventList(this);
        }

        public async Task UpdateEventAsync()
        {
            var existingEvent = await _context.Events
                .Include(e => e.Room)
                    .ThenInclude(r => r.Sections)
                        .ThenInclude(s => s.Rows)
                            .ThenInclude(row => row.Seats)
                .Include(e => e.Tickets)
                .FirstOrDefaultAsync(e => e.Id == SelectedEvent.Id);

            if (existingEvent == null) return;

            existingEvent.Name = eventName;
            existingEvent.ArtistName = artistName;
            existingEvent.Duration = duration;
            existingEvent.Description = description;
            existingEvent.IsActive = isActive;
            existingEvent.EventDates = new ObservableCollection<EventDate>(EventDates);
            existingEvent.StartingDate = EventDates.First().Date;
            existingEvent.EndingDate = EventDates.Last().Date;
            existingEvent.Room = Room;

            var newDates = EventDates.Where(nd => existingEvent.EventDates.All(ed => ed.Date != nd.Date)).ToList();
            var removedDates = existingEvent.EventDates.Where(ed => EventDates.All(nd => nd.Date != ed.Date)).ToList();
            foreach (var date in newDates)
            {
                existingEvent.EventDates.Add(date);
            }
            foreach (var date in removedDates)
            {
                existingEvent.EventDates.Remove(date);
                var ticketsToRemove = existingEvent.Tickets.Where(t => t.EventDate.Date == date.Date).ToList();
                foreach (var ticket in ticketsToRemove)
                {
                    _context.Tickets.Remove(ticket);
                }
            }
            int sectionCount = 0;
            foreach (var section in SelectedEvent.Room.Sections)
            {
                sectionCount++;
                int rowCount = 0;
                foreach (var row in section.Rows)
                {
                    rowCount++;
                    int seatCount = 0;
                    foreach (var updatedSeat in row.Seats)
                    {
                        seatCount++;
                        var existingSeat = existingEvent.Room.Sections
                            .SelectMany(s => s.Rows)
                            .SelectMany(r => r.Seats)
                            .FirstOrDefault(s => s.Id == updatedSeat.Id);

                        if (existingSeat != null)
                        {
                            _context.Entry(existingSeat).CurrentValues.SetValues(updatedSeat);

                            var existingTicket = existingEvent.Tickets.FirstOrDefault(t => t.SeatId == updatedSeat.Id);
                            if (updatedSeat.IsAvailable && existingTicket == null)
                            {
                                string seatNumber = $"{sectionCount}{rowCount:D2}{seatCount:D2}";

                                int quoting = sectionCount + rowCount + seatCount;
                                foreach (var eventDate in existingEvent.EventDates)
                                {
                                    var newTicket = new Ticket
                                    {
                                        EventId = existingEvent.Id,
                                        SeatId = updatedSeat.Id,
                                        Price = updatedSeat.Price.HasValue ? updatedSeat.Price.Value : 0,
                                        Status = "Available",
                                        SeatNumber = seatNumber,
                                        Quoting = quoting,
                                        EventDateId = eventDate.Id,
                                        EventDate = eventDate
                                    };
                                    _context.Tickets.Add(newTicket);
                                }
                            }
                            else if (updatedSeat.IsAvailable && existingTicket != null)
                            {
                                if (existingTicket.Price != updatedSeat.Price)
                                {
                                    existingTicket.Price = updatedSeat.Price.HasValue ? updatedSeat.Price.Value : 0;
                                }
                            }
                            else if (!updatedSeat.IsAvailable && existingTicket != null)
                            {
                                _context.Tickets.Remove(existingTicket);
                            }
                        }
                    }
                }
            }

            await _context.SaveChangesAsync();

            _nav.EventList(this);
        }

        [RelayCommand]
        public async Task DeleteEventAsync()
        {
            if (selectedEvent != null)
            {
                if (!DeleteWindow("Voulez-vous vraiment supprimer cette évènement " + "(" + SelectedEvent.Name + ")" + " ?",true, 450)){ return; }
                if (SelectedEvent.IsActive)
                {
                    string message = $@"Confirmation de suppression d'événement
Vous êtes sur le point de supprimer l'événement : «{SelectedEvent.Name}», qui est actuellement actif et en cours de vente.

Veuillez noter que la suppression de cet événement entraînera les conséquences suivantes :
- Arrêt immédiat de la vente de billets pour cet événement.
- Remboursement obligatoire de tous les billets déjà vendus, ce qui pourrait entraîner des complications et des coûts transactionnels.

Nous vous recommandons de réévaluer cette décision ou de prendre les mesures nécessaires pour minimiser l'impact sur votre organisation et sur les participants.

Êtes-vous certain de vouloir procéder à la suppression de cet événement actif ?";
                    if (!DeleteWindow(message,true, 750)) { return; }
                }

                foreach (var section in selectedEvent.Room.Sections)
                {
                    foreach (var row in section.Rows)
                    {
                        _context.Seats.RemoveRange(row.Seats);
                    }
                    _context.Rows.RemoveRange(section.Rows);
                }
                _context.Sections.RemoveRange(selectedEvent.Room.Sections);

                _context.Rooms.Remove(selectedEvent.Room);

                Events.Remove(selectedEvent);
                _context.Events.Remove(selectedEvent);
                await _context.SaveChangesAsync();
                _nav.EventList(this);
            }
        }
        
        [RelayCommand]
        public async Task AddEventDates()
        {
            if (SelectedDate.HasValue && SelectedHour >= 0 && SelectedMinute >= 0)
            {
                EventDate eventDateTime = new EventDate();
                eventDateTime.Date = new DateTime(SelectedDate.Value.Year, SelectedDate.Value.Month,
                    SelectedDate.Value.Day, SelectedHour, SelectedMinute, 0);
                EventDates.Add(eventDateTime);
                EventDates = new ObservableCollection<EventDate>(EventDates.OrderBy(d => d.Date));
            }
        }

        [RelayCommand]
        public async Task DeleteEventDate()
        {
            if (SelectedEventDate != null)
            {
                EventDates.Remove(SelectedEventDate);
            }
        }

        #region NavigationCommand

        [RelayCommand]
        public void EventCreate()
        {
            _isModify = false;
            EventName = "";
            ArtistName = "";
            Duration = 0;
            Description = "";
            EventDates.Clear();

            Room = new Room
            {
                Name = EventName,
                Description = EventName,
                RoomConfigId = RoomConfig.Id,
            };

            var sections = new ObservableCollection<Section>();
            var tickets = new ObservableCollection<Ticket>();

            foreach (Section roomConfigSection in RoomConfig.Sections)
            {
                var newSection = new Section()
                {
                    Name = roomConfigSection.Name,
                    Description = roomConfigSection.Description,
                    Capacity = roomConfigSection.Capacity,
                    Rows = new ObservableCollection<Row>()
                };

                foreach (Row roomConfigRow in roomConfigSection.Rows)
                {
                    var newRow = new Row()
                    {
                        Name = roomConfigRow.Name,
                        Description = roomConfigRow.Description,
                        Capacity = roomConfigRow.Capacity,
                        IsAvailable = roomConfigRow.IsAvailable,
                        Seats = new ObservableCollection<Seat>()
                    };

                    foreach (Seat roomConfigSeat in roomConfigRow.Seats)
                    {
                        var seat = new Seat()
                        {
                            Name = roomConfigSeat.Name,
                            Description = roomConfigSeat.Description,
                            IsAvailable = roomConfigSeat.IsAvailable,
                            Price = 27.99,
                        };
                        newRow.Seats.Add(seat);
                    }
                    newSection.Rows.Add(newRow);
                }
                sections.Add(newSection);
            }
            Room.Sections = sections; 
            createEditButtonName = "Créer l'évènement";
            _nav.EventCreateEdit(this); 
            createEditVisibility = Visibility.Collapsed;
        }

        [RelayCommand]
        public async Task EventEdit(object obj)
        {
            try
            {
                _isModify = true;
                SelectedEvent = (Event)(obj);
                EventName = SelectedEvent.Name;
                ArtistName = SelectedEvent.ArtistName;
                Duration = SelectedEvent.Duration;
                Description = SelectedEvent.Description;
                IsActive = SelectedEvent.IsActive;
                EventDates = new ObservableCollection<EventDate>(await _context.EventDates.Where(ed => ed.EventId == selectedEvent.Id).ToListAsync());
                Room = SelectedEvent.Room;
                createEditButtonName = "Modifier l'évènement";
                _nav.EventCreateEdit(this);
                createEditVisibility = Visibility.Visible;
            }
            catch (Exception e)
            {
                return;
            }
        }

        [RelayCommand]
        public void EventRowSelection(object obj)
        {
            _nav.EventRowsSelection(this);
        }

        [RelayCommand]
        public void EventSeatSelection(object obj)
        {
            if (obj is not null)
            {
                SelectedRow = (Row)(obj);
                _nav.EventSeatsSelection(this);
            }
        }

        #endregion

        [ObservableProperty] Visibility isDeleteVisibility;
        [ObservableProperty] Visibility isNotDeleteVisibility;
        [ObservableProperty] private string deleteMessage; 
        [ObservableProperty] private double width;
        public bool DeleteWindow(string message, bool isDelete, double width)
        {
            if (isDelete)
            {
                IsDeleteVisibility = Visibility.Visible;
                IsNotDeleteVisibility = Visibility.Collapsed;
            }
            else
            {
                IsDeleteVisibility = Visibility.Collapsed;
                IsNotDeleteVisibility = Visibility.Visible;
            }
            DeleteConfirmation view = new DeleteConfirmation(this);
            DeleteMessage = message;
            Width = width;
            view.ShowDialog();
            return view.result;
        }

        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count - 1];
        }

    }
}
