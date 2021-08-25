using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        List<Pet> FindAll();
        Pet Add(Pet pet);
        List<PetType> GetAllPetTypes();
    }
}