using HousieGame.MatchDetails.DAL;
using HousieGame.MatchDetails.Interface;
using HousieGame.MatchDetails.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.BAL
{
    public class Match_BAL : IMatchDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Match_BAL));

        public List<Match> GetAllRecord()
        {
            List<Match> objReturn = null;
            try
            {
                using (Match_DAL objDAL = new Match_DAL())
                {
                    objReturn = objDAL.GetAllRecord();
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
                using (Match_DAL objDAL = new Match_DAL())
                {
                    objReturn = objDAL.GetUpComingMatch();
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
                using (Match_DAL objDAL = new Match_DAL())
                {
                    objReturn = objDAL.GetRecordPage(iPageNo, iPageSize);
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
                using (Match_DAL objDAL = new Match_DAL())
                {
                    objReturn = objDAL.GetRecordById(iId);
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
                using (Match_DAL objDAL = new Match_DAL())
                {
                    objReturn = objDAL.ExpireMatchToken(MatchId);
                }
            }
            catch (Exception ex)
            {
                log.Error("ExpireMatchToken Error: ", ex);
            }
            return objReturn;
        }

        public Guid InsertUpdateRecord(Match objMatch)
        {
            Guid objReturn = new Guid();
            try
            {
                using (Match_DAL objDAL = new Match_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objMatch);
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
                using (Match_DAL objDAL = new Match_DAL())
                {
                    objReturn = objDAL.DeleteRecord(iId);
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
        // ~Match_BAL() {
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
