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
    public class RoomConfig
    {
        [Column("RoomConfigId"), Key]
        public int Id { get; set; }
        [Column("RoomConfigName")]
        public string Name { get; set; }
        [Column("RoomConfigDescription"), MaxLength(250, ErrorMessage = "Description trop longue !")]
        public string Description { get; set; }
        [Column("RoomConfigTotalCapacity")]
        public int? TotalCapacity { get; set; }

        public ObservableCollection<Section>? Sections { get; set; }

    }
}
