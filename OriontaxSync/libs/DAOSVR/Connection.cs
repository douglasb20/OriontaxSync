using System;
using Microsoft.Data.SqlClient;

namespace OriontaxSync.libs
{
    static class Connection
    {
        public static SqlConnection con;
        public static SqlTransaction transaction;
        public static void Connect()
        {
            string host = ConfigReader.GetConfigValue("Database", "dbhost");
            string dbuser = ConfigReader.GetConfigValue("Database", "dbuser");
            string password = ConfigReader.GetConfigValue("Database", "dbpwd");


            con = new SqlConnection(string.Format(@"Data Source={0};Initial Catalog=Etrade; User ID={1};Password={2};TrustServerCertificate=True;", host, dbuser, password));
            con.Open();
        }
        public static void ReConnect()
        {
            Close();
            Connect();
        }
        public static void BeginTransaction() { transaction = con.BeginTransaction(); }
        public static void Commit() { transaction.Commit(); }
        public static void Rollback() { transaction.Rollback(); }
        public static void Close() { con.Close(); con.Dispose(); }
        public static void TesteConn(string host, string user, string pwd)
        {
            try
            {
                con = new SqlConnection(string.Format(@"Data Source={0};Initial Catalog=Etrade; User ID={1};Password={2};TrustServerCertificate=True;", host, user, pwd));
                con.Open();

            }catch(SqlException ex)
            {
                Funcoes.ErrorMessage(ex.Message);

            }catch(Exception ex)
            {
                Funcoes.ErrorMessage(ex.Message);
            }
        }
    }
}
