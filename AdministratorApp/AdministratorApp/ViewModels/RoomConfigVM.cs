using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Data;

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
        }

        [RelayCommand]
        public void RoomEdit(object obj) => _nav.RoomEdit(this);

        [RelayCommand]
        public void RowCreate(object obj) => _nav.RowCreate(this); 
        
        [RelayCommand]
        public void RowEdit(object obj) => _nav.RowEdit(this);

        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count - 1];
        }

    }
}
