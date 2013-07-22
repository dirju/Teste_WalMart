using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Site.Models.BL
{
    public class BaseBusiness : IDisposable
    {

        protected MySqlConnection conexaoMySQL;
        protected MySqlCommand commandMySql;
        protected MySqlDataReader dataReaderMySql;
        protected MySqlTransaction transaction;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
    }
}