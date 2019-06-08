using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.PlayerInfo.Model
{
     public class Player
    {

        public int Id { get; set; }


        public Guid PlayerId { get; set; }


        public string Name { get; set; }


        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string Address { get; set; }

      
        public string PasswordHash { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }
    }
}
