using Accounting_Business.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Business.Services
{
    public interface ICityService
    {
        Task<List<City>> GetAllCities();
        void Add(City city);
        void Delete(City city);
        Task<City> Get(int id);
    }
    public class CityService : ICityService
    {
        private readonly AppDbContext _context;
        public CityService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<City>> GetAllCities()
        {
            return await _context.Cities.Where(e => e.IsActive == true).ToListAsync();
        }

        public void Add(City city)
        {
            _context.Cities.Add(city);
        }

        public void Delete(City city)
        {
            _context.Cities.Remove(city);
        }

        public async Task<City> Get(int id)
        {
          var city = await _context.Cities.FindAsync(id);
            // if (city == null) { throw new NotFo}
            return city;
        }
    }
}
