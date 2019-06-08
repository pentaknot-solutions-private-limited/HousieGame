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
    public class MatchDetailsRel_DAL : IMatchDetailsRelRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchDetailsRel_DAL));

        public List<MatchDetailsRel> GetAllRecord()
        {
            List<MatchDetailsRel> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<MatchDetailsRel>("udp_MatchDetailsRel_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetAllRecord Error: ", ex);
            }
            return objReturn;
        }

        public List<MatchDetailsRel> GetAllRecordByMatch(Guid id)
        {
            List<MatchDetailsRel> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", id);
                    objReturn = db.Query<MatchDetailsRel>("udp_MatchDetailsRel_selByMatch", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetAllRecordByMatch Error: ", ex);
            }
            return objReturn;
        }

        public MatchDetailsRelPage GetRecordPage(int iPageNo, int iPageSize)
        {
            MatchDetailsRelPage objReturn = new MatchDetailsRelPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.MatchDetailsRels = db.Query<MatchDetailsRel>("udp_MatchDetailsRel_lstpage", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();

                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            {
                log.Error("GetMatchDetailsRelPageList Error: ", ex);
            }
            return objReturn;
        }

        public MatchDetailsRel GetRecordById(int iId)
        {
            MatchDetailsRel objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<MatchDetailsRel>("udp_MatchDetailsRel_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetRecordById Error: ", ex);
            }
            return objReturn;
        }

        public List<int> GetMatchDetailsRelById(Guid MatchId)
        {
            List<int> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MatchId", MatchId);
                    objReturn = db.Query<int>("udp_MatchDetailsRelByMatchId", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetMatchDetailsRelById Error: ", ex);
            }
            return objReturn;
        }

        public Guid InsertUpdateRecord(MatchDetailsRel objMatchDetailsRel)
        {
            Guid objReturn = new Guid();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_MatchDetailsRel_ups", param: objMatchDetailsRel, commandType: System.Data.CommandType.StoredProcedure).Single();
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
                    db.Query("udp_MatchDetailsRel_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
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
        // ~MatchDetailsRel_DAL() {
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
