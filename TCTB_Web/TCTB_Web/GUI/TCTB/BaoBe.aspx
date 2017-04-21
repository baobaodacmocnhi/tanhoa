<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="BaoBe.aspx.cs" Inherits="TCTB_Web.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="form">
        <div class="title">
            DANH SÁCH BÁO BỂ</div>
        <div>
            <span>
                <asp:Label ID="Label3" runat="server" Text="ID:" Visible="false"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox></span>
            <asp:Label ID="Label1" runat="server" Text="Số Nhà:"></asp:Label>
            <asp:TextBox ID="txtSoNha" runat="server"></asp:TextBox><span style="margin-left: 20px">
                <asp:Label ID="Label2" runat="server" Text="Tên Đường:"></asp:Label>
                <asp:TextBox ID="txtTenDuong" runat="server"></asp:TextBox></span> <span style="margin-left: 20px">
                    <asp:Label ID="Label4" runat="server" Text="Phường:"></asp:Label>
                    <asp:TextBox ID="txtPhuong" runat="server"></asp:TextBox></span>
        </div>
        <div>
            <asp:CheckBox ID="chkKhongNuoc" runat="server" Text="Không Nước" />
            <span style="margin-left: 20px">
                <asp:CheckBox ID="chkXiBe" runat="server" Text="Xì Bể" /></span> <span style="margin-left: 20px">
                    <asp:CheckBox ID="chkNuocVang" runat="server" Text="Nước Vàng" /></span>
            <span style="margin-left: 20px">
                <asp:Label ID="Label5" runat="server" Text="Nguyên Nhân Khác:"></asp:Label>
                <asp:TextBox ID="txtNguyenNhanKhac" runat="server"></asp:TextBox></span>
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="Điện Thoại Khách Hàng:"></asp:Label>
            <asp:TextBox ID="txtDienThoai" runat="server"></asp:TextBox><span style="margin-left: 20px">
                <asp:Label ID="Label7" runat="server" Text="Thời Gian Nhận:"></asp:Label>
                <asp:TextBox ID="txtNgayNhan" runat="server" TextMode="Date"></asp:TextBox></span><span
                    style="margin-left: 20px">
                    <asp:Label ID="Label8" runat="server" Text="Thời Gian Giao:"></asp:Label>
                    <asp:TextBox ID="txtNgayGiao" runat="server" TextMode="Date"></asp:TextBox></span>
        </div>
        <div>
            <asp:CheckBox ID="chkGiamSat_GNKDT" runat="server" Text="Phòng GNKDT:" OnCheckedChanged="chkGiamSat_GNKDT_CheckedChanged" />
            <asp:DropDownList ID="cmbGiamSat_GNKDT" runat="server">
            </asp:DropDownList>
            <span style="margin-left: 20px">
                <asp:CheckBox ID="chkGiamSat_KTCN" runat="server" Text="Phòng KTCN:" OnCheckedChanged="chkGiamSat_KTCN_CheckedChanged" />
                <asp:DropDownList ID="cmbGiamSat_KTCN" runat="server">
                </asp:DropDownList>
            </span>
            <span style="margin-left: 20px">
            <asp:Label ID="Label9" runat="server" Text="Công Nhân Thực Hiện:"></asp:Label>
                <asp:DropDownList ID="cmbSuaBe" runat="server">
                </asp:DropDownList>
                <asp:TextBox ID="txtDienThoaiSuBe" runat="server" ></asp:TextBox>
            </span>
        </div>
        <div>
            <span style="margin-left: 80px">
                <asp:Button ID="btnThem" runat="server" Text="Thêm" /></span> <span style="margin-left: 10px">
                    <asp:Button ID="btnSua" runat="server" Text="Sửa" /></span> <span style="margin-left: 10px">
                        <asp:Button ID="btnXoa" runat="server" Text="Xóa" /></span>
        </div>
        <div>
            <asp:GridView ID="dgvBaoBe" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                OnRowCancelingEdit="dgvBaoBe_RowCancelingEdit" OnRowEditing="dgvBaoBe_RowEditing"
                OnRowDeleting="dgvBaoBe_RowDeleting" OnRowUpdating="dgvBaoBe_RowUpdating" OnRowDataBound="dgvBaoBe_RowDataBound">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="SoNha" HeaderText="Số Nhà" />
                    <asp:BoundField DataField="TenDuong" HeaderText="Tên Đường" />
                    <asp:BoundField DataField="Phuong" HeaderText="Phường" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
