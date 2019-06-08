using Dapper;
using HousieGame.Connection;
using HousieGame.PlayerInfo.Interface;
using HousieGame.PlayerInfo.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HousieGame.PlayerInfo.DAL
{
    public class Player_DAL : IPlayerRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Player_DAL));

        public List<Player> GetAllRecord()
        {
            List<Player> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Player>("udp_PlayerDetails_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetAllRecord Error: ", ex);
            }
            return objReturn;
        }


        public PlayerPage GetRecordPage(int iPageNo, int iPageSize)
        {
            PlayerPage objReturn = new PlayerPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.Players = db.Query<Player>("udp_PlayerDetails_lstpage", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();

                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            {
                log.Error("GetPlayerPageList Error: ", ex);
            }
            return objReturn;
        }

        public Player GetRecordById(Guid iId)
        {
            Player objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<Player>("udp_PlayerDetails_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetRecordById Error: ", ex);
            }
            return objReturn;
        }

        public Player ValidatePlayer(string email, string password)
        {
            Player objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@EmailId", email);
                    param.Add("@PasswordHash", password);

                    objReturn = db.Query<Player>("udp_ValidatePlayer", param: param, commandType: System.Data.CommandType.StoredProcedure).Single();
                }
            }
            catch (Exception ex)
            {
                log.Error("ValidatePlayer Error: ", ex);
            }
            return objReturn;
        }

        public Guid InsertUpdateRecord(Player objPlayer)
        {
            Guid objReturn = new Guid();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_PlayerDetails_ups", param: objPlayer, commandType: System.Data.CommandType.StoredProcedure).Single();
                }
            }
            catch (Exception ex)
            {
                log.Error("InsertUpdateRecord Error: ", ex);
            }
            return objReturn;
        }

        public bool DeleteRecord(int iId)
        {
            bool objReturn = false;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    db.Query("udp_PlayerDetails_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
                    objReturn = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("DeleteRecord Error: ", ex);
            }
            return objReturn;
        }

        List<Player> IPlayerRepository.GetAllRecord()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Player_DAL() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

