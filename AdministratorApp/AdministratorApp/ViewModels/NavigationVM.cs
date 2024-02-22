using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AdministratorApp;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace AdministratorApp.ViewModels
{
    public partial class NavigationVM : ObservableObject
    {
        TicketingContext _context;

        public NavigationVM(TicketingContext context)
        {
            _context = context;
        }

        [ObservableProperty]
        object currentView;

        [ObservableProperty]
        User user;

        [ObservableProperty]
        Visibility adminButtonVisibility;

        #region Commandes

        [RelayCommand]
        public void EventList(object obj) => CurrentView = new Views.Events.List(_context);

        //[RelayCommand]
        //private void EmployeList(object obj) => CurrentView = new EmployeeListView(_context);

        //[RelayCommand]
        //private void DepartementList(object obj) => CurrentView = new DepartementListView(_context);

        //[RelayCommand]
        //private void Clients(object obj) => CurrentView = new ClientListView(_context);

        //[RelayCommand]
        //public void Template(object obj) => CurrentView = new TemplateListView(_context, this);

        //[RelayCommand]
        //private void Settings(object obj) => CurrentView = new SettingsView(_context);

        //[RelayCommand]
        //public void Project(Project project) { CurrentView = new GestionProjetView(_context, project, this); }

        //[RelayCommand]
        //public void ProjectEmployee(Project project) { CurrentView = new ProjectEmployeeView(_context, project); }
        //[RelayCommand]
        //public void TimeLine(Project project) { CurrentView = new TimelineChart(_context, project); }
        #endregion
    }
}
