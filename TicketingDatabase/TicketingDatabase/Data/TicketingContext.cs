using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Models;

namespace TicketingDatabase.Data
{
    public class TicketingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=ticketingdb;user=root;password=14085Smitypro",
                new MySqlServerVersion(new Version(8, 0, 21)),
                mySqlOptions => mySqlOptions.EnableRetryOnFailure());
        }

        public TicketingContext(DbContextOptions<TicketingContext> options) : base(options)
        {

        }

        public TicketingContext()
        {
            DbInitializer.Initialize(this);
        }

        public DbSet<DigitalTicket> DigitalTickets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<RoomConfig> RoomConfigs { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> ClientUsers { get; set; }
        public DbSet<User> AdministratorUsers { get; set; }
        public DbSet<User> AccountantUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<RoomConfig>().ToTable("RoomConfig");
            modelBuilder.Entity<Section>().ToTable("Section");
            modelBuilder.Entity<Row>().ToTable("Row");
            modelBuilder.Entity<Seat>().ToTable("Seat");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<DigitalTicket>().ToTable("DigitalTicket");
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<Client>().ToTable("ClientUser");
            modelBuilder.Entity<Administrator>().ToTable("AdministratorUser");
            modelBuilder.Entity<Accountant>().ToTable("AccountantUser");

        }
    }

}
