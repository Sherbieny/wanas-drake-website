using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WDI.DB_Layer;
using WDI.Service_Layer;

public partial class ProjectView : System.Web.UI.Page
{
    projectServices Ps = new projectServices();
    project p = new project();
    List<project> projectList = new List<project>();
    protected void Page_Load(object sender, EventArgs e)
    {
        String PID = Request.QueryString["pid"];
        int ID = Int32.Parse(PID);
        displayContainer(ID);
    }

    public void displayContainer(int id)
    {
        ////Getting category List
        projectList = Ps.get_project_by_category(id);

        ////Initializing Row Div        
        try
        {
            ////Populating category on Page
            for (int i = 0; i < projectList.Count; i++)
            {
                ////Initializing all Column elements
                HtmlGenericControl blog_post;                
                Image img_color;
                HtmlGenericControl hover_blog_div;
                HtmlGenericControl anchor_post;
                HtmlGenericControl i_anchor;
                HtmlGenericControl hover_content_div;
                HtmlGenericControl anchor;
                HtmlGenericControl post_head_div;
                HtmlGenericControl h2_title;
                HtmlGenericControl span_subtitle;
                HtmlGenericControl p_small_description;

                ////Creating all Column elements

                blog_post = new HtmlGenericControl("div");                                                                
                img_color = new Image();
                hover_blog_div = new HtmlGenericControl("div");
                anchor_post = new HtmlGenericControl("a");
                i_anchor = new HtmlGenericControl("i");
                hover_content_div = new HtmlGenericControl("div");
                anchor = new HtmlGenericControl("a");
                post_head_div = new HtmlGenericControl("div");
                h2_title = new HtmlGenericControl("h2");
                span_subtitle = new HtmlGenericControl("span");
                p_small_description = new HtmlGenericControl("p");

                ////Add category values into elements created above                
                blog_post.Attributes.Add("class", "blog-post");                                                                
                img_color.ImageUrl = "~/images/" + projectList[i].Main_Pic_Path;
                img_color.Attributes.Add("class", "img-responsive");
                hover_blog_div.Attributes.Add("class", "hover-blog");
                anchor_post.Attributes.Add("class", "post-type");
                anchor_post.Attributes.Add("href", "ProjectSingleView.aspx?pid=" + projectList[i].ID + "");
                i_anchor.Attributes.Add("class", "fa fa-link");
                hover_content_div.Attributes.Add("class", "hover-content");
                anchor.Attributes.Add("class", "link-tag");
                anchor.Attributes.Add("href", "ProjectSingleView.aspx?pid=" + projectList[i].ID + "");
                post_head_div.Attributes.Add("class", "post-head");
                h2_title.InnerText = projectList[i].Name;
                span_subtitle.InnerText = projectList[i].Location;
                p_small_description.InnerText = projectList[i].Small_Description;

                /////////////////////////////////////////////////////////

                //add elements into their parents until Columns
                post_head_div.Controls.Add(h2_title);
                post_head_div.Controls.Add(span_subtitle);
                hover_content_div.Controls.Add(anchor);
                hover_content_div.Controls.Add(post_head_div);
                hover_content_div.Controls.Add(p_small_description);
                anchor_post.Controls.Add(i_anchor);
                hover_blog_div.Controls.Add(anchor_post);
                hover_blog_div.Controls.Add(hover_content_div);
                blog_post.Controls.Add(img_color);
                blog_post.Controls.Add(hover_blog_div);
                   
                //Adding the data into the container
                mainContainer.Controls.Add(blog_post);
                
                
            }
            ////Binding Data into the container
            mainContainer.DataBind();    
            
        }

        catch (Exception ee)
        {
            throw ee;
        }
    }
  
}