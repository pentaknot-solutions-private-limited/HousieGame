using System;
using System.Collections.Generic;
using System.Text;
using HousieGame.MatchDetails.Model;

namespace HousieGame.MatchDetails.Interface
{
    interface IMatchDetailsRepository : IDisposable
    {
        List<Match> GetAllRecord();

        MatchdetailsPage GetRecordPage(int iPageNo, int iPageSize);

        Match GetRecordById(Guid iId);

        Guid InsertUpdateRecord(Match objMatchDetails);

        bool DeleteRecord(int iId);
    }
}
