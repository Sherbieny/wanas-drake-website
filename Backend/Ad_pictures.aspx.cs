using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WDI.DB_Layer;
using WDI.Service_Layer;
public partial class Backend_Ad_pictures : System.Web.UI.Page
{

    List<project> projectList;
    projectServices Ps;
    List<picture> pictureList;
    pictureServices Is;
    List<category> categoryList;
    categoryServices Cs;
    
    protected void Page_Load(object sender, EventArgs e)
    {        
        try
        {
            Ps = new projectServices();
            projectList = new List<project>();
            Is = new pictureServices();
            pictureList = new List<picture>();
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
        inputPanel.Visible = false;
        mainPanel.Visible = false;
        gridTable.Visible = true;
        pictureTable.Visible = false;
        DisplayTable();                
    }
    protected void InitializeCategoryList()
    {
        initial_category_list.Items.Clear();
        initial_category_list.Items.Add(new ListItem("Open to Choose", "-1"));
        categoryList = Cs.get_all_categories();

        for(int i = 0; i < categoryList.Count; i++)
        {            
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
        project x = new project();                

        //Adding Columns header to the Datatable
        dt.Columns.Add("ID");
        dt.Columns.Add("Name");        
        dt.Columns.Add("Pic_Count");
        //Filling in the Data



        for (int i = 0; i < projectList.Count; i++)
        {
            x = projectList[i];
            pictureList = Is.get_picture_byProject(x.ID);
            //Counting the pictures in the project

            dt.Rows.Add(projectList[i].ID, projectList[i].Name, pictureList.Count);            
        }
        //Binding the DataTable to the GridView "thegrid"
        thegrid.DataSource = dt;
        thegrid.DataBind();
    }

    protected void select_item(object sender, EventArgs e)
    {
        try
        {
            int x = Int32.Parse(thegrid.Rows[thegrid.SelectedIndex].Cells[0].Text);            
            Session["itemID"] = Ps.get_project_byID(x).ID;            
            ShowData();            
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void ShowData(){
            
        DisplayPicturesTable();
        
        categoryChoicePanel.Visible = false;
        inputPanel.Visible = true;
        mainPanel.Visible = true;
        gridTable.Visible = false;
        pictureTable.Visible = true;

    }

    protected void DisplayPicturesTable()
    {
        //Clearing the grid
        picgrid.DataSource = null;
        picgrid.DataBind();
        //Declaring n initializing needed variable
        System.Data.DataTable dt = new System.Data.DataTable();

        //Choosing the pictures by project      
        project x = new project();

        x = Ps.get_project_byID(Int32.Parse(Session["itemID"].ToString()));

        pictureList = Is.get_picture_byProject(x.ID);
                        

        //Adding Columns header to the Datatable
        dt.Columns.Add("ID");
        dt.Columns.Add("Name");
        dt.Columns.Add("PictureUrl");
        //Filling in the Data



        for (int i = 0; i < pictureList.Count; i++)
        {            
            dt.Rows.Add(pictureList[i].ID, x.Name, "~/images/" + pictureList[i].Picture_Path);
        }
        //Binding the DataTable to the GridView "picgrid"
        picgrid.DataSource = dt;
        picgrid.DataBind();
    }


    //protected void view_item(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int x = Int32.Parse(picgrid.Rows[picgrid.SelectedIndex].Cells[0].Text);

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
    
    protected void add_picture()
    {
        try{

            project x = new project();
            picture p = new picture();            

            x = Ps.get_project_byID(Int32.Parse(Session["itemID"].ToString()));
            pictureList = Is.get_picture_byProject(x.ID);

            p.Project_ID = x.ID;                                         
            
            //Check existince                        
            bool existFlag = false;

            for (int i = 0; i < pictureList.Count; i++)
            {
                if (pictureList[i].Picture_Path == p.Picture_Path)
                    existFlag = true;
            }

            if (!existFlag)
            {

                p.Picture_Path = saveFiles(FileUpload0);              
                if(p.Picture_Path == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload Pictures')", true);
                    return;
                }

                Is.add_picture(p);                                             
                DisplayPicturesTable();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update Successfull')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('File name exists')", true);
                return;
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
            int x = Int32.Parse(picgrid.Rows[e.RowIndex].Cells[0].Text);
            Is.delete_picture(x);            
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item Deleted')", true);            
            DisplayPicturesTable();
            addButton.Visible = true;            
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void clearFields()
    {
       
        initial_category_list.SelectedValue = "-1";
        picgrid.SelectedRowStyle.Reset();

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
    
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        add_picture();
    }

    protected void btn_Cancel_Click(Object sender, EventArgs e)
    {
        Session.Remove("itemID");
        Response.Redirect("~/Backend/Ad_pictures.aspx");
    }

}