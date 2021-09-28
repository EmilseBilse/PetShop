using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        List<Owner> ReadAllOwners();

        Owner CreateOwner(Owner owner);

        Owner UpdateOwnerName(int id, string name);

        Owner DeleteOwner(int id);

        Owner GetOwnerById(int id);
    }
}