<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmployee.aspx.cs" Inherits="Lab1_ConnectedMode.GUI.WebFormEmployee" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Maintainance</title>
    <style type="text/css">
        .auto-style1 {
            width: 55%;
        }
        .auto-style2 {
            width: 163px;
        }
        .auto-style4 {
            width: 159px;
        }
        .auto-style5 {
            width: 163px;
            text-align: center;
        }
        .auto-style6 {
            width: 226px;
        }
        .auto-style7 {
            width: 356px;
        }
        .auto-style8 {
            width: 356px;
            text-align: right;
        }
        .auto-style9 {
            text-align: center;
        }
        .auto-style10 {
            width: 226px;
            height: 26px;
        }
        .auto-style11 {
            width: 356px;
            height: 26px;
        }
        .auto-style12 {
            width: 163px;
            text-align: center;
            height: 26px;
        }
        .auto-style13 {
            width: 159px;
            height: 26px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="4" style="text-align: center;font-size: 20px; font-weight:bold; color:orange;">Employee Maintainance</td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;font-size: 20px; font-weight:bold; color:orange;">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">Employee ID</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBoxEmpID" runat="server" AutoPostBack="True" OnTextChanged="TextBoxEmpID_TextChanged"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnSave" runat="server" Text="Save New" Width="100px" OnClick="btnSave_Click" />
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">First Name</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBoxFName" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="100px" OnClick="btnUpdate_Click" />
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">Last Name</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBoxLName" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="100px" OnClick="btnDelete_Click" />
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">Job Title</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBoxJobTitle" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnListAll" runat="server" Text="List All" Width="100px" OnClick="btnListAll_Click" />
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style13"></td>
                </tr>
                <tr>
                    <td class="auto-style6">Search By</td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="DropDownSearchMethods" runat="server" Width="168px" AutoPostBack="True" OnSelectedIndexChanged="DropDownSearchMethods_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">Please enter:</td>
                    <td class="auto-style8">
                        <asp:Label ID="LabelSearch" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="100px" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Label ID="LabelLastName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" class="auto-style9">
                        <asp:GridView ID="GridViewEmployees" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
