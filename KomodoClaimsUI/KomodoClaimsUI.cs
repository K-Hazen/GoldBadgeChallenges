using KomodoClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsUI
{
    public class KomodoClaimsUI
    {
        public KomodoClaimsRepo _claimsUIRepo = new KomodoClaimsRepo();

        public void Run()
        {
            SeedClaims();       //needs to go above the "run" so that it populates the see content prior to 
            RunClaims();
        }
        private void RunClaims()
        {
            bool isKomodoClaimsRunning = true;

            while (isKomodoClaimsRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to Komodo Claims \n" +
                "Please choose from the menu below by selecting the corresponding number: \n " +
                "1. See All Claims \n " +
                "2. Take Care of Next Claim \n " +
                "3. Enter New Claim \n " +
                "4. Exit");

                string agentInput = Console.ReadLine();
                agentInput = agentInput.Replace(" ", "");

                switch (agentInput)
                {
                    case "1":
                        DisplayAllClaims();
                        break;
                    case "2":
                        TakeCareOfClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        isKomodoClaimsRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddNewClaim()
        {
            KomodoClaimsClass newClaim = new KomodoClaimsClass();

            Console.Clear();

            Console.WriteLine("Enter Claim ID #:");
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose what type of claim it is - Type in coresponding number \n " +
                "1. Home \n " +
                "2. Car \n " +
                "3. Theft");

            string claimTypeString = Console.ReadLine();
            int claimTypeNumber = int.Parse(claimTypeString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeNumber;

            Console.WriteLine("Enter a description of the claim");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter claim amount:");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Date of Incident in this format Year, Month, Day");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Date Claim was filed in this format Year, Month, Day");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _claimsUIRepo.AddClaimsToQueue(newClaim);

            Console.WriteLine("The claim has been added! Prese any key to return to the main menu.");
            Console.ReadKey();

        }

        private void TakeCareOfClaim()
        {
            Console.Clear();

            KomodoClaimsClass viewNextClaim = new KomodoClaimsClass();  //needed to pull up an instance of the class not the whole queue 

            viewNextClaim = _claimsUIRepo.GetNextClaim();

            if (viewNextClaim != null)
            {
                Console.WriteLine($"ClaimID: {viewNextClaim.ClaimID} \n" +
                    $"Claim Type: {viewNextClaim.TypeOfClaim} \n" +
                    $"Claim Description: {viewNextClaim.Description} \n" +
                    $"Claim Amount: {viewNextClaim.ClaimAmount} \n" +
                    $"Date of Incident: {viewNextClaim.DateOfIncident} \n" +
                    $"Date of Claim: {viewNextClaim.DateOfClaim} \n" +
                    $"Is Claim Valid? {viewNextClaim.IsClaimValid}");
                Console.WriteLine();
                
                Console.WriteLine("Has the claim been processed? Y/N");
                char complete = char.Parse(Console.ReadLine().ToLower());

                if (complete == 'y')
                {
                    viewNextClaim = _claimsUIRepo.CompleteClaim();
                    Console.WriteLine("The claim has been processed!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Press any key to return to main menu. Current claim will remain first in line for you to return to.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("There are no more claims in the queue. \n" +
                    "Press any key to continue");
                Console.ReadKey();
            }

        }

        private void DisplayAllClaims()
        {
            Console.Clear();

            Queue<KomodoClaimsClass> allClaims = new Queue<KomodoClaimsClass>();
            allClaims = _claimsUIRepo.SeeAllClaims();

            foreach (KomodoClaimsClass claim in allClaims)
            {
                Console.WriteLine($"ClaimID: {claim.ClaimID} \n" +
                 $"Claim Type: {claim.TypeOfClaim} \n" +
                 $"Claim Description: {claim.Description} \n" +
                 $"Claim Amount: {claim.ClaimAmount} \n" +
                 $"Date of Incident: {claim.DateOfIncident} \n" +
                 $"Date of Claim: {claim.DateOfClaim} \n" +
                 $"Is Claim Valid?: {claim.IsClaimValid}");
                Console.WriteLine(); ;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedClaims()
        {
            KomodoClaimsClass fenderBender = new KomodoClaimsClass(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 04, 27));

            _claimsUIRepo.AddClaimsToQueue(fenderBender);

            KomodoClaimsClass greatSpatulasOfFire = new KomodoClaimsClass(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));

            _claimsUIRepo.AddClaimsToQueue(greatSpatulasOfFire);


            KomodoClaimsClass cakeThief = new KomodoClaimsClass(3, ClaimType.Theft, "The Case of Stolen Pancakes", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));

            _claimsUIRepo.AddClaimsToQueue(cakeThief);
        }

    }
}


