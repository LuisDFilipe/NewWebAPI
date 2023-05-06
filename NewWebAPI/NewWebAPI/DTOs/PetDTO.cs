using NewWebAPI.Entitys;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace NewWebAPI.DTOs
{
    public record PetDTO
    {
        [Required]
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }

        public static PetDTO? ToDto(PetEntity? pet)
        {
            return pet != null ? new() { id = pet.id, name = pet.name, description = pet.description } : null;
        }
    }
}
