using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class Transaction
    {
        [Column("TransactionId"), Key]
        public int Id { get; set; }
        [Column("TransactionDate")]
        public DateTime Date { get; set; }
        [Column("TransactionTotalPrice")]
        public double TotalPrice { get; set; }
        [Column("TransactionTPS")]
        public double TPS { get; set; }
        [Column("TransactionTVQ")]
        public double TVQ { get; set; }
        [Column("TransactionTotalPriceTax")]
        public double TotalPriceTax { get; set; }

        [Column("SaleId"), ForeignKey("Sale")]
        public int SaleId { get; set; }
        public Sale? Sale { get; set; }

        [Column("UserId"), ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
