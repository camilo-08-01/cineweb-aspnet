<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarPelicula.aspx.cs" Inherits="CineWeb.Pelicula.AgregarPelicula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td><asp:Label runat="server" Text="Nombre:" /></td>
            <td><asp:TextBox ID="txtNombre" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Director:" /></td>
            <td><asp:TextBox ID="txtDirector" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Idioma:" /></td>
            <td>
                <asp:DropDownList ID="ddlIdioma" runat="server" />
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Duración:" /></td>
            <td><asp:TextBox ID="txtDuracion" runat="server" TextMode="Number" /></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Valoración:" /></td>
            <td>
                <asp:DropDownList ID="ddlValoracion" runat="server" />
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="¿Es todo público?" /></td>
            <td><asp:CheckBox ID="chkEsTodoPublico" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="¿En cartelera?" /></td>
            <td><asp:CheckBox ID="chkEnCartelera" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="¿Tiene subtítulos?" /></td>
            <td><asp:CheckBox ID="chkTieneSubtitulos" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Fecha de estreno:" /></td>
            <td>
                <asp:Calendar ID="calFechaEstreno" runat="server" 
                    FirstDayOfWeek="Monday" 
                    DayNameFormat="Shortest" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
