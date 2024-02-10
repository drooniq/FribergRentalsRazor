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

        public async Task<Booking> AddAsync(Booking entity)
        {
            applicationDbContext.ChangeTracker.Clear();
            var booking = applicationDbContext.Bookings.Add(entity).Entity;
            applicationDbContext.Entry(entity.Car).State = EntityState.Unchanged;
            applicationDbContext.Entry(entity.Customer).State = EntityState.Unchanged;
            await applicationDbContext.SaveChangesAsync();
            return booking;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            var bookings = await applicationDbContext.Bookings
                .Include(c => c.Customer)
                .Include(c => c.Car)
                .ToListAsync();

            return bookings;
        }

        public async Task<Booking> RemoveAsync(Booking entity)
        {
            var admin = applicationDbContext.Bookings.Remove(entity).Entity;
            await applicationDbContext.SaveChangesAsync();
            return admin;
        }

        public async Task<IEnumerable<Booking>> FindAsync(Expression<Func<Booking, bool>> predicate)
        {
            var bookings = await applicationDbContext.Bookings
                .Include(c => c.Customer)
                .Include(c => c.Car)
                .AsQueryable()
                .Where(predicate)
                .ToListAsync();
            return bookings;
        }

        public async Task<Booking> GetByIdAsync(int? id)
        {
            //return applicationDbContext.Bookings.Find(id);
            var booking = await applicationDbContext.Bookings
                                                .Where(b => b.BookingId == id)
                                                .Include(c => c.Customer)
                                                .Include(c => c.Car)
                                                .FirstOrDefaultAsync();
            return booking;
        }

        public async Task SaveChangesAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Booking> UpdateAsync(Booking entity)
        {
            var admin = applicationDbContext.Update<Booking>(entity).Entity;
            await applicationDbContext.SaveChangesAsync();
            return admin;
        }

    }
}
