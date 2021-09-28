using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.Core.IServices
{
    public interface IOwnerService
    {
        public List<Owner> GetOwners();
        public Owner GetOwnerFromId(int id);
        public Owner CreateOwner(Owner owner);
        public Owner UpdateOwner(int id, string name);
        public void RemoveOwner(int id);
        public Owner GetById(int id);

    }
}