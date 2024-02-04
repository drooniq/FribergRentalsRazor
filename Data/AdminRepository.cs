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

        public Admin Add(Admin entity)
        {
            return applicationDbContext.Admins.Add(entity).Entity;
        }

        public IEnumerable<Admin> GetAll()
        {
            return applicationDbContext.Admins.ToList();
        }

        public Admin Remove(Admin entity)
        {
            var admin = applicationDbContext.Admins.Remove(entity).Entity;
            applicationDbContext.SaveChangesAsync();
            return admin;
        }

        public IEnumerable<Admin> Find(Expression<Func<Admin, bool>> predicate)
        {
            return applicationDbContext.Admins.AsQueryable().Where(predicate).ToList();
        }

        public Admin GetById(int? id)
        {
            return applicationDbContext.Admins.Find(id);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public Admin Update(Admin entity)
        {
            var admin = applicationDbContext.Update<Admin>(entity).Entity;
            applicationDbContext.SaveChangesAsync();
            return admin;
        }

    }
}
