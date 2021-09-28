using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.IServices;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;

namespace Ntombizodwa.PetShop.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadAllOwners();
        }

        public Owner GetOwnerFromId(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.CreateOwner(owner);
        }

        public Owner UpdateOwner(int id, string name)
        {
            return _ownerRepository.UpdateOwnerName(id,name);
        }

        public void RemoveOwner(int id)
        {
            _ownerRepository.DeleteOwner(id);
        }

        public Owner GetById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }
    }
}