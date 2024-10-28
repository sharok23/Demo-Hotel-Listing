using Demo_Hotel_Listing.Models;

namespace Demo_Hotel_Listing.Repository
{
    public interface IHotelsRepository : IGenericRepository<Hotel>
    {
        Task<Hotel> GetDetails(int id);
    }
}
