using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLayer;

namespace Vegam_Internship_Project
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        GetInfo getinfo = new GetInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            getinfo.Email = (txtEmail.Value.ToString()).Trim();
            getinfo.Password = (txtPassword.Value.ToString()).Trim();
            int id = BLL.GetLoginDetailsFromTable(getinfo.Email,getinfo.Password);
            Session["Name"] = getinfo.Email;
            Session["Password"] = getinfo.Password;
            if(id == 1)
            {
                Response.Redirect("~/AdminProfile.aspx");
            }
            else if(id == 2 || id == 3)
            {
                Response.Redirect("UserProfile.aspx");
            }
            else
            {
                lblMessage.InnerText = "Invalid Credentials";
            }
        }
    }
}