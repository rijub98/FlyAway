using ARS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ARS
{
    public class ARS_DB_Context : DbContext
    {
        public ARS_DB_Context(DbContextOptions<ARS_DB_Context> options) : base(options)
        {
        }

        // DbSet properties for each model
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Seats> Seats { get; set; }
        public DbSet<Routes> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fix Flight → Bookings relationship
            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.Flight)
                .WithMany(f => f.Bookings)
                .HasForeignKey(b => b.Flights_ID)
                .OnDelete(DeleteBehavior.NoAction);

            // Fix Seats → Bookings relationship
            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.Seat)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.Seats_ID)
                .OnDelete(DeleteBehavior.NoAction);

            // Fix Passenger → Bookings relationship
            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.Passenger)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.Passenger_ID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
