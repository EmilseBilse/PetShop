using System;
using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.IServices;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;

namespace NtombizodwaTech.PetShop.UI
{
    public class Menu
    {
        private IPetService _service;
        private IPetTypeService _typeService;
        public Menu(IPetService service, IPetTypeService petTypeService)
        {
            _service = service;
            _typeService = petTypeService;
        }
        public void Start()
        {
            ShowWelcomeGreeting();
            StartLoop();
        }

        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                    PrintAllPets();
                }else if (choice == 2)
                {
                    CreatePet();
                }
            }
        }

        private void SeeAllPetTypes()
        {
            List<PetType> petTypes = _typeService.GetAllPetTypes();
            foreach (PetType p in petTypes)
            {
                Print($"ID: {p.Id} | {p.Name}");
            }
        }
        
        private void CreatePet()
        {
            //Greeting
            Print(StringConstants.CreatePetGreeting);
            //Name
            Print(StringConstants.PetName);
            string petName = Console.ReadLine();
            //Type
            Print(StringConstants.SelectPetType);
            SeeAllPetTypes();
            string petType = Console.ReadLine();
            int typeSelection;
            while (!int.TryParse(petType,out typeSelection) || typeSelection > _typeService.GetAllPetTypes().Count)
            {
                Print(StringConstants.InvalidInputType);
                petType = Console.ReadLine();
            }
            //BirthDay
            Print(StringConstants.SelectTheBirthday);
            string birthDayInput = Console.ReadLine();
            DateTime birthDay;
            while (!DateTime.TryParse(birthDayInput, out birthDay))
            {
                Print(StringConstants.InvalidInputBirthDay);
                birthDayInput = Console.ReadLine();
            }
            //Sold Date
            Print(StringConstants.SoldDateText);
            string soldDayInput = Console.ReadLine();
            DateTime soldDay;
            while (!DateTime.TryParse(soldDayInput, out soldDay))
            {
                Print(StringConstants.InValidInputSoldDate);
                soldDayInput = Console.ReadLine();
            }
            //Color
            Print(StringConstants.ColorOfPetText);
            string petColor = Console.ReadLine();
            //Price
            Print(StringConstants.PriceOfPetText);
            string priceInput = Console.ReadLine();
            double price;
            while (!double.TryParse(priceInput, out price) || price < 0)
            {
                Print(StringConstants.InvalidInputPrice);
                priceInput = Console.ReadLine();
            }

            Pet pet = new Pet
            {
                Name = petName,
                Type = _typeService.GetTypeFromId(typeSelection),
                Birthday = birthDay,
                SoldDate = soldDay,
                Color = petColor,
                Price = price
            };
            pet = _service.Create(pet);
            Print($"Pet created with the following properties: ID: {pet.Id} | Name: {pet.Name} | Type: {pet.Type.Name} | Birthday: {pet.Birthday} | SoldDate: {pet.SoldDate} | Color: {pet.Color} | Price: {pet.Price}");
            Print("");
        }

        private void PrintAllPets()
        {
            foreach (Pet pet in _service.GetPets())
            {
                Print($"ID: {pet.Id} | Name: {pet.Name} | Type: {pet.Type.Name} | Birthday: {pet.Birthday} | SoldDate: {pet.SoldDate} | Color: {pet.Color} | Price: {pet.Price}");
            }
        }

        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            Print("");
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }

        private void ShowMainMenu()
        {
            Print("");
            Print(StringConstants.PrintAllPetsMenuText);
            Print(StringConstants.CreatePetMenuText);
            Print(StringConstants.ExitMenuText);
        }

        private void ShowWelcomeGreeting()
        {
            Console.WriteLine(StringConstants.WelcomeGreeting);
            Print("");
        }

        private void Print(string str)
        {
            Console.WriteLine(str);
        }
        
    }
}