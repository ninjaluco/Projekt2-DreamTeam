<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Gem.aspx.cs" Inherits="Index.Gem" %>
<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p<>Gem</p>
	<img src="Bilder/thumb.jpg" class="productImage" />
	<p>50-pack Pris 99,99:-<asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Lägg till" CommandArgument="3," />
        <asp:TextBox ID="amountTextBox" type="number" min="1" runat="server" Width="32px">1</asp:TextBox>
    </p> &nbsp;</asp:Content>
