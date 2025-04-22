using System.ComponentModel.DataAnnotations;
using NZWalkAPI.Models.Domain;

namespace NZWalkAPI.Models.DTOs
{
    internal class WalkDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Walk name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Range(0, 1000, ErrorMessage = "Length must be between 0 and 1000 km.")]
        [Required(ErrorMessage = "Length is required.")]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        
    }
}