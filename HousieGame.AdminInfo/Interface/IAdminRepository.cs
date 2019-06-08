using HousieGame.AdminInfo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.AdminInfo.Interface
{
    interface IAdminRepository : IDisposable
    {
        List<Admin> GetAllRecord();

        AdminPage GetRecordPage(int iPageNo, int iPageSize);

        Admin GetRecordById(Guid iId);

        Guid InsertUpdateRecord(Admin objAdmin) ;

        bool DeleteRecord(int iId);
    }
}
