using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
        [Column("SeatIsAvailable")]
        public bool IsAvailable { get; set; }

        [Column("RowId"), ForeignKey("Row")]
        public int RowId { get; set; }
        public Row? Row { get; set; }

        public ObservableCollection<Ticket>? Tickets { get; set; }

    }
}
