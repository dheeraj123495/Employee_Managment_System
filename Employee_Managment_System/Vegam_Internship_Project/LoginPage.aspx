<%@ Page Title="" Language="C#" MasterPageFile="~/Company.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Vegam_Internship_Project.WebForm2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
    <style>
        .cssStyle {
            font-size: 20px;
            font-weight: 300;
        }

        .cssStyle2 {
            font-size: 25px;
            font-weight: 600;
        }

        .auto-style1 {
            border-collapse: collapse;
            margin: 10% 35%;
            font-size: 0.9em;
            font-family: sans-serif;
            min-width: 450px;
            height: 200px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
            width: 338px;
        }
        label{
            text-align:center;
            font-size:20px;
            
        }
        .btnLogin {
            border-style: none;
            font-size: 20px;
            padding: 10px;
            margin-left: 40%;
            background-color: cornflowerblue;
            cursor: pointer;
            border-radius: 10px;
        }
    </style>
    <table class="auto-style1">
        <tr>
            <td>
                <label class="cssStyle2">Email ID&nbsp;&nbsp; : </label>
            </td>
            <td>
                <input id="txtEmail" type="email" runat="server" class="cssStyle" />
            </td>
        </tr>
        <%--  --%>
        <tr>
            <td>
                <label class="cssStyle2">Password : </label>
            </td>
            <td>
                <input id="txtPassword" type="password" runat="server" class="cssStyle" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <input id="btnLogin" class="btnLogin" type="submit" runat="server" value="Login" onclick="return emailValidate(this);" onserverclick="btnLogin_ServerClick" />
                <br />
                <br />
                <label id="lblMessage" class="lblMessage" runat="server"></label>
            </td>
        </tr>
    </table>
     <script type="text/javascript">
         
         function emailValidate(element) {
             var EmailId = document.getElementById(element.id.replace("btnLogin", "txtEmail")).value;
             if (element != null) {
                 if (EmailId == null) {
                     alert("Enter the Email");
                     return false;
                 }
                 if (EmailId.indexOf('@') <= 0) {
                     alert("Invalid Email");
                     return false
                 }
                 if ((EmailId.charAt(EmailId.length - 4) != ".") && (EmailId.charAt(EmailId.length - 3) != '.')) {
                     alert("Invalid Email");
                     return false;
                 }
                 else {
                     alert("Login Successfull");
                     return true;
                 }
                 }   
             }
     </script>
</asp:Content>


