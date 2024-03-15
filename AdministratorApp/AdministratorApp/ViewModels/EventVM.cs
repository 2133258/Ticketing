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

        [ObservableProperty] string eventName;
        [ObservableProperty] private string artistName;
        [ObservableProperty] int duration;
        [ObservableProperty] string imageSelection;
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


        public async Task LoadRoomConfigAsync()
        {
            try
            {
                var config = await _context.RoomConfigs
                    .Include(r => r.Sections)
                    .ThenInclude(s => s.Rows)
                    .ThenInclude(r => r.Seats)
                    .FirstOrDefaultAsync(); // Assuming a single config for simplification

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
                duration == null || duration <= 0 || string.IsNullOrEmpty(imageSelection))
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
            Event newEvent = new Event();
            newEvent.Name = eventName;
            newEvent.ArtistName = artistName;
            newEvent.Description = description;
            newEvent.IsActive = isActive;
            newEvent.EventDates = new ObservableCollection<EventDate>(EventDates);
            newEvent.Room = Room;
            Events.Add(newEvent);
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            _nav.EventList(this);
        }

        public async Task UpdateEventAsync()
        {
            if (SelectedEvent != null)
            {
                var eventToUpdate = await _context.Events.Include(e => e.Room).ThenInclude(r => r.Sections).ThenInclude(s => s.Rows).ThenInclude(r => r.Seats).FirstOrDefaultAsync(e => e.Id == SelectedEvent.Id);
                // Update properties
                SelectedEvent.Name = EventName;
                SelectedEvent.ArtistName = ArtistName;
                SelectedEvent.Description = Description;
                SelectedEvent.IsActive = isActive;
                SelectedEvent.ImageSource = "";
                SelectedEvent.Room = Room;

                await _context.SaveChangesAsync();
                _nav.EventList(this);
            }
        }

        [RelayCommand]
        public async Task DeleteEventAsync()
        {
            if (selectedEvent != null)
            {
                Events.Remove(selectedEvent);
                _context.Events.Remove(selectedEvent);
                await _context.SaveChangesAsync();
                _nav.EventList(this);
            }
        }

        public async Task AssignTicketToSeat(int seatId, Ticket ticket)
        {
            var seat = await _context.Seats.FirstOrDefaultAsync(s => s.Id == seatId);
            if (seat != null && seat.IsAvailable)
            {
                seat.IsAvailable = false;
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
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
                //Mettre la liste en ordre de date a chaque ajout
                EventDates = new ObservableCollection<EventDate>(EventDates.OrderBy(d => d.Date));
            }
        }

        [RelayCommand]
        public async Task DeleteEventDate()
        {
            if (SelectedEventDate != null)
            {
                EventDates.Remove(SelectedEventDate);
                SelectedEventDate = null; // Optionally clear selection
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
                Sections = RoomConfig.Sections,
                RoomConfigId = RoomConfig.Id,
            }; 
            //var sections = new ObservableCollection<Section>(); 
            //var rows = new ObservableCollection<Row>();
            //var seats = new ObservableCollection<Seat>();
            //foreach (Section roomConfigSection in RoomConfig.Sections)
            //{
            //    sections.Add(new Section()
            //    {
            //        Name = roomConfigSection.Name,
            //        Description = roomConfigSection.Description,
            //        Capacity = roomConfigSection.Capacity,
            //    }); 
            //    Room.Sections = new ObservableCollection<Section>(sections);
            //    foreach (Row roomConfigRow in roomConfigSection.Rows)
            //    {
            //        foreach (Section section in Room.Sections)
            //        {
            //            rows.Add(new Row()
            //            {
            //                Name = roomConfigRow.Name,
            //                Description = roomConfigRow.Description,
            //                Capacity = roomConfigRow.Capacity,
            //                IsAvailable = roomConfigRow.IsAvailable,
            //            });
            //            section.Rows = new ObservableCollection<Row>(rows);
            //            foreach (Seat roomConfigSeat in roomConfigRow.Seats)
            //            {
            //                foreach (Row row in section.Rows)
            //                {
                                
            //                    seats.Add(new Seat()
            //                    {
            //                        Name = roomConfigRow.Name,
            //                        Description = roomConfigRow.Description,
            //                        IsAvailable = roomConfigRow.IsAvailable,
            //                    });
            //                    row.Seats = new ObservableCollection<Seat>(seats);
            //                }
            //            }
            //        }
            //    }
            //}
            createEditButtonName = "Créer l'évènement";
            _nav.EventCreateEdit(this); 
            createEditVisibility = Visibility.Collapsed;
        }

        [RelayCommand]
        public async Task EventEdit(object obj)
        {
            SelectedEvent = (Event)(obj);
            EventName = SelectedEvent.Name;
            ArtistName = SelectedEvent.ArtistName;
            Duration = 3;
            Description = SelectedEvent.Description;
            EventDates = new ObservableCollection<EventDate>(await _context.EventDates.Where(ed => ed.EventId == selectedEvent.Id).ToListAsync());
            Room = SelectedEvent.Room;
            createEditButtonName = "Modifier l'évènement";
            _nav.EventCreateEdit(this);
            createEditVisibility = Visibility.Visible;
        }

        [RelayCommand]
        public void EventSelectionSeat(object obj) => _nav.EventSeatSelection(this);

        #endregion

        [ObservableProperty] private string deleteMessage;
        public bool DeleteWindow(string message)
        {
            DeleteConfirmation view = new DeleteConfirmation(this);
            DeleteMessage = message;
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
