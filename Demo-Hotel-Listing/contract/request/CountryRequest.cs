using System.ComponentModel.DataAnnotations;
namespace Demo_Hotel_Listing.contract.request
{
    public class CountryRequest
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
