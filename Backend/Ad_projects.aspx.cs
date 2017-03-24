using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WDI.DB_Layer;
using WDI.Service_Layer;

public partial class Ad_projects : System.Web.UI.Page
{
   List<project> projectList;
   projectServices Ps;
   List<category> categoryList;
   categoryServices Cs;
   employeeServices Es;
        
   public int status;

   employee emp;
    protected void Page_Load(object sender, EventArgs e)
    {        
        try
        {
            Ps = new projectServices();
            projectList = new List<project>();
            Cs = new categoryServices();
            categoryList = new List<category>();

            if (!Page.IsPostBack)
            {
                InitializeCategoryList();
                Session["itemID"] = null;
                            
                
            }            
            if(Session["itemID"] != null && !Page.IsPostBack)
            {
               
            }

            else
            {
                categoryChoicePanel.Visible = true;
            }

           
        }
        catch (Exception ee)
        {
            throw ee;
        }       
    }

    protected void getTable(object sender, EventArgs e)
    {
        DisplayTable();
        clearFields();
        mainPanel.Visible = true;
    }
    protected void InitializeCategoryList()
    {
        list_project_category.Items.Clear();
        list_project_category.Items.Add(new ListItem("Open to Choose", "-1"));
        categoryList = Cs.get_all_categories();

        for(int i = 0; i < categoryList.Count; i++)
        {
            list_project_category.Items.Add(new ListItem(categoryList[i].Name, "" + categoryList[i].ID));
            initial_category_list.Items.Add(new ListItem(categoryList[i].Name, "" + categoryList[i].ID));
        }
    }
    protected void DisplayTable()
    {

        //Clearing the grid
        thegrid.DataSource = null;
        thegrid.DataBind();
        //Declaring n initializing needed variable
        System.Data.DataTable dt = new System.Data.DataTable();

        //Choosing the projects by category      
        int categoryID = Int32.Parse(initial_category_list.SelectedItem.Value);
        projectList = Ps.get_project_by_category(categoryID);
        category c = new category();
        c = Cs.get_category_byID(categoryID);
        String categoryName = c.Name;

        //Adding Columns header to the Datatable
        dt.Columns.Add("ID");
        dt.Columns.Add("Name");
        dt.Columns.Add("Category");
        dt.Columns.Add("Description");
        dt.Columns.Add("Main_Pic_Path");
        dt.Columns.Add("Location");
        dt.Columns.Add("Total_Area");
        dt.Columns.Add("BuiltUp_Area");
        dt.Columns.Add("Small_Description");
        //Filling in the Data

        for (int i = 0; i < projectList.Count; i++)
        {
            dt.Rows.Add(projectList[i].ID, projectList[i].Name, categoryName, projectList[i].Descrition,
                projectList[i].Main_Pic_Path, projectList[i].Location, projectList[i].Total_Area,
                projectList[i].BuiltUp_Area, projectList[i].Small_Description);
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
            Session["itemID"] = Ps.get_project_byID(x).ID;
            status = 1;
            ShowData();
            

        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void ShowData()
    {
        project x = new project();

        x = Ps.get_project_byID(Int32.Parse(Session["itemID"].ToString()));
        
        txt_builtup_area.Text = x.BuiltUp_Area;
        txt_project_description.Text = x.Descrition;
        txt_project_small_description.Text = x.Small_Description;
        txt_project_location.Text = x.Location;        
        txt_project_name_add.Text = x.Name;
        txt_total_area.Text = x.Total_Area;
        list_project_category.SelectedValue = x.Category.ToString();

        categoryChoicePanel.Visible = false;
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

    //        Session["itemID"] = Ps.get_project_byID(x).ID;
    //        ViewData();

    //    }
    //    catch (Exception ee)
    //    {
    //        throw ee;
    //    }
    //}

    //protected void ViewData()
    //{
    //    project x = new project();
    //    x = Ps.get_project_byID(Int32.Parse(Session["itemID"].ToString()));
    //    txt_project_name_add.Text = x.Name;
    //    editPanel.Visible = true;
    //    inputPanel.Visible = false;

    //}    
    
    protected void edit_project()
    {
        try
        {
            project x = new project();
            projectList = Ps.get_all_projects();
            categoryList = Cs.get_all_categories();
            x.ID = Int32.Parse(Session["ItemID"].ToString());
            x.Name = txt_project_name_add.Text;
            x.Location = txt_project_location.Text;
            x.BuiltUp_Area = txt_builtup_area.Text;
            x.Descrition = txt_project_description.Text;
            x.Small_Description = txt_project_small_description.Text;
            x.Total_Area = txt_total_area.Text;
            x.Category = Int32.Parse(list_project_category.SelectedItem.Value);
                                   

            x.Main_Pic_Path = saveFiles(main_project_pic_path);
            if(x.Main_Pic_Path == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload Pictures')", true);
                return;
            }

            Ps.edit_project(x);
            clearFields();
            btn_save.Visible = false;
            btn_cancel.Visible = false;
            btn_submit.Visible = true;
            categoryChoicePanel.Visible = true;
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
    protected void add_project()
    {
        try{
        
            project x = new project();
            projectList = Ps.get_all_projects();
            categoryList = Cs.get_all_categories();            
            x.Name = txt_project_name_add.Text;
            x.Location = txt_project_location.Text;
            x.BuiltUp_Area = txt_builtup_area.Text;
            x.Descrition = txt_project_description.Text;
            x.Small_Description = txt_project_small_description.Text;
            x.Total_Area = txt_total_area.Text;
            x.Category = Int32.Parse(list_project_category.SelectedItem.Value);
            
            //Check existince                        
            bool existFlag = false;

            for (int i = 0; i < projectList.Count; i++)
            {
                if (projectList[i].Name == x.Name)
                    existFlag = true;
            }

            if (!existFlag)
            {
                x.Main_Pic_Path = saveFiles(main_project_pic_path);  

                if(x.Main_Pic_Path == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload Pictures')", true);
                    return;
                }                              

                if (Int32.Parse(list_project_category.SelectedItem.Value) == -1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Choose a Category')", true);
                    return;
                }


                Ps.add_project(x);
                clearFields();                                
                DisplayTable();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update Successfull')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('project Name Exists')", true);
                txt_project_name_add.Text = "";
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void delete_item(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int x = Int32.Parse(thegrid.Rows[e.RowIndex].Cells[0].Text);
            Ps.delete_project(x);
            clearFields();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item Deleted')", true);
            DisplayTable();
            addButton.Visible = true;
            editButton.Visible = false;
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void clearFields()
    {
        txt_builtup_area.Text = "";
        txt_project_description.Text = "";
        txt_project_small_description.Text = "";
        txt_project_location.Text = "";
        txt_project_name_add.Text = "";        
        txt_total_area.Text = "";
        list_project_category.SelectedValue = "-1";
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
        project x;
        x = Ps.get_project_byID(Int32.Parse(Session["itemID"].ToString()));
        if (String.IsNullOrEmpty(ctr.PostedFile.FileName))
            return "";
        try
        {
            Random unique = new Random();
            int number = unique.Next();
            //Attach a file
            //creating a timestamp for the file
            String FinalPath = "";
            System.IO.FileInfo File;
            // String FileName = "";

            //Getting the name of the files
            File = new System.IO.FileInfo(ctr.PostedFile.FileName);
            //Deciding the final path
            FinalPath = "" + x.Name + number + File.Name;

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
                        ctr.SaveAs(Server.MapPath("~/images/" + FinalPath));
                        return FinalPath;
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
        //Inserts a new project
        add_project();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        edit_project();
    }

    protected void btn_Cancel_Click(Object sender, EventArgs e)
    {
        Session.Remove("itemID");
        Response.Redirect("~/Backend/Ad_projects.aspx");
    }

    //protected void BindData(Object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton x = (LinkButton)e.Row.FindControl("DLinkButton2");
    //        if (emp.Access == 1)
    //            x.Visible = false;
    //    }
    //}
}