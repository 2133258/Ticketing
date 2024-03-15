using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace TicketingDatabase.Models
{
    public class Event
    {
        [Column("EventId"), Key]
        public int Id { get; set; }
        [Column("EventName")]
        public string Name { get; set; }
        [Column("EventDescription"), MaxLength(250, ErrorMessage = "Description trop longue !")]
        public string Description { get; set; }
        [Column("EventArtistName")]
        public string ArtistName { get; set; }
        [Column("EventIsActive")]
        public bool IsActive { get; set; }

        [Column("RoomId"), ForeignKey("Room")]
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        public ObservableCollection<Ticket>? Tickets { get; set; }
        public ObservableCollection<Sale>? Sales { get; set; }
        public ObservableCollection<EventDate>? EventDates { get; set; }
        [NotMapped]
        public string ImageSource { get; set; }

    }
}
