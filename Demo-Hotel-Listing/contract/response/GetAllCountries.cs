using Demo_Hotel_Listing.Models;

namespace Demo_Hotel_Listing.contract.response
{
    public class GetAllCountries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual IList<HotelResponse> Hotels { get; set; }
    }
}
