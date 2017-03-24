using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WDI.DB_Layer;
using WDI.Service_Layer;
public partial class Categories : System.Web.UI.Page
{
    categoryServices Cs = new categoryServices();
    public List<category> categoryList;
    protected void Page_Load(object sender, EventArgs e)
    {
        displayContainer();
    }

    public void displayContainer()
    {
        ////Getting category List
        categoryList = Cs.get_all_categories();               

        try
        {

            ////Populating category on Page
            for (int i = 0; i < categoryList.Count; i++)
            {
                //Create New Row that takes 4 Columns
                HtmlGenericControl blog_post;                
                Image img_color;
                HtmlGenericControl hover_blog_div;
                HtmlGenericControl anchor_post;
                HtmlGenericControl i_anchor;
                HtmlGenericControl hover_content_div;
                HtmlGenericControl anchor;
                HtmlGenericControl post_head_div;
                HtmlGenericControl h2_title;                

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

                blog_post.Attributes.Add("class", "blog-post");                
                img_color.ImageUrl = "~/images/" + categoryList[i].Pic_Path;
                img_color.Attributes.Add("class", "img-responsive");
                hover_blog_div.Attributes.Add("class", "hover-blog");
                anchor_post.Attributes.Add("class", "post-type");
                anchor_post.Attributes.Add("href", "ProjectView.aspx?pid=" + categoryList[i].ID + "");
                i_anchor.Attributes.Add("class", "fa fa-link");
                hover_content_div.Attributes.Add("class", "hover-content");
                anchor.Attributes.Add("class", "link-tag");
                anchor.Attributes.Add("href", "ProjectView.aspx?pid=" + categoryList[i].ID + "");
                post_head_div.Attributes.Add("class", "post-head");
                h2_title.InnerText = categoryList[i].Name;                

                /////////////////////////////////////////////////////////

                //add elements into their parents until Columns
                post_head_div.Controls.Add(h2_title);                
                hover_content_div.Controls.Add(anchor);
                hover_content_div.Controls.Add(post_head_div);
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