using System;
using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        List<Pet> FindAll();
        Pet Add(Pet pet);
        void Remove(int id);
        Pet GetPetFromId(int id);
        void UpdatePetId(int oldId, int newId);
        void UpdatePetName(int id, string newName);
        bool DoesIdExist(int id);
        void UpdatePetType(int petId, PetType newType);
        void UpdatePetBirthday(int petId, DateTime newBirthday);
        void UpdatePetSoldDate(int petId, DateTime newSoldDate);
        void UpdateColor(int petId, string newColor);
        void UpdatePrice(int id, double newPrice);
    }
}