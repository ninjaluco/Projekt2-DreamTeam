<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Varukorg.aspx.cs" Inherits="Index.Varukorg" %>
<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
		.auto-style2 {
			height: 216px;
		}
		body{
			background-color:white;
			background-image:none;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div class="varuKorgDiv">


        


	   <asp:Table ID="shoppingCartTable" runat="server"
		   CellPadding="10"
		   GridLines="Both" class="table table-striped">
		   <asp:TableHeaderRow>
			   <asp:TableHeaderCell>
				Artikel-ID
			   </asp:TableHeaderCell>
			   <asp:TableHeaderCell>
				Artikelnamn
			   </asp:TableHeaderCell>
			   <asp:TableHeaderCell>
				Antal
			   </asp:TableHeaderCell>
			   <asp:TableHeaderCell>
				Pris/st (kr)
			   </asp:TableHeaderCell>
			   <asp:TableHeaderCell>
				Summa (kr)
			   </asp:TableHeaderCell>
		   </asp:TableHeaderRow>
		   <asp:TableHeaderRow>
			   <asp:TableHeaderCell>

			   </asp:TableHeaderCell>
			   <asp:TableHeaderCell>

			   </asp:TableHeaderCell>
			   <asp:TableHeaderCell>
				  
			   </asp:TableHeaderCell>
			   <asp:TableHeaderCell>
 Totalsumma:
				   </asp:TableHeaderCell>
			   <asp:TableHeaderCell ID="sumOfAll" CssClass="sumOfAll">
				
			   </asp:TableHeaderCell>
		   </asp:TableHeaderRow>
	   </asp:Table>
       <div id="buyStuff">
	   <asp:Button ID="buttonBuy" runat="server" OnClick="buttonBuy_Click" Text="Skicka Order" />


        <asp:Label ID="buyLoggedInLabel" runat="server" ForeColor="Red"></asp:Label>
       </div>
	</div>
  
</asp:Content>
