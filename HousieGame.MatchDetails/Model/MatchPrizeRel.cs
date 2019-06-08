using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Model
{
    public class MatchPrizeRel
    {
       public Guid? MatchId { get; set; }
       
       public List<MatchPrizeDetails>  ImageDetails { get; set; }
}
}
