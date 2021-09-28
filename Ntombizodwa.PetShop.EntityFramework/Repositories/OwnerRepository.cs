using System.Collections.Generic;
using System.Linq;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;
using Ntombizodwa.PetShop.EntityFramework.Entities;

namespace Ntombizodwa.PetShop.EntityFramework.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetShopDbContext _ctx;

        public OwnerRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }


        public List<Owner> ReadAllOwners()
        {
            return _ctx.Owners.Select(entity => new Owner
            {
                Id = entity.Id,
                Name = entity.Name
            }).ToList();
        }

        public Owner CreateOwner(Owner owner)
        {
            OwnerEntity entity = _ctx.Add(new OwnerEntity
            {
                Id = owner.Id,
                Name = owner.Name
            }).Entity;

            _ctx.SaveChanges();

            return new Owner
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Owner UpdateOwnerName(int id, string name)
        {
            OwnerEntity entity = _ctx.Update(new OwnerEntity
            {
                Id = id,
                Name = name
            }).Entity;

            _ctx.SaveChanges();

            return new Owner
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Owner DeleteOwner(int id)
        {
            OwnerEntity entity = _ctx.Owners.Remove(new OwnerEntity {Id = id}).Entity;
            _ctx.SaveChanges();

            return new Owner
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Owner GetOwnerById(int id)
        {
            return _ctx.Owners.Select(entity => new Owner
            {
                Id = entity.Id,
                Name = entity.Name
            }).FirstOrDefault(owner => owner.Id == id);
        }
    }
}