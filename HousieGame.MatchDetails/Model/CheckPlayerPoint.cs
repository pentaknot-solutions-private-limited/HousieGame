using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Model
{
    public class CheckPlayerPoint
    {
        public MatchPlayerPointRel MatchPlayerPointRelModel { get; set; }


        public bool LateClaim { get; set; } //Someone has Already Claimed


        public bool WrongClaim { get; set; } //Wrong Claim


        //public bool AlreadyClaim { get; set; } //You have Already Claimed


    }
}
