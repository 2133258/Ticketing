using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace AdministratorApp.ViewModels
{
    public partial class SaleVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;
        Sale? _sale;

        public SaleVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            _sale = null;
            LoadSalesAsync();
        }

        [ObservableProperty] private ObservableCollection<Sale> sales;
        [ObservableProperty] private Sale selectedSale;

        public async Task LoadSalesAsync()
        {
            Sales = new ObservableCollection<Sale>(_context.Sales.Include(s => s.Transactions).ThenInclude(t => t.User));
        }

        [RelayCommand]
        public void SaleDetails(object obj)
        {
            selectedSale = (Sale)(obj);
            _nav.SaleDetails(this);
        }

        [RelayCommand]
        public void GoBack(object obj)
        {
            _nav.CurrentViews.Remove(_nav.CurrentViews[_nav.CurrentViews.Count - 1]);
            _nav.CurrentView = _nav.CurrentViews[_nav.CurrentViews.Count - 1];
        }
    }
}
