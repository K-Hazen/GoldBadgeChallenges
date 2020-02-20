using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKomodo
{
    public class CafeKomodoRepo
    {
        //Create

        protected readonly List<MenuClass> _menuDirectory = new List<MenuClass>();

        public bool AddItemsToMenu(MenuClass meal)
        {
            int menuLength = _menuDirectory.Count();
            _menuDirectory.Add(meal);
            bool wasContentAdded = menuLength + 1 == _menuDirectory.Count();
            return wasContentAdded; 

        }
       
        //Read - Get 

        //This populates the    
        public List<MenuClass> GetAllMenuItems()
        {
            return _menuDirectory;
        }

        //Helper method to grab item by menu meal name - so you do a for each to enable us to cycle through the list and find the name

        public MenuClass GetMealName(string mealName)
        {
            foreach (MenuClass meal in _menuDirectory)
            {
                if (meal.MealName.ToLower() == mealName.ToLower())
                {
                    return meal; 
                }
            }
            return null;
        }

        //Update - Not needed at this time

        //Delete 

        //This method 
        public bool DeleteMenuItem(string mealName)
        {
            MenuClass foundItem = GetMealName(mealName);
            bool isItemDeleted = _menuDirectory.Remove(foundItem);
            return isItemDeleted; 
        }
        

        
    }
}
