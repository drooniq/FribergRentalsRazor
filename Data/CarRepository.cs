using System.Linq.Expressions;
using FribergRentalsRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergRentalsRazor.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        { 
            this.applicationDbContext = applicationDbContext;
        }
        public Car Add(Car entity)
        {
            return applicationDbContext.Cars.Add(entity).Entity;
        }

        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.ToList();
        }

        public Car Remove(Car entity)
        {
            var car = applicationDbContext.Cars.Remove(entity).Entity;
            applicationDbContext.SaveChangesAsync();
            return car;
        }

        public IEnumerable<Car> Find(Expression<Func<Car, bool>> predicate)
        {
            return applicationDbContext.Cars.AsQueryable().Where(predicate).ToList();
        }

        public Car GetById(int? id)
        {
            return applicationDbContext.Cars.Find(id);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public Car Update(Car entity)
        {
            var car = applicationDbContext.Update<Car>(entity).Entity;
            applicationDbContext.Attach(entity).State = EntityState.Modified;
            applicationDbContext.SaveChanges();
            return car;
        }
    }
}
