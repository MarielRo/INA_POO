<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmClientes.aspx.cs" Inherits="SitioWeb.FrmClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mantenimiento de clientes</title>

    
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
            <h1> Mantenimiento de Clientes</h1>
        </div>

        
        <div>
             &nbsp;&nbsp;&nbsp;
             <asp:Label ID="lblid" runat="server" Text="Id :"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="txtId" runat="server" OnTextChanged="txtId_TextChanged" ReadOnly="True" Width="167px"></asp:TextBox>

             <br />

             Nombre:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNombre" runat="server" Width="401px"></asp:TextBox>
             <br />
             Teléfono:&nbsp;&nbsp; <asp:TextBox ID="txtTelefono" runat="server" Height="24px" Width="167px"></asp:TextBox>
             <br />
             Dirección: <asp:TextBox ID="txtDireccion" runat="server" Width="389px"></asp:TextBox>
        </div>

    <div>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" style="height: 29px" />
    </div>
    </form>
</body>
</html>
