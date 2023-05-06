using NewWebAPI.Entitys;

namespace NewWebAPI.Repositorys
{
    public interface IPetRepository
    {
        IEnumerable<PetEntity?> GetAll();
        PetEntity? GetById(int id);
        PetEntity? Post(PetEntity? pet);
        PetEntity? Put(PetEntity? pet);
        PetEntity? DeleteById(int id);
    }
}
