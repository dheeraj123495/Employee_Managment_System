using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLLayer;

namespace Vegam_Internship_Project
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        GetInfo getUserDetails = new GetInfo();
      

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet Ds = new DataSet();
            if (!Page.IsPostBack)
            {
                LoadUserDetails();
            }

        }
        void LoadUserDetails()
        {
            DataTable dt;
            DataRow dr;
            int i = 0;
            getUserDetails.Email = Session["Name"].ToString();
            getUserDetails.Password = Session["Password"].ToString();
            dt = BLL.GetUserDetailsFromTable(getUserDetails.Email,getUserDetails.Password);
            dr = dt.Rows[i];
            lblUserName.InnerText = dr["FFirstName"].ToString() + " " + dr["FLastName"].ToString();
            lblUserRole.InnerText = dr["FRoleType"].ToString();
            txtUserFirstName.Value = dr["FFirstName"].ToString();
            txtUserLastName.Value = dr["FLastName"].ToString();
            txtUserEmail.Value = dr["FEmail"].ToString();
            txtUserPassword.Value = dr["FPassword"].ToString();
            txtUserRole.Value = dr["FRoleType"].ToString();
            txtUserGender.Value = dr["FGender"].ToString();
            txtUserNumber.Value = dr["FMobile"].ToString();
            txtUserAddress.Value = dr["FAddress"].ToString();
            txtUserPincode.Value = dr["FPincode"].ToString();
            txtUserCountry.Value = dr["FCountry"].ToString();
            txtUserState.Value = dr["FState"].ToString();
            txtUserCity.Value = dr["FCity"].ToString();

        }

        protected void EditProfileBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("UpdateUserProfile.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage.aspx");
        }
    }
}