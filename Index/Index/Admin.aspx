<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Index.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <style>
    /* Remove the navbar's default rounded borders and increase the bottom margin */ 
    .navbar {
      margin-bottom: 50px;
      border-radius: 0;
    }
    
    /* Remove the jumbotron's default bottom margin */ 
     .jumbotron {
      margin-bottom: 0;
    }
   
    /* Add a gray background color and some padding to the footer */
    footer {
      background-color: #f2f2f2;
      padding: 25px;
    }
	.img-responsive1{
		height: 215px;
	}

  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


	<div class="jumbotron">
  <div class="container text-center">
    <h1>Online Store</h1>      
    <p>Mission, Vission & Values</p>
  </div>
</div>

<nav class="navbar navbar-inverse">
  <div class="container-fluids">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a class="navbar-brand" href="#">Logo</a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
        <%--<li class="active"><a href="#">Home</a></li>--%>
   <%--     <li><a href="#">Products</a></li>
        <li><a href="#">Deals</a></li>
        <li><a href="#">Stores</a></li>--%>
        <%--<li><a href="Varukorg.aspx">Varukorg</a></li>--%>
      </ul>
      <ul class="nav navbar-nav navbar-right">
        <li><a href="#"><span class="glyphicon glyphicon-user"></span> Your Account</a></li>
        <li><a href="Varukorg.aspx"><span class="glyphicon glyphicon-shopping-cart"></span> Cart</a></li>
      </ul>
    </div>
  </div>
</nav>

<div class="container">    
  <div class="rows">
    <div class="col-sm-4">
      <div class="panel panel-primary">
        <div class="panel-heading">Pennor</div>

        <div class="panel-body"><img src='Bilder/Pennor.jpg' class="img-responsive" style="width:100%" alt="Image"></div>
        <div class="panel-footer">99,99:-
			<asp:Button ID="addButton" runat="server" Text="Lägg till" CommandArgument="3," />
        <asp:TextBox ID="amountTextBox" type="number" min="1" runat="server" Width="32px">1</asp:TextBox>
        </div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-danger">
        <div class="panel-heading">Häftapparater</div>
        <div class="panel-body"><img src='Bilder/5000272_301_220.jpg' class="img-responsive" style="width:92%" alt="Image"></div>
        <div class="panel-footer">99,99:-
			<asp:Button ID="Button1" runat="server" Text="Lägg till" CommandArgument="3," />
        <asp:TextBox ID="TextBox1" type="number" min="1" runat="server" Width="32px">1</asp:TextBox>
        </div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-success">
        <div class="panel-heading">Papper</div>
        <div class="panel-body"><img src='Bilder/pappernfokus.jpg' class="img-responsive1" style="width: 100%" alt="Image"></div>
        <div class="panel-footer">99,99:-
			<asp:Button ID="Button2" runat="server" Text="Lägg till" CommandArgument="3," />
        <asp:TextBox ID="TextBox2" type="number" min="1" runat="server" Width="32px">1</asp:TextBox>
        </div>
      </div>
    </div>
  </div>
</div><br>

<div class="container">    
  <div class="rows">
    <div class="col-sm-4">
      <div class="panel panel-primary">
        <div class="panel-heading">Gem</div>
        <div class="panel-body"><img src="Bilder/thumb.jpg" class="img-responsive" style="width: 100%" alt="Image"></div>
        <div class="panel-footer">99,99:-
			<asp:Button ID="Button3" runat="server" Text="Lägg till" CommandArgument="3," />
        <asp:TextBox ID="TextBox3" type="number" min="1" runat="server" Width="32px">1</asp:TextBox>
        </div>
      </div>
    </div>
 <%--   <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">BLACK FRIDAY DEAL</div>
        <div class="panel-body"><img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width:100%" alt="Image"></div>
        <div class="panel-footer">Buy 50 mobiles and get a gift card</div>
      </div>
    </div>--%>
<%--    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">BLACK FRIDAY DEAL</div>
        <div class="panel-body"><img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width:100%" alt="Image"></div>
        <div class="panel-footer">Buy 50 mobiles and get a gift card</div>
      </div>
    </div>--%>
  </div>
</div><br><br>



</asp:Content>
