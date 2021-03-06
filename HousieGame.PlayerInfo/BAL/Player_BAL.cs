﻿using HousieGame.PlayerInfo.DAL;
using HousieGame.PlayerInfo.Interface;
using HousieGame.PlayerInfo.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.PlayerInfo.BAL
{
   public class Player_BAL : IPlayerRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Player_BAL));

        public List<Player> GetAllRecord()
        {
            List<Player> objReturn = null;
            try
            {
                using (Player_DAL objDAL = new Player_DAL())
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

        public PlayerPage GetRecordPage(int iPageNo, int iPageSize)
        {
            PlayerPage objReturn = new PlayerPage();
            try
            {
                using (Player_DAL objDAL = new Player_DAL())
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

        public Player GetRecordById(Guid iId)
        {
            Player objReturn = null;
            try
            {
                using (Player_DAL objDAL = new Player_DAL())
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

        public Player ValidatePlayer(string email, string password)
        {
            Player objReturn = null;
            try
            {
                using (Player_DAL objDAL = new Player_DAL())
                {
                    objReturn = objDAL.ValidatePlayer(email, password);
                }
            }
            catch (Exception ex)
            {
                log.Error("ValidatePlayer Error: ", ex);
            }
            return objReturn;
        }

        public Guid InsertUpdateRecord(Player objPlayer)
        {
            Guid objReturn = new Guid();
            try
            {
                using (Player_DAL objDAL = new Player_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objPlayer);
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
                using (Player_DAL objDAL = new Player_DAL())
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
        // ~Player_BAL() {
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
