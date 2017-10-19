<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Index.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p id="WelcomeUser">
        <h3></h3>
    </p>

    <div>
        <p></p>
    </div>
    <asp:TextBox ID="historikText" runat="server"></asp:TextBox>
    <asp:TextBox ID="OrderNummer" runat="server"></asp:TextBox>

    <div><p>Avsluta ditt användarkonto</p><asp:Button ID="KundDelete" runat="server" Text="Avregistrering" /></div>
</asp:Content>
