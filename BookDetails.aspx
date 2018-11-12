<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="BookDetails.aspx.cs" Inherits="BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style2 {
            width: 94px;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            width: 98px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:DataList ID="dlBooks" runat="server" Width="100%">
        <ItemTemplate>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1 title" colspan="2">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Title") %>'></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Image ID="Image1" runat="server" Height="160px" ImageUrl='<%# "images/" + Eval("coverphoto") %>' Width="160px" />
                    </td>
                    <td><strong>Author:</strong>
                        <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Author") %>'></asp:Literal>
                        <br />
                        <strong>Year:</strong>
                        <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("Year") %>'></asp:Literal>
                        <br />
                        Category:&nbsp;<asp:Literal ID="Literal7" runat="server" Text='<%# Eval("CategoryID") %>'></asp:Literal>
                        <br />
                            &nbsp;<ajaxToolkit:Rating ID="Rating1" runat="server"  CurrentRating='<%# Eval("avgRating") %>' EmptyStarCssClass="empty" FilledStarCssClass="filled" ReadOnly="True" StarCssClass="filled" WaitingStarCssClass="filled">
                        </ajaxToolkit:Rating>
                           
                            &nbsp;Votes (<asp:Literal ID="Literal5" runat="server" Text='<%# Eval("votes") %>'></asp:Literal>
                            )<br />
                        <br />
                        <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("description") %>'></asp:Literal>
                        
                        &nbsp;</td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <h2>User Reviews</h2>
    <p>
        <asp:DataList ID="dlReviews" runat="server" Width="100%">
            <ItemTemplate>
                <ajaxToolkit:Rating ID="Rating1" runat="server"  CurrentRating='<%# Eval("Rating") %>' EmptyStarCssClass="empty" FilledStarCssClass="filled" ReadOnly="True" StarCssClass="filled" WaitingStarCssClass="filled">
                </ajaxToolkit:Rating>
                <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("username") %>'></asp:Literal>
                &nbsp;<br />
                <asp:Literal ID="Literal8" runat="server" Text='<%# Eval("Comment") %>'></asp:Literal>
                <br /> 
                <br />
            </ItemTemplate>
        </asp:DataList>
    </p>
    <p>
    &nbsp;<asp:Label ID="lblExceptionMessage" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <table class="auto-style3">
        <tr>
            <td class="auto-style4">Your Rating: *</td>
            <td>
                <ajaxToolkit:Rating ID="Rating2" runat="server" EmptyStarCssClass="empty" FilledStarCssClass="filled" StarCssClass="filled" WaitingStarCssClass="filled">
                </ajaxToolkit:Rating>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Comment:</td>
            <td>
                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
  
  
 
</asp:Content>

