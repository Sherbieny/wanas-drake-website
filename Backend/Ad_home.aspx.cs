using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WDI.DB_Layer;
using WDI.Service_Layer;


public partial class Ad_home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            employee emp = (employee)Session["User"];

            if (emp == null)
            {
                Response.Redirect("~/Backend/Ad_register.aspx");
            }            
            else if (emp.Access == 1)
            {
                employeesPage.Visible = false;
                employeesPage2.Visible = false;
                employeesPage3.Visible = false;
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }
}