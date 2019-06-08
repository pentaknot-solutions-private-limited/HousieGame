using HousieGame.MatchDetails.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Interface
{
    interface IMatchPlayerPointRelRepository : IDisposable
    {
        List<MatchPlayerPointRel> GetAllRecord();

        MatchPlayerPointRelPage GetRecordPage(int iPageNo, int iPageSize);

        MatchPlayerPointRel GetRecordById(Guid iId);

        MatchPlayerPointRel InsertUpdateRecord(MatchPlayerPointRel objMatchPlayerRel);

        bool DeleteRecord(int iId);
    }
}
