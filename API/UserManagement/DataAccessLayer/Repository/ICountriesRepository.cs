using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface ICountriesRepository
    {
        Task<IEnumerable<Countries>> GetCountriesAsync();
        Task<Countries> GetCountryByIdAsync(Guid id);
        Task<Countries> AddCountryAsync(AddCountries addCountries);
        Task <bool>UpdateCountryAsync(UpdateCountries updateCountries);
        Task <bool>DeleteCountryAsync(Guid id);
    }
}
