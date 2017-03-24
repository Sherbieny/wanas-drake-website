using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WDI.DB_Layer;
using WDI.Service_Layer;
using System.Net.Mail;


public partial class Backend_Ad_register : System.Web.UI.Page
{
    employeeServices Es;
    List<employee> employeeList;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("User");
        try
        {
            Es = new employeeServices();
            employeeList = new List<employee>();
        }

        catch(Exception ee)
        {
            throw ee;
        }
    }

    protected void InsertUser()
    {

        try
        {
            //Initializing attributes
            employee newEmployee = new employee();
            employeeList = new List<employee>();
            employeeList = Es.get_all_employee();
            //Getting input data
            newEmployee.Name = reg_username.Text;
            newEmployee.Email = reg_email.Text;
            newEmployee.Password = reg_password.Text;
            newEmployee.Access = 1;

            //checking if employee exists
            bool existFlag = false;
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (newEmployee.Name == employeeList[i].Name)
                    existFlag = true;
            }            

            if (!existFlag)
            {
                Es.add_employee(newEmployee);                
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Employee Added')", true);
                clearFields();
                return;
            }            
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Employee Name Exists')", true);
                reg_username.Text = "";
                return;
            }
        }

        catch (Exception ee)
        {
            throw ee;
        }
        

    }

    protected void login()
    {
        employee user_login = Es.get_employee_byName(log_username.Text);
        if (user_login.ID != 0 && user_login.Password == log_password.Text)
        {
            Session["User"] = user_login;            
            clearFields();
            Response.Redirect("Ad_home.aspx", false);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong Username or Password')", true);
            clearFields();            
            return;
        }
    }

    private string GeneratePassword()
    {
        string strPwdchar = "abcdefghijklmnopqrstuvwxyz0123456789#+@&$ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string strPwd = "";
        Random rnd = new Random();
        for (int i = 0; i <= 7; i++)
        {
            int iRandom = rnd.Next(0, strPwdchar.Length - 1);
            strPwd += strPwdchar.Substring(iRandom, 1);
        }
        return strPwd;
    }

    public void sendPassword(String password, String useremail)
    {
        SmtpClient client = new SmtpClient();
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;
        client.Host = "smtp.gmail.com";
        client.Port = 587;

        // setup Smtp authentication
        System.Net.NetworkCredential credentials =
            new System.Net.NetworkCredential("info@csharkstudio.com", "Memo4444");
        client.UseDefaultCredentials = false;
        client.Credentials = credentials;

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress("info@csharkstudio.com");
        msg.To.Add(new MailAddress(useremail));

        msg.Subject = "Message from WDI website";
        msg.IsBodyHtml = true;
        msg.Body = string.Format(
                                 "<html><head></head><body><b> Mail From : " + String.Format("{0}", "WDI Architects") +                                                                  
                                 "<br/> Message : Your new password is  " + String.Format("{0}", password) +
                                 "</b></body>"
                                 );


        try
        {
            client.Send(msg);          
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('An Error has occured - please try again or contact system administrator')", true);
        }

    }

    protected void clearFields()
    {
        reg_confirm_password.Text = "";
        reg_email.Text = "";
        reg_username.Text = "";
        reg_password.Text = "";
        log_password.Text = "";        
        log_username.Text = "";        
    }
   
    protected void btn_Register_Click(object sender, EventArgs e)
    {
        InsertUser();
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "clentscript", "alert('Welcome to WDI... Please login with your new credentials'); parent.location.href='Ad_register.aspx'", true);
    }

    protected void btn_Login_Click(object sender, EventArgs e)
    {
        login();
    }

    protected void btn_Recover_Click(object sender, EventArgs e)
    {
        employee x = Es.get_employee_byMail(txt_recover_mail.Text);
        if(x.ID != 0)
        {
            x.Password = GeneratePassword();
            Es.edit_employee(x);
            sendPassword(x.Password, txt_recover_mail.Text);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "clentscript", "alert('Password Sent'); parent.location.href='Ad_register.aspx'", true);
            txt_recover_mail.Text = "";            
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This Email address is not registered !')", true);
        }
    }
}