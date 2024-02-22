using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class Ticket
    {
        [Column("TicketId"), Key]
        public int Id { get; set; }
        [Column("TicketPrice")]
        public double Price { get; set; }
        [Column("TicketStatus")]
        public string Status { get; set; }
        [Column("TicketQuoting")]
        public int Quoting { get; set; }

        [Column("SeatId"), ForeignKey("Seat")]
        public int SeatId { get; set; }
        public Seat? Seat { get; set; }

        [Column("EventId"), ForeignKey("Event")]
        public int EventId { get; set; }
        public Event? Event { get; set; }

    }
}
