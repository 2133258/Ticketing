using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class Client : User
    {
        [Column("ClientId"), Key]
        public int Id { get; set; }
        [Column("ClientFirstName")]
        public string FirstName { get; set; }
        [Column("ClientLastName")]
        public string LastName { get; set; }
        [Column("ClientEmail")]
        public string Email { get; set; }
        [Column("ClientPhone")]
        public string Phone { get; set; }

        [NotMapped]
        public ObservableCollection<Ticket> Cart { get; set; }
    }
}
