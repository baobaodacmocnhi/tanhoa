<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabTheoDoiTieuThuThap.ascx.cs" Inherits="BaoCao_Web.View.tabDHN.tabTheoDoiTieuThuThap" %>
<link href="../../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style2
    {
        height: 40px;
    }
    .style3
    {
        width: 75px;
        height: 40px;
    }
    .style4
    {
        width: 66px;
        height: 40px;
    }
    .style5
    {
        width: 66px;
    }
    .style6
    {
         width: 119px;
        height: 26px;
    }
    .style7
    {
         width: 100px;
        height: 26px;
    }
    .style9
    {
        width: 100px;
        height: 28px;
        text-align:right;
        margin-right:10px;
    }
    </style>

<div class="block block_left events" style="width: 1200px; float:left;">
        <table style="font-size:14px; font-family: Times New Roman;">
            <tr>
                <td class="style2"> 
                    <asp:Label ID="Label13" runat="server" Text=" BÁO CÁO THEO :" 
                        CssClass="label" Visible="False"></asp:Label></td>
                <td class="style2"> 
                    <asp:DropDownList ID="bcTheo" runat="server" 
                        onselectedindexchanged="bcTheo_SelectedIndexChanged" Visible="False">
                        <asp:ListItem Value="1">Tổ Đọc Số</asp:ListItem>
                        <asp:ListItem Value="2">Quận Phường</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style2"> <asp:Label ID="Label1" runat="server" Text="ĐỢT ĐỌC SỐ  : " 
                        CssClass="label"></asp:Label></td>
                <td class="style3">
                    <asp:DropDownList ID="dot" runat="server" Height="20px" Width="56px">
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style2"> 
                    <asp:Label ID="Label2" runat="server" Text="KỲ " 
                        CssClass="label"></asp:Label></td>
                <td class="style4">
                    <asp:DropDownList ID="ky" runat="server" Height="20px" Width="47px">
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="NĂM" 
                        CssClass="label"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="nam" runat="server" Height="20px" Width="50px"></asp:TextBox>
                </td>
                <td class="style2">&nbsp;<asp:Button ID="btXemBangKe" runat="server" Text="XEM THÔNG TIN" 
                        CssClass="button" onclick="btXemBangKe_Click" /></td>
            </tr>
        </table>

 	<h3>&nbsp;
        </h3>
	<div class="block_content">
        
            <table cellpadding="0" cellspacing="0" style="width:100%; font-family:Times New Roman; font-size:15px;" class="table_list" >
              <tbody>
                  <tr class="head" >
                    <td class="style6" rowspan="2"><asp:Label ID="lbTieuDe" runat="server" Text="TỔ ĐỌC SỐ"></asp:Label> 
                        </td>
                    <td class="style7" colspan="2">
                        <b>KỲ TRƯỚC</b></td>
                     
                    <td class="style7" colspan="2">
                       <b>KỲ NÀY</b></td>
                     <td class="style7" colspan="2">
                       <b>TĂNG/GIẢM</b></td>
                 
                     <td class="style7" colspan="2">
                       <b>CÙNG KỲ NĂM TRƯỚC</b></td>
                     <td class="style7" colspan="2">
                       <b>TĂNG GIẢM</b></td>
                   
                </tr>
                 <tr class="head1">
                  
                    <td class="style9">
                        TT = 0 m<sup>3</sup></td>
                    <td class="style9">
                        TT = 1->4 m<sup>3</sup></td>
                  <td class="style9">
                        TT = 0 m<sup>3</sup></td>
                    <td class="style9">
                        TT = 1->4 m<sup>3</sup></td>
                    <td class="style9">
                        TT = 0 m<sup>3</sup></td>
                    <td class="style9">
                        TT = 1->4 m<sup>3</sup></td>
                    <td class="style9">
                        TT = 0 m<sup>3</sup></td>
                    <td class="style9">
                        TT = 1->4 m<sup>3</sup></td>
                    <td class="style9">
                        TT = 0 m<sup>3</sup></td>
                    <td class="style9">
                        TT = 1->4 m<sup>3</sup></td>
                </tr>
              </tbody>
            </table>
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="415px" 
                Width="1213px" BorderWidth="0px">
            <asp:GridView ID="sanLuongTo" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#CC9966" 
    BorderWidth="1px" CellPadding="4" 
                            ShowFooter="True" ShowHeader="False" 
                onrowdatabound="sanLuongTo_RowDataBound" style="margin-right: 0px" 
                BorderStyle="Dotted">
                <Columns>
                    <asp:TemplateField HeaderText="TENTO">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TENTO") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TENTO") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Middle" Width="118px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KT_DHN">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("KT_DHN") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="kt_DHN" runat="server" Text='<%# Bind("KT_DHN") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="kt_DHN" runat="server" Text='<%# Bind("KT_DHN","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("KT_SANLUONG") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="ktSanLuong" runat="server" Text='<%# Bind("KT_SANLUONG") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ktSanLuong" runat="server" 
                                            Text='<%# Bind("KT_SANLUONG","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KN_DHN">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("KN_DHN") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="kn_DHN" runat="server" Text='<%# Bind("KN_DHN") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="kn_DHN" runat="server" Text='<%# Bind("KN_DHN","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KN_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("KN_SANLUONG") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="knSanLuong" runat="server" Text='<%# Bind("KN_SANLUONG") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="knSanLuong" runat="server" 
                                            Text='<%# Bind("KN_SANLUONG","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TANGIAM_DHN">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TANGIAM_DHN") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" 
                                            style="width: 100%; height: 28px;">
                                <tr>
                                    <td style="text-align: left">
                                        &nbsp;<asp:Image ID="dhn_change_sum" runat="server" Height="24px" 
                                            Width="30px" />
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("TANGIAM_DHN") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                <tr>
                                    <td style="text-align: left">
                                        &nbsp;<asp:Image ID="dhn_change" runat="server" Height="24px" Width="30px" />
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label6" runat="server" 
                                                        Text='<%# Bind("TANGIAM_DHN","{0:0,0}") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TANGIAM_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" 
                                            Text='<%# Bind("TANGIAM_SANLUONG") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" 
                                            style="width: 100%; height: 28px;">
                                <tr>
                                    <td style="text-align: left">
                                        &nbsp;<asp:Image ID="sl_change_sum" runat="server" Height="24px" Width="30px" />
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("TANGIAM_SANLUONG") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                <tr>
                                    <td style="text-align: left">
                                        &nbsp;<asp:Image ID="sl_change" runat="server" Height="24px" 
                                                        ImageUrl="" Width="30px" />
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label7" runat="server" 
                                                        Text='<%# Bind("TANGIAM_SANLUONG","{0:0,0}") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NT_DHN">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("NT_DHN") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("NT_DHN") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("NT_DHN","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("NT_SANLUONG") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("NT_SANLUONG") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" 
                                            Text='<%# Bind("NT_SANLUONG","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NT_TANGIAM_DHN">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("NT_TANGIAM_DHN") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" 
                                            style="width: 100%; height: 28px;">
                                <tr>
                                    <td style="text-align: left">
                                        &nbsp;<asp:Image ID="nt_dhn_change_sum" runat="server" Height="24px" 
                                                        Width="30px" />
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("NT_TANGIAM_DHN") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                <tr>
                                    <td style="text-align: left">
                                        &nbsp;<asp:Image ID="dhn_nt" runat="server" Height="24px" 
                                                        ImageUrl="" Width="30px" />
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label10" runat="server" 
                                                        Text='<%# Bind("NT_TANGIAM_DHN","{0:0,0}") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NT_TANGIAM_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox11" runat="server" 
                                            Text='<%# Bind("NT_TANGIAM_SANLUONG") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" 
                                            style="width: 100%; height: 28px;">
                                <tr>
                                    <td style="text-align: left">
                                        &nbsp;<asp:Image ID="nt_sl_change_sum" runat="server" Height="24px" 
                                                        Width="30px" />
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label11" runat="server" 
                                                        Text='<%# Bind("NT_TANGIAM_SANLUONG") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                <tr>
                                    <td style="text-align: left">
                                        &nbsp;<asp:Image ID="sl_nt" runat="server" Height="24px" 
                                                        ImageUrl="" Width="30px" />
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label11" runat="server" 
                                            Text='<%# Bind("NT_TANGIAM_SANLUONG","{0:0,0}") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
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
        </asp:Panel>
   </div>
 </div>