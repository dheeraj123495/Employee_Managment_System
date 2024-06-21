using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using BLLayer;


namespace Vegam_Internship_Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        GetInfo getinfo = new GetInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_ServerClick(object sender, EventArgs e)
        {
            string dt;
            if (Page.IsValid)
            {
                getinfo.Fname = firstNameTxt.Value.ToString();
                getinfo.Lname = lastNameTxt.Value.ToString();
                getinfo.Email = emailIdTxt.Value.ToString();
                getinfo.Pnumber = Convert.ToInt64(phoneNumberTxt.Value.ToString());
                getinfo.Password =passwordTxt.Value.ToString();
                dt = BLL.InsertInfoToTable(getinfo.Fname,getinfo.Lname,getinfo.Email,getinfo.Pnumber,getinfo.Password);
                if(dt != null)
                {
                    lblMessageSussess.InnerText = "Credentials already in use";
                }
            }
        }
    }
}