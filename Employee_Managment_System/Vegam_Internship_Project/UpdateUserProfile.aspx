<%@ Page Title="" Language="C#" MasterPageFile="~/Company.Master" AutoEventWireup="true" CodeBehind="UpdateUserProfile.aspx.cs" Inherits="Vegam_Internship_Project.WebForm5" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <style>
        #lblSuccessMsg {
            color: green;
        }

        #lblErrorMsg {
            color: red;
        }

        .btnCss {
            border-style: none;
            font-size: 15px;
            padding: 10px;
            margin-left: 10%;
            background-color: cornflowerblue;
            cursor: pointer;
            border-radius: 10px;
        }
    </style>
    <table>
        <tr>
            <td>
                <label>Gender : </label>
            </td>
            <td>
                <select runat="server" id="selectGender">
                    <option value="" selected>-Select Gender--</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>
                <label>Mobile Number : </label>
            </td>
            <td>
                <input type="number" id="txtUserNumber" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <label>Address :</label>
            </td>
            <td>
                <input type="text" id="txtUserAddress" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <label>Pin Code :</label>
            </td>
            <td>
                <input type="number" id="txtUserPincode" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <label>Country :</label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <label>State :</label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <label>City :</label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <input type="submit" class="btnCss" value="Update Info" id="updateProfileBtn" runat="server" onserverclick="UpdateInfoBtn_ServerClick" />
                <input type="submit" class="btnCss" value="Back to Profile" id="btnbackToProfile" runat="server" onserverclick="backToProfile_ServerClick" />
            </td>
        </tr>
    </table>
    <br />
    <label id="lblSuccessMsg" runat="server"></label>
    <br />
    <label id="lblErrorMsg" runat="server"></label>
</asp:Content>
