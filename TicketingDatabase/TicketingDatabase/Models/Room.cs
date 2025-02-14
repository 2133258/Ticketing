﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class Room
    {
        [Column("RoomId"), Key]
        public int Id { get; set; }
        [Column("RoomName")]
        public string Name { get; set; }
        [Column("RoomDescription"), MaxLength(250, ErrorMessage = "Description trop longue !")]
        public string Description { get; set; }
        [Column("RoomTotalCapacity")]
        public int? TotalCapacity { get; set; }

        [Column("RoomConfigId"), ForeignKey("RoomConfig")]
        public int RoomConfigId { get; set; }
        public RoomConfig? RoomConfig { get; set; }

        public ObservableCollection<Section>? Sections { get; set; }

    }
}
