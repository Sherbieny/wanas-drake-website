using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WDI.DB_Layer;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for categoryServices
/// </summary>

namespace WDI.Service_Layer
{ 
    public class categoryServices
    {
        ConnectionDB Connection;
	    public categoryServices()
	    {
            Connection = new ConnectionDB();
	    }


        /// <summary>
        /// This Functions get all categories
        /// </summary>       
        public List<category> get_all_categories()
        {
            category c = new category();
            List<category> CategoryList;
            
            try
            {
                CategoryList = new List<category>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_all_categories", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;

                //////////////////Retreiveing the category props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {                    
                    c = new category();
                    c.ID = Convert.ToInt32(dr["ID"]);
                    c.Name = Convert.ToString(dr["Name"]);
                    c.Pic_Path = Convert.ToString(dr["Pic_Path"]);

                    CategoryList.Add(c);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
            }

            return CategoryList;
        }

        /////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This Functions get a certain category by ID
        /// </summary>  
        public category get_category_byID(int EID)
        {
            category c = new category();

            try
            {
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_category_byID", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = EID;
                //////////////////Retreiveing the category props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    c = new category();
                    c.ID = Convert.ToInt32(dr["ID"]);
                    c.Name = Convert.ToString(dr["Name"]);
                    c.Pic_Path = Convert.ToString(dr["Pic_Path"]);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
            }

            return c;
        }

        /////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This Functions add a category
        /// </summary>  

        public void add_category(category c)
        {
            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("add_category", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = c.Name;
                commdel.Parameters.Add("EPic_Path", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = c.Pic_Path;          
                //////////////////Executing the Command/////////////////
                commdel.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This Functions remove a category
        /// </summary>  

        public void delete_category(int EID)
        {

            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("delete_category", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = EID;
                //////////////////Executing the Command/////////////////
                commdel.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This Functions edit a category
        /// </summary>  

        public void edit_category(category c)
        {

            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("edit_category", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = c.ID;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = c.Name;
                commdel.Parameters.Add("EPic_Path", MySqlDbType.VarChar);
                commdel.Parameters[2].Value = c.Pic_Path;
                //////////////////Executing the Command/////////////////
                commdel.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
            }
        }        
    }
}