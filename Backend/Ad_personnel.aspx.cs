using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WDI.DB_Layer;
using WDI.Service_Layer;

public partial class Backend_Ad_personnel : System.Web.UI.Page
{
    List<person> personList;
    personnelServices Ps;
    


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Ps = new personnelServices();
            personList = new List<person>();

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
                initializeTypeList();
            }

            DisplayTable();
           
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }   
   
    protected void DisplayTable()
    {
        String PersonType = "";
        //Clearing the grid
        thegrid.DataSource = null;
        thegrid.DataBind();
        //Declaring n initializing needed variable
        System.Data.DataTable dt = new System.Data.DataTable();

        //Getting Personnel List      

        personList = Ps.get_all_person();                

        //Adding Columns header to the Datatable
        dt.Columns.Add("ID");
        dt.Columns.Add("Name");
        dt.Columns.Add("Title");
        dt.Columns.Add("Description");        
        dt.Columns.Add("Type");
        dt.Columns.Add("Pic_Path");
        dt.Columns.Add("PicSmall_Path");       
        //Filling in the Data

        for (int i = 0; i < personList.Count; i++)
        {

            if (personList[i].Type == 0)
                PersonType = "Person";
            else if (personList[i].Type == 1)
                PersonType = "Company";

            dt.Rows.Add(personList[i].ID, personList[i].Name, personList[i].Title, personList[i].Description,
                PersonType, personList[i].Pic_Path, personList[i].PicSmall_Path);
        }
        //Binding the DataTable to the GridView "TheGrid"
        thegrid.DataSource = dt;
        thegrid.DataBind();
    }

    protected void initializeTypeList()
    {
        list_person_type.Items.Clear();
        list_person_type.Items.Add(new ListItem("Open to Choose", "-1"));
        list_person_type.Items.Add(new ListItem("Person", "0"));
        list_person_type.Items.Add(new ListItem("Company", "1"));             

    }
    protected void select_item(object sender, EventArgs e)
    {
        try
        {
            int x = Int32.Parse(thegrid.Rows[thegrid.SelectedIndex].Cells[0].Text);
            Session["itemID"] = Ps.get_person_byID(x).ID;            
            ShowData();


        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void ShowData()
    {
        person x = new person();

        x = Ps.get_person_byID(Int32.Parse(Session["itemID"].ToString()));
        

        txt_person_name.Text = x.Name;
        txt_person_title.Text = x.Title;
        txt_person_description.Text = x.Description;        
        list_person_type.SelectedValue = x.Type.ToString();        
        
        btn_save.Visible = true;
        btn_cancel.Visible = true;
        btn_submit.Visible = false;
        addButton.Visible = false;
        editButton.Visible = true;

    }


    //protected void view_item(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int x = Int32.Parse(thegrid.Rows[thegrid.SelectedIndex].Cells[0].Text);

    //        Session["itemID"] = Ps.get_person_byID(x).ID;
    //        ViewData();

    //    }
    //    catch (Exception ee)
    //    {
    //        throw ee;
    //    }
    //}

    //protected void ViewData()
    //{
    //    person x = new person();
    //    x = Ps.get_person_byID(Int32.Parse(Session["itemID"].ToString()));
    //    txt_person_name_add.Text = x.Name;
    //    editPanel.Visible = true;
    //    inputPanel.Visible = false;

    //}    

    protected void edit_person()
    {
        try
        {
            person x = new person();
            personList = Ps.get_all_person();
       
            x.ID = Int32.Parse(Session["ItemID"].ToString());
            x.Name = txt_person_name.Text;
            x.Title = txt_person_title.Text;
            x.Description = txt_person_description.Text;

            //Checking the type
            //Checking the type 
            //if (list_person_type.SelectedItem.Value != "0" ||
            //    list_person_type.SelectedItem.Value != "1")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please choose a type')", true);
            //    return;
            //}

            x.Type = Int32.Parse(list_person_type.Items[list_person_type.SelectedIndex].Value);
            x.Pic_Path = saveFiles(person_pic_path);
            x.PicSmall_Path = saveFiles(person_picSmall_path);
            
            if (x.Pic_Path == "" || x.PicSmall_Path == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload Picture')", true);
                return;
            }
           

            Ps.edit_person(x);
            clearFields();            
            btn_save.Visible = false;
            btn_cancel.Visible = false;
            btn_submit.Visible = true;            
            addButton.Visible = true;
            editButton.Visible = false;



            Session.Remove("itemID");
            DisplayTable();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update Successfull')", true);
        }

        catch (Exception ee)
        {
            throw ee;
        }
    }
    protected void add_person()
    {
        try
        {

            person x = new person();
            personList = Ps.get_all_person();

            x.Name = txt_person_name.Text;
            x.Title = txt_person_title.Text;
            x.Description = txt_person_description.Text;

            //Checking the type 
            //if (Int32.Parse(list_person_type.Items[list_person_type.SelectedIndex].Value) != 0 ||
            //    Int32.Parse(list_person_type.Items[list_person_type.SelectedIndex].Value) != 1)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please choose a type')", true);
            //    return;
            //}

            x.Type = Int32.Parse(list_person_type.SelectedItem.Value);

            //Check existince                        
            bool existFlag = false;

            for (int i = 0; i < personList.Count; i++)
            {
                if (personList[i].Name == x.Name)
                    existFlag = true;
            }

            if (!existFlag)
            {

                x.Pic_Path = saveFiles(person_pic_path);
                x.PicSmall_Path = saveFiles(person_picSmall_path);
                if (x.Pic_Path == "" || x.PicSmall_Path == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload Picture')", true);
                    return;
                }

                Ps.add_person(x);
                clearFields();
                DisplayTable();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Addition Successfull')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('person Name Exists')", true);
                txt_person_name.Text = "";
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void clearFields()
    {
        txt_person_name.Text = "";
        txt_person_title.Text = "";
        txt_person_description.Text = "";
        list_person_type.Items.Clear();
        initializeTypeList();
        thegrid.SelectedRowStyle.Reset();
    }

    /// <summary>
    /// This function save the files to the File System
    /// </summary>
    /// <param name="ctr"></param>
    /// <param name="ToolName"></param>
    /// <param name="img"></param>
    /// <param name="check"></param>
    /// <returns></returns>
    public String saveFiles(FileUpload ctr)
    {
        if (String.IsNullOrEmpty(ctr.PostedFile.FileName))
            return "";
        try
        {
            //Attach a file
            //creating a timestamp for the file
            String FinalPath = "";
            System.IO.FileInfo File;
            // String FileName = "";

            //Getting the name of the files
            File = new System.IO.FileInfo(ctr.PostedFile.FileName);
            //Deciding the final path
            FinalPath = "images/" + File.Name;
            if (ctr.HasFile || String.IsNullOrEmpty(ctr.PostedFile.FileName))
            {
                try
                {
                    //Check file size 
                    int FileSize = ctr.PostedFile.ContentLength;
                    int MaxFileSize = 5;
                    if (FileSize > (MaxFileSize * 1048576)) //5 MB file length
                    {
                        //MaxAttachmentSizeLabel.Text = "File Size is too large; Maximum file size permitted is 5 MB";
                        //MaxAttachmentSizeLabel.Visible = true;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('File to big - max size is 5MB')", true);
                        return "";
                    }
                    else
                    {
                        ctr.SaveAs(Server.MapPath("~/" + FinalPath));
                        return File.Name;
                    }

                }
                catch (Exception er)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error Uploading File !! Please contact Administrator')", true);
                    return "";
                }
            }

        }

        catch (Exception er)
        {
            return "";
        }
        return "";
    }


    protected void btn_Insert_Click(object sender, EventArgs e)
    {
        //Inserts a new person
        add_person();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        edit_person();
    }

    protected void btn_Cancel_Click(Object sender, EventArgs e)
    {
        Session.Remove("itemID");
        Response.Redirect("~/Backend/Ad_personnel.aspx");
    }
    protected void delete_item(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int x = Int32.Parse(thegrid.Rows[e.RowIndex].Cells[0].Text);
            Ps.delete_person(x);            
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item Deleted')", true);
            clearFields();
            Session.Remove("itemID");
            DisplayTable();
            addButton.Visible = true;
            editButton.Visible = false;
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }
}