using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class EventDate
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Date { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event? Event { get; set; }

        [Column("TicketId"), ForeignKey("Ticket")]
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
