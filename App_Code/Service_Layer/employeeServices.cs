using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WDI.DB_Layer;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for employeeervices
/// </summary>
namespace WDI.Service_Layer
{
	public class employeeServices
	{
        ConnectionDB Connection;

        public employeeServices()
        {
            Connection = new ConnectionDB();
        }

        /// <summary>
        /// This Functions get all employee
        /// </summary>       
        public List<employee> get_all_employee()
        {
            employee p = new employee();
            List<employee> employeeList;

            try
            {
                employeeList = new List<employee>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_all_employee", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;

                //////////////////Retreiveing the employee props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    p = new employee();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Name = Convert.ToString(dr["Name"]);
                    p.Access = Convert.ToInt32(dr["Access"]);
                    p.Email = Convert.ToString(dr["Email"]);
                    p.Password = Convert.ToString(dr["Password"]);                 

                    employeeList.Add(p);
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

            return employeeList;
        }

        ///////////////////////////////////////////////////////////////////////////////
     
        /// <summary>
        /// This Functions get employee by ID
        /// </summary>   
        public employee get_employee_byID(int EID)
        {
            employee p = new employee();

            try
            {
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_employee_byID", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = EID;
                //////////////////Retreiveing the employee props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    p = new employee();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Name = Convert.ToString(dr["Name"]);
                    p.Access = Convert.ToInt32(dr["Access"]);
                    p.Email = Convert.ToString(dr["Email"]);
                    p.Password = Convert.ToString(dr["Password"]); 
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
        /// This Functions get employee by ID
        /// </summary>   
        public employee get_employee_byName(String EName)
        {
            employee p = new employee();

            try
            {
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_employee_byName", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = EName;
                //////////////////Retreiveing the employee props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    p = new employee();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Name = Convert.ToString(dr["Name"]);
                    p.Access = Convert.ToInt32(dr["Access"]);
                    p.Email = Convert.ToString(dr["Email"]);
                    p.Password = Convert.ToString(dr["Password"]);
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
        /// This Functions get employee by ID
        /// </summary>   
        public employee get_employee_byMail(String EEmail)
        {
            employee p = new employee();

            try
            {
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("get_employee_byMail", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EEmail", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = EEmail;
                //////////////////Retreiveing the employee props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    p = new employee();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Name = Convert.ToString(dr["Name"]);
                    p.Access = Convert.ToInt32(dr["Access"]);
                    p.Email = Convert.ToString(dr["Email"]);
                    p.Password = Convert.ToString(dr["Password"]);
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
        /// This Functions add a employee
        /// </summary>  
        public void add_employee(employee p)
        {
            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("add_employee", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = p.Name;
                commdel.Parameters.Add("EAccess", MySqlDbType.Int32);
                commdel.Parameters[1].Value = p.Access;
                commdel.Parameters.Add("EEmail", MySqlDbType.VarChar);
                commdel.Parameters[2].Value = p.Email; 
                commdel.Parameters.Add("EPassword", MySqlDbType.VarChar);
                commdel.Parameters[3].Value = p.Password;                
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
        /// This Functions remove a employee
        /// </summary>  
        public void delete_employee(int EID)
        {

            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("delete_employee", Connection.conn);
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
        /// This Functions edit a employee
        /// </summary>  
        public void edit_employee(employee p)
        {

            try
            {
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("edit_employee", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////Get Parameters///////////////////////
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = p.ID;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = p.Name;
                commdel.Parameters.Add("EAccess", MySqlDbType.Int32);
                commdel.Parameters[2].Value = p.Access;
                commdel.Parameters.Add("EEmail", MySqlDbType.VarChar);
                commdel.Parameters[3].Value = p.Email; 
                commdel.Parameters.Add("EPassword", MySqlDbType.VarChar);
                commdel.Parameters[4].Value = p.Password;               
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