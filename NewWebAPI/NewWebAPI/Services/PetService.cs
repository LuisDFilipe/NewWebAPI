using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWebAPI.DTOs;
using NewWebAPI.Entitys;
using System.Net;

namespace NewWebAPI.Repositorys
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        IEnumerable<PetDTO?> IPetService.GetPets()
        {
            var result = _petRepository.GetAll().Select(pet => PetDTO.ToDto(pet)).ToList();
            return result;
        }

        PetDTO? IPetService.GetPet(int id)
        {
            var result = PetDTO.ToDto(_petRepository.GetById(id));
            return result;
        }

        PetDTO? IPetService.PostPet(PetDTO pet)
        {
            var result = PetDTO.ToDto(_petRepository.Post(PetEntity.ToEntity(pet)));
            return result;
        }

        PetDTO? IPetService.PutPet(PetDTO pet)
        {
            var result = PetDTO.ToDto(_petRepository.Put(PetEntity.ToEntity(pet)));
            return result;
        }

        PetDTO? IPetService.DeletePet(int id)
        {
            return PetDTO.ToDto(_petRepository.DeleteById(id));
        }
    }
}
