using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class DigitalTicket
    {
        [Column("DigitalTicketId"), Key]
        public int Id { get; set; }
        [Column("DigitalTicketUniqueCode")]
        public string UniqueCode { get; set; }
        [Column("DigitalTicketDateSent")]
        public DateTime DateSent { get; set; }

        [Column("TicketId"), ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }

        [Column("UserId"), ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Column("TransactionId"), ForeignKey("Transaction")]
        public int TransactionId { get; set; }
        public Transaction? Transaction { get; set; }
    }
}
