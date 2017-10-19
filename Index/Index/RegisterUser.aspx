<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="Index.RegisterUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2>REGISTRERA DIG SOM NY KUND</h2>
        <p>Vänligen fyll i uppgifterna nedan för att registrera dig.</p>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Användarnamn</td>
                    <td>
                        <asp:TextBox ID="NickName" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNick" runat="server" ControlToValidate="NickName" EnableClientScript="False" EnableTheming="False" ErrorMessage="*Du måste ange ett användarnamn" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Lösenord</td>
                    <td>
                        <asp:TextBox ID="Password" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="Password" EnableClientScript="False" EnableTheming="False" ErrorMessage="*Du måste ange ett lösenord" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Namn</td>
                    <td>
                        <asp:TextBox ID="Name" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="Name" EnableClientScript="False" EnableTheming="False" ErrorMessage="*Du måste ange ett namn" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Gata</td>
                    <td>
                        <asp:TextBox ID="Street" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorStreet" runat="server" ControlToValidate="Street" EnableClientScript="False" EnableTheming="False" ErrorMessage="*Du måste ange en gata" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Postnummer</td>
                    <td>
                        <asp:TextBox ID="Zip" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorZip" runat="server" ControlToValidate="Zip" EnableClientScript="False" EnableTheming="False" ErrorMessage="*Du måste ange ett postnummer" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Postadress</td>
                    <td>
                        <asp:TextBox ID="City" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server" ControlToValidate="City" EnableClientScript="False" EnableTheming="False" ErrorMessage="*Du måste ange en postadress" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Personnummer(ÅÅÅÅMMDD-XXXX)</td>
                    <td>
                        <asp:TextBox ID="SSN" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSSN" runat="server" ControlToValidate="SSN" EnableClientScript="False" EnableTheming="False" ErrorMessage="*Du måste ange ett personnummer" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Telfonnummer</td>
                    <td>
                        <asp:TextBox ID="Telefon" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefon" runat="server" ControlToValidate="Telefon" EnableClientScript="False" EnableTheming="False" ErrorMessage="*Du måste ange ett telefonnummer" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Epostadress</td>
                    <td>
                        <asp:TextBox ID="Epost" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEpost" runat="server" ControlToValidate="Epost" EnableClientScript="False" EnableTheming="False" ErrorMessage="*Du måste ange en telefon" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonReg" runat="server" Text="Registera" OnClick="ButtonReg_Click" /></td>
                    <td>&nbsp;</td>

            </tbody>
        </table>
    </div>


</asp:Content>
