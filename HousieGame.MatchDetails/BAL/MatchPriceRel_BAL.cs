using HousieGame.MatchDetails.DAL;
using HousieGame.MatchDetails.Interface;
using HousieGame.MatchDetails.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchPrice.BAL
{
    public class MatchPriceRel_BAL : IMatchPriceRelRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchPriceRel_BAL));

        public List<MatchPriceRel> GetAllRecord()
        {
            List<MatchPriceRel> objReturn = null;
            try
            {
                using (MatchPriceRel_DAL objDAL = new MatchPriceRel_DAL())
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

        public MatchPriceRelPage GetRecordPage(int iPageNo, int iPageSize)
        {
            MatchPriceRelPage objReturn = new MatchPriceRelPage();
            try
            {
                using (MatchPriceRel_DAL objDAL = new MatchPriceRel_DAL())
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

        public MatchPriceRel GetRecordById(Guid iId)
        {
            MatchPriceRel objReturn = null;
            try
            {
                using (MatchPriceRel_DAL objDAL = new MatchPriceRel_DAL())
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

        public Guid ClaimPrize(Guid MatchId, int? ClaimedPrize)
        {
            Guid objReturn = new Guid();
            try
            {
                using (MatchPriceRel_DAL objDAL = new MatchPriceRel_DAL())
                {
                    objReturn = objDAL.ClaimPrize(MatchId, ClaimedPrize);
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
                using (MatchPriceRel_DAL objDAL = new MatchPriceRel_DAL())
                {
                    objReturn = objDAL.GetRecordByMatchIdAndDisplayPosition(iId, displayposition);
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
                using (MatchPriceRel_DAL objDAL = new MatchPriceRel_DAL())
                {
                    objReturn = objDAL.GetRecordsById(iId);
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
                using (MatchPriceRel_DAL objDAL = new MatchPriceRel_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objMatchPriceRel);
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
                using (MatchPriceRel_DAL objDAL = new MatchPriceRel_DAL())
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
