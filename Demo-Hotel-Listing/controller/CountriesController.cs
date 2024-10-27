using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo_Hotel_Listing.Models;
using AutoMapper;
using Demo_Hotel_Listing.contract.response;
using Demo_Hotel_Listing.Repository;
using Demo_Hotel_Listing.contract.request;

namespace Demo_Hotel_Listing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper,ICountriesRepository countriesRepository)
        {
            this._mapper = mapper;
            this._countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryResponse>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<CountryResponse>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryResponse>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryDto = _mapper.Map<CountryResponse>(country);

            return countryDto;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, CountryRequest countryRequest)
        {

            var country = await _countriesRepository.GetAsync(id);

            _mapper.Map(countryRequest, country);

            try
            {
                await _countriesRepository.UpdateAsync(country);
                var response = _mapper.Map<CountryResponse>(country);
                return Ok(response);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryResponse>> PostCountry(CountryRequest countryRequest)
        {
            var country = _mapper.Map<Country>(countryRequest);
            await _countriesRepository.AddAsync(country);
            var countryResponse = _mapper.Map<CountryResponse>(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, countryResponse);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepository.DeleteAsync(id);

            return Ok();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
