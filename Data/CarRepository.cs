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
        public async Task<Car> AddAsync(Car entity)
        {
            var car = applicationDbContext.Cars.Add(entity).Entity;
            await applicationDbContext.SaveChangesAsync();
            return car;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await applicationDbContext.Cars.ToListAsync();
        }

        public async Task<Car> RemoveAsync(Car entity)
        {
            var car = applicationDbContext.Cars.Remove(entity).Entity;
            await applicationDbContext.SaveChangesAsync();
            return car;
        }

        public async Task<IEnumerable<Car>> FindAsync(Expression<Func<Car, bool>> predicate)
        {
            return await applicationDbContext.Cars.AsQueryable().Where(predicate).ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int? id)
        {
            return await applicationDbContext.Cars.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Car> UpdateAsync(Car entity)
        {
            var car = applicationDbContext.Update<Car>(entity).Entity;
            applicationDbContext.Attach(entity).State = EntityState.Modified;
            await applicationDbContext.SaveChangesAsync();
            return car;
        }
    }
}
