using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Data;

namespace GuichetAutonome.ViewModels
{
    public partial class AccountVM : ObservableObject
    {
        TicketingContext _context;
        NavigationVM _nav;

        public AccountVM(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
        }

    }
}
