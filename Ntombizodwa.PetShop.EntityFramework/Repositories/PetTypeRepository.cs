using System.Collections.Generic;
using System.Linq;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;
using Ntombizodwa.PetShop.EntityFramework.Entities;

namespace Ntombizodwa.PetShop.EntityFramework.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly PetShopDbContext _ctx;

        public PetTypeRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<PetType> GetAllPetTypes()
        {
            return _ctx.PetTypes.Select(e => new PetType
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
        }

        public PetType GetTypeFromId(int id)
        {
            return _ctx.PetTypes.Select(tpe => new PetType
            {
                Id = tpe.Id,
                Name = tpe.Name
            }).FirstOrDefault(petType => petType.Id == id);
        }

        public PetType deletePetType(int id)
        {
            PetTypeEntity e = _ctx.PetTypes.Remove(new PetTypeEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new PetType
            {
                Id = e.Id,
                Name = e.Name
            };
        }
    }
}