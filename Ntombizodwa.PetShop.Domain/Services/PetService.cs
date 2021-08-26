using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.IServices;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;

namespace Ntombizodwa.PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repo;
        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }

        public List<Pet> GetPets()
        {
            return _repo.FindAll();
        }

        public Pet Create(Pet pet)
        {
            return _repo.Add(pet);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Pet GetPetFromId(int id)
        {
            return _repo.GetPetFromId(id);
        }

        public Pet AddPetWithId(Pet pet)
        {
            return _repo.AddPetWithId(pet);
        }
    }
}