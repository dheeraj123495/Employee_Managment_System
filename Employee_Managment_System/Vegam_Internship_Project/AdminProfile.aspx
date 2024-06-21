<%@ Page Title="" Language="C#" MasterPageFile="~/Company.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="Vegam_Internship_Project.WebForm3" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <style>
        table, td {
            border: 2px solid black;
            font-size: 25px;
            text-align: center;
        }

        td {
            padding: 10px;
        }

        table {
            border-collapse: collapse;
        }
        /* .inputText{
            height:10px;
        }*/
        #btnSubmit {
            font-size: 20px;
            background-color: coral;
            padding: 10px;
            margin-top: 15px;
            font-weight: 700;
        }

        #lblSuccessMessage {
            color: green;
        }

        #lblErrorMessage {
            color: red;
        }
        #btnlogout{
            font-size: 20px;
            background-color: coral;
            padding: 10px;
            margin-top: 15px;
            font-weight: 700;
        }
    </style>
    <h1>Admin Profile&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnlogout" runat="server" Height="54px" OnClick="Button1_Click" Text="Logout" ValidationGroup="loginGroup" Width="93px" />
    </h1>
    <h1>Welcome Back :
        <label id="lblAdminName" runat="server"></label>
    </h1>

    <table>
        <tr>
            <td colspan="2">Add User </td>
        </tr>
        <tr>
            <td>
                <label>User First Name</label>
            </td>
            <td>
                <input type="text" id="txtUserFirstName" runat="server" class="inputText" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserFirstName"
                    runat="server" ForeColor="Red"
                    ErrorMessage="Username is required"
                    ControlToValidate="txtUserFirstName" Display="Dynamic" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label>User Last Name</label>
            </td>
            <td>
                <input type="text" id="txtUserLastName" runat="server" class="inputText" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserLastName"
                    runat="server" ForeColor="Red"
                    ErrorMessage="Username is required"
                    ControlToValidate="txtUserLastName" Display="Dynamic" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label>Email</label>
            </td>
            <td>
                <input type="email" id="txtUserEmail" runat="server" class="inputText" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail"
                    runat="server" ForeColor="Red"
                    ErrorMessage="Email is required"
                    ControlToValidate="txtUserEmail" Display="Dynamic" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label>Role ID</label>
            </td>
            <td>
                <input type="number" id="txtUserRoleId" runat="server" class="inputText" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserRoleId"
                    runat="server" ForeColor="Red"
                    ErrorMessage="Role ID is required"
                    ControlToValidate="txtUserRoleId" Display="Dynamic" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label>Password</label>
            </td>
            <td>
                <input type="password" id="txtUserPassword" runat="server" class="inputText" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserPassword"
                    runat="server" ForeColor="Red"
                    ErrorMessage="Password is required"
                    ControlToValidate="txtUserPassword" Display="Dynamic" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <input type="submit" runat="server" value="Add User" id="btnSubmit" onserverclick="AddUser" validationgroup="AddUserGroup" />
                <br />
                <label id="lblSubmit" runat="server"></label>
                <br /><br />

            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="userGridViewDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="FId"
        ShowHeaderWhenEmpty="True" OnRowEditing="userGridViewDetails_RowEditing" OnRowCancelingEdit="userGridViewDetails_RowCancelingEdit" 
        OnRowUpdating="userGridViewDetails_RowUpdating" OnRowDeleting="UserGridViewDetails_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None">
       
        <AlternatingRowStyle BackColor="White" />
        <Columns>
             <asp:TemplateField HeaderText="User ID">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("FId") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserID" Text='<%# Eval("FId") %>' runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Name">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("FFirstName") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" Text='<%# Eval("FFirstName") %>' runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("FEmail") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" Text='<%# Eval("FEmail") %>' runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Role Id">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("FUserRoleId") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtRoleId" Text='<%# Eval("FUserRoleId") %>' runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Password">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("FPassword") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPassword" Text='<%# Eval("FPassword") %>' runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ValidateRequestMode="Disabled">
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/edit.png" ValidationGroup="EditUserGroup" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/Images/delete.png" ValidationGroup="EditUserGroup" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" ValidationGroup="EditUserGroup" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" ValidationGroup="EditUserGroup" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <label id="lblSuccessMessage" runat="server"></label>
    <br />
    <br />
</asp:Content>
