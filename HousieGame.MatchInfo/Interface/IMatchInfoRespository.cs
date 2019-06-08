using HousieGame.MatchInfo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchInfo.Interface
{
  public interface IMatchInfoRespository : IDisposable
    {
        List<MatchDetails> GetAllRecord();

        MatchDetailsPage GetRecordPage(int iPageNo, int iPageSize);

        MatchDetails GetRecordById(Guid iId);

        Guid InsertUpdateRecord(MatchDetails objMatchDetails);

        bool DeleteRecord(int iId);
    }
}
