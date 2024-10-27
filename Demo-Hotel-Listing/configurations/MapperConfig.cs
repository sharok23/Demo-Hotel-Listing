﻿
using AutoMapper;
using Demo_Hotel_Listing.contract.request;
using Demo_Hotel_Listing.contract.response;
using Demo_Hotel_Listing.Models;

namespace Demo_Hotel_Listing.configurations
{
    public class MapperConfig : Profile
    {
       public MapperConfig() {
            CreateMap<CountryRequest, Country>();
            CreateMap<Country, CountryResponse>();
        }    
    }
}
