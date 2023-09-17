using GlobalErrorApp.Models;

namespace GlobalErrorApp.Services
{
    public interface IDriverService
    {
      public Task<IEnumerable<Driver>>GetDrivers();
       public Task<Driver> GetDriverById(int Id);
        public Task<Driver> Add(Driver driver);
        public Task<Driver> Update(Driver driver);
        public Task<bool> Delete(int Id);
    }
}
