using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSKDotNetCore.ConsoleApp
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-5V2KGHB", //server name 
            InitialCatalog = "DotNetTrainingBatch4", //database name
            UserID = "sa",
            Password = "sasa@1234",
            TrustServerCertificate = true
        };
    }
}
