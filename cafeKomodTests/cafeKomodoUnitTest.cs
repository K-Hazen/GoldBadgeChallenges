using System;
using System.Collections.Generic;
using CafeKomodo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cafeKomodoTest
{
    [TestClass]
    public class CafeKomodoUnitTest
    {
        [TestMethod]
        public void AddToMenu_ShouldReturnCorrectBoolean()
        {
            //newing up an instance of the Menu Class and Repo Class
            MenuClass menuItem = new MenuClass();
            CafeKomodoRepo komodoRepo = new CafeKomodoRepo();
            
            //Adding a bool test to see if is working
            bool addItem = komodoRepo.AddItemsToMenu(menuItem);
            Assert.IsTrue(addItem); 
        }

        [TestMethod]
        public void GetAllMenuItems()
        {
            MenuClass menuItem = new MenuClass();
            CafeKomodoRepo komodoRepo = new CafeKomodoRepo();
            komodoRepo.AddItemsToMenu(menuItem);
            List<MenuClass> menuItems = komodoRepo.GetAllMenuItems();
            bool isMenuDirectoryPopulated = menuItems.Contains(menuItem);
            Assert.IsTrue(isMenuDirectoryPopulated);

        }

        private CafeKomodoRepo _repoKomodo;
        private MenuClass _menuContent;

        [TestInitialize]
        public void Arrange() 
        {
            List<string> billSando = new List<string>() { "Whole wheat bread, carved turkey, gravy, swiss cheese, bacon, lettuce, tomato, chips and a pickle" };
            _repoKomodo = new CafeKomodoRepo();
            _menuContent = new MenuClass(1, "Bill's Turkey Sandwich", "The one and only way Bill will eat a turkey sando", billSando, 10.99m);

            _repoKomodo.AddItemsToMenu(_menuContent);

        }
        
       [TestMethod]
        
        public void GetItemByName_ShouldReturnCorrectBoolean()
        {
            //Arrange();
            MenuClass searchItem = _repoKomodo.GetMealName("Bill's Turkey Sandwich");
            Assert.AreEqual( _menuContent, searchItem); 
        }

        [TestMethod]
        public void RemoveByItemName_ShouldReturnCorrectBoolean()
        {
            bool removeItem = _repoKomodo.DeleteMenuItem("Bill's Turkey Sandwich");
            Assert.IsTrue(removeItem);
        }
    }
}
