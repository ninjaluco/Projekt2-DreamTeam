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

    <div><p>Order</p>
        <asp:ListBox ID="historikText" runat="server" Height="281px" OnSelectedIndexChanged="historikText_SelectedIndexChanged" Width="261px"></asp:ListBox>
        <asp:TextBox ID="textBoxOrderInfo" runat="server"></asp:TextBox>
    </div>

    <asp:TextBox ID="OrderNummer" runat="server"></asp:TextBox>

    <div><p>Avsluta ditt användarkonto</p><asp:Button ID="KundDelete" runat="server" Text="Avregistrering" OnClick="KundDelete_Click" /></div>
</asp:Content>
