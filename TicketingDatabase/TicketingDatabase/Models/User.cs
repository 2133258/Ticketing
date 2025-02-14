﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TicketingDatabase.Models
{
    public class User
    {
        [Column("UserId"), Key]
        public int Id { get; set; }
        [Column("UserName")]
        public string UserName { get; set; }
        [Column("UserPassword"), MaxLength(250, ErrorMessage = "Description trop longue !")]
        public string Password { get; set; }
        [Column("UserCreationDate")]
        public DateTime CreationDate { get; set; }
        [Column("UserType")]
        public string Type { get; set; }

        public ObservableCollection<DigitalTicket>? DigitalTickets { get; set; }
        public ObservableCollection<Transaction>? Transactions { get; set; }
    }
}
