using HousieGame.MatchDetails.DAL;
using HousieGame.MatchDetails.Interface;
using HousieGame.MatchDetails.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.BAL
{
    public class MatchDetailsRel_BAL : IMatchDetailsRelRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchDetailsRel_BAL));

        public List<MatchDetailsRel> GetAllRecord()
        {
            List<MatchDetailsRel> objReturn = null;
            try
            {
                using (MatchDetailsRel_DAL objDAL = new MatchDetailsRel_DAL())
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

        public List<MatchDetailsRel> GetAllRecordByMatch(Guid id)
        {
            List<MatchDetailsRel> objReturn = null;
            try
            {
                using (MatchDetailsRel_DAL objDAL = new MatchDetailsRel_DAL())
                {
                    objReturn = objDAL.GetAllRecordByMatch(id);
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
                using (MatchDetailsRel_DAL objDAL = new MatchDetailsRel_DAL())
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

        public MatchDetailsRel GetRecordById(int iId)
        {
            MatchDetailsRel objReturn = null;
            try
            {
                using (MatchDetailsRel_DAL objDAL = new MatchDetailsRel_DAL())
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

        public List<int> GetMatchDetailsRelById(Guid MatchId)
        {
            List<int> objReturn = null;
            try
            {
                using (MatchDetailsRel_DAL objDAL = new MatchDetailsRel_DAL())
                {
                    objReturn = objDAL.GetMatchDetailsRelById(MatchId);
                }
            }
            catch (Exception ex)
            {
                log.Error("GetMatchDetailsRelById Error: ", ex);
            }
            return objReturn;
        }

        public Guid InsertUpdateRecord(MatchDetailsRel objMatch)
        {
            Guid objReturn = new Guid();
            try
            {
                using (MatchDetailsRel_DAL objDAL = new MatchDetailsRel_DAL())
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
                using (MatchDetailsRel_DAL objDAL = new MatchDetailsRel_DAL())
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
