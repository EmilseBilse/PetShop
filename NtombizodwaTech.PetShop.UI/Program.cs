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
            IPetService service = new PetService(repo);
            Menu menu = new Menu(service);
            menu.Start();
        }
    }
}