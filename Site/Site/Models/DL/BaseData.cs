using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Site.Models.DL
{
    public class BaseData : IDisposable
    {

        public MySqlConnection conexaoMySQL;
        protected MySqlCommand commandMySql;
        protected MySqlDataReader dataReaderMySql;
        public MySqlTransaction transaction;
        
        public BaseData()
        {
            if(conexaoMySQL == null)
            {
                string strConexao = ConfigurationManager.AppSettings["StringConexao"];
                conexaoMySQL = new MySqlConnection(strConexao);
                conexaoMySQL.Open();
            }
        }

        public void Dispose()
        {
            if (conexaoMySQL.State ==  System.Data.ConnectionState.Open)
                conexaoMySQL.Close();
            GC.SuppressFinalize(this); 
        }
        
    }
}