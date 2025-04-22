using System.ComponentModel.DataAnnotations;

namespace NZWalkAPI.Models.DTOs
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Region name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(3, ErrorMessage = "Region code cannot exceed 3 characters.")]
        [MinLength(3, ErrorMessage = "Region code must be at least 3 characters.")]
        public string Code { get; set; } = string.Empty;
        public string? RegionImageUrl { get; set; }
    }
}
