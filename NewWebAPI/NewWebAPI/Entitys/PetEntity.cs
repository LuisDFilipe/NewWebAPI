using NewWebAPI.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace NewWebAPI.Entitys
{
    public record PetEntity
    {
        [Required]
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? cagePasswordHash { get; set; }

        public static PetEntity? ToEntity(PetDTO? pet)
        {
            return pet != null ? new() { id = pet.id, name = pet.name, description = pet.description } : null;
        }

        internal static string Sha256HashString(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using var hash = SHA256.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToHexString(byteArray);
        }
    }
}
