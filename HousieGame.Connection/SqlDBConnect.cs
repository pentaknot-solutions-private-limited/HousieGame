using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HousieGame.Connection
{
    public class SqlDBConnect : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public SqlConnection GetConnection()
        {
            //return new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=Housie; Integrated Security=true;");
            return new SqlConnection("Data Source=SQL5041.site4now.net;Initial Catalog=DB_A444FC_housie;User Id=DB_A444FC_housie_admin;Password=2019@Housie;");
        }
    }
}
