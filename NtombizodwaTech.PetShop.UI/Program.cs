using System;
using Ntombizodwa.PetShop.Core.IServices;
using Ntombizodwa.PetShop.Data.Repositories;
using Ntombizodwa.PetShop.Domain.IRepositories;
using Ntombizodwa.PetShop.Domain.Services;

namespace NtombizodwaTech.PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetRepository petRepo = new PetRepositoryInMemory();
            IPetTypeRepository petTypeRepo = new PetTypeRepository();
            
            IPetService service = new PetService(petRepo);
            IPetTypeService pTypeService = new PetTypeService(petTypeRepo);
            
            Menu menu = new Menu(service, pTypeService);
            menu.Start();
        }
    }
}