using System.Linq.Expressions;

namespace FribergRentalsRazor.Models
{
    public interface ICustomer
    {
        Customer Add(Customer entity);
        Customer Update(Customer entity);
        Customer GetById(int? id);
        Customer Remove(Customer entity);
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate);
        void SaveChanges();
    }
}
