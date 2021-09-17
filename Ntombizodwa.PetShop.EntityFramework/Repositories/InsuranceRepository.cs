using System.Collections.Generic;
using System.Linq;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;
using Ntombizodwa.PetShop.EntityFramework.Entities;

namespace Ntombizodwa.PetShop.EntityFramework.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly PetShopDbContext _ctx;

        public InsuranceRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public Insurance GetById(int id)
        {
            return _ctx.Insurances.Select(ie => new Insurance
            {
                Id = ie.Id,
                Name = ie.Name,
                Price = ie.Price
            })
                .FirstOrDefault(insurance => insurance.Id == id);
        }

        public List<Insurance> ReadAll()
        {
            return _ctx.Insurances.Select(ie => new Insurance
            {
                Id = ie.Id,
                Name = ie.Name,
                Price = ie.Price
            })
                //.Take(50)       for at lave flere sider med 50 på hver side så programmet ikke bliver for langsom
                .ToList();
        }

        public Insurance Create(Insurance insurance)
        {
            var entity = _ctx.Add(new InsuranceEntity
            {
                Name = insurance.Name,
                Price = insurance.Price
            }).Entity;
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }
    }
}