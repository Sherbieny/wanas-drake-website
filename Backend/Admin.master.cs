using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WDI.DB_Layer;
using WDI.Service_Layer;

public partial class Admin : System.Web.UI.MasterPage
{

    public int tempID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
            Response.Redirect("~/Backend/Ad_register.aspx");
        else
        {
            employee emp = (employee)Session["User"];
            if (emp.Access == 1)
            {
                employeesItem.Visible = false;
                employeesItem2.Visible = false;
                employeesItem3.Visible = false;
            }
                
        }
    }

    protected void log_out_Click(object sender, EventArgs e)
    {
        Session.Remove("User");
        Response.Redirect("~/Backend/Ad_register.aspx");
    }
}
