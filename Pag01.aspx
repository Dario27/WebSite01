<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pag01.aspx.cs" Inherits="Pag01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        INGRESAR UNIVERSIDAD<br />
        <br />
        Codigo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCod" runat="server" Width="68px" Enabled="False"></asp:TextBox>
        <br />
        Nombre&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNomUni" runat="server" Width="258px"></asp:TextBox>
        <br />
        Cantidad estudiantes&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtCant" runat="server" Width="55px"></asp:TextBox>
        <br />
        Bilingüe &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="rboSi" runat="server" Text="SI" GroupName="Bili" />
        <asp:RadioButton ID="RboNo" runat="server" Text="No" GroupName="Bili" />
        <br />
        Categoria: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="cboCat" runat="server" OnSelectedIndexChanged="cboCat_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btn_Grabar" runat="server" Text="Grabar" OnClick="btn_Grabar_Click" />
    
        <asp:Button ID="btnCons" runat="server" Text="Consultar" OnClick="btn_Grabar_Click" PostBackUrl="~/Pag02.aspx" />
    
    </div>
    </form>
</body>
</html>
