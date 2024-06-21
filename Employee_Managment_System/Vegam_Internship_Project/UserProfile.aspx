<%@ Page Title="" Language="C#" MasterPageFile="~/Company.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Vegam_Internship_Project.WebForm4" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <style>
        #lblSuccessMsg {
            color: green;
        }

        #lblErrorMsg {
            color: red;
        }
        .cssStyle{
            border-style:none;
            font-size:20px;
            font-weight:300;
        }
        .cssStyle2{
            font-size:25px;
            font-weight:600;
        }
        .editProfileBtnClass{
            border-style:none;
            font-size:20px;
            padding:10px;
            margin-left:20%;
            background-color:cornflowerblue;
            cursor:pointer;
            border-radius:10px;
        }
        #btnLogout{
            font-size: 20px;
            background-color: coral;
            padding: 10px;
            margin-top: 15px;
            font-weight: 700;
        }
    </style>
    <h1>Profile : 
        <label id="lblUserRole" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
        <asp:Button ID="btnLogout" runat="server" Height="54px" OnClick="Button1_Click" Text="Logout" ValidationGroup="loginGroup" Width="93px" />
    </h1>
    <h1>Welcome :
        <label id="lblUserName" runat="server"></label>
    </h1>
    <br />
    <table>
        <tr>
            <td>
                <label class="cssStyle2">First Name : </label>
            </td>
            <td>
                <input type="text" id="txtUserFirstName" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">Last Name : </label>
            </td>
            <td>
                <input type="text" id="txtUserLastName" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">Email : </label>
            </td>
            <td>
                <input type="email" id="txtUserEmail" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">Password : </label>
            </td>
            <td>
                <input type="text" id="txtUserPassword" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">User Role : </label>
            </td>
            <td>
                <input type="text" id="txtUserRole" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">Gender : </label>
            </td>
            <td>
                 <input type="text" id="txtUserGender" runat="server" class="cssStyle" readonly />

            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">Mobile Number : </label>
            </td>
            <td>
                <input type="number" id="txtUserNumber" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">Address :</label>
            </td>
            <td>
                <input type="text" id="txtUserAddress" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">Pin Code :</label>
            </td>
            <td>
                <input type="number" id="txtUserPincode" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">Country :</label>
            </td>
            <td>
                <input type="text" id="txtUserCountry" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">State :</label>
            </td>
            <td>
                <input type="text" id="txtUserState" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td>
                <label class="cssStyle2">City :</label>
            </td>
            <td>
                <input type="text" id="txtUserCity" runat="server" class="cssStyle" readonly />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <input type="submit" value="Edit Info" id="editProfileBtn" class="editProfileBtnClass" runat="server" onserverclick="EditProfileBtn_ServerClick" />
            </td>
        </tr>
    </table>
    <label id="lblSuccessMsg" runat="server"></label>
    <br />
    <label id="lblErrorMsg" runat="server"></label>
</asp:Content>
