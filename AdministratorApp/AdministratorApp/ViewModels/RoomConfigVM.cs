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

            if (!DeleteWindow("Voulez-vous vraiment supprimer cette section ?")) return; 

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
                Capacity = 10,
                Seats = new ObservableCollection<Seat>(),
            };
            
            await _context.Rows.AddAsync(newRow);
            RoomConfig.Sections.First(s => s.Id == SelectedSection.Id).Rows.Add(newRow);
            await _context.SaveChangesAsync();
            SelectedSection = SelectedSection;
        }

        [RelayCommand]
        public async Task DeleteRow(object obj)
        {
            if (obj is not Row) return;

            Row row = (Row)obj;
            _context.Rows.Remove(row);
            RoomConfig.Sections.First(s => s.Id == SelectedSection.Id).Rows.Remove(row);
            await _context.SaveChangesAsync();
            SelectedSection = SelectedSection;
        }

        [RelayCommand]
        public async Task AddEmptySeat()
        {
            if (SelectedRow == null) return;

            var newSeat = new Seat
            {
                Name = $"Siège {SelectedRow.Seats.Count + 1}",
                Description = "",
            };

            await _context.Seats.AddAsync(newSeat);
            RoomConfig.Sections.First(s => s.Id == SelectedSection.Id).Rows.First(r => r.Id == SelectedRow.Id).Seats.Add(newSeat);
            await _context.SaveChangesAsync();
            OnPropertyChanged(nameof(SelectedRow));
        }

        [RelayCommand]
        public async Task DeleteSeat(object obj)
        {
            if (obj is not Seat) return;

            Seat seat = (Seat)obj;
            _context.Seats.Remove(seat);
            RoomConfig.Sections.First(s => s.Id == SelectedSection.Id).Rows.First(r => r.Id == SelectedRow.Id).Seats.Remove(seat);
            await _context.SaveChangesAsync();
            SelectedRow = SelectedRow;
        }

        [RelayCommand]
        public void RoomEdit(object obj) => _nav.RoomEdit(this);

        [RelayCommand]
        public void RowEdit(object obj)
        {
            selectedRow = (Row)(obj);
            _nav.RowCreateEdit(this);
        }

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
