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
    public class MatchPriceRel_DAL : IMatchPriceRelRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchPriceRel_DAL));

        public List<MatchPriceRel> GetAllRecord()
        {
            List<MatchPriceRel> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<MatchPriceRel>("udp_MatchPriceRel_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetAllRecord Error: ", ex);
            }
            return objReturn;
        }

        public MatchPriceRelPage GetRecordPage(int iPageNo, int iPageSize)
        {
            MatchPriceRelPage objReturn = new MatchPriceRelPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.MatchPlayerRels = db.Query<MatchPlayerRel>("udp_MatchPriceRel_lstpage", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();

                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            {
                log.Error("GetMatchPriceRelPageList Error: ", ex);
            }
            return objReturn;
        }

        public MatchPriceRel GetRecordById(Guid iId)
        {
            MatchPriceRel objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<MatchPriceRel>("udp_MatchPriceRel_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetRecordById Error: ", ex);
            }
            return objReturn;
        }


        public Guid ClaimPrize(Guid MatchId, int? ClaimedPrize)
        {
            Guid objReturn = new Guid();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MatchId", MatchId);
                    param.Add("@ClaimedPrize", ClaimedPrize);
                    objReturn = db.Query<Guid>("udp_ClaimPrize_ups", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("ClaimPrize Error: ", ex);
            }
            return objReturn;
        }


        public MatchPriceRel GetRecordByMatchIdAndDisplayPosition(Guid iId, int? displayposition)
        {
            MatchPriceRel objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MatchId", iId);
                    param.Add("@DisplayPosition", displayposition);
                    objReturn = db.Query<MatchPriceRel>("udp_GetMatchPriceRelByMatchIdAndDisplayPosition", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetRecordByMatchIdAndDisplayPosition Error: ", ex);
            }
            return objReturn;
        }


        public List<MatchPriceRel> GetRecordsById(Guid iId)
        {
            List<MatchPriceRel> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<MatchPriceRel>("udp_MatchPriceRel_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetRecordsById Error: ", ex);
            }
            return objReturn;
        }


        public Guid InsertUpdateRecord(MatchPriceRel objMatchPriceRel)
        {
            Guid objReturn = new Guid();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_MatchPriceRel_ups", param: objMatchPriceRel, commandType: System.Data.CommandType.StoredProcedure).Single();
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
                    db.Query("udp_MatchPriceRel_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
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
        // ~MatchPriceRel_DAL() {
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
