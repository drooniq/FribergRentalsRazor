using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FribergRentalsRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergRentalsRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Booking> Admins { get; set; } = default!;
        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().ToTable(nameof(Booking));
            modelBuilder.Entity<Car>().ToTable(nameof(Car));
            modelBuilder.Entity<Customer>().ToTable(nameof(Customer));
            modelBuilder.Entity<Booking>().ToTable(nameof(Booking));
            base.OnModelCreating(modelBuilder);
        }
    }
}
