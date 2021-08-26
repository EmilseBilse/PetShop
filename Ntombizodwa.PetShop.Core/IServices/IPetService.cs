using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetPets();
        Pet Create(Pet pet);
        void Remove(int id);
        Pet GetPetFromId(int id);
        Pet AddPetWithId(Pet pet);
    }
}