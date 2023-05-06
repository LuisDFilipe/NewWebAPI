using NewWebAPI.Context;
using NewWebAPI.Entitys;
using System.Net;

namespace NewWebAPI.Repositorys
{
    public class PetRepository : IPetRepository
    {
        private readonly PetContext _context;

        public PetRepository(PetContext context)
        {
            _context = context;
        }

        public IEnumerable<PetEntity?> GetAll()
        {
            return _context.Pets.ToList();
        }

        public PetEntity? GetById(int id)
        {
            try
            {
                return _context.Pets.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PetEntity? Post(PetEntity? pet)
        {
            try
            {
                _context.Pets.Add(pet);
                _context.SaveChanges();
                return pet;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PetEntity? Put(PetEntity? pet)
        {
            try
            {
                PetEntity? dbPet = _context.Pets.Find(pet?.id);
                if (dbPet == null) return null;

                dbPet.name = pet.name;
                dbPet.description = pet.description;

                _context.SaveChanges();

                return dbPet;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PetEntity? DeleteById(int id)
        {
            PetEntity? dbPet = _context.Pets.Find(id);
            if (dbPet == null) return null;

            try
            {
                _context.Pets.Remove(dbPet);
                _context.SaveChanges();
                return dbPet;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
