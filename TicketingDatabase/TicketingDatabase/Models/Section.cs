using System;
using System.Collections.Generic;
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
        public int Capacity { get; set; }

        [Column("RoomId"),ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public ICollection<Row> Rows { get; set; }

    }
}
