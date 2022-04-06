using System;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using CommonLayer;
namespace DataAccessLayer
{
    public class DbConnect
    {
        public SqlConnection connection;
        public DbConnect()
        {
            connection = new SqlConnection(DbConnectionConfig.ConnectionString);
        }
    }
}
