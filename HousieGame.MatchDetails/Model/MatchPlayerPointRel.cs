using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Model
{
   public  class MatchPlayerPointRel
    {
        public int Id { get; set; }

        public Guid MatchId { get; set; }

        public Guid PlayerId { get; set; }


        public int? ClaimedPrize { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }


        public bool? FirstLine { get; set; }


        public bool? SecondLine { get; set; }


        public bool? ThirdLine { get; set; }


        public bool? FullHousie { get; set; }


    }
}
