using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WDI.DB_Layer;
using WDI.Service_Layer;

public partial class Ad_categories : System.Web.UI.Page
{
    List<category> CategoryList;
    categoryServices Cs;
     
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Cs = new categoryServices();
            CategoryList = new List<category>();

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
            }
            
            DisplayTable();
        }
        catch(Exception ee)
        {
            throw ee;
        }

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



        CategoryList = Cs.get_all_categories();
        //Adding Columns header to the Datatable
        dt.Columns.Add("ID");
        dt.Columns.Add("Name");
        dt.Columns.Add("Pic_Path");
        //Filling in the Data

        for (int i = 0; i < CategoryList.Count; i++)
        {
            dt.Rows.Add(CategoryList[i].ID, CategoryList[i].Name, "~/images/" + CategoryList[i].Pic_Path);
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

            Session["itemID"] = Cs.get_category_byID(x).ID;
            ShowData();

        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void ShowData()
    {
        category x = new category();
        x = Cs.get_category_byID(Int32.Parse(Session["itemID"].ToString()));
        txt_category_name_edit.Text = x.Name;
        editPanel.Visible = true;
        inputPanel.Visible = false;
        addButton.Visible = false;
        editButton.Visible = true;
        
    }  

    protected void edit_category()
    {
        try
        {
            category x = new category();
            CategoryList = Cs.get_all_categories();
            x.ID = Int32.Parse(Session["ItemID"].ToString());
            x.Name = txt_category_name_edit.Text;

            x.Pic_Path = saveFiles(edit_pic_path);

            if (x.Pic_Path == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload Picture')", true);
                return;
            }
            Cs.edit_category(x);
            txt_category_name_edit.Text = "";
            thegrid.SelectedRowStyle.Reset();
            editPanel.Visible = false;
            inputPanel.Visible = true;
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
    protected void add_category()
    {
        try
        {
            category x = new category();

            x.Name = txt_category_name_add.Text;

            bool existFlag = false;

            for (int i = 0; i < CategoryList.Count; i++)
            {
                if (CategoryList[i].Name == x.Name)
                    existFlag = true;
            }

            if(!existFlag)
            {
                x.Pic_Path = saveFiles(pic_path);

                if (x.Pic_Path == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload Picture')", true);
                    return;
                }
                Cs.add_category(x);
                DisplayTable();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Add Successfull')", true);
                txt_category_name_add.Text = "";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Category Name Exists')", true);
            }

        }
        catch(Exception ee)
        {
            throw ee;
        }
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
        //Inserts a new Category
        add_category();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        edit_category();
    }

    protected void delete_item(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int x = Int32.Parse(thegrid.Rows[e.RowIndex].Cells[0].Text);
            Cs.delete_category(x);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item Deleted')", true);
            txt_category_name_edit.Text = "";
            addButton.Visible = true;
            editButton.Visible = false;
            inputPanel.Visible = true;
            editPanel.Visible = false;
            thegrid.SelectedRowStyle.Reset();
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
        Response.Redirect("~/Backend/Ad_categories.aspx");
    }
 
}