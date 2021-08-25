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
            IPetRepository repo = new PetRepositoryInMemory();
            IPetTypeRepository pTypeRepo = new PetTypeRepository();
            
            IPetService service = new PetService(repo);
            IPetTypeService pTypeService = new PetTypeService(pTypeRepo);
            
            Menu menu = new Menu(service, pTypeService);
            menu.Start();
        }
    }
}