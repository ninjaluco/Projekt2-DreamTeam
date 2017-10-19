<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="Index.RegisterUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Reg">

        <div class="RegRow">Användarnamn<asp:TextBox ID="NickName" runat="server"></asp:TextBox></div>    
        <div class="RegRow">Lösenord<asp:TextBox ID="Password" runat="server"></asp:TextBox></div>
        <div class="RegRow">Namn<asp:TextBox ID="Name" runat="server"></asp:TextBox> </div>
        <div class="RegRow">Gata<asp:TextBox ID="Street" runat="server"></asp:TextBox></div>
        <div class="RegRow">Postnummer<asp:TextBox ID="Zip" runat="server"></asp:TextBox></div>
        <div class="RegRow">Postadress<asp:TextBox ID="City" runat="server"></asp:TextBox></div>
        <div class="RegRow">Personnummer(ÅÅÅÅMMDD-XXXX)<asp:TextBox ID="SSN" runat="server"></asp:TextBox></div>
        <div class="RegRow">Telfonnummer<asp:TextBox ID="Telefon" runat="server"></asp:TextBox></div>
        <div class="RegRow">Epostadress<asp:TextBox ID="Epost" runat="server"></asp:TextBox></div>
        <div class="RegButton"><asp:Button ID="ButtonReg" runat="server" Text="Registera" OnClick="ButtonReg_Click" /></div>
                       
    </div>
    <div class="container">
  <h2>Bordered Table</h2>
  <p>The .table-bordered class adds borders to a table:</p>            
  <table class="table table-bordered">
    <thead>
      <tr>
        <th>Firstname</th>
        <th>Lastname</th>
        <th>Email</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>John</td>
        <td>Doe</td>
        <td>john@example.com</td>
      </tr>
      <tr>
        <td>Mary</td>
        <td>Moe</td>
        <td>mary@example.com</td>
      </tr>
      <tr>
        <td>July</td>
        <td>Dooley</td>
        <td>july@example.com</td>
      </tr>
    </tbody>
  </table>
</div>


</asp:Content>
