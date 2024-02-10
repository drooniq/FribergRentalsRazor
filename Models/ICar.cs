using System.Linq.Expressions;

namespace FribergRentalsRazor.Models
{
    public interface ICar
    {
        Task<Car> AddAsync(Car entity);
        Task<Car> UpdateAsync(Car entity);
        Task<Car> GetByIdAsync(int? id);
        Task<Car> RemoveAsync(Car entity);
        Task<IEnumerable<Car>> GetAllAsync();
        Task<IEnumerable<Car>> FindAsync(Expression<Func<Car, bool>> predicate);
        Task SaveChangesAsync();
    }
}
