using HousieGame.MatchTokenDetails.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchTokenDetails.Interface
{
   public interface IMatchTokenDetailsRepository :IDisposable
    
        {
        List<MatchTokenInfo> GetAllRecord();

        MatchTokenDetailsPage GetRecordPage(int iPageNo, int iPageSize);

        MatchTokenInfo GetRecordById(Guid iId);

        Guid InsertUpdateRecord(MatchTokenInfo objMatchDetails);

        bool DeleteRecord(int iId);
    
}
}
