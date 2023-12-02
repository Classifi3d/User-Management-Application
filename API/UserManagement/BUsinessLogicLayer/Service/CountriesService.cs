using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;

namespace BusinessLogicLayer.Service
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepository _countriesRepository;

        public CountriesService(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }

        public async Task<IEnumerable<Countries>> GetCountriesAsync()
        {
            return await _countriesRepository.GetCountriesAsync();
        }

        public async Task<Countries> GetCountryByIdAsync(Guid id)
        {
            return await _countriesRepository.GetCountryByIdAsync(id);
        }

        public async Task<Countries> AddCountryAsync(AddCountries addCountries)
        {
            return await _countriesRepository.AddCountryAsync(addCountries);
        }

        public async Task<bool> UpdateCountryAsync(UpdateCountries updateCountries)
        {
            return await _countriesRepository.UpdateCountryAsync(updateCountries);
        }

        public async Task<bool> DeleteCountryAsync(Guid id)
        {
            return await _countriesRepository.DeleteCountryAsync(id);
        }
    }
}
