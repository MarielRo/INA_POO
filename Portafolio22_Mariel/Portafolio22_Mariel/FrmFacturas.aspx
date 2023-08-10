<%@ Page Title="" Language="C#" MasterPageFile="~/FrmPaginaMaestra.Master" AutoEventWireup="true" CodeBehind="FrmFacturas.aspx.cs" Inherits="Portafolio22_Mariel.FrmFacturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center">
        <asp:Button ID="btnMostrar" runat="server" Text="Mostrar todos los Productos" class="btn btn-secondary" />
        <br /> <br /> <br />
    </div>

    <div class="d-flex justify-content-center">
        <asp:GridView ID="grdFacturas" runat="server" CellPadding="5" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5" OnPageIndexChanging="grdFacturas_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br /><br />
    </div>

    <div class="d-flex justify-content-center">
        <asp:GridView ID="grdDetalleFacturas" runat="server" CellPadding="5" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5" OnPageIndexChanging="grdDetalleFacturas_PageIndexChanging" >
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br /><br />
    </div>

</asp:Content>
