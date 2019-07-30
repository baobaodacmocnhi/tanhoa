<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="hc_CapNhatThongTinNV.aspx.cs" Inherits="BaoCao_Web.View.hc_CapNhatThongTinNV" %>

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
        {            color: #CC0000;
            font-size: x-large;
        }
        .style7
        {
            width: 252px;
        }
        .style8
        {
        }
        .style12
        {
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
        }
        .style16
        {
            width: 169px;
            height: 28px;
        }
        .style17
        {
            height: 28px;
        }
        .style20
        {
            width: 140px;
            height: 28px;
        }
        .style21
        {
            width: 252px;
            height: 28px;
        }
        .style22
        {
            width: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="title_page" style="hight:20px;">
        <asp:Label ID="title" runat="server" 
        Text="CẬP NHẬT THÔNG TIN NHÂN VIÊN"></asp:Label>
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
                        <td class="style22">
                            &nbsp;</td>
                        <td class="style4" rowspan="3">
                            <strong>CHUYỂN ĐẾN</strong></td>
                        <td>
                            PHÒNG BAN ĐỘI :</td>
                        <td>
                            <asp:DropDownList ID="cbPhongBanDoi0" runat="server" Height="19px" Width="195px" 
                                AutoPostBack="True">
                                <asp:ListItem Value="1">Tất Cả</asp:ListItem>
                                <asp:ListItem Value="2">To</asp:ListItem>
                                <asp:ListItem Value="3">232</asp:ListItem>
                            </asp:DropDownList>
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
                        <td class="style22">
                            &nbsp;</td>
                        <td class="style15" colspan="2">
                            <asp:CheckBox ID="ckNV0" runat="server" 
                                Text="Nhân Viên Văn Phòng" />
                            <asp:CheckBox ID="ckCN0" runat="server" Text="Công Nhân Đi Ngoài" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style12" colspan="2">
                            &nbsp;</td>
                        <td class="style22">
                            &nbsp;</td>
                        <td class="style15">
                            &nbsp;</td>
                        <td class="style7">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style13" align="right">
                            &nbsp;</td>
                        <td class="style8">
                            &nbsp;</td>
                        <td class="style22">
                            &nbsp;</td>
                        <td class="style14">
                            &nbsp;</td>
                        <td class="style15">
                            &nbsp;</td>
                        <td class="style7">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style16">
                            </td>
                        <td class="style17">
                            &nbsp;</td>
                        <td class="style17" colspan="2">
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
                            <asp:Label ID="lbThanhCong" runat="server" 
                                style="font-weight: 700; font-size: large; color: #0000FF"></asp:Label>
                        </td>
                    </tr>
                </table>
<center>
                
                
                <fieldset >
                                
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CellPadding="4" 
                                    Width="57%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" 
                                    BorderWidth="1px" style="text-align: center; margin-right: 31px;" 
                                PageSize="1000" onrowcommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:BoundField HeaderText="STT">
                                        <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UserFullCode" HeaderText="MÃ NV">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UserFullName" HeaderText="HỌ TÊN" >
                                        <ItemStyle VerticalAlign="Middle" Width="240px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UserLoaiNV" HeaderText="LOẠI NV" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Dept" HeaderText="PHÒNG BAN" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="TRONGAI" runat="server" 
                                                    CommandArgument='<%# Bind("UserFullCode") %>' CommandName="TRONGAI" 
                                                    ForeColor="Blue" 
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
</center>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
