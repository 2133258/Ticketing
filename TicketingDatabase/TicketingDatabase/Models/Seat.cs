using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class Seat
    {
        [Column("SeatId"), Key]
        public int Id { get; set; }
        [Column("SeatName")]
        public string Name { get; set; }
        [Column("SeatDescription"), MaxLength(250, ErrorMessage = "Description trop longue !")]
        public string Description { get; set; }
        [Column("SeatCapacity")]
        public int Capacity { get; set; }

        [Column("RowId"), ForeignKey("Row")]
        public int RowId { get; set; }
        public Row? Row { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }

    }
}
