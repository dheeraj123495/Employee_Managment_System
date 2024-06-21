using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using BLLayer;
using Exception = System.Exception;

namespace Vegam_Internship_Project
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        GetInfo getUserInfo = new GetInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(Session["Name"] != null)
                {
                    lblAdminName.InnerText = Session["Name"].ToString().Trim();
                }
                LoadGridView();
            }
        }

        protected void AddUser(object sender, EventArgs e)
        {
            string str;
            getUserInfo.Fname = txtUserFirstName.Value.ToString();
            getUserInfo.Lname = txtUserLastName.Value.ToString();
            getUserInfo.Email = txtUserEmail.Value.ToString();
            getUserInfo.RoleId = Convert.ToInt32(txtUserRoleId.Value.ToString());
            getUserInfo.Password = txtUserPassword.Value.ToString();
            str = BLL.InsertUserInfoToTable(getUserInfo.Fname,getUserInfo.Lname,getUserInfo.Email,getUserInfo.RoleId,getUserInfo.Password);
            if (str != null)
            {
                lblSubmit.InnerText = "Credentials already in use";
            }
            else
            {
                lblSubmit.InnerText = "User Added Successfully";
                LoadGridView();
            }
        }

        void LoadGridView()
        {
            DataTable dtbl = BLL.LoadDatailsForGridView();
            if (dtbl.Rows.Count > 0)
            {
                userGridViewDetails.DataSource = dtbl;
                userGridViewDetails.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                userGridViewDetails.DataSource = dtbl;
                userGridViewDetails.DataBind();
                userGridViewDetails.Rows[0].Cells.Clear();
                userGridViewDetails.Rows[0].Cells.Add(new TableCell());
                userGridViewDetails.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                userGridViewDetails.Rows[0].Cells[0].Text = "No Data Found..!";
                userGridViewDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void userGridViewDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            userGridViewDetails.EditIndex = e.NewEditIndex;
            LoadGridView();
        }

         protected void userGridViewDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string str;
            try
            {
                getUserInfo.UserId = Convert.ToInt32(userGridViewDetails.DataKeys[e.RowIndex].Value.ToString());
                getUserInfo.RoleId =Convert.ToInt32((userGridViewDetails.Rows[e.RowIndex].FindControl("txtRoleId") as TextBox).Text.ToString());
                getUserInfo.Fname = (userGridViewDetails.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text;
                getUserInfo.Email = (userGridViewDetails.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text;  
                getUserInfo.Password = (userGridViewDetails.Rows[e.RowIndex].FindControl("txtPassword") as TextBox).Text;
                str = BLL.UpdateUserInfoToTable(getUserInfo.UserId, getUserInfo.RoleId, getUserInfo.Fname, getUserInfo.Email, getUserInfo.Password);
                if (str != null)
                {
                    lblSuccessMessage.InnerText = "Credentials already in use";
                }
                else
                {
                    userGridViewDetails.EditIndex = -1;
                    LoadGridView();
                    lblSuccessMessage.InnerText = "Selected Information updated Successfully";
                }
            }
            catch(Exception ex)
            {
                lblSuccessMessage.InnerText = ex.Message;
            }
        }
        protected void userGridViewDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            userGridViewDetails.EditIndex = -1;
            LoadGridView();

        }

        protected void UserGridViewDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            getUserInfo.UserId = Convert.ToInt32(userGridViewDetails.DataKeys[e.RowIndex].Value.ToString());
            BLL.DeleteUserRowFromTable(getUserInfo.UserId);
            lblSuccessMessage.InnerText = "User Deleted Successfully";
            LoadGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage.aspx");
        }
    }
}