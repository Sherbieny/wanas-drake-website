using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WDI.DB_Layer;
using WDI.Service_Layer;

public partial class Backend_Ad_employees : System.Web.UI.Page
{
    List<employee> employeeList;
    employeeServices Es;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Es = new employeeServices();
            employeeList = new List<employee>();

            employee emp = (employee)Session["User"];
            if (emp == null)
            {
                Response.Redirect("~/Backend/Ad_register.aspx");
            }
            else if (emp.Access == 1)
            {
                Session.Remove("User");
                Response.Redirect("~/Backend/Ad_register.aspx");
            }

            if (Session["itemID"] != null && Page.IsPostBack)
            {
                
            }
            else if (!Page.IsPostBack)
            {
                Session["itemID"] = null;
                InitializeAccessList();
            }

            DisplayTable();
            
        }
        catch (Exception ee)
        {
            throw ee;
        }

    }



    protected void InitializeAccessList()
    {
        list_access_type.Items.Clear();
        list_access_type.Items.Add(new ListItem("Open to Choose", "-1"));
        list_access_type.Items.Add(new ListItem("Administrator", "0"));
        list_access_type.Items.Add(new ListItem("Limited User", "1"));       
    }

    /// <summary>
    /// This Function Displays all the categories existing in the DB 
    /// </summary>
    protected void DisplayTable()
    {

        //Clearing the grid
        thegrid.DataSource = null;
        thegrid.DataBind();
        //Declaring n initializing needed variable
        System.Data.DataTable dt = new System.Data.DataTable();

        

        employeeList = Es.get_all_employee();
        //Adding Columns header to the Datatable
        dt.Columns.Add("ID");
        dt.Columns.Add("Name");
        dt.Columns.Add("Email");
        dt.Columns.Add("Access");

        String accessType = "";

        //Filling in the Data

        for (int i = 0; i < employeeList.Count; i++)
        {
            if (employeeList[i].Access == 0)
                accessType = "Administrator";
            else
                accessType = "Limited User";
            dt.Rows.Add(employeeList[i].ID, employeeList[i].Name, employeeList[i].Email, accessType);
        }
        //Binding the DataTable to the GridView "TheGrid"
        thegrid.DataSource = dt;
        thegrid.DataBind();
    }

    protected void select_item(object sender, EventArgs e)
    {
        try
        {
            int x = Int32.Parse(thegrid.Rows[thegrid.SelectedIndex].Cells[0].Text);

            Session["itemID"] = Es.get_employee_byID(x).ID;
            ShowData();

        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void ShowData()
    {
        employee x = new employee();
        x = Es.get_employee_byID(Int32.Parse(Session["itemID"].ToString()));
        txt_employee_name.Text = x.Name;
        txt_employee_email.Text = x.Email;
        txt_employee_pass.Text = x.Password;
        list_access_type.SelectedValue = x.Access.ToString();
        editPanel.Visible = true;                
        editButton.Visible = true;

    }

    protected void edit_employee()
    {
        try
        {
            employee x = new employee();            
            employeeList = Es.get_all_employee();            

            x.ID = Int32.Parse(Session["ItemID"].ToString());            
            x.Name = txt_employee_name.Text;
            x.Email = txt_employee_email.Text;
            x.Access = Int32.Parse(list_access_type.Items[list_access_type.SelectedIndex].Value);
            if (txt_employee_pass.Text != "")
            {
                x.Password = txt_employee_pass.Text;
            }
            else 
            { 
            x.Password = Es.get_employee_byID(x.ID).Password;
            }

            Es.edit_employee(x);
            txt_employee_name.Text = "";
            txt_employee_email.Text = "";
            txt_employee_pass.Text = "";
            editPanel.Visible = false;                        
            editButton.Visible = false;
            Session.Remove("itemID");
            DisplayTable();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update Successfull')", true);
            thegrid.SelectedRowStyle.Reset();
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }       

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        edit_employee();
    }

    protected void delete_item(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int x = Int32.Parse(thegrid.Rows[e.RowIndex].Cells[0].Text);
            Es.delete_employee(x);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item Deleted')", true);
            txt_employee_name.Text = "";
            txt_employee_email.Text = "";            
            editButton.Visible = false;           
            editPanel.Visible = false;
            DisplayTable();
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void btn_Cancel_Click(Object sender, EventArgs e)
    {
        Session.Remove("itemID");
        Response.Redirect("~/Backend/Ad_employees.aspx");
    }
}