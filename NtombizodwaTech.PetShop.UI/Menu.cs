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
                }else if (choice == 3)
                {
                    SearchOnType();
                }else if (choice == 4)
                {
                    DeletePet();
                }else if (choice == 5)
                {
                    UpdatePet();
                }
            }
        }

        private void UpdatePet()
        {
            PrintAllPets();
            Print(StringConstants.SelectTheIdOfThePetToUpdate);
            Print(StringConstants.SelectZeroToCancel);
            int id = GetChoiceId();
            Pet updatePet = _service.GetPetFromId(id);
            Print($"ID: {updatePet.Id} | Name: {updatePet.Name} | Type: {updatePet.Type.Name} | Birthday: {updatePet.Birthday} | SoldDate: {updatePet.SoldDate} | Color: {updatePet.Color} | Price: {updatePet.Price}");
            Print(StringConstants.SelectWhatToUpdate);
            Print(StringConstants.UpdateChoices);
            int updateChoice = GetChoiceIdUpdate();
            switch (updateChoice)
            {
                case 1: //ID
                    //_service.Remove(updatePet.Id.Value);
                    // check if input id already exist
                    break;
                case 2: //Name
                    break;
                case 3: //Type
                    break;
                case 4: //Birthday
                    break;
                case 5: //SoldDate
                    break;
                case 6: // Color
                    break;
                case 7: //Price
                    break;
                default:
                    break;
            }
        }

        private int GetChoiceIdUpdate()
        {
            string idString = Console.ReadLine();
            int idInt;
            while (!int.TryParse(idString,out idInt) || idInt is < 0 or >= 7)
            {
                Print(StringConstants.InvalidInputType);
                idString = Console.ReadLine();
            }

            return idInt;
        }

        private int GetChoiceId()
        {
            string idString = Console.ReadLine();
            int idInt;
            while (!int.TryParse(idString,out idInt) || idInt < 0)
            {
                Print(StringConstants.InvalidInputType);
                idString = Console.ReadLine();
            }

            return idInt;
        }

        private void DeletePet()
        {
            PrintAllPets();
            Print(StringConstants.SelectTheIdOfThePetToRemove);
            Print(StringConstants.SelectZeroToCancel);
            int id = GetChoiceId();
            if (id != 0)
            {
                _service.Remove(id);
            }
        }

        private void SearchOnType()
        {
            Print(StringConstants.SearchTypeMenuText);
            SeeAllPetTypes();
            string petType = Console.ReadLine();
            int typeSelection;
            while (!int.TryParse(petType,out typeSelection) || typeSelection > _typeService.GetAllPetTypes().Count)
            {
                Print(StringConstants.InvalidInputType);
                petType = Console.ReadLine();
            }
            List<Pet> petsList = _service.GetPets();
            foreach (Pet pet in petsList)
            {
                if (typeSelection == pet.Type.Id)
                {
                    Print($"ID: {pet.Id} | Name: {pet.Name} | Type: {pet.Type.Name} | Birthday: {pet.Birthday} | SoldDate: {pet.SoldDate} | Color: {pet.Color} | Price: {pet.Price}");
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
            Print(StringConstants.SearchPetsOnTypeText);
            Print(StringConstants.DeleteMenuText);
            Print(StringConstants.UpdatePetMenuText);
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