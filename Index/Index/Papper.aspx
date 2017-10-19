<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Papper.aspx.cs" Inherits="Index.Papper" %>
<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	    <style type="text/css">

		.bild {
    background-image: url('Bilder/10798171-Some-Office-Stuff-Hand-Drawn-Stock-Vector-doodle.jpg');
    
}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="bild">

    <p>Papper</p>
	<img src="Bilder/pappernfokus.jpg" class="productImage" />
	
	<p>5-pack Pris: 99,99:-<asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Lägg till" CommandArgument="4," />
        <asp:TextBox ID="amountTextBox" type="number" min="1" runat="server" Width="32px">1</asp:TextBox>
    </p> &nbsp;
    </div>
	<div class="bild"> <img src="Bilder/10798171-Some-Office-Stuff-Hand-Drawn-Stock-Vector-doodle.jpg" />
</div>
</asp:Content>
