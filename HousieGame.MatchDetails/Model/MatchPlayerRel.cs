using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Model
{
   public  class MatchPlayerRel
    {
        public int Id { get; set; }

        public Guid MatchId { get; set; }

        public Guid PlayerId { get; set; }


        public string TokenGeneratedNumber { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }
    }
}

