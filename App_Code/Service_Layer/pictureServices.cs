using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WDI.DB_Layer;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for pictureServices
/// </summary>
/// 

namespace WDI.Service_Layer
{
    public class pictureServices
    {
        ConnectionDB Connection;
        public pictureServices()
        {
            Connection = new ConnectionDB();
        }

         /// <summary>
        /// This Functions get all pictures
        /// </summary>       
        public List<picture> get_all_pictures()
        {
            picture p = new picture();
            List<picture> pictureList;
            
            try
            {
                pictureList = new List<picture>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_all_pictures", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;

                //////////////////Retreiveing the picture props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {                    
                    p = new picture();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Picture_Path = Convert.ToString(dr["Picture_Path"]);
                    p.Project_ID = Convert.ToInt32(dr["Project_ID"]);
                  

                    pictureList.Add(p);
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

            return pictureList;
        }

        /////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This Functions get a certain picture by ID
        /// </summary>  
        public picture get_picture_byID(int EID)
        {
            picture p = new picture();

            try
            {
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_picture_byID", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = EID;
                //////////////////Retreiveing the picture props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    p = new picture();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Picture_Path = Convert.ToString(dr["Picture_Path"]);
                    p.Project_ID = Convert.ToInt32(dr["Project_ID"]);
                  
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

            return p;
        }

        /////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This Functions get a certain picture by project
        /// </summary>  
        public List<picture> get_picture_byProject(int EProject_ID)
        {            
            picture p = new picture();
            List<picture> pictureList;

            try
            {
                pictureList = new List<picture>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_picture_byProject", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EProject_ID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = EProject_ID;
                //////////////////Retreiveing the picture props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    p = new picture();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Picture_Path = Convert.ToString(dr["Picture_Path"]);
                    p.Project_ID = Convert.ToInt32(dr["Project_ID"]);
                  
                    pictureList.Add(p);
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

            return pictureList;
        }

        /////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This Functions add a picture
        /// </summary>  

        public void add_picture(picture p)
        {
            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("add_picture", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EPicture_Path", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = p.Picture_Path;
                commdel.Parameters.Add("EProject_ID", MySqlDbType.Int32);
                commdel.Parameters[1].Value = p.Project_ID;                         
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
        /// This Functions remove a picture
        /// </summary>  

        public void delete_picture(int EID)
        {

            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("delete_picture", Connection.conn);
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
        /// This Functions edit a picture
        /// </summary>  

        public void edit_picture(picture p)
        {

            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("edit_picture", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = p.ID;
                commdel.Parameters.Add("EPicture_Path", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = p.Picture_Path;
                commdel.Parameters.Add("EProject_ID", MySqlDbType.Int32);
                commdel.Parameters[2].Value = p.Project_ID;            ;
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