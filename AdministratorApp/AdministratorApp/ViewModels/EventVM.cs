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

namespace AdministratorApp.ViewModels
{
    public partial class EventVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;
        Event _event;
        private bool _isModify;
        public EventVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            _isModify = false;
            LoadEventsAsync();
        }

        [ObservableProperty] ObservableCollection<Event> events;
        [ObservableProperty] Event selectedEvent;

        [ObservableProperty] string eventName;
        [ObservableProperty] private string artistName;
        [ObservableProperty] int duration;
        [ObservableProperty] string imageSelection;
        [ObservableProperty] string description; 

        [ObservableProperty] Section selectedSection;

        [ObservableProperty] Visibility createEditVisibility;
        [ObservableProperty] string createEditButtonName;

        [ObservableProperty] ObservableCollection<DateTime> eventDates; 
        [ObservableProperty] DateTime? selectedDate; 
        [ObservableProperty] private int _selectedHour;
        [ObservableProperty] private int _selectedMinute;
        [ObservableProperty] private ObservableCollection<int> hours;
        [ObservableProperty] private ObservableCollection<int> minutes;

        public async Task LoadEventsAsync()
        {
            var events = await _context.Events.ToListAsync();
            Events = new ObservableCollection<Event>(events);

            Hours = new ObservableCollection<int>(Enumerable.Range(0, 24));
            Minutes = new ObservableCollection<int>(Enumerable.Range(0, 12).Select(i => i * 5));
            EventDates = new ObservableCollection<DateTime>();
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
                _event.Name = eventName;
                _event.ArtistName = artistName;
                _event.Description = description;
                _event.IsActive = true;
                UpdateEventAsync(_event);
            }
            else
            {
                Event newEvent = new Event();
                newEvent.Name = eventName;
                newEvent.ArtistName = artistName;
                newEvent.Description = description;
                newEvent.IsActive = true;
                AddEventAsync(newEvent);
            }
        }

        public async Task AddEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            GoBack(this);
            LoadEventsAsync();
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            if (_event != null)
            {
                var eventToUpdate = await _context.Events.FirstOrDefaultAsync(e => e.Id == updatedEvent.Id);
                // Update properties
                eventToUpdate.Name = updatedEvent.Name;
                eventToUpdate.ArtistName = updatedEvent.ArtistName;
                eventToUpdate.Description = updatedEvent.Description;
                eventToUpdate.IsActive = true;
                // Set other properties similarly

                await _context.SaveChangesAsync();
                _nav.EventList(this);
            }
        }

        [RelayCommand]
        public async Task DeleteEventAsync(int eventId)
        {
            var eventToDelete = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
                LoadEventsAsync();
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
                DateTime eventDateTime = new DateTime(SelectedDate.Value.Year, SelectedDate.Value.Month, SelectedDate.Value.Day, SelectedHour, SelectedMinute, 0);
                EventDates.Add(eventDateTime);
            }
            else
            {

            }
        }

        #region NavigationCommand

        [RelayCommand]
        public void EventCreate(object obj)
        {
            _isModify = false;
            createEditButtonName = "Créer l'évènement";
            _nav.EventCreateEdit(this);
        }

        [RelayCommand]
        public void EventEdit(object obj)
        {
            SelectedEvent = (Event)(obj);
            EventName = SelectedEvent.Name;
            ArtistName = SelectedEvent.ArtistName;
            Duration = 3;
            Description = SelectedEvent.Description;
            createEditButtonName = "Modifier l'évènement";
            _nav.EventCreateEdit(this);
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
