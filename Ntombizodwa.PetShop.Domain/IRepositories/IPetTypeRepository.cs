using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        List<PetType> GetAllPetTypes();
        PetType GetTypeFromId(int id);
        PetType deletePetType(int id);
    }
}