using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchTokenDetails
{
   public  class MatchTokenInfo
    {
        public int Id { get; set; }


        public Guid MatchTokenId { get; set; }


        public Guid? MatchId { get; set; }


        public string MatchToken { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }
    }
}

