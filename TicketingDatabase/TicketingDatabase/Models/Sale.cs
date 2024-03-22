using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingDatabase.Models
{
    public class Sale
    {
        [Column("SaleId"), Key]
        public int Id { get; set; }
        [Column("SaleDate")]
        public DateTime Date { get; set; }
        [Column("SaleTotalPrice")]
        public double TotalPrice { get; set; }
        [Column("SaleTPS")]
        public double TPS { get; set; }
        [Column("SaleTVQ")]
        public double TVQ { get; set; }
        [Column("SaleTotalPriceTax")]
        public double TotalPriceTax { get; set; }

        [Column("EventId"), ForeignKey("Event")]
        public int? EventId { get; set; }
        public Event? Event { get; set; }

        public ObservableCollection<Transaction>? Transactions { get; set; }

    }
}
