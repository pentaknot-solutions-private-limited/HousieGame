using Dapper;
using HousieGame.Connection;
using HousieGame.MatchDetails.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HousieGame.MatchDetails.DAL
{
     public class MatchPlayerRel_DAL :IMatchPlayerRelRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchPlayerRel_DAL));

        public List<MatchPlayerRel> GetAllRecord()
        {
            List<MatchPlayerRel> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<MatchPlayerRel>("udp_MatchPlayerRel_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetAllRecord Error: ", ex);
            }
            return objReturn;
        }

        public MatchPlayerRelPage GetRecordPage(int iPageNo, int iPageSize)
        {
            MatchPlayerRelPage objReturn = new MatchPlayerRelPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.MatchPlayerRels = db.Query<MatchPlayerRel>("udp_MatchPlayerRel_lstpage", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();

                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            {
                log.Error("GetRecordPage Error: ", ex);
            }
            return objReturn;
        }

        public MatchPlayerRel GetRecordById(Guid iId)
        {
            MatchPlayerRel objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<MatchPlayerRel>("udp_MatchPlayerRel_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetRecordById Error: ", ex);
            }
            return objReturn;
        }

        public MatchPlayerRel GetMatchPlayer(Guid PlayerId, Guid MatchId)
        {
            MatchPlayerRel objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@PlayerId", PlayerId);
                    param.Add("@MatchId", MatchId);
                    objReturn = db.Query<MatchPlayerRel>("udp_GetMatchPlayer_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetMatchPlayer Error: ", ex);
            }
            return objReturn;
        }

        public List<MatchPlayerRel> GetMatchById(Guid iId)
        {
            List<MatchPlayerRel> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<MatchPlayerRel>("udp_MatchPlayerRel_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetMatchById Error: ", ex);
            }
            return objReturn;
        }

        public MatchPlayerRel GetPlayerById(Guid PlayerId, Guid MatchId)
        {
            MatchPlayerRel objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@PlayerId", PlayerId);
                    param.Add("@MatchId", MatchId);
                    objReturn = db.Query<MatchPlayerRel>("udp_MatchPlayerDetails_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetPlayerById Error: ", ex);
            }
            return objReturn;
        }



        public List<MatchPlayerRel> GetListRecordById(Guid iId)
        {
            List<MatchPlayerRel> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<MatchPlayerRel>("udp_MatchPlayerRel_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetListRecordById Error: ", ex);
            }
            return objReturn;
        }


        public int GetCountById(Guid iId)
        {
            int objReturn = 0;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MatchId", iId);
                    objReturn = db.Query<int>("udp_GetMatchPlayerRelCountByMatchId", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetCountById Error: ", ex);
            }
            return objReturn;
        }


        public Guid WrongClaim(Guid MatchId, Guid PlayerId)
        {
            Guid objReturn = new Guid();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MatchId", MatchId);
                    param.Add("@PlayerId", PlayerId);
                    objReturn = db.Query<Guid>("udp_WrongClaim_ups", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("WrongClaim Error: ", ex);
            }
            return objReturn;
        }

        public bool CheckClaimOfAnotherPlayer(Guid MatchId, int LineOfClaim)
        {
            bool objReturn = false;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MatchId", MatchId);
                    if (LineOfClaim == 1)
                    {
                        objReturn = db.Query<bool>("udp_CheckFirstLineClaim", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                    } else if(LineOfClaim == 2)
                    {
                        objReturn = db.Query<bool>("udp_CheckSecondLineClaim", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                    } else if(LineOfClaim == 3)
                    {
                        objReturn = db.Query<bool>("udp_CheckThirdLineClaim", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("CheckClaimOfAnotherPlayer Error: ", ex);
            }
            return objReturn;
        }

        public int MarkedNumberCount(Guid MatchId)
        {
            int objReturn = 0;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", MatchId);
                    objReturn = db.Query<int>("udp_isMatchLive", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("MarkedNumberCount Error: ", ex);
            }
            return objReturn;
        }

        public CheckPlayerMatch CheckPlayerMatch(Guid playerId, Guid matchId)
        {
            CheckPlayerMatch objReturn = new CheckPlayerMatch();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@PlayerId", playerId);
                    param.Add("@MatchId", matchId);
                    objReturn = db.Query<CheckPlayerMatch>("udp_CheckPlayerMatch_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("CheckPlayerMatch Error: ", ex);
            }
            return objReturn;
        }

        public Guid InsertUpdateRecord(MatchPlayerRel objMatchPlayerRel)
        {
            Guid objReturn = new Guid();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_MatchPlayerRel_ups", param: objMatchPlayerRel , commandType: System.Data.CommandType.StoredProcedure).Single();
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
                    db.Query("udp_MatchPlayerRel_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
                    objReturn = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("DeleteRecord Error: ", ex);
            }
            return objReturn;
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
        // ~MatchPlayerRel_DAL() {
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
