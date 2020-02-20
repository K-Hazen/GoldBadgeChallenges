using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public enum ClaimType { Car =1, Home =2, Theft =3}
    public class KomodoClaimsClass
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsClaimValid
        {
            get
            {
                TimeSpan claimSpan = DateOfClaim - DateOfIncident;
                double totalDaysSinceIncident = claimSpan.TotalDays;
                int dayCount = Convert.ToInt32(Math.Floor(totalDaysSinceIncident));

                if (dayCount < 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set { }

        }

        //create constructors 
        public KomodoClaimsClass() { }

        public KomodoClaimsClass(int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;  
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

        }

    }
}
