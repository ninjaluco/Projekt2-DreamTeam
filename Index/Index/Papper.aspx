<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Papper.aspx.cs" Inherits="Index.Papper" %>
<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	    <style type="text/css">

		/*.bild {
    background-image: url('Bilder/10798171-Some-Office-Stuff-Hand-Drawn-Stock-Vector-doodle.jpg');
    
}*/
	</style>

    <script src="Js/JSPapper.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<%--<div class="bild">

    <p>Papper</p>--%>


	<div class="container-fluid">
        <div class="row"></div>
    </div>
	<%--<div class="bild"> <img src="Bilder/10798171-Some-Office-Stuff-Hand-Drawn-Stock-Vector-doodle.jpg" />--%>
</div>
</asp:Content>
