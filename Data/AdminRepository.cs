using System.Linq.Expressions;
using FribergRentalsRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergRentalsRazor.Data
{
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Booking Add(Booking entity)
        {
            return applicationDbContext.Admins.Add(entity).Entity;
        }

        public IEnumerable<Booking> GetAll()
        {
            return applicationDbContext.Admins.ToList();
        }

        public Booking Remove(Booking entity)
        {
            var admin = applicationDbContext.Admins.Remove(entity).Entity;
            applicationDbContext.SaveChangesAsync();
            return admin;
        }

        public IEnumerable<Booking> Find(Expression<Func<Booking, bool>> predicate)
        {
            return applicationDbContext.Admins.AsQueryable().Where(predicate).ToList();
        }

        public Booking GetById(int? id)
        {
            return applicationDbContext.Admins.Find(id);
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
