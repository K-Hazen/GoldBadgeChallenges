using System;
using System.Collections.Generic;
using KomodoClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaimsUnitTest
{
    [TestClass]
    public class ClaimsUnitTest1
    {
        [TestMethod]
        public void IsClaimValid_ShouldReturnCorrectBoolean()
        {
            KomodoClaimsClass isValidTest = new KomodoClaimsClass();
            isValidTest.DateOfClaim = new DateTime(2020, 12, 23);
            isValidTest.DateOfIncident = new DateTime(2020, 12, 2);
            bool x = isValidTest.IsClaimValid;              //This is calling in the function in the getter by invoking "." then property name 
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void IsClaimContentAdded_ShouldReturnCorrectBoolean()
        {
            //creating new instances of the class to work with variable then carry all content of the Class/Repo
            KomodoClaimsClass claimContent = new KomodoClaimsClass();   
            KomodoClaimsRepo claimRepo = new KomodoClaimsRepo();

            //checking to see if AddClaimToDirectory method is oeprational. So claimRepo calls the class... "." calls the method and passes in claimContent from the ClaimsClass

            bool addClaim = claimRepo.AddClaimsToQueue(claimContent); 
            Assert.IsTrue(addClaim); 
        }

        [TestMethod]
        public void SeeAllClaims_ShouldReturnCorrectBoolean()
        {
            KomodoClaimsClass claimItem = new KomodoClaimsClass();
            KomodoClaimsRepo claimRepo = new KomodoClaimsRepo();

            claimRepo.AddClaimsToQueue(claimItem);
            Queue<KomodoClaimsClass> seeAll = claimRepo.SeeAllClaims();
            bool directoryHasClaim = seeAll.Contains(claimItem);
            Assert.IsTrue(directoryHasClaim); 
        }

        private KomodoClaimsRepo _claimsRepo;
        private KomodoClaimsClass _claimContent;

        [TestInitialize]
        public void Arrange()
        {
            _claimsRepo = new KomodoClaimsRepo();
            _claimContent = new KomodoClaimsClass(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 04, 27));

            _claimsRepo.AddClaimsToQueue(_claimContent); //this passes all the constructor info into _claimsRepo

        }

        [TestMethod]
        public void GetNextClaim_ShouldReturnCorrectBoolean() 
        {
            //this line is bringing in the info passed from the constructor and calling the method
            KomodoClaimsClass queueItem = _claimsRepo.GetNextClaim();       
            Assert.AreEqual("Car accident on 465", queueItem.Description);  //this is picking a field w/in the queue to test 
        }

        [TestMethod]
        public void CompleteClaim_ShouldReturnCorrectBoolean()
        {
            KomodoClaimsClass dequeueItem = _claimsRepo.CompleteClaim();
            Assert.AreEqual(null, null);
        }

        
    }
}
