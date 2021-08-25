using System;
using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.IServices;
using Ntombizodwa.PetShop.Core.Models;

namespace NtombizodwaTech.PetShop.UI
{
    public class Menu
    {
        private IPetService _service;
        public Menu(IPetService service)
        {
            _service = service;
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
            List<PetType> petTypes = _service.GetAllPetTypes();
            foreach (PetType p in petTypes)
            {
                Print($"ID: {p.Id} | {p.Name}");
            }
        }
        
        private void CreatePet()
        {
            Print(StringConstants.CreatePetGreeting);
            Print(StringConstants.PetName);
            string PetName = Console.ReadLine();
            Print(StringConstants.SelectPetType);
            SeeAllPetTypes();
        }

        private void PrintAllPets()
        {
            foreach (Pet pet in _service.GetPets())
            {
                Print($"{pet.Id} {pet.Name} {pet.Type.Name} {pet.Birthday} {pet.SoldDate} {pet.Color} {pet.Price}");
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