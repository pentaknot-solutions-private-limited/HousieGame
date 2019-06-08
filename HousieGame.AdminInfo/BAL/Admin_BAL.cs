using HousieGame.AdminInfo.DAL;
using HousieGame.AdminInfo.Interface;
using HousieGame.AdminInfo.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.AdminInfo.BAL
{
    public class Admin_BAL : IAdminRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Admin_BAL));

        public List<Admin> GetAllRecord()
        {
            List<Admin> objReturn = null;
            try
            {
                using (Admin_DAL objDAL = new Admin_DAL())
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

        public AdminPage GetRecordPage(int iPageNo, int iPageSize)
        {
            AdminPage objReturn = new AdminPage();
            try
            {
                using (Admin_DAL objDAL = new Admin_DAL())
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

        public Admin GetRecordById(Guid iId)
        {
            Admin objReturn = null;
            try
            {
                using (Admin_DAL objDAL = new Admin_DAL())
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

        public Admin Validate(string email, string password)
        {
            Admin objReturn = null;
            try
            {
                using (Admin_DAL objDAL = new Admin_DAL())
                {
                    objReturn = objDAL.Validate(email, password);
                }
            }
            catch (Exception ex)
            {
                log.Error("Validate Error: ", ex);
            }
            return objReturn;
        }

        public Guid InsertUpdateRecord(Admin objAdmin)
        {
            Guid objReturn = new Guid();
            try
            {
                using (Admin_DAL objDAL = new Admin_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objAdmin);
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
                using (Admin_DAL objDAL = new Admin_DAL())
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
        // ~Admin_BAL() {
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
