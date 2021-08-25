using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> GetAllPetTypes();
        PetType GetTypeFromId(int Id);
    }
}