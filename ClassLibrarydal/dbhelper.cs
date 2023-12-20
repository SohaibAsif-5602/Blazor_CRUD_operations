using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibrarydal
{
    public class dbhelper
    {
        public static SqlConnection Getconnection()
        {
            SqlConnection sqlConnection=new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True");

            return sqlConnection;
        }
    }
}