using NewWebAPI.Entitys;

namespace NewWebAPI.Context
{
    public class PetContextSeed
    {
        public static void SeedDatabase(PetContext petContext)
        {
            if (!petContext.Pets.Any())
            {
                var pets = new List<PetEntity>()
                {
                    new PetEntity { id = 1, name = "Pantufa", description = "Descrição 1" },
                    new PetEntity { id = 2, name = "Kika", description = "Descrição 2" },
                    new PetEntity { id = 3, name = "Zacarias", description = "Descrição 3" }
                };
                petContext.Pets.AddRange(pets);
                petContext.SaveChanges();
            }
        }
    }
}
