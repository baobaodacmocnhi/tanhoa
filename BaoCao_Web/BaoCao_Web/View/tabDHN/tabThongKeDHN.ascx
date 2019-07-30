<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabThongKeDHN.ascx.cs" Inherits="BaoCao_Web.View.tabDHN.tabThongKeDHN" %>
<style type="text/css">
    .style7
    {
         width: 100px;
        height: 26px;
    }
    .style9
    {
        width: 120px;
        height: 28px;
        text-align:right;
        margin-right:10px;
    }
    </style>
<table width="2500px;" border="0" cellpadding="0" cellspacing="0">
<tr>
<td>
<div class="block block_left events" style="width: 780px;">
<h4>TỔNG SỐ ĐỒNG HỒ NƯỚC&nbsp; KỲ&nbsp;
                    <asp:DropDownList ID="cbKy" runat="server" Height="20px" 
        Width="47px" AutoPostBack="True" 
        onselectedindexchanged="cbKy_SelectedIndexChanged">
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
                 LÀ 
    <asp:Label ID="lbSoDHN" runat="server" Text="Label" CssClass="numberonline" 
        Font-Bold="True" Font-Names=".VnBodoniH" Font-Size="15pt" ForeColor="Red"></asp:Label>
</h4>

</div>

</td>
</tr>
<tr>
<td><div class="block block_left events" style="width: 160px;">
 	<!--<h3>THEO CỞ ĐHN </h3>
	<div class="block_content">
        <asp:GridView ID="DONGHONUOC" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ShowFooter="True" style="text-align: right" 
            onrowdatabound="DONGHONUOC_RowDataBound">
            <Columns>
                <asp:BoundField DataField="CODH" HeaderText="CỞ ĐHN">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="SỐ LƯỢNG">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SODH") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lbSum" runat="server" Text="Label"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SODH","{0:0,0}")  %>'></asp:Label>
                     </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
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
 	</div>-->
   
    <h3>THEO NĂM LẮP ĐẶT </h3>
    <div class="block_content">
        <asp:GridView ID="NAMGAN" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ShowFooter="True" style="text-align: right" 
            onrowdatabound="NAMGAN_RowDataBound">
            <Columns>
                <asp:BoundField DataField="NGAYTHAY" HeaderText="NĂM GẮN">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="SỐ LƯỢNG">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SODH") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lbSum" runat="server" Text="Label"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SODH","{0:0,0}")  %>'></asp:Label>
                     </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
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


 	</div>
</div>
<div class="block block_left events" style="width: 2330px; float:right">
 	<h3> BẢNG THỐNG KÊ SỐ LIỆU ĐỒNG HỒ NƯỚC TRÊN MẠNG </h3>
	<div class="block_content">
        <table cellpadding="0" cellspacing="0" style="width:100%; font-family:Times New Roman; font-size:15px;" class="table_list" >
              <tbody>
                  <tr class="head" >
                    <td style="width:165px;" rowspan="2">TÊN ĐHN
                        </td>
                    <td class="style7" colspan="9" style="background-color:#FFB6C1;">
                        <b>HIỆN CÓ TRÊN MẠNG (1);</b> &nbsp;&nbsp; (1) = (2) + (3) </td>
                     
                    <td class="style7" colspan="9">
                      <b>SỬ DỤNG < 5 NĂM (2);</b></td>
                     <td class="style7" colspan="9">
                       <b>SỬ DỤNG >= 5 NĂM (3);</b></td>
                </tr>
                 <tr class="head1">
                  
                    <td class="style9">
                        15</td>
                    <td class="style9">
                        20</td>
                  <td class="style9">
                        25</td>
                    <td class="style9">
                        40</td>
                    <td class="style9">
                        50</td>
                    <td class="style9">
                       75</td>
                    <td class="style9">
                        100</td>
                    <td class="style9">
                        150</td>
                    <td class="style9">
                        200</td>
                    <td class="style9" style="background-color:#9ACD32;">
                        15</td>
                    <td class="style9" style="background-color:#9ACD32;">
                        20</td>
                  <td class="style9" style="background-color:#9ACD32;">
                        25</td>
                    <td class="style9" style="background-color:#9ACD32;">
                        40</td>
                    <td class="style9" style="background-color:#9ACD32;">
                        50</td>
                    <td class="style9" style="background-color:#9ACD32;">
                       75</td>
                    <td class="style9" style="background-color:#9ACD32;">
                        100</td>
                    <td class="style9" style="background-color:#9ACD32;">
                        150</td>
                    <td class="style9" style="background-color:#9ACD32;">
                        200</td>

                     <td class="style9" style="background-color:#FFB6C1;">
                        15</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        20</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        25</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        40</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        50</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                       75</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        100</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        150</td>
                    <td class="style9" style="background-color:#FFB6C1;">
                        200</td>
                </tr>
              
              </tbody>
            </table>
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" 
                Width="2340px" BorderWidth="0px">
                <asp:GridView ID="thongkedhn" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" ForeColor="Black" GridLines="Vertical" ShowFooter="True" 
                    onrowdatabound="thongkedhn_RowDataBound" ShowHeader="False" Width="2327px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Select" Text='<%# Bind("TENDHN") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderText="15">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </ItemTemplate> 
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="20">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CO20","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="Label289" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("CO20","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                             <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                             <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="25">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CO25","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("CO25") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="40">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CO40") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("CO40","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="50">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("CO50","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("CO50","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="80">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("CO80","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("CO80","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="100">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("CO100","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("CO100","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="150">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("CO150","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("CO150","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="200">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("CO200","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("CO200","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="15">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("NHOCO15","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("NHOCO15","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="20">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("NHOCO20","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("NHOCO20","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="25">
                            <EditItemTemplate>
                                <asp:TextBox ID="Label12" runat="server" Text='<%# Bind("NHOCO25") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("NHOCO25","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="40">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("NHOCO40","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("NHOCO40","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="50">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("NHOCO50","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("NHOCO50","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="80">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("NHOCO80","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("NHOCO80","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="100">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("NHOCO100","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label16" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label16" runat="server" Text='<%# Bind("NHOCO100","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="150">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("NHOCO150","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%# Bind("NHOCO150","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="200">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("NHOCO200","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label18" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label18" runat="server" Text='<%# Bind("NHOCO200","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="15">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("LONCO15","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label19" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label19" runat="server" Text='<%# Bind("LONCO15","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="20">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("LONCO20","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label20" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label20" runat="server" Text='<%# Bind("LONCO20","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px"  />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="25">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("LONCO25","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Bind("LONCO25","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px"  />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="40">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("LONCO40","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label22" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label22" runat="server" Text='<%# Bind("LONCO40","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px"  />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="50">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox23" runat="server" Text='<%# Bind("LONCO50","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label23" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label23" runat="server" Text='<%# Bind("LONCO50","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px"  />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="80">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox24" runat="server" Text='<%# Bind("LONCO80","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label24" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label24" runat="server" Text='<%# Bind("LONCO80","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px"  />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="100">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox25" runat="server" Text='<%# Bind("LONCO100","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label25" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label25" runat="server" Text='<%# Bind("LONCO100","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px"  />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="150">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox26" runat="server" Text='<%# Bind("LONCO150","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Bind("LONCO150","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px"  />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="200">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox27" runat="server" Text='<%# Bind("LONCO200","{0:0,0}") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Bind("CO15","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Bind("LONCO200","{0:0,0}") %>'></asp:Label>
                             </ItemTemplate> <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                             <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" 
                                 />
                        </asp:TemplateField>
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
        </asp:Panel>
    </div>
  </div></td></tr>
</table>

