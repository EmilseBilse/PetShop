using System;
using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.IServices;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;

namespace Ntombizodwa.PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repo;
        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }

        public List<Pet> GetPets()
        {
            return _repo.FindAll();
        }

        public Pet Create(Pet pet)
        {
            return _repo.Add(pet);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Pet GetPetFromId(int id)
        {
            return _repo.GetPetFromId(id);
        }

        public void UpdatePetId(int oldId, int newId)
        {
            _repo.UpdatePetId(oldId,newId);
        }

        public void UpdatePetName(int id, string newName)
        {
            _repo.UpdatePetName(id,newName);
        }

        public bool DoesIdExist(int id)
        {
            return _repo.DoesIdExist(id);
        }

        public void UpdatePetType(int petId, PetType newType)
        {
            _repo.UpdatePetType(petId,newType);
        }

        public void UpdatePetBirthday(int petId, DateTime newBirthday)
        {
            _repo.UpdatePetBirthday(petId,newBirthday);
        }

        public void UpdatePetSoldDate(int petId, DateTime newSoldDate)
        {
            _repo.UpdatePetSoldDate(petId,newSoldDate);
        }

        public void UpdateColor(int petId, string newColor)
        {
            _repo.UpdateColor(petId,newColor);
        }

        public void UpdatePrice(int id, double newPrice)
        {
            _repo.UpdatePrice(id,newPrice);
        }
    }
}