using Demo_Hotel_Listing.Data;
using Demo_Hotel_Listing.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_Hotel_Listing.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;

        public CountriesRepository(HotelListingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            //return await _context.Countries
            //    .FirstOrDefaultAsync(q => q.Id == id);
            return await _context.Countries
                .Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public override async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries
                .Include(q => q.Hotels)
                .ToListAsync();
        }

    }
}
