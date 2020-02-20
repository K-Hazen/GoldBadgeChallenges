using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class KomodoClaimsRepo
    {
        //Need to change this to a queue and then update methods below to work with queue funcationality 
        protected readonly Queue<KomodoClaimsClass> _claimsQueue = new Queue<KomodoClaimsClass>();

        //create

        public bool AddClaimsToQueue(KomodoClaimsClass claimContent)
        {
            int queueLength = _claimsQueue.Count();
            _claimsQueue.Enqueue(claimContent);                                             //This ups the claimsDirectory to 1
            bool wasClaimContentAdded = queueLength + 1 == _claimsQueue.Count();    //This returns true because both = 1 
            return wasClaimContentAdded;
        }

        //Read (or get)

        public Queue<KomodoClaimsClass> SeeAllClaims()
        {
            return _claimsQueue;
        }

        //Methods to get queue to function - so when they hit "2" it pulls off the top of the queue 

        public KomodoClaimsClass GetNextClaim()
        {
            if (_claimsQueue.Count() != 0)  //".Count" method was added to the field so that it returned an int to be able to compare to 0
            {
                return _claimsQueue.Peek();
            }
            else
            {
                return null;
            }
        }

        public KomodoClaimsClass CompleteClaim()
        {
            return _claimsQueue.Dequeue();
        }
    }
}
