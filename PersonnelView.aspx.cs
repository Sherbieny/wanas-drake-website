using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WDI.DB_Layer;
using WDI.Service_Layer;

public partial class PersonnelView : System.Web.UI.Page
{

    personnelServices Ps = new personnelServices();
    person p = new person();
    protected void Page_Load(object sender, EventArgs e)
    {
        String PID = Request.QueryString["pid"];
        int ID = Int32.Parse(PID);
        displayItem(ID);
    }

    public void displayItem(int id)
    {

        ////Getting the person
        p = Ps.get_person_byID(id);

        ////Initializing the elements
        HtmlGenericControl row_div = new HtmlGenericControl("div");
        row_div.Attributes.Add("class", "row");

        HtmlGenericControl img_col_div = new HtmlGenericControl("div");
        img_col_div.Attributes.Add("class", "col-md-5");

        Image img = new Image();

        HtmlGenericControl text_img_col_div = new HtmlGenericControl("div");
        text_img_col_div.Attributes.Add("class", "col-md-4");

        HtmlGenericControl h2_title = new HtmlGenericControl("h2");
        HtmlGenericControl h3_subtitle = new HtmlGenericControl("h3");
        HtmlGenericControl p_text = new HtmlGenericControl("p");

        HtmlGenericControl img2_col_div = new HtmlGenericControl("div");
        img2_col_div.Attributes.Add("class", "col-md-3");

        Image imgSmall = new Image();

        ////Add values into elements
        img.ImageUrl = "~/images/" + p.Pic_Path;
        h2_title.InnerText = p.Name;
        h3_subtitle.InnerText = p.Title;
        p_text.InnerText = p.Description;
        imgSmall.ImageUrl = "~/images/" + p.PicSmall_Path;

        ////Adding elemnts to their parents
        text_img_col_div.Controls.Add(h2_title);
        text_img_col_div.Controls.Add(h3_subtitle);
        text_img_col_div.Controls.Add(p_text);
        img_col_div.Controls.Add(img);
        img2_col_div.Controls.Add(imgSmall);
        row_div.Controls.Add(img_col_div);
        row_div.Controls.Add(text_img_col_div);
        row_div.Controls.Add(img2_col_div);
        mainContainer.Controls.Add(row_div);
        mainContainer.DataBind();


    }
}