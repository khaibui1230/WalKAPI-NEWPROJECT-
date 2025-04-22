using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalkAPI.Models.Domain;
using NZWalkAPI.Models.DTOs;
using NZWalkAPI.Reposotiory;

namespace NZWalkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        //GetALl Walks
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            // get walks from the database
            var walksDomain = await walkRepository.GetAllAsync();
            // Convert to DTO using AutoMapper
            var walksDto = mapper.Map<List<WalkDto>>(walksDomain);
            //return Dto
            return Ok(walksDto);
        }

        //Get Walk by Id
        //Get : https   ://localhost:5000/api/walks/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalksByID(Guid id)
        {
            var walkDomain = await walkRepository.GetByIdAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }
            // Convert to DTO using AutoMapper
            var walkDto = mapper.Map<WalkDto>(walkDomain);
            return Ok(walkDto);
        }
        //Post : https   ://localhost:5000/api/walks
        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequest addWalkRequest)
        {
            // Convert to Domain Model
            var walkDomain = new Walks()
            {
                Name = addWalkRequest.Name,
                LengthInKm = addWalkRequest.LengthInKm,
                Description = addWalkRequest.Description,
                WalkImageUrl = addWalkRequest.WalkImageUrl,
                RegionId = addWalkRequest.RegionId,
                DifficultyId = addWalkRequest.DifficultyId
            };
            // Pass the domain model to the repository
            var walk = await walkRepository.CreateAsync(walkDomain);
            // Convert to DTO using AutoMapper
            var walkDto = mapper.Map<WalkDto>(walk);
            return CreatedAtAction(nameof(GetWalksByID), new { id = walkDto.Id }, walkDto);
        }

        //Put : https   ://localhost:5000/api/walks/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalk(Guid id, [FromBody] UpdateWalkRequest updateWalkRequest)
        {
            // Convert to Domain Model
            var walkDomain = new Walks()
            {
                Name = updateWalkRequest.Name,
                LengthInKm = updateWalkRequest.LengthInKm,
                Description = updateWalkRequest.Description,
                WalkImageUrl = updateWalkRequest.WalkImageUrl,
                RegionId = updateWalkRequest.RegionId,
                DifficultyId = updateWalkRequest.DifficultyId
            };

            // Pass the domain model to the repository
            var walk = await walkRepository.UpdateAsync(id, walkDomain);
            if (walk == null)
            {
                return NotFound();
            }
            // Convert to DTO using AutoMapper
            var walkDto = mapper.Map<WalkDto>(walk);

            return Ok(walkDto);
        }
        //Delete : https   ://localhost:5000/api/walks/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var walk = await walkRepository.DeleteAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
            // Convert to DTO using AutoMapper
            var walkDto = mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }
    }
}
