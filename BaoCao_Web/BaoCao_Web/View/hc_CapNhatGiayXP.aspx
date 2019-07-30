<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="hc_CapNhatGiayXP.aspx.cs" Inherits="BaoCao_Web.View.hc_CapNhatGiayXP" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script language="javascript" type="text/javascript">
          window.document.getElementById("HOME").className = "top_link";
          window.document.getElementById("DHN").className = "top_link";
          window.document.getElementById("CHAMCONG").className = "current_link";
          window.document.getElementById("BDBC").className = "top_link";
    </script>
    <style type="text/css">
        .style4
        {
        }
        .style7
        {
            width: 252px;
        }
        .style8
        {
        }
        .style10
        {
            width: 135px;
        }
        .style12
        {
            width: 170px;
        }
        .style13
        {
            width: 169px;
        }
        .style14
        {
            width: 157px;
        }
        .style15
        {
            width: 140px;
        }
        .style16
        {
            width: 169px;
            height: 71px;
        }
        .style17
        {
            height: 71px;
        }
        .style18
        {
            height: 71px;
        }
        .style20
        {
            width: 140px;
            height: 71px;
        }
        .style21
        {
            width: 252px;
            height: 71px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="title_page" style="hight:20px;"><asp:Label ID="title" runat="server" 
        Text="CẬP NHẬT GIẤY ĐƯỢC PHÉP VỀ SỚM"></asp:Label>
    </div>
<div class="block_content">
    <AjaxControl:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </AjaxControl:ToolkitScriptManager>
    <table class="table_list_in">
                    <tr>
                        <td class="style12">
                            PHÒNG BAN ĐỘI :</td>
                        <td class="style8">
                            <asp:DropDownList ID="cbPhongBanDoi" runat="server" Height="19px" Width="195px" 
                                AutoPostBack="True" onselectedindexchanged="cbPhongBanDoi_SelectedIndexChanged">
                                <asp:ListItem Value="1">Tất Cả</asp:ListItem>
                                <asp:ListItem Value="2">To</asp:ListItem>
                                <asp:ListItem Value="3">232</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style4" colspan="2">
                            <asp:CheckBox ID="ckNV" runat="server" Checked="True" 
                                Text="Nhân Viên Văn Phòng" />
                        </td>
                        <td colspan="2">
                            <asp:CheckBox ID="ckCN" runat="server" Text="Công Nhân Đi Ngoài" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style12">
                            NHÂN VIÊN :</td>
                        <td class="style8">
                            <asp:DropDownList ID="cpNhanVien" runat="server" Height="19px" Width="195px">
                                <asp:ListItem Value="1">Tất Cả</asp:ListItem>
                                <asp:ListItem Value="2">To</asp:ListItem>
                                <asp:ListItem Value="3">232</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style10">
                            <asp:Label ID="Label7" runat="server" Text="THÁNG"></asp:Label>
                        &nbsp;<asp:DropDownList ID="cbThang" runat="server" Width="61px">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style14">
                            &nbsp;</td>
                        <td class="style15">
                            &nbsp;</td>
                        <td class="style7">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style12">
                            LOẠI GIẤY PHÉP :</td>
                        <td class="style8">
                            <asp:DropDownList ID="cpLoaiGiayPhep" runat="server" Height="19px" 
                                Width="195px" AutoPostBack="True" 
                                onselectedindexchanged="cpLoaiGiayPhep_SelectedIndexChanged">
                                <asp:ListItem Value="TN">Trong Ngày</asp:ListItem>
                                <asp:ListItem Value="TH">Có Thời Hạn</asp:ListItem>
                                <asp:ListItem Value="KT">Không Thời Hạn</asp:ListItem>
                                <asp:ListItem Value="CT">Công Tác</asp:ListItem>
                                <asp:ListItem Value="VH">Đi Ngoài</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style10">
                            &nbsp;<asp:Label ID="Label1" runat="server" Text="NGÀY"></asp:Label>
                        </td>
                        <td class="style14">
                            <asp:TextBox ID="tungay" runat="server" autocomplete="off" />
                            <AjaxControl:CalendarExtender ID="CalendarExtender1" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="tungay">
                            </AjaxControl:CalendarExtender>
                            
                        </td>
                        <td class="style15">
                            <asp:Label ID="Label2" runat="server" Text="TỪ NGÀY" Visible="False"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="denngay" runat="server" autocomplete="off" Visible="False" />
                            <AjaxControl:CalendarExtender ID="CalendarExtender2" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="denngay">
                            </AjaxControl:CalendarExtender>
                           
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style13" align="right">
                            <asp:Label ID="Label3" runat="server" Text="BUỔI :" Visible="False"></asp:Label>
                        </td>
                        <td class="style8">
                            <asp:DropDownList ID="cbGiayCongTac" runat="server" Visible="False">
                                <asp:ListItem Value="N">Cả Ngày</asp:ListItem>
                                <asp:ListItem Value="S">Buổi Sáng</asp:ListItem>
                                <asp:ListItem Value="C">Buổi Chiều</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style10">
                            <asp:Label ID="Label4" runat="server" Text="PHÚT VÀO TRỂ"></asp:Label>
                        </td>
                        <td class="style14">
                            <asp:TextBox ID="txtPhutVao" runat="server"></asp:TextBox>
                        </td>
                        <td class="style15">
                            <asp:Label ID="Label5" runat="server" Text="PHÚT VỀ SỚM"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="txtPhutRa" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style16">
                            <asp:Label ID="Label6" runat="server" Text="Nội Dung :" Visible="False"></asp:Label>
                            </td>
                        <td class="style17">
                            <asp:TextBox ID="txtNoiDungCT" runat="server" Height="24px" Visible="False" 
                                Width="197px"></asp:TextBox>
                        </td>
                        <td class="style18" colspan="2">
                            <asp:Button ID="btXemBangKe" runat="server" CssClass="button" 
                                onclick="btXemBangKe_Click" Text="CẬP NHẬT" Height="32px" Width="139px" />
                            </td>
                        <td class="style20">
                            </td>
                        <td class="style21">
                            </td>
                    </tr>
                    <tr>
                        <td class="style12">
                            &nbsp;</td>
                        <td class="style8" colspan="5">
                            <asp:Label ID="lbThanhCong" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <fieldset>
                                <legend><b>DANH SÁCH NGÀY XIN PHÉP THÁNG
                            <asp:DropDownList ID="cbThang0" runat="server" Width="61px">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="cbNam" runat="server" Width="61px">
                            </asp:DropDownList>
                        &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button" 
                                onclick="Button1_Click" Text="XEM" Height="21px" Width="113px" />
                                    </b></legend>
                                
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CellPadding="4" onpageindexchanging="GridView1_PageIndexChanging" 
                                    Width="100%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" 
                                    BorderWidth="1px" style="text-align: center" 
                                    onrowcommand="GridView1_RowCommand" PageSize="15">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                        <asp:BoundField DataField="PHONGBAN" HeaderText="PHÒNG BAN">
                                        <ItemStyle VerticalAlign="Middle" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MANV" HeaderText="MÃ NV">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TENNV" HeaderText="HỌ TÊN" >
                                        <ItemStyle VerticalAlign="Middle" Width="240px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LOAICT" HeaderText="XIN PHÉP" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TUNGAY" HeaderText="TỪ NGÀY" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DENNGAY" HeaderText="ĐẾN NGÀY" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PHUTVAO" HeaderText="VÀO TRỂ" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PHUTRA" HeaderText="VỀ SỚM" >
                                        <ItemStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="TRONGAI" runat="server" CommandArgument='<%# Bind("ID") %>' 
                                                    CommandName="TRONGAI" ForeColor="Blue" 
                                                    onclientclick="if(confirm('Bạn có muốn xóa ?') == false)return false;">Xóa</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>
                                
                            </fieldset>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
