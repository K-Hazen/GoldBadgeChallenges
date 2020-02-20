using CafeKomodo;
using System;
using System.Collections.Generic;

namespace KomodoCafeUI
{
    public class CafeKomodoUI
    {
        private readonly CafeKomodoRepo _komodoRepo = new CafeKomodoRepo();

        private IConsole _console;

        public CafeKomodoUI(IConsole console)
        {
            _console = console; 
        }

        public void Run()
        {
            SeedItems();
            RunMenu();

        }

        private void RunMenu()
        {

            bool isKomodoRunning = true;

            while (isKomodoRunning)
            {
                Console.Clear();
                Console.WriteLine("Select a number to get started! \n" +
                    "1. Add Menu Item \n" +
                    "2. Delete Menu Item \n" +
                    "3. View Entire Menu");

                string managerInput = Console.ReadLine();
                managerInput = managerInput.Replace(" ", ""); //what is this doing? 

                switch (managerInput)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ShowAllMenuItems();
                        break;
                    default:
                        break;
                }

            }

        }

        private void AddNewMenuItem()
        {
            MenuClass itemContent = new MenuClass();
            Console.WriteLine("Enter Meal Number");

            itemContent.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Now, enter the meal's Name.");
            itemContent.MealName = Console.ReadLine();

            Console.WriteLine("Now, enter a description of the meal.");
            itemContent.MealDescription = Console.ReadLine();

            Console.WriteLine("Now, enter the list of ingrediants."); 
            itemContent.IndgredientList.Add(Console.ReadLine());

            Console.WriteLine("You are doing so good! Last step, enter price.");
            itemContent.MealPrice = decimal.Parse(Console.ReadLine());

            _komodoRepo.AddItemsToMenu(itemContent);

            Console.WriteLine("Your item has been added! Prese any key to return to the main menu.");
            Console.ReadKey();

        }

        private void ShowAllMenuItems()
        {
            Console.Clear();

            List<MenuClass> fullMenu = _komodoRepo.GetAllMenuItems(); //calling to the method in the repo

            foreach (MenuClass item in fullMenu)
            {
                // have to declare variable but needs to match type of the list, then call the class (item) then use "." operator to access list
                string ingredientList = "";
                foreach (string ingredient in item.IndgredientList) 
                {
                    ingredientList = ingredient + " " + ingredientList; //use ingredientList on both sides to be able to then add the next item to the list without writing over the first item 
                }
                    
                Console.WriteLine($"Meal Number: {item.MealNumber} \n" +
                $"Meal Name: {item.MealName} \n" +
                $"Meal Description: {item.MealDescription} \n" +
                $"Ingredients: {ingredientList} \n" +
                $"Meal Price:{item.MealPrice}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void DeleteMenuItem()
        {
            Console.WriteLine("Enter Meal Name");
            string mealToRemove = Console.ReadLine();

            MenuClass existingItem = _komodoRepo.GetMealName(mealToRemove);

            if (existingItem == null)
            {
                Console.WriteLine("Their is no item by that name. \n" +
                    "Press any key to continue");
                Console.ReadKey();

            }
            else
            {
                _komodoRepo.DeleteMenuItem(mealToRemove);
            }

            Console.WriteLine("Your Menu Item has been deleted. \n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        //seed content 

        private void SeedItems()
        {
            List<string> billSando = new List<string>() { "Whole wheat bread, carved turkey, gravy, swiss cheese, bacon, lettuce, tomato, chips and a pickle" };

            MenuClass turkeySandwich = new MenuClass(1, "Bill's Turkey Sandwich", "The one and only way Bill will eat a turkey sando", billSando, 10.99m);

            _komodoRepo.AddItemsToMenu(turkeySandwich);

            List<string> infernoChili = new List<string>() { "Ground turkey, beans (all of them), red peppers, green peppers, orange peppers, chili spices, lots of cumin, and ghost peppers" };

            MenuClass chiliSoup = new MenuClass(2, "Inferno Chili", "If you're not tearing up we'll refund you", infernoChili, 9.99m);

            _komodoRepo.AddItemsToMenu(chiliSoup);

            List<string> burger = new List<string>() { "1 / 4 lb beef patty, pepper-jack cheese, served between a pretzel bun, lettuce, tomato, onion, pickles, A1 sausce " };

            MenuClass burgerKomodo = new MenuClass(3, "Komodo's Saucy Burger", "A one of a kind house special that can be described by words. It's that good! If it doesn't talk back get your server.", burger, 12.99m);

            _komodoRepo.AddItemsToMenu(burgerKomodo);
        }
    }
}


