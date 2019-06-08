using HousieGame.MatchDetails.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Interface
{
    interface IMatchDetailsRelRepository : IDisposable

    {
        List<MatchDetailsRel> GetAllRecord();

        MatchDetailsRelPage GetRecordPage(int iPageNo, int iPageSize);

        MatchDetailsRel GetRecordById(int iId);

        Guid InsertUpdateRecord(MatchDetailsRel objMatchDetailsRel);

        bool DeleteRecord(int iId);

    }
}
