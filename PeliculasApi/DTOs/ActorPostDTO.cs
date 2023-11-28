using System.ComponentModel.DataAnnotations;
using PeliculasApi.Validations;

namespace PeliculasApi.DTOs
{
    public class ActorPostDTO
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        [WeightFileValidation(MaxWeightInMegaBytes: 4)]
        [FileTypeValidation(fileTypeGroup: FileTypeGroup.Imagen)]
        public IFormFile Photo { get; set; }
    }
}
