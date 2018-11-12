<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 168px;
        }
        #Reset1 {
            width: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        Sign Up</h1>
    <p>
        <asp:Label ID="lblExceptionMessage" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">User Name*</td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Height="18px" Width="151px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Password*</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Height="16px" Width="151px"></asp:TextBox>
                <ajaxToolkit:PasswordStrength ID="txtPassword_PasswordStrength" runat="server" BehaviorID="txtPassword_PasswordStrength" MinimumSymbolCharacters="1" TargetControlID="txtPassword" MinimumUpperCaseCharacters="1" PreferredPasswordLength="8" RequiresUpperAndLowerCaseCharacters="True" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Confirm Password*</td>
            <td>
                <asp:TextBox ID="txtConfirmPwd" runat="server" Height="18px" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">First Name*</td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" Height="17px" Width="148px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Last Name*</td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" Height="18px" Width="146px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Gender*</td>
            <td>
                <asp:RadioButtonList ID="rdoGender" runat="server">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email*</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Height="16px" Width="235px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Date of Birth*</td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" BehaviorID="txtDOB_CalendarExtender" TargetControlID="txtDOB" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up Now" OnClick="btnSignUp_Click" />
            </td>
            <td>
                <input id="btnReset" type="reset" value="Clear" /></td>
        </tr>
    </table>
</asp:Content>

