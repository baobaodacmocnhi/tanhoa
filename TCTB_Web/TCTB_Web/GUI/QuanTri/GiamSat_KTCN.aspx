<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="GiamSat_KTCN.aspx.cs" Inherits="TCTB_Web.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="form">
    <div class="title">GIÁM SÁT P.KTCN</div>
        <div>
            <asp:Label CssClass="label" ID="Label3" runat="server" Text="ID:" Visible="false"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>
        </div>
        <div>
            <asp:Label CssClass="label" ID="Label1" runat="server" Text="Họ Tên:"></asp:Label>
            <asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label CssClass="label" ID="Label2" runat="server" Text="Điện Thoại:"></asp:Label>
            <asp:TextBox ID="txtDienThoai" runat="server"></asp:TextBox>
        </div>
        <div>
            <span style="margin-left: 80px">
                <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" /></span>
            <span style="margin-left: 10px">
                <asp:Button ID="btnSua" runat="server" Text="Sửa" OnClick="btnSua_Click" /></span>
            <span style="margin-left: 10px">
                <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" /></span>
        </div>
        <div style="margin-top: 30px">
            <asp:GridView ID="dgvNhanVien" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvNhanVien_SelectedIndexChanged"
                DataKeyNames="ID">
                <Columns>
                    <%--<asp:TemplateField HeaderText="ID" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="ID" HeaderText="ID">
                        <ItemStyle CssClass="hidden" />
                        <HeaderStyle CssClass="hidden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TenNV" HeaderText="Họ Tên" />
                    <asp:BoundField DataField="DienThoai" HeaderText="Điện Thoại" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
