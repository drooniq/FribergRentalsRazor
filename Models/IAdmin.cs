using System.Linq.Expressions;

namespace FribergRentalsRazor.Models
{
    public interface IAdmin
    {
        Admin Add(Admin entity);
        Admin Update(Admin entity);
        Admin GetById(int? id);
        Admin Remove(Admin entity);
        IEnumerable<Admin> GetAll();
        IEnumerable<Admin> Find(Expression<Func<Admin, bool>> predicate);
        void SaveChanges();
    }
}
