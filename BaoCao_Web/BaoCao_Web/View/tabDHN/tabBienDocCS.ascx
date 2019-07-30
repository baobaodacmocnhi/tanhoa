<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabBienDocCS.ascx.cs" Inherits="BaoCao_Web.View.tabDHN.tabBienDocCS" %>
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
         width: 37px;
        height: 26px;
    }
    .style7
    {
    }
    .style9
    {
        width: 100px;
        height: 28px;
        text-align:right;
        margin-right:10px;
    }
    .style10
    {
        width: 194px;
    }
    .style11
    {
        width: 70px;
    }
    .style12
    {
        width: 97px;
        height: 28px;
        text-align: right;
        margin-right: 10px;
    }
    </style>

<div class="block block_left events" style="width: 1000px; float:left;">
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
                    <td class="style6" rowspan="2" >SỐ STT</td>
                    <td class="style10" rowspan="2" >
                        HỌ TÊN&nbsp;</td>
                     
                    <td class="style11" rowspan="2" >
                       <b>MÁY<br />
&nbsp;ĐỌC SỐ</b></td>
                     <td class="style7" colspan="6" >
                         KẾT QUẢ BIÊN ĐỌC&nbsp;</td>
                 
                </tr>
                 <tr class="head1">
                  
                    <td class="style9">
                        SỐ LƯỢNG ĐHN</td>
                    <td class="style9">
                        SẢN LƯỢNG</td>
                    <td class="style9">
                        KHÔNG GHI ĐƯỢC CHỈ SỐ</td>
                    <td class="style9">
                        NHÀ
                        <br />
                        XÂY ĐỰNG</td>
                    <td class="style9">
                        CHỈ SỐ TĂNG BẤT THƯỜNG</td>
                    <td class="style12">
                        CHỈ SỐ GIẢM BẤT THƯỜNG</td>
                </tr>
              </tbody>
            </table>
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="390px" 
                Width="1193px" BorderWidth="0px" >
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4" onrowdatabound="GridView1_RowDataBound" ShowFooter="True" 
                ShowHeader="False" Width="994px" Font-Size="Medium">
                <Columns>
                    <asp:BoundField DataField="STT" HeaderText="STT">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="38px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FULLNAME" HeaderText="FULLNAME">
                    <ItemStyle VerticalAlign="Middle" Width="195px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="MAYDS">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MAYDS","{0:0,0}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("MAYDS","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SOLUONGDHN">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("SOLUONGDHN","{0:0,0}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("SOLUONGDHN","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SANLUONG","{0:0,0}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("SANLUONG","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KHONGGHI">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("KHONGGHI","{0:0,0}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("KHONGGHI","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NHAXD">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("NHAXD","{0:0,0}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("NHAXD","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TANG">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TANG","{0:0,0}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("TANG","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GIAM">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("GIAM","{0:0,0}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("GIAM","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </asp:Panel>
   </div>
 </div>