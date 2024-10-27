using Demo_Hotel_Listing.Models;


namespace Demo_Hotel_Listing.Repository
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
