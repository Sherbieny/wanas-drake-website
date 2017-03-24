using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
/// <summary>
/// Summary description for ConnectionDB
/// </summary>

namespace WDI.DB_Layer
{ 
    public class ConnectionDB
    {
        public MySqlConnection conn { get; set; }

	    public ConnectionDB()
	    {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["WDIConnectionString"].ConnectionString);
	    }

        public void connect()
        {
            try { conn.Open(); }
            catch (Exception e) { }
        }

        public void disconnect()
        {
            conn.Close();
        }
    }
}