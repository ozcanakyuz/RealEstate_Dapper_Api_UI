﻿namespace RealEstate_Dapper_Api.Dtos.PopularLocationDtos
{
    public class GetByIdPopularLocationDto
    {
        public int PopularLocationId { get; set; }
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
    }
}
