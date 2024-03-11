using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace TicketingDatabase.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TicketingContext context)
        {
            // Ensure the database exists and is created
            context.Database.EnsureCreated();

            // Check if any rooms exist
            if (context.RoomConfigs.Any())
            {
                return; // DB has been seeded
            }

            // Seed data for RoomConfig
            var rooms = new RoomConfig[]
            {
            new RoomConfig
            {
                Name = "Salle Théâtre Cchic",
                Description = "Grande salle de spectacle",
                TotalCapacity = null,
                Sections = new ObservableCollection<Section>
                {
                    new Section
                    {
                        Name = "Section 1",
                        Description = "La section la plus avancé de la salle",
                        Capacity = null,
                        Rows = new ObservableCollection<Row>
                        {
                            new Row
                            {
                                Name = "Rangée 1",
                                Description = "La première rangée de la section",
                                Capacity = 10,
                                IsAvailable = true,
                                Seats = new ObservableCollection<Seat>
                                {
                                    new Seat { Name = "Siège 1", Description = "Premier siège de la rangée", IsAvailable = true },
                                    new Seat { Name = "Siège 2", Description = "Deuxième siège de la rangée", IsAvailable = true },
                                    // Add more seats as needed
                                }
                            },
                            // Add more rows as needed
                        }
                    },
                    // Add more sections as needed
                }
            },
                // Add more RoomConfigs as needed
            };

            foreach (RoomConfig r in rooms)
            {
                context.RoomConfigs.Add(r);
            }

            context.SaveChanges();

        }
    }
}
