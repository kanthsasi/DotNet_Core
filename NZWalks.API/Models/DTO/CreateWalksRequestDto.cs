using NZWalks.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class CreateWalksRequestDto
    {
        [Required]
        [MaxLength(30,ErrorMessage ="Name should contain only 30 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="Description should contain only 100 characters")]
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficultyID { get; set; }

       

    }
}
