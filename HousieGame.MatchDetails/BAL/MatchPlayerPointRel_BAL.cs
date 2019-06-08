using HousieGame.MatchDetails.DAL;
using HousieGame.MatchDetails.Interface;
using HousieGame.MatchDetails.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.BAL
{
    public class MatchPlayerPointRel_BAL : IMatchPlayerPointRelRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchPlayerPointRel_BAL));

        public List<MatchPlayerPointRel> GetAllRecord()
        {
            List<MatchPlayerPointRel> objReturn = null;
            try
            {
                using (MatchPlayerPointRel_DAL objDAL = new MatchPlayerPointRel_DAL())
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

        public List<MatchWinner> GetMatchWinner(Guid MatchId)
        {
            List<MatchWinner> objReturn = null;
            try
            {
                using (MatchPlayerPointRel_DAL objDAL = new MatchPlayerPointRel_DAL())
                {
                    objReturn = objDAL.GetMatchWinner(MatchId);
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
                using (MatchPlayerPointRel_DAL objDAL = new MatchPlayerPointRel_DAL())
                {
                    objReturn = objDAL.GetCheckUpdatedAddresses(MatchId);
                }
            }
            catch (Exception ex)
            {
                log.Error("GetCheckUpdatedAddresses Error: ", ex);
            }
            return objReturn;
        }

        public MatchPlayerPointRelPage GetRecordPage(int iPageNo, int iPageSize)
        {
            MatchPlayerPointRelPage objReturn = new MatchPlayerPointRelPage();
            try
            {
                using (MatchPlayerPointRel_DAL objDAL = new MatchPlayerPointRel_DAL())
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

        public MatchPlayerPointRel GetRecordById(Guid iId)
        {
            MatchPlayerPointRel objReturn = null;
            try
            {
                using (MatchPlayerPointRel_DAL objDAL = new MatchPlayerPointRel_DAL())
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

        public MatchPlayerPointRel CheckPlayerPoint(Guid MatchId, Guid PlayerId)
        {
            MatchPlayerPointRel objReturn = null;
            try
            {
                using (MatchPlayerPointRel_DAL objDAL = new MatchPlayerPointRel_DAL())
                {
                    objReturn = objDAL.CheckPlayerPoint(MatchId, PlayerId);
                }
            }
            catch (Exception ex)
            {
                log.Error("CheckPlayerPoint Error: ", ex);
            }
            return objReturn;
        }

        public MatchPlayerPointRel InsertUpdateRecord(MatchPlayerPointRel objMatch)
        {
            MatchPlayerPointRel objReturn = new MatchPlayerPointRel();
            try
            {
                using (MatchPlayerPointRel_DAL objDAL = new MatchPlayerPointRel_DAL())
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
                using (MatchPlayerPointRel_DAL objDAL = new MatchPlayerPointRel_DAL())
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


