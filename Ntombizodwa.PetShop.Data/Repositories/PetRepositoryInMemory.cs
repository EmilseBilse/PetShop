using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;

namespace Ntombizodwa.PetShop.Data.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private List<Pet> PetList = new List<Pet>();
        private List<PetType> PetTypes = new List<PetType>();
        
        private static int Id = 1;
        public List<Pet> FindAll()
        {
            return PetList;
        }

        public Pet Add(Pet pet)
        {
            pet.Id++;
            PetList.Add(pet);
            return pet;
        }

        public List<PetType> GetAllPetTypes()
        {
            PetType cat = new PetType
            {
                Id = 1,
                Name = "Cat"
            };
            PetType dog = new PetType
            {
                Id = 2,
                Name = "Dog"
            };
            PetType goat = new PetType
            {
                Id = 3,
                Name = "Goat"
            };

            PetTypes.AddRange(new List<PetType>
            {
                cat,dog,goat
            });
            return PetTypes;
        }
    }
}