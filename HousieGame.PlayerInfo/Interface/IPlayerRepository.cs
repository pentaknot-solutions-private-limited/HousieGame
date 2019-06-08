using HousieGame.PlayerInfo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.PlayerInfo.Interface
{
    interface IPlayerRepository :IDisposable
    {
        List<Player> GetAllRecord();

        PlayerPage GetRecordPage(int iPageNo, int iPageSize);

        Player GetRecordById(Guid iId);

        Guid InsertUpdateRecord(Player objPlayer);

        bool DeleteRecord(int iId);

    }
}
