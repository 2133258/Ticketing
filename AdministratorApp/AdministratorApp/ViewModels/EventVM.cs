using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Data;

namespace AdministratorApp.ViewModels
{
    public partial class EventVM : ObservableObject
    {
        TicketingContext _context;

        public EventVM(TicketingContext context)
        {
            _context = context;
        }
    }
}
