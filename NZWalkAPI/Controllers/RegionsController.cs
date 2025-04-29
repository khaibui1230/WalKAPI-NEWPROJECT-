using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalkAPI.Models.Domain;
using NZWalkAPI.Models.DTOs;
using NZWalkAPI.Reposotiory;

namespace NZWalkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
       
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController( IRegionRepository regionRepository, IMapper mapper)
        {
            
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        //GetALl Regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // get regions from the database
            var regionsDomain = await regionRepository.GetAllAsync();

            //// convert to DTO
            //var regionsDto = new List<RegionDto>();
            //foreach (var region in regionsDomain)
            //{
            //    var regionDto = new RegionDto()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl
            //    };
            //    regionsDto.Add(regionDto);
            //}
            // Convert to DTO using AutoMapper
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

            //return Dto
            return Ok(regionsDto);
        }
        //Get Region by Id
        //Get : https   ://localhost:5000/api/regions/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRegionsByID(Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            //convert to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            //return Dto
            return Ok(regionDto);
        }
        //Create Region
        //Post : https   ://localhost:5000/api/regions
        [HttpPost]
        
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Convert Dto to domain
            var regionDomain = mapper.Map<Region>(addRegionRequestDto);

            // Use the domain to create a new region
            regionDomain =  await regionRepository.CreateAsync(regionDomain);

            // Convert the created domain to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return CreatedAtAction(nameof(GetRegionsByID),new {id = regionDto.Id}, regionDto);

        }
        //Update Region by Id
        //Put : https   ://localhost:5000/api/regions/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRegion(Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // convert Dto to domain
            var regionDomain = mapper.Map<Region>(updateRegionRequestDto);
            // Use the domain to update the region
            var updateRegionDomain = await regionRepository.UpdateAsync(id, regionDomain);
            
            if (updateRegionDomain == null)
            {
                return NotFound();
            }
            // Convert the updated domain to DTO
            // Return the updated region
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // Delete Region by Id
        //Delete : https   ://localhost:5000/api/regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            // Get region in database
            var regionDomain = await regionRepository.DeleteAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //return the region remove
            //map to DTO
            
            return Ok(mapper.Map<RegionDto>(regionDomain));

        }

    }
}
