using System.Linq.Expressions;

namespace FribergRentalsRazor.Models
{
    public interface IBooking
    {
        Task<Booking> AddAsync(Booking entity);
        Task<Booking> UpdateAsync(Booking entity);
        Task<Booking> GetByIdAsync(int? id);
        Task<Booking> RemoveAsync(Booking entity);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<IEnumerable<Booking>> FindAsync(Expression<Func<Booking, bool>> predicate);
        Task SaveChangesAsync();
    }
}
