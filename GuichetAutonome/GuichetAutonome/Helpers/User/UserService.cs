using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Models;

namespace GuichetAutonome.Helpers.User
{
    public static class UserService
    {
        public static TicketingDatabase.Models.User? connectedEmploye { get; set; }
    }
}
