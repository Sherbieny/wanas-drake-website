using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WDI.DB_Layer;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for projectServices
/// </summary>
namespace WDI.Service_Layer
{
	public class projectServices
	{
		ConnectionDB Connection;

        public projectServices()
        {
            Connection = new ConnectionDB();
        }
        
         /// <summary>
        /// This Functions get all projects
        /// </summary>       
        public List<project> get_all_projects()
        {
            project p = new project();
            List<project> ProjectList;

            try
            {
                ProjectList = new List<project>();
                MySqlDataReader dr;
                    /////////////////Construcing the MY SQL command//////////// 
                    Connection.connect();
                    MySqlCommand commdel = new MySqlCommand("get_all_projects", Connection.conn);
                    commdel.CommandType = System.Data.CommandType.StoredProcedure;

                    //////////////////Retreiveing the Project props from DB/////////
                    dr = commdel.ExecuteReader();
                while(dr.Read())
                {
                    p = new project();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Name = Convert.ToString(dr["Name"]);
                    p.Category = Convert.ToInt32(dr["Category"]);
                    p.Descrition = Convert.ToString(dr["Description"]);
                    p.Main_Pic_Path = Convert.ToString(dr["Main_Pic_Path"]);
                    p.Location = Convert.ToString(dr["Location"]);
                    p.Total_Area = Convert.ToString(dr["Total_Area"]);
                    p.BuiltUp_Area = Convert.ToString(dr["BuiltUp_Area"]);
                    p.Small_Description = Convert.ToString(dr["Small_Description"]);

                    ProjectList.Add(p);
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

            return ProjectList;
        }
        
        ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This Functions get a certain project by ID
        /// </summary>  
        public project get_project_byID(int EID)
        {
            project p = new project();

            try
            {
                MySqlDataReader dr;
                    /////////////////Construcing the MY SQL command//////////// 
                    Connection.connect();
                    MySqlCommand commdel = new MySqlCommand("get_project_byID", Connection.conn);
                    commdel.CommandType = System.Data.CommandType.StoredProcedure;
                    commdel.Parameters.Add("EID", MySqlDbType.Int32);
                    commdel.Parameters[0].Value = EID;
                    //////////////////Retreiveing the Project props from DB/////////
                    dr = commdel.ExecuteReader();
                    while (dr.Read())
                    {
                        p = new project();
                        p.ID = Convert.ToInt32(dr["ID"]);
                        p.Name = Convert.ToString(dr["Name"]);
                        p.Category = Convert.ToInt32(dr["Category"]);
                        p.Descrition = Convert.ToString(dr["Description"]);
                        p.Main_Pic_Path = Convert.ToString(dr["Main_Pic_Path"]);
                        p.Small_Description = Convert.ToString(dr["Small_Description"]);
                        p.Location = Convert.ToString(dr["Location"]);
                        p.Total_Area = Convert.ToString(dr["Total_Area"]);
                        p.BuiltUp_Area = Convert.ToString(dr["BuiltUp_Area"]);
                        p.Small_Description = Convert.ToString(dr["Small_Description"]);
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
        /// This Functions get a list projects by their category
        /// </summary>  
        public List<project> get_project_by_category(int ECategory)
        {
            project p = new project();
            List<project> ProjectList;
            try
            {
                ProjectList = new List<project>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_project_by_category", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("ECategory", MySqlDbType.Int32);
                commdel.Parameters[0].Value = ECategory;
                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    p = new project();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Name = Convert.ToString(dr["Name"]);
                    p.Category = Convert.ToInt32(dr["Category"]);
                    p.Descrition = Convert.ToString(dr["Description"]);
                    p.Main_Pic_Path = Convert.ToString(dr["Main_Pic_Path"]);                    
                    p.Location = Convert.ToString(dr["Location"]);
                    p.Total_Area = Convert.ToString(dr["Total_Area"]);
                    p.BuiltUp_Area = Convert.ToString(dr["BuiltUp_Area"]);
                    p.Small_Description = Convert.ToString(dr["Small_Description"]);

                    ProjectList.Add(p);
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

            return ProjectList;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This Functions add a project
        /// </summary>  
        public void add_project(project p)
        {
            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("add_project", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = p.Name;
                commdel.Parameters.Add("ECategory", MySqlDbType.Int32);
                commdel.Parameters[1].Value = p.Category;
                commdel.Parameters.Add("EDescription", MySqlDbType.VarChar);
                commdel.Parameters[2].Value = p.Descrition;
                commdel.Parameters.Add("EMain_Pic_Path", MySqlDbType.VarChar);
                commdel.Parameters[3].Value = p.Main_Pic_Path;                
                commdel.Parameters.Add("ELocation", MySqlDbType.VarChar);
                commdel.Parameters[4].Value = p.Location;
                commdel.Parameters.Add("ETotal_Area", MySqlDbType.VarChar);
                commdel.Parameters[5].Value = p.Total_Area;
                commdel.Parameters.Add("EBuiltUp_Area", MySqlDbType.VarChar);
                commdel.Parameters[6].Value = p.BuiltUp_Area;
                commdel.Parameters.Add("ESmall_Description", MySqlDbType.VarChar);
                commdel.Parameters[7].Value = p.Small_Description;
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
        /// This Functions remove a project
        /// </summary>          
        public void delete_project(int EID)
        {

            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("delete_project", Connection.conn);
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
        /// This Functions edit a project
        /// </summary>  
        public void edit_project(project p)
        {

            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("edit_project", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = p.ID;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = p.Name;
                commdel.Parameters.Add("ECategory", MySqlDbType.Int32);
                commdel.Parameters[2].Value = p.Category;
                commdel.Parameters.Add("EDescription", MySqlDbType.VarChar);
                commdel.Parameters[3].Value = p.Descrition;
                commdel.Parameters.Add("EMain_Pic_Path", MySqlDbType.VarChar);
                commdel.Parameters[4].Value = p.Main_Pic_Path;               
                commdel.Parameters.Add("ELocation", MySqlDbType.VarChar);
                commdel.Parameters[5].Value = p.Location;
                commdel.Parameters.Add("ETotal_Area", MySqlDbType.VarChar);
                commdel.Parameters[6].Value = p.Total_Area;
                commdel.Parameters.Add("EBuiltUp_Area", MySqlDbType.VarChar);
                commdel.Parameters[7].Value = p.BuiltUp_Area;
                commdel.Parameters.Add("ESmall_Description", MySqlDbType.VarChar);
                commdel.Parameters[8].Value = p.Small_Description;
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