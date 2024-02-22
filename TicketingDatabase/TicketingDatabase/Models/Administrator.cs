using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class Administrator : User
    {
        [Column("AdministratorId"), Key]
        public int Id { get; set; }
        [Column("AdministratorFirstName")]
        public string FirstName { get; set; }
        [Column("AdministratorLastName")]
        public string LastName { get; set; }
        [Column("AdministratorEmail")]
        public string Email { get; set; }

    }
}
