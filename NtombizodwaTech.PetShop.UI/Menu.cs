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
                    Print(StringConstants.TypeNewId);
                    int newId = ReturnValidId();
                    _service.UpdatePetId(updatePet.Id.Value,newId);
                    break;
                case 2: //Name
                    Print(StringConstants.TypeNewName);
                    string newName = Console.ReadLine();
                    _service.UpdatePetName(updatePet.Id.Value,newName);
                    break;
                case 3: //Type
                    Print(StringConstants.SelectNewPetType);
                    SeeAllPetTypes();
                    int newTypeId = GetPetTypeFromUser();
                    PetType newPetType = _typeService.GetTypeFromId(newTypeId);
                    _service.UpdatePetType(updatePet.Id.Value,newPetType);
                    break;
                case 4: //Birthday
                    Print(StringConstants.SelectNewBirthday);
                    DateTime newBirthDay = GetValidDate();
                    _service.UpdatePetBirthday(updatePet.Id.Value,newBirthDay);
                    break;
                case 5: //SoldDate
                    Print(StringConstants.SelectNewSoldDate);
                    DateTime newSoldDate = GetValidDate();
                    _service.UpdatePetSoldDate(updatePet.Id.Value, newSoldDate);
                    break;
                case 6: // Color
                    Print(StringConstants.SelectNewColor);
                    string newColor = Console.ReadLine();
                    _service.UpdateColor(updatePet.Id.Value,newColor);
                    break;
                case 7: //Price
                    Print(StringConstants.SelectNewPrice);
                    double newPrice = GetValidPriceFromUser();
                    _service.UpdatePrice(updatePet.Id.Value,newPrice);
                    break;
            }
        }

        private DateTime GetValidDate()
        {
            string dayInput = Console.ReadLine();
            DateTime validDate;
            while (!DateTime.TryParse(dayInput, out validDate))
            {
                Print(StringConstants.InvalidInputDay);
                dayInput = Console.ReadLine();
            }

            return validDate;
        }

        private int GetChoiceIdUpdate()
        {
            string idString = Console.ReadLine();
            int idInt;
            while (!int.TryParse(idString,out idInt) || idInt is < 0 or > 8)
            {
                Print(StringConstants.InvalidInputType);
                idString = Console.ReadLine();
            }

            return idInt;
        }
        
        private int ReturnValidId()
        {
            string idString = Console.ReadLine();
            int idInt;
            while (!int.TryParse(idString,out idInt) || idInt < 0)
            {
                bool doesIdExist = _service.DoesIdExist(idInt);
                if (doesIdExist)
                {
                    Print(StringConstants.ThisIdAlreadyExists);
                    idString = Console.ReadLine();
                }
                else
                {
                    Print(StringConstants.InvalidInputType);
                    idString = Console.ReadLine();
                }
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

        private int GetPetTypeFromUser()
        {
            string petType = Console.ReadLine();
            int typeSelection;
            while (!int.TryParse(petType,out typeSelection) || typeSelection > _typeService.GetAllPetTypes().Count)
            {
                Print(StringConstants.InvalidInputType);
                petType = Console.ReadLine();
            }

            return typeSelection;
        }
        
        private void SearchOnType()
        {
            Print(StringConstants.SearchTypeMenuText);
            SeeAllPetTypes();
            int typeSelection = GetPetTypeFromUser();
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

        private double GetValidPriceFromUser()
        {
            string priceInput = Console.ReadLine();
            double price;
            while (!double.TryParse(priceInput, out price) || price < 0)
            {
                Print(StringConstants.InvalidInputPrice);
                priceInput = Console.ReadLine();
            }

            return price;
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
            DateTime birthDay = GetValidDate();
            //Sold Date
            Print(StringConstants.SoldDateText);
            DateTime soldDay = GetValidDate();
            //Color
            Print(StringConstants.ColorOfPetText);
            string petColor = Console.ReadLine();
            //Price
            Print(StringConstants.PriceOfPetText);
            double price = GetValidPriceFromUser();

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