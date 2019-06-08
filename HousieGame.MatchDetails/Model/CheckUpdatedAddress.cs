using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Model
{
    public class CheckUpdatedAddress
    {
        public Guid Id { get; set; }

        public string PlayerName { get; set; }


        public string PrizeFile { get; set; }


        public bool FirstLine { get; set; }


        public bool SecondLine { get; set; }


        public bool ThirdLine { get; set; }


        public bool FullHousie { get; set; }


        public bool Lucky { get; set; }


        public bool Expired { get; set; }


        public bool Empty { get; set; }

    }
}
