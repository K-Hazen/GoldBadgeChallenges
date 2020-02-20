using BadgesKomodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesKomodoUI
{
    public class BadgesKomodoUI
    {
        private readonly BadgeRepo _repoBadge = new BadgeRepo();

        public void Run()
        {
            SeedContent();
            RunBadges();
        }

        private void RunBadges()
        {
            bool isBadgesRunning = true;

            while (isBadgesRunning)
            {
                Console.Clear();

                Console.WriteLine("Weclome to Blazing Saddles Badge Access Portal");
                Console.WriteLine("Pick an option by choosing a number:\n " +
                    "1. Add a Badge\n " +
                    "2. Edit a Badge Access\n " +
                    "3. List all Badges");
               
                string badgeMakerInput = Console.ReadLine ();
                badgeMakerInput = badgeMakerInput.Replace(" ", "");

                switch (badgeMakerInput)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        UpdateBadgeAccess();
                        break;
                    case "3":
                        SeeAllBadges();
                        break;
                    case "4":
                        isBadgesRunning = false; 
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddNewBadge()
        {
            BadgeClass content = new BadgeClass();

            bool isAddFunctionRunning = true;

                Console.WriteLine("What is the number on the badge?");
                content.BadgeID = int.Parse(Console.ReadLine());

            while (isAddFunctionRunning)
            {
                Console.Clear();
                Console.WriteLine("List a door user needs access to");
                content.ListOfDoors.Add(Console.ReadLine());

                Console.WriteLine("Are there any other doors user needs access to? y/n");
                char addMore = char.Parse(Console.ReadLine().ToLower());

                if(addMore == 'y')
                {
                    isAddFunctionRunning = true;
                }
                else
                {
                    isAddFunctionRunning = false; 
                }
            }
            _repoBadge.AddBadgeToDictionary(content);
            Console.WriteLine("Your badge has been added!");

            Console.WriteLine("Press any key to return to start menu");
            Console.ReadKey();    
        }

        private void UpdateBadgeAccess()
        {
            Console.Clear();

            Console.WriteLine("What is the badge number you would like to update?");
            int badgeIDToUpdate = Convert.ToInt32(Console.ReadLine());

            Dictionary<int, List<string>> accessListToUpdate = _repoBadge.GetAllBadges();

            if (accessListToUpdate.ContainsKey(badgeIDToUpdate))
            {
                List<string> badgeIDValue = _repoBadge.GetRoomAccessList(badgeIDToUpdate);

               
                string displayAccessDoors = "";
                foreach(string indexValue in badgeIDValue)  //badgeIDValue.ForEach(delegate (string displayAccessDoors) could be used as a foreach loop
                {
                    displayAccessDoors = indexValue + ", " + displayAccessDoors; 
                }
                
                Console.WriteLine($"Badge ID {badgeIDToUpdate} has access to {displayAccessDoors}");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?\n" +
                    "1. Remove Door Access\n" +
                    "2. Add Door Access\n" +
                    "3. Remove All Access Doors");
                int addOrDelete = Convert.ToInt32(Console.ReadLine());

                if(addOrDelete == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Which door would you like to remove access to?");
                    string removeDoor = Console.ReadLine();

                    _repoBadge.DeleteRoomAccessTwo(badgeIDToUpdate, removeDoor);

                    Console.WriteLine("Your door access has been removed\n" +
                        "Press any key to continue...");
                    Console.ReadKey();

                }
                else if (addOrDelete == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Which door would you like to add access for?");
                    string doorToAdd = Console.ReadLine();

                    _repoBadge.AddRoomAccessTwo(badgeIDToUpdate, doorToAdd);
                    
                    Console.WriteLine("Your door access has been added\n" +
                      "Press any key to continue...");
                    Console.ReadKey();
                }
                else if(addOrDelete == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Would you like to clear all access for badge #: {badgeIDToUpdate}\n"+
                        $"Input Y/N");
                    char clearAllCommand = char.Parse(Console.ReadLine().ToLower());
                    
                    if (clearAllCommand == 'y')
                    {
                        _repoBadge.DeleteAllRoomAccess(badgeIDToUpdate);

                        Console.WriteLine("Badges...We don't need no stinking badges!!! Your access has been deleted\n" +
                     "Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You have chosen 'N' or entered a value not recognized\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Your choice was not recognized.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Badge number was not found...\n" +
                    "Press any key to continue");
                Console.ReadKey();
            }

        }
        
        private void SeeAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> listOfBadges = _repoBadge.GetAllBadges();

            foreach(KeyValuePair<int, List<string>> dictionaryEntry in listOfBadges)
            {
                string accessList = "";
                foreach(string accessDoor in dictionaryEntry.Value)
                {
                    accessList = accessDoor + ", " + accessList; 
                }
               
                Console.WriteLine($"Badge ID: {dictionaryEntry.Key}\n" +
                    $"Door Access: {accessList}");
                Console.WriteLine();
            }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
        }

        private void SeedContent()
        {
            List<string> badgeOneAccess = new List<string>() { "A4", "B2", "A8" };
            List<string> badgeTwoAccess = new List<string>() { "A1", "C4" };
            List<string> badgeThreeAccess = new List<string>() { "A4", "C4", "A2", "A8" };

            BadgeClass badgeOne = new BadgeClass(1892, badgeOneAccess);
            _repoBadge.AddBadgeToDictionary(badgeOne);

            BadgeClass badgeTwo = new BadgeClass(8675309, badgeTwoAccess);
            _repoBadge.AddBadgeToDictionary(badgeTwo);

            BadgeClass badgeThree = new BadgeClass(812875, badgeThreeAccess);
            _repoBadge.AddBadgeToDictionary(badgeThree);



        }
    }
}
