using System.Linq;
using System.Linq.Expressions;
using FribergRentalsRazor.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace FribergRentalsRazor.Data
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            var customer = applicationDbContext.Customers.Add(entity).Entity;
            await applicationDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await applicationDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> RemoveAsync(Customer entity)
        {
            var customer = applicationDbContext.Customers.Remove(entity).Entity;
            await applicationDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await applicationDbContext.Customers.AsQueryable().Where(predicate).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int? id)
        {
            return await applicationDbContext.Customers.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {
            var customer = applicationDbContext.Update<Customer>(entity).Entity;
            applicationDbContext.Attach(entity).State = EntityState.Modified;
            await applicationDbContext.SaveChangesAsync();
            return customer;
        }
    }
}
