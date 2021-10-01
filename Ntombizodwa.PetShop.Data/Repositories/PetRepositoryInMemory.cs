using System;
using System.Collections.Generic;
using System.Linq;
using Ntombizodwa.PetShop.Core.Filtering;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;

namespace Ntombizodwa.PetShop.Data.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private static readonly List<Pet> _petList = new List<Pet>();

        private static int _id = 1;
        public List<Pet> FindAll()
        {
            return _petList;
        }

        public List<Pet> FindAll(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Pet Add(Pet pet)
        {
            pet.Id = _id++;
            _petList.Add(pet);
            return pet;
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            throw new NotImplementedException();
        }

        public List<Pet> SortPetsByPriceList()
        {
            List<Pet> tempList = _petList;
            return tempList;
        }

        public int TotalCount()
        {
            throw new NotImplementedException();
        }


        public void Remove(int id)
        {
            _petList.Remove(GetPetFromId(id));
            //FixId();
        }

        public Pet GetPetFromId(int id)
        {
            /*foreach (Pet pet in _petList)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            */

            Pet pet = _petList.FirstOrDefault(pet => pet.Id == id);
            return pet;
        }

        public void UpdatePetType(int petId, PetType newType)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetBirthday(int petId, DateTime newBirthday)
        {
            foreach (Pet p in _petList)
            {
                if (p.Id == petId)
                {
                    p.Birthday = newBirthday;
                }
            }
        }

        public void UpdatePrice(int id, double newPrice)
        {
            foreach (var p in _petList)
            {
                if (p.Id == id)
                {
                    p.Price = newPrice;
                }
            }
        }
        
        public void UpdateColor(int petId, string newColor)
        {
            foreach (var p in _petList)
            {
                if (p.Id == petId)
                {
                    p.Color = newColor;
                }
            }
        }
        
        public void UpdatePetSoldDate(int petId, DateTime newSoldDate)
        {
            foreach (Pet p in _petList)
            {
                if (p.Id == petId)
                {
                    p.SoldDate = newSoldDate;
                }
            }
        }

        /*public void UpdatePetType(int petId, PetType newType)
        {
            foreach (var p in _petList)
            {
                if (p.Id == petId)
                {
                    p.Type = newType;
                }
            }
        }*/

        public void UpdatePetName(int id, string newName)
        {
            foreach (Pet p in _petList)
            {
                if (p.Id == id)
                {
                    p.Name = newName;
                }
            }
        }
        
        public void UpdatePetId(int oldId, int newId)
        {
            foreach (Pet p in _petList)
            {
                if (p.Id == oldId)
                {
                    p.Id = newId;
                }
            }
        }

        public bool DoesIdExist(int id)
        {
            foreach (Pet p in _petList)
            {
                if (p.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public Pet UpdateFulllPet(Pet pet)
        {
            //_petList = _petList.Where(p => p.Id != p.Id.ToList());
            return null;
        }
        
    }
}