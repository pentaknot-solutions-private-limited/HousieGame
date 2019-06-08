using Dapper;
using HousieGame.Connection;
using HousieGame.MatchDetails.Interface;
using HousieGame.MatchDetails.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HousieGame.MatchDetails.DAL
{
    public class MatchPlayerPointRel_DAL : IMatchPlayerPointRelRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchPlayerPointRel_DAL));

        public List<MatchPlayerPointRel> GetAllRecord()
        {
            List<MatchPlayerPointRel> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<MatchPlayerPointRel>("udp_MatchPlayerPointRel_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetAllRecord Error: ", ex);
            }
            return objReturn;
        }

        public MatchPlayerPointRelPage GetRecordPage(int iPageNo, int iPageSize)
        {
            MatchPlayerPointRelPage objReturn = new MatchPlayerPointRelPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.MatchPlayerPointRels = db.Query<MatchPlayerPointRel>("udp_MatchPlayerPointRel_lstpage", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();

                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            {
                log.Error("GetMatchPlayerPointRelPageList Error: ", ex);
            }
            return objReturn;
        }

        public MatchPlayerPointRel GetRecordById(Guid iId)
        {
            MatchPlayerPointRel objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<MatchPlayerPointRel>("udp_MatchPlayerPointRel_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetRecordById Error: ", ex);
            }
            return objReturn;
        }

        public List<MatchWinner> GetMatchWinner(Guid MatchId)
        {
            List<MatchWinner> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", MatchId);
                    objReturn = db.Query<MatchWinner>("udp_MatchWinner_lst", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetMatchWinner Error: ", ex);
            }
            return objReturn;
        }

        public List<CheckUpdatedAddress> GetCheckUpdatedAddresses(Guid MatchId)
        {
            List<CheckUpdatedAddress> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MatchId", MatchId);
                    objReturn = db.Query<CheckUpdatedAddress>("udp_CheckUpdateAddress", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetCheckUpdatedAddresses Error: ", ex);
            }
            return objReturn;
        }

        public MatchPlayerPointRel CheckPlayerPoint(Guid MatchId, Guid PlayerId)
        {
            MatchPlayerPointRel objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MatchId", MatchId);
                    param.Add("@PlayerId", PlayerId);
                    objReturn = db.Query<MatchPlayerPointRel>("udp_CheckPlayerPoint_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("CheckPlayerPoint Error: ", ex);
            }
            return objReturn;
        }

        public MatchPlayerPointRel InsertUpdateRecord(MatchPlayerPointRel objMatchPlayerPointRel)
        {
            MatchPlayerPointRel objReturn = new MatchPlayerPointRel();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<MatchPlayerPointRel>("udp_MatchPlayerPointRel_ups", param: objMatchPlayerPointRel , commandType: System.Data.CommandType.StoredProcedure).Single();
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
                    db.Query("udp_MatchPlayerPointRel_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
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
        // ~MatchPlayerPointRel_DAL() {
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