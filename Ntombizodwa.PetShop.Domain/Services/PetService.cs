using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ntombizodwa.PetShop.Core.Filtering;
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

        public int TotalCount()
        {
            return _repo.TotalCount();
        }

        public List<Pet> GetPets(Filter filter)
        {
            if (filter is not {Limit: > 0} || filter.Limit > 100)
            {
                throw new ArgumentException("Filter limit must be between 1 and 100");
            }

            int totalCount = TotalCount();
            double maxPageCount = Math.Ceiling((double)totalCount / filter.Limit);
            if (filter.Page < 1 || filter.Page > maxPageCount)
            {
                throw new ArgumentException("Page must be above 0");
            }
            return _repo.FindAll(filter);
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
            if (id <= 0)
            {
                throw new InvalidDataException($"Id must be above zero. Your value is: {id}");
            }
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

        public List<Pet> SortPetsByPriceList()
        {
            List<Pet> notSortedList = _repo.SortPetsByPriceList();
            List<Pet> returnList = notSortedList.OrderBy(o => o.Price).ToList();
            return returnList;
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}