using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaExpress.Extensions
{
    public class BaseDbHelper
    {
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(
                "Server=mssqlstud.fhict.local;Database= dbi522311_cexpress;User Id= dbi522311_cexpress;Password=123456;");
        }


        public SqlTransaction GetNewSqlTransaction()
        {
            var conn = GetConnection();
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();
            return transaction;
        }

        public int GetLastCreatedId(string entityType)
        {
            var conn = GetConnection();

            var sql = $"SELECT * FROM {entityType} ORDER BY Id DESC";
            var cmd = new SqlCommand(sql, conn);

            conn.Open();
            var id = (int)cmd.ExecuteScalar();
            conn.Close();

            return id;
        }
    }
}
