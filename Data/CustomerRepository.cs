using System.Linq;
using System.Linq.Expressions;
using FribergRentalsRazor.Models;
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

        public Customer Add(Customer entity)
        {
            return applicationDbContext.Customers.Add(entity).Entity;
        }

        public IEnumerable<Customer> GetAll()
        {
            return applicationDbContext.Customers.ToList();
        }

        public Customer Remove(Customer entity)
        {
            var customer = applicationDbContext.Customers.Remove(entity).Entity;
            applicationDbContext.SaveChangesAsync();
            return customer;
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return applicationDbContext.Customers.AsQueryable().Where(predicate).ToList();
        }

        public Customer GetById(int? id)
        {
            return applicationDbContext.Customers.Find(id);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public Customer Update(Customer entity)
        {
            var customer = applicationDbContext.Update<Customer>(entity).Entity;
            applicationDbContext.Attach(entity).State = EntityState.Modified;
            applicationDbContext.SaveChanges();
            return customer;
        }
    }
}
