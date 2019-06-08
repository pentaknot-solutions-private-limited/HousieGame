using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Model
{
    public class MatchPriceRelPage
    {
        public List<MatchPlayerRel> MatchPlayerRels { get; set; }

        public int TotalRecords { get; set; }
    }
}
