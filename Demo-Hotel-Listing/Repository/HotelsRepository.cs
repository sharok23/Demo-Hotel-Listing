using Demo_Hotel_Listing.Data;
using Demo_Hotel_Listing.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_Hotel_Listing.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        private readonly HotelListingDbContext _context;
        public HotelsRepository(HotelListingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Hotel> GetDetails(int id)
        {
            return await _context.Hotels
                .Include(h => h.Country)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

    }
}
