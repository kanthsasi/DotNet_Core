using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(3,ErrorMessage ="Code has to be a Maximum of 3 character")]
        public string Code { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="Code has to be a minimum of 3 character ")]
        public string Name { get; set; }
        
        public string? RegionImageUrl { get; set; }
    }
}
