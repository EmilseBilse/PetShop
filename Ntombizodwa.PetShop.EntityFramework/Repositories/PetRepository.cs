using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;
using Ntombizodwa.PetShop.EntityFramework.Entities;

namespace Ntombizodwa.PetShop.EntityFramework.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopDbContext _ctx;
        public PetRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Pet> FindAll()
        {
            return _ctx.Pets
                .Include(pet => pet.Insurance)
                .Include(pet => pet.Owner)
                .Include(pet => pet.PetType)
                .Select(petEntity => new Pet
                {
                    Id = petEntity.Id,
                    Name = petEntity.Name,
                    Color = petEntity.Color,
                    Birthday = petEntity.BirthDate,
                    SoldDate = petEntity.SoldDate,
                    Price = petEntity.Price,
                    Insurance = new Insurance
                    {
                        Id = petEntity.Insurance.Id,
                        Name = petEntity.Insurance.Name
                    },
                    Owner = new Owner
                    {
                        Id = petEntity.Owner.Id,
                        Name = petEntity.Owner.Name
                    },
                    PetType = new PetType
                    {
                        Id = petEntity.PetType.Id,
                        Name = petEntity.PetType.Name
                    }
                }).ToList();
        }

        public Pet Add(Pet pet)
        {
            PetEntity entity = _ctx.Add(new PetEntity
            {
                Id = pet.Id,
                Name = pet.Name,
                Color = pet.Color,
                BirthDate = pet.Birthday,
                SoldDate = pet.SoldDate,
                PetTypeId = pet.PetType.Id,
                OwnerId = pet.Owner.Id,
                InsuranceId = pet.Insurance.Id,
                Price = pet.Price
            }).Entity;

            _ctx.SaveChanges();

            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                Color = entity.Color,
                Birthday = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Price = entity.Price
            };
        }

        public void Remove(int id)
        {
            PetEntity entity = _ctx.Pets.Remove(new PetEntity {Id = id}).Entity;
            _ctx.SaveChanges();
        }

        public Pet GetPetFromId(int id)
        {
            return _ctx.Pets
                .Select(pet => new Pet
                {
                    Id = pet.Id,
                    Name = pet.Name
                }).FirstOrDefault(pet => pet.Id == id);
        }

        public void UpdatePetId(int oldId, int newId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetName(int id, string newName)
        {
            throw new NotImplementedException();
        }

        public bool DoesIdExist(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetType(int petId, PetType newType)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetBirthday(int petId, DateTime newBirthday)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetSoldDate(int petId, DateTime newSoldDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateColor(int petId, string newColor)
        {
            throw new NotImplementedException();
        }

        public void UpdatePrice(int id, double newPrice)
        {
            throw new NotImplementedException();
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            throw new NotImplementedException();
        }

        public List<Pet> SortPetsByPriceList()
        {
            throw new NotImplementedException();
        }
    }
}