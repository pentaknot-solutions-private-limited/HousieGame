using HousieGame.MatchTokenDetails.DAL;
using HousieGame.MatchTokenDetails.Interface;
using HousieGame.MatchTokenDetails.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchTokenDetails.BAL
{
  public  class MatchToken_BAL : IMatchTokenDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchToken_BAL));

        public List<MatchTokenInfo> GetAllRecord()
        {
            List<MatchTokenInfo> objReturn = null;
            try
            {
                using (MatchToken_DAL objDAL = new MatchToken_DAL())
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

        public MatchTokenDetailsPage GetRecordPage(int iPageNo, int iPageSize)
        {
            MatchTokenDetailsPage objReturn = new MatchTokenDetailsPage();
            try
            {
                using (MatchToken_DAL objDAL = new MatchToken_DAL())
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

        public MatchTokenInfo GetRecordById(Guid iId)
        {
            MatchTokenInfo objReturn = null;
            try
            {
                using (MatchToken_DAL objDAL = new MatchToken_DAL())
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

        public Guid InsertUpdateRecord(MatchTokenInfo objMatch)
        {
            Guid objReturn = new Guid();
            try
            {
                using (MatchToken_DAL objDAL = new MatchToken_DAL())
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
                using (MatchToken_DAL objDAL = new MatchToken_DAL())
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
