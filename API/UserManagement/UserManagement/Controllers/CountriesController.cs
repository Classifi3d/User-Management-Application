using BusinessLogicLayer.Service;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountriesAsync()
        {
            var country = await _countriesService.GetCountriesAsync();
            return Ok(country);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCountryById")]
        public async Task<IActionResult> GetCountryByIdAsync([FromRoute] Guid id)
        {
            var country = await _countriesService.GetCountryByIdAsync(id);
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> AddCountryAsync([FromBody] AddCountries addCountries)
        {
            var country = await _countriesService.AddCountryAsync(addCountries);
            return Ok(country);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountryAsync(
            [FromBody] UpdateCountries updateCountries
        )
        {
            var response = await _countriesService.UpdateCountryAsync(updateCountries);
            if (response == true)
            {
                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ActionName("DeleteById")]
        public async Task<IActionResult> DeleteCountryAsync(Guid id)
        {
            var response = await _countriesService.DeleteCountryAsync(id);
            if (response == true)
            {
                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
