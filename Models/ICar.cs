using System.Linq.Expressions;

namespace FribergRentalsRazor.Models
{
    public interface ICar
    {
        Car Add(Car entity);
        Car Update(Car entity);
        Car GetById(int? id);
        Car Remove(Car entity);
        IEnumerable<Car> GetAll();
        IEnumerable<Car> Find(Expression<Func<Car, bool>> predicate);
        void SaveChanges();
    }
}
