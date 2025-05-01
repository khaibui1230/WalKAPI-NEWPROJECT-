using AutoMapper;
using NZWalkAPI.Models.Domain;
using NZWalkAPI.Models.DTOs;

namespace NZWalkAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() { 
            CreateMap<Region, RegionDto>()
                .ReverseMap();
            // Convert to DTO using AutoMapper
            CreateMap<AddRegionRequestDto, Region>()
                .ReverseMap();
            
            CreateMap<UpdateRegionRequestDto, Region>()
                .ReverseMap();

            // Walk
            CreateMap<Walks , WalkDto>().ReverseMap();
            CreateMap<AddWalkRequest, Walks>()
                .ReverseMap();
            CreateMap<UpdateWalkRequest, Walks>().ReverseMap();

            //Images
            CreateMap<Image, ImageUploadRequestDto>().ReverseMap();
        }
    }
}
