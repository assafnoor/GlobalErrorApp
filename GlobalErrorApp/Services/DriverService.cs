using GlobalErrorApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GlobalErrorApp.Services
{
    public class DriverService : IDriverService
    {
        private readonly applicationDbContext _dbContext;

        public DriverService(applicationDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<Driver> Add(Driver driver)
        {
           var result= await _dbContext.Drivers.AddAsync(driver);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int Id)
        {
            var result= await GetDriverById(Id);
            _dbContext.Drivers.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public async Task<Driver> GetDriverById(int Id)
        {
           return await _dbContext.Drivers.SingleOrDefaultAsync(x => x.Id == Id);
            
        }

        public async Task<IEnumerable<Driver>> GetDrivers()
        {
            return await _dbContext.Drivers.ToListAsync();
        }

        public async Task<Driver> Update(Driver driver)
        {

            var result = _dbContext.Drivers.Update(driver);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
