using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WDI.DB_Layer;
using WDI.Service_Layer;

public partial class Personnel : System.Web.UI.Page
{
    personnelServices Ps = new personnelServices();
    public List<person> personList;
    protected void Page_Load(object sender, EventArgs e)
    {
        displayContainer();
    }

    public void displayContainer()
    {
        ////Getting Personnel List
        personList = Ps.get_all_person();       
        
        ////Initializing Row Div
        HtmlGenericControl row_div;
        HtmlGenericControl rowCompany_div;
       
        try
        {                

            ////Populating Personnel on Page
            for (int i = 0; i < personList.Count; i++)
            {
                //Create New Row that takes 4 Columns
                row_div = new HtmlGenericControl("div"); 
                row_div.Attributes.Add("class", "row");
                rowCompany_div = new HtmlGenericControl("div");
                rowCompany_div.Attributes.Add("class", "row");

                //Create 4 Columns per Row
                for (int j = 0; j < 4 && i < personList.Count; j++)
                {
                    /////Checking if its a person or a company
                    if (personList[i].Type == 0)
                    {
                        ////Creating the Column and adding the info
                        addPersonInfo(row_div, personList[i]);
                        //Incrementing outer counter to move the list
                        i++;
                    }
                    else
                    {
                        ////Creating the Column and adding the info
                        addCompanyInfo(rowCompany_div, personList[i]);
                        //Incrementing outer counter to move the list
                        i++;
                    }                                                            
                }               
                //Decrementing the outer counter 1 step back to prevent the additional count as it exists the innerloop
                i--;
                
                ////Adding the newly created row into the container
                mainPersonContainer.Controls.Add(row_div);
                mainCompanyContainer.Controls.Add(rowCompany_div);
            }
               ////Binding Data into the container
            mainPersonContainer.DataBind();
            mainCompanyContainer.DataBind();
        }

        catch(Exception ee)
        {
            throw ee;
        }
    }

    public void addPersonInfo(HtmlGenericControl parent, person p)
    {

        ////Initializing all Column elements
        HtmlGenericControl col_div;
        HtmlGenericControl team_post_div;
        Image img;
        HtmlGenericControl team_hover_div;
        HtmlGenericControl h2_title;
        HtmlGenericControl span_subtitle;
        HtmlGenericControl ul_list;
        HtmlGenericControl li_list;
        HtmlGenericControl anchor;
        HtmlGenericControl i_anchor;

        ////Creating all Column elements
        col_div = new HtmlGenericControl("div");
        team_post_div =  new HtmlGenericControl("div");
        img = new Image();
        team_hover_div  = new HtmlGenericControl("div");
        h2_title = new HtmlGenericControl("h2");
        span_subtitle = new HtmlGenericControl("span");
        ul_list = new HtmlGenericControl("ul");
        li_list = new HtmlGenericControl("li");
        anchor = new HtmlGenericControl("a");
        i_anchor  = new HtmlGenericControl("i");

        ////Add Person values into elements created above                
        col_div.Attributes.Add("class", "col-md-3");                
        team_post_div.Attributes.Add("class", "team-post");
        img.ImageUrl = "~/images/" + p.Pic_Path;
        img.Attributes.Add("class", "img-responsive");                
        team_hover_div.Attributes.Add("class", "team-hover");                
        h2_title.InnerText = p.Name;                
        span_subtitle.InnerText = p.Title;                
        ul_list.Attributes.Add("class", "team-social");
        anchor.Attributes.Add("href", "PersonnelView.aspx?pid=" + p.ID + "");                  
        i_anchor.Attributes.Add("class", "fa fa-plus");

        /////////////////////////////////////////////////////////

        //add elements into their parents until Columns
        anchor.Controls.Add(i_anchor);
        li_list.Controls.Add(anchor);
        ul_list.Controls.Add(li_list);
        team_hover_div.Controls.Add(h2_title);
        team_hover_div.Controls.Add(span_subtitle);
        team_hover_div.Controls.Add(ul_list);
        team_post_div.Controls.Add(img);
        team_post_div.Controls.Add(team_hover_div);
        col_div.Controls.Add(team_post_div);

        //Adding the 4 columns into the main Row container        
        parent.Controls.Add(col_div);
    }

    public void addCompanyInfo(HtmlGenericControl parent, person p)
    {

        ////Initializing all Column elements
        HtmlGenericControl col_div;
        HtmlGenericControl team_post_div;
        Image img;
        HtmlGenericControl team_hover_div;
        HtmlGenericControl h2_title;
        HtmlGenericControl span_subtitle;
        HtmlGenericControl ul_list;
        HtmlGenericControl li_list;
        HtmlGenericControl anchor;
        HtmlGenericControl i_anchor;

        ////Creating all Column elements
        col_div = new HtmlGenericControl("div");
        team_post_div = new HtmlGenericControl("div");
        img = new Image();
        team_hover_div = new HtmlGenericControl("div");
        h2_title = new HtmlGenericControl("h2");
        span_subtitle = new HtmlGenericControl("span");
        ul_list = new HtmlGenericControl("ul");
        li_list = new HtmlGenericControl("li");
        anchor = new HtmlGenericControl("a");
        i_anchor = new HtmlGenericControl("i");

        ////Add Person values into elements created above                
        col_div.Attributes.Add("class", "col-md-3");
        team_post_div.Attributes.Add("class", "team-post");
        img.ImageUrl = "~/images/" + p.Pic_Path;
        img.Attributes.Add("class", "img-responsive");
        team_hover_div.Attributes.Add("class", "team-hover");
        h2_title.InnerText = p.Name;
        span_subtitle.InnerText = p.Title;
        ul_list.Attributes.Add("class", "team-social");
        anchor.Attributes.Add("href", "PersonnelView.aspx?pid=" + p.ID + "");
        anchor.Attributes.Add("target", "_blank");
        i_anchor.Attributes.Add("class", "fa fa-plus");

        /////////////////////////////////////////////////////////

        //add elements into their parents until Columns
        anchor.Controls.Add(i_anchor);
        li_list.Controls.Add(anchor);
        ul_list.Controls.Add(li_list);
        team_hover_div.Controls.Add(h2_title);
        team_hover_div.Controls.Add(span_subtitle);
        team_hover_div.Controls.Add(ul_list);
        team_post_div.Controls.Add(img);
        team_post_div.Controls.Add(team_hover_div);
        col_div.Controls.Add(team_post_div);

        //Adding the 4 columns into the main Row container        
        parent.Controls.Add(col_div);
    }        
}