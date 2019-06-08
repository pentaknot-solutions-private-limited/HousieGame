using HousieGame.MatchDetail.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetail.Interface
{
   public  interface  IMatchDetailRepository : IDisposable
    {
        List<MatchDetailPage> GetAllRecord();

        MatchDetails GetRecordPage(int iPageNo, int iPageSize);

        MatchDetailPage GetRecordById(Guid iId);

        Guid InsertUpdateRecord(MatchDetailPage objMatchdetail);

        bool DeleteRecord(int iId);
    }
}
