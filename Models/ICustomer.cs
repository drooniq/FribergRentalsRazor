using System.Linq.Expressions;

namespace FribergRentalsRazor.Models
{
    public interface ICustomer
    {
        Task<Customer> AddAsync(Customer entity);
        Task<Customer> UpdateAsync(Customer entity);
        Task<Customer> GetByIdAsync(int? id);
        Task<Customer> RemoveAsync(Customer entity);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> predicate);
        Task SaveChangesAsync();
    }
}
