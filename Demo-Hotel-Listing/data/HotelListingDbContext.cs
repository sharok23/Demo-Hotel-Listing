using Demo_Hotel_Listing.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_Hotel_Listing.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }


        //public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}

