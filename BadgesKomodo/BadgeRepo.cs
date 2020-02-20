using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesKomodo
{
    public class BadgeRepo
    {

        //create

        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public bool AddBadgeToDictionary(BadgeClass badge)
        {

            //Dictionary<int, List<string>> dictionaryOne = GetAllBadges();

            int assignBadgeID = badge.BadgeID;
            List<string> accessList = badge.ListOfDoors;

            int dictionaryLength = _badgeDictionary.Count();
            _badgeDictionary.Add(assignBadgeID, accessList);

            bool isbadgeAdded = dictionaryLength + 1 == _badgeDictionary.Count();
            return isbadgeAdded; 

            //dictionaryOne.Add(assignBadgeID, accessList);



            //AddBadgeToDictionary (int badgeID, List<string> roomAccess); 
            //int dictionaryLength = _badgeDictionary.Count();
            //_badgeDictionary.Add(badgeID, roomAccess);
            //bool wasBadgeContentAdded = dictionaryLength + 1 == _badgeDictionary.Count();
            //return wasBadgeContentAdded;
        }


        //Read (Get)
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeDictionary;
        }

        //Update

        //passing in old list parameter and newAccess parameter to add the two together 

        //public bool AddRoomAccess(List<string> oldRoomAccess, string newRoomAccess)
        //{
        //    //List<string> oldRoomAccess = new List<string>();
        //    //oldRoomAccess = GetRoomAccessList(badgeID);
        //    oldRoomAccess.Add(newRoomAccess);

        //    if (oldRoomAccess.Contains(newRoomAccess)) //note for UI -- the list parameter is the dictionary[key] and this passes in list not the key. Pass in dictionary value name with the key in square brackets
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //    //needing to write a method to show we are adding to a list (not actually adding it) .  roomsToAdd == oldAccess + roomsToAdd
        //}

        public void AddRoomAccessTwo(int badgeID, string doorToAdd)
        {
          
            List<string> currentAccess = GetRoomAccessList(badgeID);
            currentAccess.Add(doorToAdd);

            //_badgeDictionary[badgeID] = currentAccess; 

        }



        //Helper Method

        public List<string> GetRoomAccessList(int badgeID)
        {
            //dictionaries are inherently bools

            List<string> roomAccessList = new List<string>();

            if (_badgeDictionary.TryGetValue(badgeID, out roomAccessList))
            {
                return roomAccessList;
            }
            else
            {
                return null;  //in UI tell it what to do with a null value
            }
        }

        //Delete

        //

        /*public List<string> DeleteRoomAccess(List<string> roomAccess, string roomToRemove)
        {
           int roomAccessListLength = roomAccess.Count();
            roomAccess.Remove(roomToRemove);
            return roomAccess;
        }*/

        public void DeleteRoomAccessTwo(int badgeID, string doorToRemove)
        {
            List<string> newList = GetRoomAccessList(badgeID);
            newList.Remove(doorToRemove);

            //_badgeDictionary[badgeID] = newList; 
        }

        public void DeleteAllRoomAccess(int badgeID)
        {
            List<string> currentAccessList = GetRoomAccessList(badgeID);
            currentAccessList.Clear(); 
        }

        //public void DeleteRoomAccess(int badgeID, string doorToRemove)
        //{
        //    foreach(int numberID in _badgeDictionary.Keys)
        //    {
        //        if (numberID == badgeID)
        //        {
        //            _badgeDictionary[numberID].Remove(doorToRemove); //doesn't this just overwrite the List with a string? 
        //        }
        //    }
        //}

    }
}
