using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.IServices;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;

namespace Ntombizodwa.PetShop.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _repo;

        public PetTypeService(IPetTypeRepository repo)
        {
            _repo = repo;
        }

        public List<PetType> GetAllPetTypes()
        {
            return _repo.GetAllPetTypes();
        }

        public PetType GetTypeFromId(int id)
        {
            return _repo.GetTypeFromId(id);
        }
    }
}