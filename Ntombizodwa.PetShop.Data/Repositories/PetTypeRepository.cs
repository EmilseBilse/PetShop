using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;

namespace Ntombizodwa.PetShop.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private static List<PetType> _petTypesTable = new List<PetType>();

        public PetTypeRepository()
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

            _petTypesTable.AddRange(new List<PetType>
            {
                cat,dog,goat
            });
        }
        
        public List<PetType> GetAllPetTypes()
        {
            return _petTypesTable;
        }

        public PetType GetTypeFromId(int id)
        {
            foreach (PetType t in _petTypesTable)
            {
                if (t.Id == id)
                {
                    return t;
                }
            }
            return null;
        }

        public PetType deletePetType(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}