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
using GuichetAutonome.Helpers.User;
using GuichetAutonome.Views.Template;
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
        [ObservableProperty] private EventDate selectedEventDate;

        [ObservableProperty] private Section selectedSection;
        [ObservableProperty] private ObservableCollection<Section> sections;
        [ObservableProperty] private Row selectedRow;
        [ObservableProperty] private Seat selectedSeat;

        [ObservableProperty] private ObservableCollection<Ticket> chosenTickets;
        [ObservableProperty] private ObservableCollection<Ticket> availableTickets;
        [ObservableProperty] private ObservableCollection<Ticket> cart;


        public async Task LoadTicketsAsync()
        {
            var availableTickets = await _context.Tickets.Where(t => t.EventId == selectedEvent.Id && t.EventDateId == SelectedEventDate.Id).Where(t => t.Status == "Available").ToListAsync();
            var sections = await _context.Sections.Include(s => s.Rows).ThenInclude(r => r.Seats.Where(s => s.IsAvailable)).Where(s => s.RoomId == selectedEvent.RoomId).ToListAsync();
            foreach (Section section in sections)
            {
                foreach (Row sectionRow in section.Rows)
                {
                    // Temporary list to hold seats to be removed
                    var seatsToRemove = new List<Seat>();

                    foreach (Seat sectionRowSeat in sectionRow.Seats)
                    {
                        if (!availableTickets.Any(t => t.SeatId == sectionRowSeat.Id))
                        {
                            // Instead of removing immediately, add to the temporary list
                            seatsToRemove.Add(sectionRowSeat);
                        }
                    }

                    // Remove the seats after iteration is complete
                    foreach (Seat seatToRemove in seatsToRemove)
                    {
                        sectionRow.Seats.Remove(seatToRemove);
                    }
                }
            }
            Sections = new ObservableCollection<Section>(sections);
            AvailableTickets = new ObservableCollection<Ticket>(availableTickets);
            ChosenTickets = ChosenTickets is not null ? new ObservableCollection<Ticket>(ChosenTickets) : new ObservableCollection<Ticket>();
            SelectedSection = Sections.FirstOrDefault();
            SelectedRow = SelectedSection.Rows.FirstOrDefault();
            Cart = UserService.cart is null ? new ObservableCollection<Ticket>() : new ObservableCollection<Ticket>(UserService.cart);
        }

        public async Task LoadEventsAsync()
        {
            var events = await _context.Events.Where(e => e.IsActive).Include(e => e.EventDates).ToListAsync();
            Events = new ObservableCollection<Event>(events);
        }

        [RelayCommand]
        public async Task AddSeatToList(object obj)
        {
            if (obj is not Seat) return;
            Seat seat = (Seat)obj;
            ChosenTickets.Add(AvailableTickets.First(t => t.SeatId == seat.Id));
            SelectedRow.Seats.Remove(seat);
            ChosenTickets = new ObservableCollection<Ticket>(ChosenTickets.OrderBy(t => t.SeatNumber));
        }

        [RelayCommand]
        public async Task RemoveSeatToList(object obj)
        {
            if (obj is not Ticket) return;
            Ticket ticket = (Ticket)obj;
            SelectedRow.Seats.Add(ticket.Seat);
            ChosenTickets.Remove(ticket);
            SelectedRow.Seats = new ObservableCollection<Seat>(SelectedRow.Seats.OrderBy(s => s.Name));
        }

        [RelayCommand]
        public async Task AddTicketsToCartAsync()
        {
            if (ChosenTickets == null || ChosenTickets.Count == 0)
            {
                var message = $@"Vous n'avez aucun siège de selectionner.";
                DeleteWindow(message, false, 450);
                return;
            }

            if (Cart.Count >= 6 || ChosenTickets.Count + Cart.Count > 6)
            {
                var message = $@"Le nombre maximum de billets est 6.";
                DeleteWindow(message, false, 450);
                return;
            }

            var ticketsToUpdate = new ObservableCollection<Ticket>();
            UserService.cart = UserService.cart is null ? new ObservableCollection<Ticket>() : new ObservableCollection<Ticket>(UserService.cart);
            Cart = Cart is null ? new ObservableCollection<Ticket>() : new ObservableCollection<Ticket>(Cart);
            foreach (var ticket in ChosenTickets)
            {
                var ticketToUpdate = await _context.Tickets.FindAsync(ticket.Id);
                if (ticketToUpdate.Status != "Purchasing")
                {
                    ticketToUpdate.Status = "Purchasing";
                    ticketsToUpdate.Add(ticketToUpdate);
                }
                SelectedRow.Seats.Add(ticket.Seat);
                UserService.cart.Add(ticket);
                Cart.Add(ticket);
            }

            if (ticketsToUpdate.Count > 0)
            {
                try
                {
                    _context.Tickets.UpdateRange(ticketsToUpdate);
                    await _context.SaveChangesAsync();
                    ChosenTickets.Clear();
                    _nav.CartDetails(this);
                }
                catch (Exception ex)
                {
                    return;
                }
            }

            
        }

        [RelayCommand]
        public async Task EventDetails(object obj)
        {
            SelectedEvent = (Event)(obj);
            _nav.EventDetails(this);
        }

        [RelayCommand]
        public async Task EventTicketChoice()
        {
            await LoadTicketsAsync();
            _nav.EventTicketChoice(this);
        }

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
