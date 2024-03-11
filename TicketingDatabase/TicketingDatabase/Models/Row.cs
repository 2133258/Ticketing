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
    public class Row
    {
        [Column("RowId"), Key]
        public int Id { get; set; }
        [Column("RowName")]
        public string Name { get; set; }
        [Column("RowDescription"), MaxLength(250, ErrorMessage = "Description trop longue !")]
        public string Description { get; set; }
        [Column("RowCapacity")]
        public int? Capacity { get; set; }
        [Column("RowIsAvailable")]
        public bool IsAvailable { get; set; }

        [Column("SectionId"), ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section? Section { get; set; }

        public ObservableCollection<Seat> Seats { get; set; }

    }
}
