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
    public class Match_DAL : IMatchDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Match_DAL));

        public List<Match> GetAllRecord()
        {
            List<Match> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Match>("udp_MatchDetails_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetAllRecord Error: ", ex);
            }
            return objReturn;
        }

        public List<Match> GetUpComingMatch()
        {
            List<Match> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Match>("udp_UpcomingMatchDetails_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetUpComingMatch Error: ", ex);
            }
            return objReturn;
        }

        public MatchdetailsPage GetRecordPage(int iPageNo, int iPageSize)
        {
            MatchdetailsPage objReturn = new MatchdetailsPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.MatchDetailss = db.Query<MatchTokenRel>("udp_MatchDetailsTokenRel_lstpage", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();

                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            {
                log.Error("GetRecordPage Error: ", ex);
            }
            return objReturn;
        }

        public Match GetRecordById(Guid iId)
        {
            Match objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<Match>("udp_MatchDetails_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetRecordById Error: ", ex);
            }
            return objReturn;
        }

        public Guid ExpireMatchToken(Guid MatchId)
        {
            Guid objReturn = new Guid();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MatchId", MatchId);
                    objReturn = db.Query<Guid>("udp_ExpireMatchToken_ups", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("ExpireMatchToken Error: ", ex);
            }
            return objReturn;
        }

        public Guid InsertUpdateRecord(Match objMatchDetails)
        {
            Guid objReturn = new Guid();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_MatchDetails_ups", param: objMatchDetails , commandType: System.Data.CommandType.StoredProcedure).Single();
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
                    db.Query("udp_MatchDetails_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
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
        // ~MatchDetails_DAL() {
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
