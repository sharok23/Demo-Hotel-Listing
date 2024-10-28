using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo_Hotel_Listing.Data;
using Demo_Hotel_Listing.Models;
using Demo_Hotel_Listing.contract.response;
using Demo_Hotel_Listing.Repository;
using AutoMapper;
using Demo_Hotel_Listing.contract.request;
using Demo_Hotel_Listing.exception;
using System.Diagnostics.Metrics;

namespace Demo_Hotel_Listing.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHotelsRepository _hotelsRepository;
        private readonly ICountriesRepository _countriesRepository;

        public HotelsController(IMapper mapper, IHotelsRepository hotelsRepository, ICountriesRepository countriesRepository)
        {
            this._mapper = mapper;
            _hotelsRepository = hotelsRepository;
            _countriesRepository = countriesRepository;
    }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            var hotels = await _hotelsRepository.GetAllAsync();
            var records = _mapper.Map<List<HotelResponse>>(hotels);
            return Ok(records);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelResponse>> GetHotel(int id)
        {
            var hotel = await _hotelsRepository.GetDetails(id);

            if (!await HotelExists(id))
            {
                throw new NotFoundException("Hotel", id);
            }

            var hotelDto = _mapper.Map<HotelResponse>(hotel);
            return Ok(hotelDto);

        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelRequest hotelRequest)
        {
            var hotel = await _hotelsRepository.GetAsync(id);
            if (!await HotelExists(id))
            {
                throw new NotFoundException("Hotel", id);
            }

            _mapper.Map(hotelRequest, hotel);
            await _hotelsRepository.UpdateAsync(hotel);
            var response = _mapper.Map<HotelResponse>(hotel);
            return Ok(response);
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelResponse>> PostHotel(HotelRequest addHotelRequest)
        {
            var countryExists = await _countriesRepository.Exists(addHotelRequest.CountryId);
            if (!countryExists)
            {
                throw new NotFoundException("Countries", addHotelRequest.CountryId);
            }
            var hotel = _mapper.Map<Hotel>(addHotelRequest);
            await _hotelsRepository.AddAsync(hotel);
            var hotelResponse = _mapper.Map<HotelResponse>(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotelResponse);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);
            if (!await HotelExists(id))
            {
                throw new NotFoundException("Hotel", id);
            }

            await _hotelsRepository.DeleteAsync(id);
            return Ok();

        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelsRepository.Exists(id);
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
