using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AdministratorApp.Views.Template;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TicketingDatabase.Data;
using TicketingDatabase.Models;
using System.Windows;

namespace AdministratorApp.ViewModels
{
    public partial class RoomConfigVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;

       public RoomConfigVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            InitializeViewModelAsync();
        }
        
        [ObservableProperty] RoomConfig roomConfig;
        [ObservableProperty] private Section selectedSection;
        [ObservableProperty] private Row selectedRow;
        

        private async Task InitializeViewModelAsync()
        {
            await LoadRoomConfigAsync();
            if (RoomConfig.Sections.Any())
            {
                SelectedSection = RoomConfig.Sections.First();
            }
        }

        public async Task LoadRoomConfigAsync()
        {
            var config = await _context.RoomConfigs
                .Include(r => r.Sections)
                    .ThenInclude(s => s.Rows)
                    .ThenInclude(r => r.Seats)
                .FirstOrDefaultAsync(); // Assuming a single config for simplification

            RoomConfig = config ?? new RoomConfig { Sections = new ObservableCollection<Section>() };
        }

        [RelayCommand]
        public async Task AddEmptySection()
        {
            var newSection = new Section
            {
                Name = $"Section {RoomConfig.Sections.Count + 1}",
                Description = "",
                Rows = new ObservableCollection<Row>(),
            };

            RoomConfig.Sections.Add(newSection);
            await _context.Sections.AddAsync(newSection);
            await _context.SaveChangesAsync();

            SelectedSection = newSection; 
        }

        [RelayCommand]
        public async Task DeleteSection()
        {
            if (SelectedSection == null) return;
            var message = $@"Les rangées et les sièges associés à cette section seront également supprimer.

Voulez-vous vraiment supprimer la {SelectedSection.Name}?";
            if (!DeleteWindow(message, true, 550)) return;

            // Explicitly remove rows and seats within those rows
            var rowsToDelete = SelectedSection.Rows.ToList();
            foreach (var row in rowsToDelete)
            {
                var seatsToDelete = row.Seats.ToList();
                _context.Seats.RemoveRange(seatsToDelete); // Delete all seats within each row
                _context.Rows.Remove(row); // Then delete the row itself
            }

            _context.Sections.Remove(SelectedSection);
            RoomConfig.Sections.Remove(SelectedSection);

            await _context.SaveChangesAsync();

            SelectedSection = RoomConfig.Sections.FirstOrDefault();
            OnPropertyChanged(nameof(RoomConfig.Sections));
        }

        [RelayCommand]
        public async Task AddEmptyRow()
        {
            if (SelectedSection == null) return;

            var newRow = new Row
            {
                Name = $"Rangée {SelectedSection.Rows.Count + 1}",
                Description = "",
                Seats = new ObservableCollection<Seat>(),
                IsAvailable = true,
            };

            await _context.Rows.AddAsync(newRow);
            RoomConfig.Sections.First(s => s.Id == SelectedSection.Id).Rows.Add(newRow);
            await _context.SaveChangesAsync();
            SelectedSection = SelectedSection;
        }

        [RelayCommand]
        public async Task DeleteRow(object obj)
        {
            if (obj is not Row row) return;

            var message = $@"Les sièges associer à cette rangée seront également supprimer.

Voulez-vous vraiment supprimer la {row.Name} ?";
            if (!DeleteWindow(message, true, 550)) return;

            // Directly remove seats in the row
            _context.Seats.RemoveRange(row.Seats);

            _context.Rows.Remove(row);
            SelectedSection.Rows.Remove(row);

            await _context.SaveChangesAsync();
            SelectedSection = SelectedSection; // Refresh the selected section
        }


        [RelayCommand]
        public async Task AddEmptySeat()
        {
            if (SelectedRow == null) return;

            var newSeat = new Seat
            {
                Name = $"Siège {SelectedRow.Seats.Count + 1}",
                Description = "",
                IsAvailable = true,
            };

            await _context.Seats.AddAsync(newSeat);
            RoomConfig.Sections.First(s => s.Id == SelectedSection.Id).Rows.First(r => r.Id == SelectedRow.Id).Seats.Add(newSeat);
            await _context.SaveChangesAsync();
            OnPropertyChanged(nameof(SelectedRow));
        }

        [RelayCommand]
        public async Task DeleteSeat(object obj)
        {
            if (obj is not Seat seat) return;

            if (!DeleteWindow($"Voulez-vous vraiment supprimer le {seat.Name} ?", true, 450)) return;

            _context.Seats.Remove(seat);
            SelectedRow.Seats.Remove(seat);

            await _context.SaveChangesAsync();
            SelectedRow = SelectedRow; // Refresh the selected row
        }


        [RelayCommand]
        public void RoomEdit(object obj) => _nav.RoomEdit(this);

        [RelayCommand]
        public void RowEdit(object obj)
        {
            if (obj is not null)
            {
                selectedRow = (Row)(obj);
                _nav.RowCreateEdit(this);
            }
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
