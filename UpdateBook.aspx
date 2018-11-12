<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="UpdateBook.aspx.cs" Inherits="UpdateBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 132px;
        }
        .auto-style3 {
            width: 132px;
            height: 20px;
            font-weight: bold;
        }
        .auto-style4 {
            height: 20px;
        }
        .auto-style5 {
            width: 132px;
            height: 26px;
            font-weight: bold;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style7 {
            width: 132px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <script type="text/javascript">
        function previewFile()
        {
            var preview = document.getElementById('<%=imgCoverPhoto.ClientID %>');
            var file = document.getElementById('<%=upCoverPhoto.ClientID %>').file[0];

            var reader = new FileReader();

            reader.onload = function ()
            {
                preview.src = reader.result;
            }

            if (file)
            {
                reader.readAsDataURL(file);
            }
            else
            {
                preview.src = "";
            }
        }
    </script>
    <h1>Update Book</h1>
    <p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
    <asp:Panel ID="pnlDetails" runat="server" Visible="False">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Book ID</td>
                <td class="auto-style4">
                    <asp:Label ID="lblBookID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Title *</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="255" Width="255px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Year </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtYear" runat="server" MaxLength="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Description*</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Height="86px" Rows="10" TextMode="MultiLine" Width="385px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Author*</td>
                <td>
                    <asp:TextBox ID="txtAuthor" runat="server" MaxLength="255" Width="255px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Category *</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Cover Photo *</td>
                <td>
                    <asp:Image ID="imgCoverPhoto" runat="server" Height="100px" Width="100px" />
                    <asp:FileUpload ID="upCoverPhoto" runat="server" onchange="previewFile()"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

