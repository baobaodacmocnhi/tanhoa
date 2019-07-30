<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabCodeDocSo.ascx.cs" Inherits="BaoCao_Web.View.tabDHN.tabCodeDocSo" %>
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
         width: 109px;
        height: 26px;
    }
    .style7
    {
         height: 26px;
        text-align: center;
    }
    .style9
    {
        width: 90px;
        height: 28px;
        text-align:right;
        margin-right:10px;
        
    }
    </style>

<div class="block block_left events" style="width: 1750px; float:left;">
        <table style="font-size:14px; font-family: Times New Roman;">
            <tr>
                <td class="style2"> 
                    <asp:Label ID="Label13" runat="server" Text=" BÁO CÁO THEO :" 
                        CssClass="label" Visible="False"></asp:Label></td>
                <td class="style2"> 
                    <asp:DropDownList ID="bcTheo" runat="server" Visible="False">
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
                     <td class="style7" colspan="9">
                         <strong>KỲ NÀY</strong></td>
                   
                     <td class="style7" colspan="9" style="background-color:#FFB6C1;"">
                         <strong>KỲ TRƯỚC</strong></td>
                   
                </tr>
                 <tr class="head1">
                  
                    <td class="style9">
                        04</td>
                    <td class="style9">
                        05</td>
                  <td class="style9">
                        06</td>
                    <td class="style9">
                        08</td>
                    <td class="style9">
                        M</td>
                    <td class="style9">
                        N</td>
                    <td class="style9">
                        Q</td>
                    <td class="style9">
                        F</td>
                    <td class="style9">
                        K</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        04</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        05</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        06</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        08</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        M</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        N</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        Q</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        F</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        K</td>
                </tr>
              </tbody>
            </table>
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="390px" 
                Width="1745px" BorderWidth="0px">
            <asp:GridView ID="bcCode" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#CC9966" 
    BorderWidth="1px" CellPadding="4" 
                            ShowFooter="True" ShowHeader="False" 
                onrowdatabound="bcCode_RowDataBound" style="margin-right: 0px" 
                BorderStyle="Dotted" >
                <Columns>
                    <asp:TemplateField HeaderText="TENTO">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TENTO") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label14" runat="server" Text='<%# Bind("TENTO") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                            HorizontalAlign="Center" VerticalAlign="Middle" Width="118px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KT_DHN">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("KN_CODE4") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KN_CODE4" runat="server" Text='<%# Bind("KN_CODE4") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KN_CODE4" runat="server" Text='<%# Bind("KN_CODE4","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("KN_CODE5") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KN_CODE5" runat="server" Text='<%# Bind("KN_CODE5") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KN_CODE5" runat="server" 
                                            Text='<%# Bind("KN_CODE5","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KN_DHN">
                        <EditItemTemplate>
                            <asp:TextBox ID="KN_CODE6" runat="server" Text='<%# Bind("KN_CODE6") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KN_CODE6" runat="server" Text='<%# Bind("KN_CODE6") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KN_CODE6" runat="server" Text='<%# Bind("KN_CODE6","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KN_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KN_CODE8" runat="server" Text='<%# Bind("KN_CODE8") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KN_CODE8" runat="server" Text='<%# Bind("KN_CODE8") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KN_CODE8" runat="server" 
                                            Text='<%# Bind("KN_CODE8","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TANGIAM_DHN">
                        <EditItemTemplate>
                            <asp:TextBox ID="KN_CODEM" runat="server" Text='<%# Bind("KN_CODEM") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KN_CODEM" runat="server" Text='<%# Bind("KN_CODEM") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                           <asp:Label ID="KN_CODEM" runat="server" 
                                                        Text='<%# Bind("KN_CODEM","{0:0,0}") %>'></asp:Label>
                                
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TANGIAM_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KN_CODEN" runat="server" 
                                            Text='<%# Bind("KN_CODEN") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KN_CODEN" runat="server" Text='<%# Bind("KN_CODEN") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KN_CODEN" runat="server" 
                                                        Text='<%# Bind("KN_CODEN","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NT_DHN">
                        <EditItemTemplate>
                            <asp:TextBox ID="KN_CODEQ" runat="server" Text='<%# Bind("KN_CODEQ") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KN_CODEQ" runat="server" Text='<%# Bind("KN_CODEQ") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KN_CODEQ" runat="server" Text='<%# Bind("KN_CODEQ","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KN_CODEF" runat="server" Text='<%# Bind("KN_CODEF") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KN_CODEF" runat="server" Text='<%# Bind("KN_CODEF") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KN_CODEF" runat="server" 
                                            Text='<%# Bind("KN_CODEF","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>
                    
                                        <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KN_CODEK" runat="server" Text='<%# Bind("KN_CODEK") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KN_CODEK" runat="server" Text='<%# Bind("KN_CODEK") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KN_CODEK" runat="server" 
                                            Text='<%# Bind("KN_CODEK","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>

                                        <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KT_CODE4" runat="server" Text='<%# Bind("KT_CODE4") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KT_CODE4" runat="server" Text='<%# Bind("KT_CODE4") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KT_CODE4" runat="server" 
                                            Text='<%# Bind("KT_CODE4","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>

                                        <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KT_CODE5" runat="server" Text='<%# Bind("KT_CODE5") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KT_CODE5" runat="server" Text='<%# Bind("KT_CODE5") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KT_CODE5" runat="server" 
                                            Text='<%# Bind("KT_CODE5","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>

                                        <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KT_CODE6" runat="server" Text='<%# Bind("KT_CODE6") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KT_CODE6" runat="server" Text='<%# Bind("KT_CODE6") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KT_CODE6" runat="server" 
                                            Text='<%# Bind("KT_CODE6","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>

                                        <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KT_CODE8" runat="server" Text='<%# Bind("KT_CODE8") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KT_CODE8" runat="server" Text='<%# Bind("KT_CODE8") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KT_CODE8" runat="server" 
                                            Text='<%# Bind("KT_CODE8","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>

                                        <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KT_CODEM" runat="server" Text='<%# Bind("KT_CODEM") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KT_CODEM" runat="server" Text='<%# Bind("KT_CODEM") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KT_CODEM" runat="server" 
                                            Text='<%# Bind("KT_CODEM","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>

                                        <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KT_CODEN" runat="server" Text='<%# Bind("KT_CODEN") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KT_CODEN" runat="server" Text='<%# Bind("KT_CODEN") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KT_CODEN" runat="server" 
                                            Text='<%# Bind("KT_CODEN","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>

                                        <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KT_CODEQ" runat="server" Text='<%# Bind("KT_CODEQ") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KT_CODEQ" runat="server" Text='<%# Bind("KT_CODEQ") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KT_CODEQ" runat="server" 
                                            Text='<%# Bind("KT_CODEQ","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KT_CODEF" runat="server" Text='<%# Bind("KT_CODEF") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KT_CODEF" runat="server" Text='<%# Bind("KT_CODEF") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KT_CODEF" runat="server" 
                                            Text='<%# Bind("KT_CODEF","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="NT_SANLUONG">
                        <EditItemTemplate>
                            <asp:TextBox ID="KT_CODEK" runat="server" Text='<%# Bind("KT_CODEK") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="KT_CODEK" runat="server" Text='<%# Bind("KT_CODEK") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="KT_CODEK" runat="server" 
                                            Text='<%# Bind("KT_CODEK","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" 
                            Font-Bold="true" />
                        <ItemStyle Font-Names="Times New Roman" Font-Size="Medium" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
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