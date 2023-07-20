<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SitioWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

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
            <h1>Listado de Clientes</h1>
            <hr />
        </div>

        <div>
            Nombre del Cliente <asp:TextBox ID="txtNombre" runat="server" Width="329px"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            &nbsp;<asp:Button ID="btnAgregar" runat="server" Text="Agregar Nuevo" OnClick="btnAgregar_Click" Width="134px" />
               
            &nbsp;
               
            <br />
        </div>
        <asp:GridView ID="grdLista" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros para mostrar" ForeColor="#333333" GridLines="None" Width="100%" OnPageIndexChanging="grdLista_PageIndexChanging" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("ID_CLIENTE").ToString() %>' CommandName="Modificar" OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("ID_CLIENTE").ToString() %>' CommandName="Eliminar" OnCommand="lnkEliminar_Command">Eliminar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                <asp:BoundField DataField="TELEFONO" HeaderText="Teléfono" />
                <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <div>
            <h2>Listado de Productos </h2> 
        </div>
        <div>
            Nombre del Producto <asp:TextBox ID="txtdescripcion" runat="server" Width="304px"></asp:TextBox>
            <asp:Button ID="btnBuscarProdu" runat="server" Text="Buscar" OnClick="btnBuscarProdu_Click" Width="91px" />
            &nbsp;<asp:Button ID="btnAgregarProdu" runat="server" Text="Agregar Producto" OnClick="btnAgregarProdu_Click" Width="140px" />
               
            <br />
        </div>

        <div>
            <asp:GridView ID="grdListaProdu" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No hay productos para mostar" ForeColor="#333333" GridLines="None" Width="100%" PageSize="5">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkModificarProdu" runat="server" CommandArgument='<%# Eval("ID_PRODUCTO").ToString() %>' CommandName="ModificarProdu" OnCommand="lnkModificarProdu_Command">Modificar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEliminarProdu" runat="server" CommandArgument='<%# Eval("ID_PRODUCTO").ToString() %>' CommandName="EliminarProdu" OnCommand="lnkEliminarProdu_Command">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" />
                    <asp:BoundField DataField="PRECIO_COMPRA" HeaderText="Precio Compra" />
                    <asp:BoundField DataField="PRECIO_VENTA" HeaderText="Precio Venta" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>


    </form>
</body>
</html>
