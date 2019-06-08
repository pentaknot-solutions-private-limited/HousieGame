using log4net;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousieGame.Common
{
    public class Helper
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Helper));
        public void Dispose()
        {
        }
        public String GetUserIP(ConnectionInfo connection)
        {
            return connection.RemoteIpAddress.ToString();
        }
    }
}
