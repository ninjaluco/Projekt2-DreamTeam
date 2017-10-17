<%@ Page Title=""  Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Häftapparater.aspx.cs" Inherits="Index.Häftapparater" %>

<%--För att kunna anropa metoder från mastern.--%>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>Häftapparater</p>
	<img src="Bilder/5000272_301_220.jpg" class="productImage" />
	<p>Pris: 99,99:-<asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Lägg till" CommandArgument="1," />
    </p>
    </asp:Content>
