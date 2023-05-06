using Microsoft.AspNetCore.Mvc;
using NewWebAPI.DTOs;
using NewWebAPI.Repositorys;
using System.Net;

namespace NewWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    [ProducesResponseType(typeof(PetDTO), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(PetDTO), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(PetDTO), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(PetDTO), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(PetDTO), (int)HttpStatusCode.Conflict)]
    [ProducesResponseType(typeof(PetDTO), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(PetDTO), (int)HttpStatusCode.InternalServerError)]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("pets")]
        public ActionResult<IEnumerable<PetDTO?>> GetAll()
        {
            return _petService.GetPets().ToList();
        }

        [HttpGet("pet")]
        public ActionResult<PetDTO?> GetById(int id)
        {
            PetDTO? result = _petService.GetPet(id);
            if (result == null) return NotFound(new ErrorDetailsDTO((int)HttpStatusCode.NotFound, $"Record with id '{id}' was not found")); //record doesn't exist
            return result;
        }

        [HttpPost("pet")]
        public ActionResult<PetDTO?> Post([FromBody] PetDTO pet)
        {
            PetDTO? result = _petService.PostPet(pet);
            if (result == null)
            {
                PetDTO? existingPet = _petService.GetPet(pet.id);
                if (existingPet != null) return Conflict(new ErrorDetailsDTO((int)HttpStatusCode.Conflict, $"Record with id '{pet.id}' already exists")); //record doesn't exist

                return Conflict(new ErrorDetailsDTO((int)HttpStatusCode.Conflict, "Error creating record")); //couldn't create record
            }
            return result;
        }

        [HttpPut("pet")]
        public ActionResult<PetDTO?> Put(int id, [FromBody] PetDTO pet)
        {
            if (id != pet.id) return BadRequest(new ErrorDetailsDTO((int)HttpStatusCode.BadRequest, $"The ids '{id}' and '{pet?.id}' don't match")); //ids don't match

            PetDTO? existingPet = _petService.GetPet(id);
            if (existingPet == null) return NotFound(new ErrorDetailsDTO((int)HttpStatusCode.NotFound, $"Record with id '{id}' was not found")); //record doesn't exist

            PetDTO? result = _petService.PutPet(pet);
            if (result == null) return Conflict(new ErrorDetailsDTO((int)HttpStatusCode.Conflict, "Error creating record")); //couldn't create record
            return result;
        }

        [HttpDelete("pet")]
        public ActionResult<PetDTO?> DeleleById(int id)
        {
            PetDTO? existingPet = _petService.GetPet(id);
            if (existingPet == null) return NotFound(new ErrorDetailsDTO((int)HttpStatusCode.NotFound, $"Record with id '{id}' was not found")); //record doesn't exist

            PetDTO? result = _petService.DeletePet(id);
            return result;
        }
    }
}
