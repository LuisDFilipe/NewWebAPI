using Microsoft.AspNetCore.Mvc;
using NewWebAPI.DTOs;

namespace NewWebAPI.Repositorys
{
    public interface IPetService
    {
        IEnumerable<PetDTO?> GetPets();
        PetDTO? GetPet(int id);
        PetDTO? PostPet(PetDTO pet);
        PetDTO? PutPet(PetDTO pet);
        PetDTO? DeletePet(int id);
    }
}
