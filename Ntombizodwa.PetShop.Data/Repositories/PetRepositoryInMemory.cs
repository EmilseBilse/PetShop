using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;

namespace Ntombizodwa.PetShop.Data.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private readonly List<Pet> _petList = new List<Pet>();

        private static int _id = 1;
        public List<Pet> FindAll()
        {
            return _petList;
        }

        public Pet Add(Pet pet)
        {
            pet.Id = _id++;
            _petList.Add(pet);
            return pet;
        }
        

        public void Remove(int id)
        {
            _petList.Remove(GetPetFromId(id));
            //FixId();
        }

        public Pet GetPetFromId(int id)
        {
            foreach (Pet pet in _petList)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet AddPetWithId(Pet pet)
        {
            _petList.Add(pet);
            return pet;
        }

        private void FixId()
        {
            if ((_id + 1) > _petList.Count)
            {
                _id = _petList.Count;
            }
        }
    }
}