<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tab_TheoDoiGhiCS.ascx.cs" Inherits="BaoCao_Web.View.tabDHN.tab_TheoDoiGhiCS" %>
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
    </style>

<div class="block block_left events" style="width: 780px; float:left;">
        <table style="font-size:14px; font-family: Times New Roman;">
            <tr>
                <td class="style2"> 
                    &nbsp;</td>
                <td class="style2"> 
                    &nbsp;</td>
                <td class="style2"> <asp:Label ID="Label1" runat="server" Text="ĐỢT ĐỌC SỐ  : " 
                        CssClass="label"></asp:Label></td>
                <td class="style3">
                    <asp:DropDownList ID="dot" runat="server" Height="20px" Width="56px">
                        <asp:ListItem>00</asp:ListItem>
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4" onrowdatabound="GridView1_RowDataBound" ShowFooter="True" 
                Width="775px" Font-Size="Medium" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="MÁY ĐS">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MAYDS","{0:0,0}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("MAYDS","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="70px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="FULLNAME" HeaderText="TÊN NHÂN VIÊN">
                    <ItemStyle VerticalAlign="Middle" Width="195px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SOLUONG" HeaderText="SỐ LƯỢNG" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BATDAU" HeaderText="BẮT ĐẦU ĐỌC" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="KETHUC" HeaderText="KẾT THÚC ĐỌC" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
    </div>
 </div>