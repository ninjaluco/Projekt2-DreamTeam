<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Varukorg.aspx.cs" Inherits="Index.Varukorg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 330px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div>

    <h3>Table example, constructed at design time</h3>
    <asp:Table id="shoppingCartTable" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                Row 0, Col 0
            </asp:TableCell>
            <asp:TableCell>
                Row 0, Col 1
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Row 1, Col 0
            </asp:TableCell>
            <asp:TableCell>
                Row 1, Col 1
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    </div>

</asp:Content>
