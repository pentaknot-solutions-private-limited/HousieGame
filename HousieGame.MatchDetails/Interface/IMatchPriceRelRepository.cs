using HousieGame.MatchDetails.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.Interface
{
    interface IMatchPriceRelRepository : IDisposable
    {
        List<MatchPriceRel> GetAllRecord();

        MatchPriceRelPage GetRecordPage(int iPageNo, int iPageSize);

        MatchPriceRel GetRecordById(Guid iId);

        Guid InsertUpdateRecord(MatchPriceRel objMatchPriceRel);

        bool DeleteRecord(int iId);

    }
}
