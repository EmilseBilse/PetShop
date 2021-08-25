using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetPets();
        Pet Create(Pet pet);
        List<PetType> GetAllPetTypes();
    }
}