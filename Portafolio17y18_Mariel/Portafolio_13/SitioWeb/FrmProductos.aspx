<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmProductos.aspx.cs" Inherits="SitioWeb.FrmProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mantenimiento de Productos </title>

    <style>
        #form1 {
            margin: 10px auto;
            width: 70%;
        }
    </style>

    <script type="text/javascript">
        function mostrarMensaje(mensaje) {
            alert(mensaje);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> Mantenimiento de Productos</h1>
        </div>

        
        <div>
             &nbsp;&nbsp;&nbsp;
             <asp:Label ID="lblid" runat="server" Text="Id Producto:"></asp:Label>
             &nbsp;&nbsp; &nbsp; <asp:TextBox ID="txtId" runat="server" OnTextChanged="txtId_TextChanged" ReadOnly="True" Width="167px"></asp:TextBox>

             <br />

             Descripción:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="txtDescripcion" runat="server" Width="401px"></asp:TextBox>
             <br />
             Precio Compra:&nbsp;&nbsp; <asp:TextBox ID="txtPrecioCompra" runat="server" Height="24px" Width="167px"></asp:TextBox>
             <br />
            Precio Venta:&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="txtPrecioVenta" runat="server" Height="24px" Width="167px"></asp:TextBox>
            Gravado: <asp:TextBox ID="txtGravado" runat="server" Width="148px"></asp:TextBox>
             <br />
        </div>

    <div>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    </div>
    </form>
</body>
</html>
