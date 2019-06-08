using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Model
{
     interface IMatchPlayerRelRepository : IDisposable

    {
        List<MatchPlayerRel> GetAllRecord();

        MatchPlayerRelPage GetRecordPage(int iPageNo, int iPageSize);

        MatchPlayerRel GetRecordById(Guid iId);

        Guid InsertUpdateRecord(MatchPlayerRel objMatchPlayerRel);

        bool DeleteRecord(int iId);

    }
}
