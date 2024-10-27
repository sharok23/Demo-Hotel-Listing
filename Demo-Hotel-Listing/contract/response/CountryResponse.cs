using System.ComponentModel.DataAnnotations;

namespace Demo_Hotel_Listing.contract.response
{
    public class CountryResponse
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
