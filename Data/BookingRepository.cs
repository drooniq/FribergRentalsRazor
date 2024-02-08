using System.Linq.Expressions;
using FribergRentalsRazor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FribergRentalsRazor.Data
{
    public class BookingRepository : IBooking
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Booking Add(Booking entity)
        {
            applicationDbContext.ChangeTracker.Clear();
            var booking = applicationDbContext.Bookings.Add(entity).Entity;
            applicationDbContext.Entry(entity.Car).State = EntityState.Unchanged;
            applicationDbContext.Entry(entity.Customer).State = EntityState.Unchanged;
            applicationDbContext.SaveChanges();
            return booking;
        }

        public IEnumerable<Booking> GetAll()
        {
            return applicationDbContext.Bookings
                .Include(c => c.Customer)
                .Include(c => c.Car);
        }

        public Booking Remove(Booking entity)
        {
            var admin = applicationDbContext.Bookings.Remove(entity).Entity;
            applicationDbContext.SaveChangesAsync();
            return admin;
        }

        public IEnumerable<Booking> Find(Expression<Func<Booking, bool>> predicate)
        {
            return applicationDbContext.Bookings
                .Include(c => c.Customer)
                .Include(c => c.Car)
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }

        public Booking GetById(int? id)
        {
            //return applicationDbContext.Bookings.Find(id);
            return applicationDbContext.Bookings.Where(b => b.BookingId == id)
                                                .Include(c => c.Customer)
                                                .Include(c => c.Car)
                                                .FirstOrDefault();
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public Booking Update(Booking entity)
        {
            var admin = applicationDbContext.Update<Booking>(entity).Entity;
            applicationDbContext.SaveChangesAsync();
            return admin;
        }

    }
}
