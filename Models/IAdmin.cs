using System.Linq.Expressions;

namespace FribergRentalsRazor.Models
{
    public interface IAdmin
    {
        Task<Admin> AddAsync(Admin entity);
        Task<Admin> UpdateAsync(Admin entity);
        Task<Admin> GetByIdAsync(int? id);
        Task<Admin> RemoveAsync(Admin entity);
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<IEnumerable<Admin>> FindAsync(Expression<Func<Admin, bool>> predicate);
        Task SaveChangesAsync();
    }
}
