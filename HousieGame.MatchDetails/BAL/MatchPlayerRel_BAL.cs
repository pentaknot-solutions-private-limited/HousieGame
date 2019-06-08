using HousieGame.MatchDetails.DAL;
using HousieGame.MatchDetails.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.BAL
{
   public class MatchPlayerRel_BAL : IMatchPlayerRelRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchPlayerRel_BAL));

        public List<MatchPlayerRel> GetAllRecord()
        {
            List<MatchPlayerRel> objReturn = null;
            try
            {
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
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

        public MatchPlayerRelPage GetRecordPage(int iPageNo, int iPageSize)
        {
            MatchPlayerRelPage objReturn = new MatchPlayerRelPage();
            try
            {
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
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

        public MatchPlayerRel GetRecordById(Guid iId)
        {
            MatchPlayerRel objReturn = null;
            try
            {
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
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

        public MatchPlayerRel GetMatchPlayer(Guid PlayerId, Guid MatchId)
        {
            MatchPlayerRel objReturn = null;
            try
            {
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
                {
                    objReturn = objDAL.GetMatchPlayer(PlayerId, MatchId);
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
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
                {
                    objReturn = objDAL.GetMatchById(iId);
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
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
                {
                    objReturn = objDAL.GetPlayerById(PlayerId, MatchId);
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
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
                {
                    objReturn = objDAL.GetListRecordById(iId);
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
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
                {
                    objReturn = objDAL.GetCountById(iId);
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
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
                {
                    objReturn = objDAL.WrongClaim(MatchId, PlayerId);
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
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
                {
                    objReturn = objDAL.CheckClaimOfAnotherPlayer(MatchId, LineOfClaim);
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
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
                {
                    objReturn = objDAL.MarkedNumberCount(MatchId);
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
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
                {
                    objReturn = objDAL.CheckPlayerMatch(playerId, matchId);
                }
            }
            catch (Exception ex)
            {
                log.Error("CheckPlayerMatch Error: ", ex);
            }
            return objReturn;
        }

        public Guid InsertUpdateRecord(MatchPlayerRel objMatch)
        {
            Guid objReturn = new Guid();
            try
            {
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
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
                using (MatchPlayerRel_DAL objDAL = new MatchPlayerRel_DAL())
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

