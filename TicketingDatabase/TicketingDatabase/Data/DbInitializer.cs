using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketingDatabase.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TicketingContext context)
        {
            context.Database.EnsureCreated();

            //// Check if any data exists
            //if (context.Events.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //// Seed data for Events, Tickets, etc.
            //var events = new Event[]
            //{
            //    new Event { Name = "Concert", Description = "Rock Concert", ArtistName = "Band XYZ", Date = DateTime.Parse("2024-04-25"), RoomId = 1 },
            //    // Add more events as needed
            //};

            //foreach (Event e in events)
            //{
            //    context.Events.Add(e);
            //}
            //context.SaveChanges();

        }
    }
}
