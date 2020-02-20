using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKomodo
{
   public class MenuClass
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> IndgredientList { get; set; } = new List<string>(); //this second half = giving us a starter blank list to populate
        public decimal MealPrice { get; set; }


        public MenuClass() { }

        public MenuClass(int mealNumber, string mealName, string mealDescription, List<string> ingredientList, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            IndgredientList = ingredientList;
            MealPrice = mealPrice;
        }

    }
}
