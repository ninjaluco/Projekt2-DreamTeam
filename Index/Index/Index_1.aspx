<%@ Page  MasterPageFile="~/Main.Master" Language="C#" AutoEventWireup="true" CodeBehind="Index_1.aspx.cs" Inherits="Index.Index_1" %>
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
	<asp:Image ID="Image1" runat="server" ImageUrl="~/Bilder/10798171-Some-Office-Stuff-Hand-Drawn-Stock-Vector-doodle.jpg" Width="100%" Height="10%" BorderStyle="Solid" />
	
	<div class="bild"> <img src="Bilder/10798171-Some-Office-Stuff-Hand-Drawn-Stock-Vector-doodle.jpg" />
</div>
</asp:Content>


