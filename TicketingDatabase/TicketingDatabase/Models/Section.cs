using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class Section
    {
        [Column("SectionId"), Key]
        public int Id { get; set; }
        [Column("SectionName")]
        public string Name { get; set; }
        [Column("SectionDescription"), MaxLength(250, ErrorMessage = "Description trop longue !")]
        public string Description { get; set; }
        [Column("SectionCapacity")]
        public int? Capacity { get; set; }

        [Column("RoomId"),ForeignKey("Room")]
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        [Column("RoomConfigId"), ForeignKey("RoomConfig")]
        public int? RoomConfigId { get; set; }
        public RoomConfig? RoomConfig { get; set; }

        public ObservableCollection<Row> Rows { get; set; }

    }
}
