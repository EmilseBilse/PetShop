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
            InsuranceEntity entity = _ctx.Add(new InsuranceEntity
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

        public Insurance Remove(int id)
        {
             InsuranceEntity toRemove = _ctx.Insurances.Single(ie => ie.Id == id);
             _ctx.Remove(toRemove);
             _ctx.SaveChanges();
             Insurance modelValue = new Insurance
             {
                 Id = toRemove.Id,
                 Name = toRemove.Name,
                 Price = toRemove.Price
             };
             return modelValue;

             /*InsuranceEntity entity = _ctx.Remove(new InsuranceEntity {Id = id}).Entity;   //virker også
             _ctx.SaveChanges();
             return new Insurance
             {
                 Id = entity.Id,
                 Name = entity.Name,
                 Price = entity.Price
             };
             */
        }

        public Insurance Update(Insurance insurance)
        {
            InsuranceEntity insuranceEntity = new InsuranceEntity
            {
                Id = insurance.Id,
                Name = insurance.Name,
                Price = insurance.Price
            };
            InsuranceEntity entity = _ctx.Update(insuranceEntity).Entity;
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