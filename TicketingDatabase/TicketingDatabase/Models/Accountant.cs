using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class Accountant : User
    {
        [Column("AccountantId"), Key]
        public int Id { get; set; }
        [Column("AccountantFirstName")]
        public string FirstName { get; set; }
        [Column("AccountantLastName")]
        public string LastName { get; set; }
        [Column("AccountantEmail")]
        public string Email { get; set; }

    }
}
