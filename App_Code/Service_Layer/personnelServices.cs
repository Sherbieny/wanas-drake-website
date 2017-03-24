using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WDI.DB_Layer;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for personnelServices
/// </summary>
namespace WDI.Service_Layer
{
	public class personnelServices
	{
        ConnectionDB Connection;
        public personnelServices()
        {
            Connection = new ConnectionDB();
        }

         /// <summary>
        /// This Functions get all person
        /// </summary>       
        public List<person> get_all_person()
        {
            person p = new person();
            List<person> personList;

            try
            {
                personList = new List<person>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_all_person", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;

                //////////////////Retreiveing the person props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    p = new person();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Name = Convert.ToString(dr["Name"]);
                    p.Title = Convert.ToString(dr["Title"]);
                    p.Description = Convert.ToString(dr["Description"]);
                    p.Type = Convert.ToInt32(dr["Type"]);
                    p.Pic_Path = Convert.ToString(dr["Pic_Path"]);
                    p.PicSmall_Path = Convert.ToString(dr["PicSmall_Path"]);

                    personList.Add(p);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Connection.disconnect();
            }

            return personList;
        }

        ///////////////////////////////////////////////////////////////////////////////
     
        /// <summary>
        /// This Functions get person by ID
        /// </summary>   
        public person get_person_byID(int EID)
        {
            person p = new person();

            try
            {
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_person_byID", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = EID;
                //////////////////Retreiveing the person props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    p = new person();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Name = Convert.ToString(dr["Name"]);
                    p.Title = Convert.ToString(dr["Title"]);
                    p.Description = Convert.ToString(dr["Description"]);
                    p.Type = Convert.ToInt32(dr["Type"]);
                    p.Pic_Path = Convert.ToString(dr["Pic_Path"]);
                    p.PicSmall_Path = Convert.ToString(dr["PicSmall_Path"]);
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

        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This Functions add a person
        /// </summary>  
        public void add_person(person p)
        {
            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("add_person", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = p.Name;
                commdel.Parameters.Add("ETitle", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = p.Title;
                commdel.Parameters.Add("EDescription", MySqlDbType.Text);
                commdel.Parameters[2].Value = p.Description;
                commdel.Parameters.Add("EType", MySqlDbType.Int32);
                commdel.Parameters[3].Value = p.Type;
                commdel.Parameters.Add("EPic_Path", MySqlDbType.VarChar);
                commdel.Parameters[4].Value = p.Pic_Path;
                commdel.Parameters.Add("EPicSmall_Path", MySqlDbType.VarChar);
                commdel.Parameters[5].Value = p.PicSmall_Path;
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
        /// This Functions remove a person
        /// </summary>  
        public void delete_person(int EID)
        {

            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("delete_person", Connection.conn);
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
        /// This Functions edit a person
        /// </summary>  
        public void edit_person(person p)
        {

            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("edit_person", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////Get Parameters///////////////////////
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = p.ID;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = p.Name;
                commdel.Parameters.Add("ETitle", MySqlDbType.VarChar);
                commdel.Parameters[2].Value = p.Title;
                commdel.Parameters.Add("EDescription", MySqlDbType.Text);
                commdel.Parameters[3].Value = p.Description;
                commdel.Parameters.Add("EType", MySqlDbType.Int32);
                commdel.Parameters[4].Value = p.Type;
                commdel.Parameters.Add("EPic_Path", MySqlDbType.VarChar);
                commdel.Parameters[5].Value = p.Pic_Path;
                commdel.Parameters.Add("EPicSmall_Path", MySqlDbType.VarChar);
                commdel.Parameters[6].Value = p.PicSmall_Path;  
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