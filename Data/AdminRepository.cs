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

        public async Task<Admin> AddAsync(Admin entity)
        {
            var admin = applicationDbContext.Admins.Add(entity).Entity;
            await applicationDbContext.SaveChangesAsync();
            return admin;
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await applicationDbContext.Admins.ToListAsync();
        }

        public async Task<Admin> RemoveAsync(Admin entity)
        {
            var admin = applicationDbContext.Admins.Remove(entity).Entity;
            await applicationDbContext.SaveChangesAsync();
            return admin;
        }

        public async Task<IEnumerable<Admin>> FindAsync(Expression<Func<Admin, bool>> predicate)
        {
            return await applicationDbContext.Admins.AsQueryable().Where(predicate).ToListAsync();
        }

        public async Task<Admin> GetByIdAsync(int? id)
        {
            return await applicationDbContext.Admins.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Admin> UpdateAsync(Admin entity)
        {
            var admin = applicationDbContext.Update<Admin>(entity).Entity;
            await applicationDbContext.SaveChangesAsync();
            return admin;
        }
    }
}
