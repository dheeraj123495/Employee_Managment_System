using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLLayer;
using Exception = System.Exception;

namespace Vegam_Internship_Project
{
    public enum Gender
    {
        Others = 'O',
        Male = 'M',
        Female = 'F'
    }
    public partial class WebForm5 : System.Web.UI.Page
    {
        GetInfo getUserDetails = new GetInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet Ds = new DataSet();
            if (!Page.IsPostBack)
            {
                Array arrList = Enum.GetValues(typeof(Gender));
                foreach (Gender gender in arrList)
                {
                    selectGender.Items.Add(new ListItem(gender.ToString(), ((char)gender).ToString()));
                }
                string Physicalpath = Server.MapPath("Country.xml");
                Ds.ReadXml(Physicalpath);
                DropDownList1.DataTextField = "CountryName";
                DropDownList1.DataValueField = "CountryId";
                DropDownList1.DataSource = Ds;
                DropDownList1.DataBind();
                ListItem Li = new ListItem("Select Country", "-1");
                DropDownList1.Items.Insert(0, Li);
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            if (DropDownList1.SelectedItem.Text == "India")
            {
                DataSet DS2 = new DataSet();
                DS2.ReadXml(Server.MapPath("India.xml"));
                DropDownList2.DataTextField = "CountryName";
                DropDownList2.DataValueField = "CountryId";
                DropDownList2.DataSource = DS2;
                DropDownList2.DataBind();

            }
            else if (DropDownList1.SelectedItem.Text == "US")
            {
                DataSet Ds3 = new DataSet();
                Ds3.ReadXml(Server.MapPath("US.xml"));
                DropDownList2.DataTextField = "CountryName";
                DropDownList2.DataValueField = "CountryId";
                DropDownList2.DataSource = Ds3;
                DropDownList2.DataBind();

            }
            ListItem li3 = new ListItem("Select", "-1");
            DropDownList2.Items.Insert(0, li3);
            if (DropDownList1.SelectedIndex == 0)
            {
                DropDownList2.Enabled = false;
                DropDownList3.Enabled = false;
            }
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            if (DropDownList2.SelectedItem.Text == "Karnataka")
            {
                DataSet DS4 = new DataSet();
                DS4.ReadXml(Server.MapPath("City_India_Kar.xml"));
                DropDownList3.DataTextField = "CityName";
                DropDownList3.DataValueField = "CityId";
                DropDownList3.DataSource = DS4;
                DropDownList3.DataBind();

            }
            else if (DropDownList1.SelectedItem.Text == "US")
            {
                DataSet Ds5 = new DataSet();
                Ds5.ReadXml(Server.MapPath("City_US_Newyork.xml"));
                DropDownList3.DataTextField = "CityName";
                DropDownList3.DataValueField = "CityId";
                DropDownList3.DataSource = Ds5;
                DropDownList3.DataBind();

            }
            ListItem li4 = new ListItem("Select", "-1");
            DropDownList3.Items.Insert(0, li4);
            if (DropDownList2.SelectedIndex == 0)
            {
                DropDownList3.Enabled = false;
            }
        }
        protected void UpdateInfoBtn_ServerClick(object sender, EventArgs e)
        {
            try
            {

                getUserDetails.Email = Session["Name"].ToString();
                getUserDetails.Password = Session["Password"].ToString();
                getUserDetails.Gender = char.Parse(selectGender.Value.ToString());
                getUserDetails.Pnumber = Convert.ToInt64(txtUserNumber.Value.ToString());
                getUserDetails.Country = DropDownList1.SelectedValue.ToString();
                getUserDetails.State = DropDownList2.SelectedValue.ToString();
                getUserDetails.City = DropDownList3.SelectedValue.ToString();
                getUserDetails.Address = txtUserAddress.Value.ToString();
                getUserDetails.PinCode = txtUserPincode.Value.ToString();
                BLL.UpdateUserProfileDataToTable(getUserDetails.Email,getUserDetails.Password, getUserDetails.Gender,getUserDetails.Pnumber,getUserDetails.Country,getUserDetails.State,getUserDetails.City,getUserDetails.Address,getUserDetails.PinCode);
                lblSuccessMsg.InnerText = "Profile Updated Successfully";
                lblErrorMsg.InnerText = "";

            }
            catch (Exception ex)
            {
                lblErrorMsg.InnerText = ex.Message;
                lblSuccessMsg.InnerText = "";
            }

        }
  

        protected void backToProfile_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}