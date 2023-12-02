using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CountriesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Countries>> GetCountriesAsync()
        {
            return await _dbContext.Countries.ToListAsync();
        }
        public async Task<Countries> GetCountryByIdAsync(Guid id)
        {
            var country = await _dbContext.Countries.FindAsync(id);
            if (country == null)
            {
                return new Countries();
            }
            else return country;
        }

        public async Task<Countries> AddCountryAsync(AddCountries addCountries)
        {
            var country = new Countries()
            {
                Id = new Guid(),
                Name = addCountries.Name,
                Code = addCountries.Code,
                Flag = addCountries.Flag
            };
            await _dbContext.Countries.AddAsync(country);
            await _dbContext.SaveChangesAsync();

            return country;
        }
        public async Task<bool> UpdateCountryAsync(UpdateCountries updateCountries)
        {
            var country = _dbContext.Countries.Where(x => x.Name == updateCountries.Name).FirstOrDefault();
            if (country != null)
            {
                _dbContext.Update(country);
                country.Name = updateCountries.Name;
                country.Code = updateCountries.Code;
                country.Flag = updateCountries.Flag;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
            
            

        }

        public async Task<bool> DeleteCountryAsync(Guid id)
        {
            var country = await _dbContext.Countries.FindAsync(id);
            if (country != null)
            {
                _dbContext.Countries.Remove(country);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
