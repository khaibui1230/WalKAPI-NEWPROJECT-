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
    public class ImageController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IImageRepository imageRepository;

        public ImageController(IMapper mapper, IImageRepository imageRepository)
        {
            this.mapper = mapper;
            this.imageRepository = imageRepository;
        }
        //POST : /api/Image/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto requestDto) { 

            ValidateFileUpload(requestDto);

            if (ModelState.IsValid)
            {
                //Conver DTO to Domain Model 
                // Convert DTO to Domain
                var imageDomainModel = new Image
                {
                    File = requestDto.File,
                    FileName = requestDto.FileName,
                    FileDescription = requestDto.FileDescription,
                    FileExtension = Path.GetExtension(requestDto.File.FileName) 
                };
                //User Repositoru to upload image
                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto requestDto)
        {
            var allowExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (requestDto.File == null || requestDto.File.Length == 0)
            {
                ModelState.AddModelError("File", "File is required");
                return;
            }

            var extension = Path.GetExtension(requestDto.File.FileName).ToLower();

            if (!allowExtensions.Contains(extension))
            {
                ModelState.AddModelError("File", "Unsupported file extension");
            }

            if (requestDto.File.Length > 10 * 1024 * 1024) // 10MB
            {
                ModelState.AddModelError("File", "File size more than 10MB, please upload a smaller size file");
            }
        }

    }
}
