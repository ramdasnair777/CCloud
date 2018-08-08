using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseADO
    {
        protected readonly string _connString; 
      // protected readonly SqlConnection connection;
        public BaseADO()
        {
            //_connString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            // = new SqlConnection(_connString);
            _connString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }
    }
}
