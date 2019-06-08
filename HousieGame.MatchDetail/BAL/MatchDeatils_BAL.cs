using HousieGame.MatchDetail.Interface;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.MatchDetails.BAL
{


    public class MatchDetails_BAL : IMatchDetailRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MatchDetails_BAL));

        public List<MatchDetailss> GetAllRecord()
        {
            List<MatchDetailss> objReturn = null;
            try
            {
                using (MatchDetails objDAL = new Admin_DAL())
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

    }
