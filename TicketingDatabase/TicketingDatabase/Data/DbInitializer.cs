using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingDatabase.Models;
using TicketingDatabase.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace TicketingDatabase.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TicketingContext context)
        {
            context.Database.EnsureCreated();

            if (!context.RoomConfigs.Any())
            {
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
                            Description = "",
                            Capacity = null,
                            Rows = new ObservableCollection<Row>
                            {
                                new Row
                                {
                                    Name = "Rangée 1",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 2",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 3",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 4",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 5",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 6",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 7",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 8",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 9",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 10",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                    }
                                },

                            }
                        },new Section
                        {
                            Name = "Section 2",
                            Description = "",
                            Capacity = null,
                            Rows = new ObservableCollection<Row>
                            {
                                new Row
                                {
                                    Name = "Rangée 1",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 2",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 42", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 43", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 44", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 3",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 42", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 43", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 44", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 45", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 46", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 47", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 4",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 42", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 43", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 44", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 45", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 46", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 47", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 48", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 49", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 50", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 5",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 42", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 43", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 44", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 45", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 46", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 47", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 48", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 6",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 42", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 43", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 44", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 45", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 46", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 47", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 48", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 7",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 42", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 43", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 44", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 45", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 46", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 47", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 48", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 49", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 50", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 51", Description = "", IsAvailable = true },
                                    }
                                },
                            }
                        },new Section
                        {
                            Name = "Section 3",
                            Description = "",
                            Capacity = null,
                            Rows = new ObservableCollection<Row>
                            {
                                new Row
                                {
                                    Name = "Rangée 1",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                    }
                                }, new Row
                                {
                                    Name = "Rangée 2",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                    }
                                }, new Row
                                {
                                    Name = "Rangée 3",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 4",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                    }
                                },
                            }
                        },new Section
                        {
                            Name = "Section 4",
                            Description = "",
                            Capacity = null,
                            Rows = new ObservableCollection<Row>
                            {
                                new Row
                                {
                                    Name = "Rangée 1",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 42", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 43", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 44", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 45", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 46", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 47", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 48", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 49", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 50", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 51", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 52", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 53", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 54", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 2",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 42", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 43", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 44", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 45", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 46", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 47", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 48", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 49", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 3",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 42", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 43", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 44", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 45", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 46", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 47", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 48", Description = "", IsAvailable = true },
                                    }
                                },new Row
                                {
                                    Name = "Rangée 4",
                                    Description = "",
                                    IsAvailable = true,
                                    Seats = new ObservableCollection<Seat>
                                    {
                                        new Seat { Name = "Siège 1", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 2", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 3", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 4", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 5", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 6", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 7", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 8", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 9", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 10", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 11", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 12", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 13", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 14", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 15", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 16", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 17", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 18", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 19", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 20", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 21", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 22", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 23", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 24", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 25", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 26", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 27", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 28", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 29", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 30", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 31", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 32", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 33", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 34", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 35", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 36", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 37", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 38", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 39", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 40", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 41", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 42", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 43", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 44", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 45", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 46", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 47", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 48", Description = "", IsAvailable = true },
                                        new Seat { Name = "Siège 49", Description = "", IsAvailable = true },
                                    }
                                },
                            }
                        },
                    }
                },
                };
                foreach (RoomConfig r in rooms)
                {
                    context.RoomConfigs.Add(r);
                }
                context.SaveChanges();
            }
           
            if (!context.Rooms.Any())
            {
                var room = new Room
                {
                    Name = "Grande salle de spectacle",
                    Description = "Une salle spacieuse idéale pour les concerts et les spectacles.",
                    TotalCapacity = 1000,
                    RoomConfigId = 1,
                };
                var roomConfig = context.RoomConfigs.Include(rc => rc.Sections).ThenInclude(s => s.Rows).ThenInclude(r => r.Seats).FirstOrDefault(rc => rc.Id == 1);
                var sections = new ObservableCollection<Section>();

                foreach (Section roomConfigSection in roomConfig.Sections)
                {
                    var newSection = new Section()
                    {
                        Name = roomConfigSection.Name,
                        Description = roomConfigSection.Description,
                        Capacity = roomConfigSection.Capacity,
                        Rows = new ObservableCollection<Row>() // Create a new collection for rows
                    };

                    foreach (Row roomConfigRow in roomConfigSection.Rows)
                    {
                        var newRow = new Row()
                        {
                            Name = roomConfigRow.Name,
                            Description = roomConfigRow.Description,
                            Capacity = roomConfigRow.Capacity,
                            IsAvailable = roomConfigRow.IsAvailable,
                            Seats = new ObservableCollection<Seat>() // Create a new collection for seats
                        };

                        foreach (Seat roomConfigSeat in roomConfigRow.Seats)
                        {
                            var seat = new Seat()
                            {
                                Name = roomConfigSeat.Name,
                                Description = roomConfigSeat.Description,
                                IsAvailable = roomConfigSeat.IsAvailable,
                                Price = 27.99,
                            };
                            newRow.Seats.Add(seat);
                        }
                        newSection.Rows.Add(newRow); // Add the new row to the section
                    }
                    sections.Add(newSection); // Add the new section to the room
                }
                room.Sections = sections; // Assign the sections to the room

                context.Rooms.Add(room);
                context.SaveChanges();

                if (!context.Events.Any())
                {
                    // Exemple de données d'événement
                    var events = new Event[]
                    {
                    new Event
                    {
                        Name = "Concert de musique classique",
                        Description = "Un magnifique concert de musique classique avec les plus grands compositeurs.",
                        ArtistName = "Orchestre symphonique de Montréal",
                        Duration = 120,
                        IsActive = true,
                        StartingDate = DateTime.Now.Date,
                        EndingDate = DateTime.Now.Date.AddDays(2),
                        RoomId = 1
                    },
                    new Event
                    {
                        Name = "Spectacle d'humour",
                        Description = "Une soirée de rires et de divertissement avec un humoriste renommé.",
                        ArtistName = "Gad Elmaleh",
                        Duration = 90,
                        IsActive = true,
                        StartingDate = DateTime.Now.Date.AddDays(5),
                        EndingDate = DateTime.Now.Date.AddDays(7),
                        RoomId = 1
                    }
                    };

                    foreach (Event e in events)
                    {
                        context.Events.Add(e);
                    }

                    context.SaveChanges();

                    if (!context.EventDates.Any())
                    {
                        var contextEvents = context.Events.ToList();

                        foreach (var eventEntity in contextEvents)
                        {
                            // Assuming you want to add multiple dates for each event
                            var eventDates = new List<EventDate>
                            {
                                new EventDate
                                {
                                    Date = eventEntity.StartingDate?.AddHours(21).AddMinutes(30), // Example: the day after the event starts
                                    EventId = eventEntity.Id
                                },
                                new EventDate
                                {
                                    Date = eventEntity.StartingDate?.AddDays(1).AddHours(20), // Example: the day after the event starts
                                    EventId = eventEntity.Id
                                },
                                new EventDate
                                {
                                    Date = eventEntity.StartingDate?.AddDays(2).AddHours(19).AddMinutes(30), // Another example date
                                    EventId = eventEntity.Id
                                }
                                // Add more dates as needed
                            };

                            foreach (var eventDate in eventDates)
                            {
                                context.EventDates.Add(eventDate);
                            }
                        }

                        context.SaveChanges();

                        if (!context.Tickets.Any())
                        {
                            foreach (Event contextEvent in context.Events)
                            {
                                var tickets = new List<Ticket>();
                                int sectionCount = 0;
                                foreach (Section roomSection in contextEvent.Room.Sections)
                                {
                                    sectionCount++;
                                    int rowCount = 0;
                                    foreach (Row roomSectionRow in roomSection.Rows)
                                    {
                                        rowCount++;
                                        int seatCount = 0;
                                        foreach (Seat seat in roomSectionRow.Seats.Where(s => s.IsAvailable))
                                        {
                                            seatCount++;
                                            // Building the SeatNumber based on section, row, and seat count
                                            string seatNumber = $"{sectionCount}{rowCount:D2}{seatCount:D2}";

                                            // Quoting is the sum of section, row, and seat index
                                            int quoting = sectionCount + rowCount + seatCount;

                                            foreach (EventDate eventDate in contextEvent.EventDates)
                                            {
                                                var ticket = new Ticket
                                                {
                                                    EventId = contextEvent.Id,
                                                    SeatId = seat.Id,
                                                    Price = seat.Price.HasValue ? seat.Price.Value : 0,
                                                    Status = "Available",
                                                    SeatNumber = seatNumber,
                                                    Quoting = quoting,
                                                    EventDateId = eventDate.Id,
                                                    EventDate = eventDate,
                                                };

                                                context.Tickets.Add(ticket);
                                            }
                                        }
                                    }
                                }
                            }

                            context.SaveChanges();

                            if (!context.Users.Any())
                            {
                                var clients = new List<Client>
                                {
                                    new Client
                                    {
                                        UserName = "clientUser1",
                                        Password = "password", // In a real application, ensure to hash passwords
                                        CreationDate = DateTime.Now,
                                        Type = "Client",
                                        FirstName = "John",
                                        LastName = "Doe",
                                        Email = "john.doe@example.com",
                                        Phone = "1234567890"
                                    },
                                };

                                foreach (var client in clients)
                                {
                                    context.Users.Add(client);
                                }

                                context.SaveChanges();

                                var admins = new List<Administrator>
                                {
                                    new Administrator
                                    {
                                        UserName = "Admin",
                                        Password = CryptographyHelper.HashPassword("54321"), 
                                        CreationDate = DateTime.Now,
                                        Type = "Administrator",
                                        FirstName = "Admin",
                                        LastName = "Admin",
                                        Email = "admin@admin.com"
                                    }
                                };

                                foreach (var admin in admins)
                                {
                                    context.Users.Add(admin);
                                }

                                context.SaveChanges();

                                if (!context.Sales.Any())
                                {
                                    // Example sale data
                                    var sales = new Sale[]
                                    {
                                        new Sale
                                        {
                                            Date = DateTime.Now,
                                            TotalPrice = 200.00,
                                            TPS = 10.00,
                                            TVQ = 15.00,
                                            TotalPriceTax = 225.00,
                                            EventId = 1
                                        },
                                        new Sale
                                        {
                                            Date = DateTime.Now.AddDays(-1),
                                            TotalPrice = 150.00,
                                            TPS = 7.50,
                                            TVQ = 11.25,
                                            TotalPriceTax = 168.75,
                                            EventId = 1
                                        }
                                    };

                                    foreach (Sale s in sales)
                                    {
                                        context.Sales.Add(s);
                                    }
                                    context.SaveChanges();

                                    if (!context.Transactions.Any())
                                    {
                                        // Example Transaction data
                                        var transactions = new Transaction[]
                                        {
                                            new Transaction
                                            {
                                                Date = DateTime.Now,
                                                TotalPrice = 200.00,
                                                TPS = 10.00,
                                                TVQ = 15.00,
                                                TotalPriceTax = 225.00,
                                                SaleId = 1,
                                                UserId = 1,
                                            },
                                            new Transaction
                                            {
                                                Date = DateTime.Now.AddDays(-1),
                                                TotalPrice = 150.00,
                                                TPS = 7.50,
                                                TVQ = 11.25,
                                                TotalPriceTax = 168.75,
                                                SaleId = 2,
                                                UserId = 1,
                                            }
                                        };

                                        foreach (Transaction t in transactions)
                                        {
                                            context.Transactions.Add(t);
                                        }
                                        context.SaveChanges();

                                        if (!context.DigitalTickets.Any())
                                        {
                                            // Example Transaction data
                                            var digitalTickets = new DigitalTicket[]
                                            {
                                                new DigitalTicket
                                                {
                                                    UniqueCode = "234523445243ewrwe5234554",
                                                    DateSent = DateTime.Now,
                                                    TicketId = 2,
                                                    UserId = 1,
                                                    TransactionId = 1
                                                },
                                                new DigitalTicket
                                                {
                                                    UniqueCode = "32423523dsfsghr45234452345",
                                                    DateSent = DateTime.Now,
                                                    TicketId = 2,
                                                    UserId = 1,
                                                    TransactionId = 1
                                                }, new DigitalTicket
                                                {
                                                    UniqueCode = "324235fdsf2345234452345",
                                                    DateSent = DateTime.Now,
                                                    TicketId = 351,
                                                    UserId = 1,
                                                    TransactionId = 2
                                                }, new DigitalTicket
                                                {
                                                    UniqueCode = "324235234523t43wdw4452345",
                                                    DateSent = DateTime.Now,
                                                    TicketId = 352,
                                                    UserId = 1,
                                                    TransactionId = 2
                                                }, new DigitalTicket
                                                {
                                                    UniqueCode = "3242352345234tewef452345",
                                                    DateSent = DateTime.Now,
                                                    TicketId = 353,
                                                    UserId = 1,
                                                    TransactionId = 2
                                                },

                                            };

                                            foreach (DigitalTicket dt in digitalTickets)
                                            {
                                                context.DigitalTickets.Add(dt);
                                                context.Tickets.FirstOrDefault(t => t.Id == dt.TicketId).Status = "Purshased";
                                            }
                                            context.SaveChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
