<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Pennor.aspx.cs" Inherits="Index.Pennor" %>
<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>Pennor</p>

	<img src="Bilder/Pennor.jpg" class="productImage" />
	<p id="FivePack">5-pack Pris: 99,99:-<asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Lägg till" CommandArgument="2," />
    </p>
    




</asp:Content>
