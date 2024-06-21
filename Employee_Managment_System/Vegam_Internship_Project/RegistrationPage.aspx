<%@ Page Title="" Language="C#" MasterPageFile="~/Company.Master" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="Vegam_Internship_Project.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script src="javascript/script.js" type="text/javascript"></script>
    <style>
        .auto-style1 {
            border-collapse: collapse;
            margin: 10% 32%;
            font-size: 0.9em;
            font-family: sans-serif;
            min-width: 500px;
            height: 200px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
            height:300px;
        }
          .cssStyle {
            font-size: 20px;
            font-weight: 300;
            
        }
        .cssStyle2 {
            font-size: 25px;
            font-weight: 600;
        }
         .btnregistration {
            border-style: none;
            font-size: 20px;
            padding: 10px;
            margin-left: 40%;
            background-color: cornflowerblue;
            cursor: pointer;
            border-radius: 10px;
        }
         .heading{
             font-size:30px;
         }
         .lblMessage{
             color:green;margin-left:30%;font-size:20px;
         }
    </style>
    <div>
        <table class="auto-style1">
            <tr>
                <th colspan="2" class="heading">Registration Page</th>
            </tr>
            <tr>
                <td>
                    <label class="cssStyle2">First Name : </label>
                </td>
                <td>
                    <input id="firstNameTxt" class="cssStyle" type="text" runat="server" required />
                </td>
            </tr>
            <tr>
                <td>
                    <label class="cssStyle2">Last Name : </label>
                </td>
                <td>
                    <input id="lastNameTxt" class="cssStyle" type="text" runat="server" required/>
                </td>
            </tr>
            <tr>
                <td>
                    <label class="cssStyle2">Email Id : </label>
                </td>
                <td>
                    <input id="emailIdTxt" class="cssStyle" type="email" runat="server" required/>
                </td>
            </tr>
            <tr>
                <td>
                    <label class="cssStyle2">Phone Number : </label>
                </td>
                <td>
                    <input id="phoneNumberTxt" class="cssStyle" type="number" runat="server" required />
                </td>
            </tr>
            <tr>
                <td>
                    <label class="cssStyle2">Password : </label>
                </td>
                <td>
                    <input id="passwordTxt" class="cssStyle" type="password" runat="server" required/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="btnSubmit" onclick="return userValid(this);" type="submit" value="Register" class="btnregistration" runat="server" onserverclick="BtnSubmit_ServerClick" />
                    <%--<input id="btnSubmit" type="submit" onsubmit="return  Validate()" value="Register" class="btnregistration" runat="server" />--%>
                    <br />
                    <label id="lblMessageSussess" class="lblMessage" runat="server" style=""></label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="loginlink" runat="server" NavigateUrl="~/LoginPage.aspx">Click here to login</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
