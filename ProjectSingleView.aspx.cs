using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WDI.DB_Layer;
using WDI.Service_Layer;


public partial class ProjectSingleView : System.Web.UI.Page
{
    project pro = new project();
    projectServices Ps = new projectServices();
    List<project> projectList = new List<project>();
    List<picture> pictureList = new List<picture>();
    pictureServices PicS = new pictureServices();
    protected void Page_Load(object sender, EventArgs e)
    {
        String PID = Request.QueryString["pid"];
        int ID = Int32.Parse(PID);
        displayIndicators(ID);
        displayWrapper(ID);
    }

    public void displayIndicators(int id)
    {
        HtmlGenericControl li = new HtmlGenericControl("li");
        

        pictureList = PicS.get_picture_byProject(id);

        for (int i = 0; i < pictureList.Count; i++)
        {
            li = new HtmlGenericControl("li");
            if(i == 0)
            {
                li.Attributes.Add("class", "active");
            }
            li.Attributes.Add("data-target", "#carousel-example-generic");
            li.Attributes.Add("data-slide-to", ""+i);
            //li.InnerText = "data-target='#carousel-example-generic' data-slide-to='" + i + "'";
            indicators.Controls.Add(li);
        }


        indicators.DataBind();
    }

    public void displayWrapper (int id) 
    {
        HtmlGenericControl itemDiv = new HtmlGenericControl("div");
        Image img = new Image();
        HtmlGenericControl capDiv = new HtmlGenericControl("div");

        HtmlGenericControl p = new HtmlGenericControl("p");
        HtmlGenericControl span_PName = new HtmlGenericControl("span");
        HtmlGenericControl span_PLocation = new HtmlGenericControl("span");
        HtmlGenericControl span_PTArea = new HtmlGenericControl("span");
        HtmlGenericControl span_PBArea = new HtmlGenericControl("span");
        HtmlGenericControl span_PDesc = new HtmlGenericControl("span");

        HtmlGenericControl span_PName1 = new HtmlGenericControl("span");
        HtmlGenericControl span_PLocation1 = new HtmlGenericControl("span");
        HtmlGenericControl span_PTArea1 = new HtmlGenericControl("span");
        HtmlGenericControl span_PBArea1 = new HtmlGenericControl("span");
        HtmlGenericControl span_PDesc1 = new HtmlGenericControl("span");        

       
        //////////////////////////////////////////////////////
        pro = Ps.get_project_byID(id);
        pictureList = PicS.get_picture_byProject(id);

        for(int i = 0; i<pictureList.Count; i++)
        {
            itemDiv = new HtmlGenericControl("div");                    
            capDiv = new HtmlGenericControl("div");

            p = new HtmlGenericControl("p");
            span_PName = new HtmlGenericControl("span");
            span_PLocation = new HtmlGenericControl("span");
            span_PTArea = new HtmlGenericControl("span");
            span_PBArea = new HtmlGenericControl("span");
            span_PDesc = new HtmlGenericControl("span");

            span_PName1 = new HtmlGenericControl("span");
            span_PLocation1 = new HtmlGenericControl("span");
            span_PTArea1 = new HtmlGenericControl("span");
            span_PBArea1 = new HtmlGenericControl("span");
            span_PDesc1 = new HtmlGenericControl("span");            


            //////////////////////////////////
            if (i == 0)
            {
                itemDiv.Attributes.Add("class", "item active");
            }
            else
            {
                itemDiv.Attributes.Add("class", "item");
            }
            
            capDiv.Attributes.Add("class", "carousel-caption");
            p.Attributes.Add("style", "width:220px;");
            span_PName.Attributes.Add("style", "font-weight: bold");
            span_PLocation.Attributes.Add("style", "font-weight: bold");
            span_PTArea.Attributes.Add("style", "font-weight: bold");
            span_PBArea.Attributes.Add("style", "font-weight: bold");
            span_PDesc.Attributes.Add("style", "font-weight: bold");

            ///////////////////////////////////////////////////////////////         
            span_PName.InnerText = "Project Name: ";
            span_PName1.InnerHtml = pro.Name +"<br>";
            span_PLocation.InnerText = "Project Location: ";
            span_PLocation1.InnerHtml = pro.Location + "<br>";
            span_PTArea.InnerText = "Project Total Area: ";
            span_PTArea1.InnerHtml = pro.Total_Area + "<br>";
            span_PBArea.InnerText = "Project Built-Up Area: ";
            span_PBArea1.InnerHtml = pro.BuiltUp_Area + "<br>";
            span_PDesc.InnerText = "Project Location: ";
            span_PDesc1.InnerHtml = pro.Descrition + "<br>";


            img = new Image();
            img.ImageUrl = "~/images/" + pictureList[i].Picture_Path;            

            p.Controls.Add(span_PName);
            p.Controls.Add(span_PName1);            
            p.Controls.Add(span_PLocation);
            p.Controls.Add(span_PLocation1);            
            p.Controls.Add(span_PTArea);
            p.Controls.Add(span_PTArea1);            
            p.Controls.Add(span_PBArea);
            p.Controls.Add(span_PBArea1);            
            p.Controls.Add(span_PDesc);
            p.Controls.Add(span_PDesc1);            
            
            capDiv.Controls.Add(p);
            itemDiv.Controls.Add(img);
            itemDiv.Controls.Add(capDiv);
            Wrapper.Controls.Add(itemDiv);
        }

       
        
        ///////////////////////////////////////////////////////////////////
      
        
        Wrapper.DataBind();

    }

    //public void displaySlideShow(int id)
    //{
    //    HtmlGenericControl li = new HtmlGenericControl("li");
    //    Image img = new Image();

    //    pictureList = PicS.get_picture_byProject(id);

    //    for (int i = 0; i < pictureList.Count; i++)
    //    {
    //        li = new HtmlGenericControl("li");
    //        img = new Image();
    //        img.ImageUrl = "~/images/" + pictureList[i].Picture_Path;

    //        li.Controls.Add(img);
    //        slideShowContent.Controls.Add(li);
    //    }

        
    //    slideShowContent.DataBind();
    //}

    //public void displayDiscription(int id)
    //{
    //    p = Ps.get_project_byID(id);

    //    HtmlGenericControl p_discription = new HtmlGenericControl("p");
    //    HtmlGenericControl bold = new HtmlGenericControl("b");

    //    bold.InnerText = "" + p.Descrition;

    //    p_discription.Controls.Add(bold);
    //    descriptionContent.Controls.Add(p_discription);
    //    descriptionContent.DataBind();
    //}

    //public void displayInfo(int id)
    //{
    //    /////////GENERATING THE ELEMENTS//////////////////////////////
    //    HtmlGenericControl sidebar_div = new HtmlGenericControl("div");
    //    /////////FIRST DIV/////////////////        
    //    HtmlGenericControl post_div = new HtmlGenericControl("div");
    //    HtmlGenericControl h1_title = new HtmlGenericControl("h1");
    //    HtmlGenericControl span_subtitle = new HtmlGenericControl("p");

    //    /////////SECOND DIV/////////////////
    //    HtmlGenericControl tag_div = new HtmlGenericControl("div");
    //    HtmlGenericControl post_ul = new HtmlGenericControl("ul");
    //    HtmlGenericControl li_info1 = new HtmlGenericControl("li");
    //    HtmlGenericControl li_info2 = new HtmlGenericControl("li");
    //    HtmlGenericControl i_info1 = new HtmlGenericControl("i");
    //    HtmlGenericControl i_info2 = new HtmlGenericControl("i");
    //    HtmlGenericControl bold1 = new HtmlGenericControl("b");
    //    HtmlGenericControl bold2 = new HtmlGenericControl("b");
       

    //    /////////////////////////////////////////////////////////////////

    //    p = Ps.get_project_byID(id);
        
    //    ///////////////ADDING ATTIBUTES/////////////////////////////////


    //    sidebar_div.Attributes.Add("class", "sidebar-blog");
        
    //    ///////////FIRST DIV////////////////////////                
    //    post_div.Attributes.Add("class", "post-title");
    //    h1_title.InnerText = "" + p.Name;
    //    span_subtitle.InnerText = "" + p.Location;

    //    post_div.Controls.Add(h1_title);
    //    post_div.Controls.Add(span_subtitle);       
        
    //    /////////////SECOND DIV//////////////////////
    //    tag_div.Attributes.Add("class", "tags-widget sidebar-widget");
    //    post_ul.Attributes.Add("class", "post-tags");
    //    i_info1.Attributes.Add("class", "fa fa-info-circle");
    //    i_info2.Attributes.Add("class", "fa fa-info-circle");
    //    bold1.InnerHtml = " Total Area: " + p.Total_Area + " m&#178;";
    //    bold2.InnerHtml = " Built-up Area: " + p.BuiltUp_Area + " m&#178;";

    //    li_info1.Controls.Add(i_info1);
    //    li_info1.Controls.Add(bold1);
    //    li_info2.Controls.Add(i_info2);
    //    li_info2.Controls.Add(bold2);
    //    post_ul.Controls.Add(li_info1);
    //    post_ul.Controls.Add(li_info2);
    //    tag_div.Controls.Add(post_ul);
    //    //////////////////////////////////////////////////////////////////

    //    sidebar_div.Controls.Add(post_div);
    //    sidebar_div.Controls.Add(tag_div);

    //    infoContent.Controls.Add(sidebar_div);
    //    infoContent.DataBind();
     
    //}


}