using System.Linq.Expressions;
using FribergRentalsRazor.Models;
using Microsoft.EntityFrameworkCore;

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
            return applicationDbContext.Bookings.Add(entity).Entity;
        }

        public IEnumerable<Booking> GetAll()
        {
            return applicationDbContext.Bookings.ToList();
        }

        public Booking Remove(Booking entity)
        {
            var admin = applicationDbContext.Bookings.Remove(entity).Entity;
            applicationDbContext.SaveChangesAsync();
            return admin;
        }

        public IEnumerable<Booking> Find(Expression<Func<Booking, bool>> predicate)
        {
            return applicationDbContext.Bookings.AsQueryable().Where(predicate).ToList();
        }

        public Booking GetById(int? id)
        {
            return applicationDbContext.Bookings.Find(id);
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
