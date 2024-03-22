using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Models;

namespace GuichetAutonome.Helpers.User
{
    public static class UserService
    {
        public static TicketingDatabase.Models.User? connected { get; set; }

        public static ObservableCollection<Ticket>? cart { get; set; }

    }
}
