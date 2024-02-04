using System.Linq.Expressions;

namespace FribergRentalsRazor.Models
{
    public interface IBooking
    {
        Booking Add(Booking entity);
        Booking Update(Booking entity);
        Booking GetById(int? id);
        Booking Remove(Booking entity);
        IEnumerable<Booking> GetAll();
        IEnumerable<Booking> Find(Expression<Func<Booking, bool>> predicate);
        void SaveChanges();
    }
}
