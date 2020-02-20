using System;
using System.Collections.Generic;
using BadgesKomodo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgesKomodo_Tests
{
    [TestClass]
    public class BadgeTest1
    {
        [TestMethod]
        public void AddToDictionary_ShouldGetCorrectBoolean()
        {
            BadgeClass badge = new BadgeClass();
            BadgeRepo repoBadge = new BadgeRepo();

            bool addBadge = repoBadge.AddBadgeToDictionary(badge);
            Assert.IsTrue(addBadge);
        }

        [TestMethod]
        public void GetAllBadges_ShouldReturnCorrectBoolean()
        {
            BadgeRepo repoBadge = new BadgeRepo();
            BadgeClass badgeContent = new BadgeClass();
            
            repoBadge.AddBadgeToDictionary(badgeContent);
            Dictionary<int, List<string>> getAll = repoBadge.GetAllBadges();

            bool dictionaryHasKey = getAll.ContainsKey(badgeContent.BadgeID);

            Assert.IsTrue(dictionaryHasKey);
        }

        private BadgeRepo _repo;
        private BadgeClass _badgeContent; 
        
        [TestInitialize]
        public void Arrange()
        {
            List<string> badgeDoorAccess = new List<string>() { "A4", "C4" };
            _repo = new BadgeRepo();
            _badgeContent = new BadgeClass(8675309, badgeDoorAccess); 
            _repo.AddBadgeToDictionary(_badgeContent);
        }

        [TestMethod]
        public void GetRoomAccessList_ShouldReturnSomething()
        {
            int badgeID = 8675309;

            _repo.GetRoomAccessList(badgeID);
            Assert.AreEqual(2, _badgeContent.ListOfDoors.Count);
            
        }

        [TestMethod]
        public void AddRoomAccess_ShouldReturnEqual()
        {
            //check indexer, count, iterate through the list and check to see if strings are equal 

            int badgeID = 8675309;
            string door = "A10";
            
             _repo.AddRoomAccessTwo(badgeID, door);
            
            Assert.AreEqual(3,_badgeContent.ListOfDoors.Count);
            
            //List<string> roomAccessList = new List<string>();
            //int badgeID = 21;
           
            //roomAccessList = repoBadge.GetRoomAccessList(badgeID);
        }

        [TestMethod]
        public void RemoveRoomAccess_ShouldReturnEqual()
        {

            int badgeID = 8675309;
            string doorToRemove = "C4";

            _repo.DeleteRoomAccessTwo(badgeID, doorToRemove);

            Assert.AreEqual(1, _badgeContent.ListOfDoors.Count);
        }

        [TestMethod]
        public void DeleteAllAccess_ShouldReturnEqaul()
        {
            int badgeID = 8675309;

            _repo.DeleteAllRoomAccess(badgeID);

            Assert.AreEqual(0, _badgeContent.ListOfDoors.Count);

        }
        
    }
}
