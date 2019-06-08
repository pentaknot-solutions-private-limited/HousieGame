using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Model
{
    public class CheckPlayerMatch
    {
        public Guid? PlayerId { get; set; }


        public bool? PlayerDeleted { get; set; }


        public bool? MatchDeleted { get; set; }


        public bool AlreadyClaim { get; set; }


        public int? Count { get; set; }

    }
}
