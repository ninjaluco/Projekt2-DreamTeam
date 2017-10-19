<%@ Page Title=""  Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Häftapparater.aspx.cs" Inherits="Index.Häftapparater" %>

<%--För att kunna anropa metoder från mastern.--%>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	    <style type="text/css">
		.auto-style2 {
			height: 216px;
		}
	
		.bild {
    background-image: url('Bilder/10798171-Some-Office-Stuff-Hand-Drawn-Stock-Vector-doodle.jpg');
    
}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="bild">

    <p>Häftapparater</p>
	<img src="Bilder/5000272_301_220.jpg" class="productImage" />
	<p>Pris: 99,99:-<asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Lägg till" CommandArgument="1," />
        <asp:TextBox ID="amountTextBox" type="number" min="1" runat="server" Width="32px">1</asp:TextBox>
    </p>&nbsp;

		</div>
	<div class="bild"> <img src="Bilder/10798171-Some-Office-Stuff-Hand-Drawn-Stock-Vector-doodle.jpg" />
</div>
		
    </asp:Content>
