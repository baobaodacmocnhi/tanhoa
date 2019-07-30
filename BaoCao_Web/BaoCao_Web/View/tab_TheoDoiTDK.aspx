<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="tab_TheoDoiTDK.aspx.cs" Inherits="BaoCao_Web.View.tab_TheoDoiTDK" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 145px;
            height: 39px;
        }
        .style2
        {
            width: 144px;
            height: 39px;
        }
        .style6
        {
            height: 39px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script language="javascript" type="text/javascript">
           window.document.getElementById("HOME").className = "top_link";
           window.document.getElementById("DHN").className = "current_link";
           window.document.getElementById("HSKH").className = "top_link";
           window.document.getElementById("BDBC").className = "top_link";
    </script>
   <div class="Pages_content">

<div class="title_page"><asp:Label ID="title" runat="server" Text="THEO DÕI THAY ĐỒNG HỒ NƯỚC "></asp:Label></div>
 <asp:Panel ID="Panel1" runat="server" Height="94%" ScrollBars="Both" >  
       <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1"  />     
 <div class="block block_left events" style="width: 1250px; margin-left:10px; margin-bottom:10px;">
 	<h3>Theo Dõi Tình Hình Báo Thay </h3>
	<div class="block_content">
        <table style="font-size:14px; font-family: Times New Roman;">
            <tr>
                <td class="style6"> <asp:Label ID="Label1" runat="server" Text="Từ Ngày : " CssClass="label"></asp:Label></td>
                <td class="style1"><asp:TextBox runat="server" ID="tungay" autocomplete="off" /></td>
                <td class="style6"> <asp:Label ID="Label2" runat="server" Text="Đến Ngày : " CssClass="label"></asp:Label></td>
                <td class="style2"><asp:TextBox runat="server" ID="denngay" autocomplete="off" /></td>
                <td class="style6">&nbsp;<asp:Button ID="btXemBangKe" runat="server" Text="XEM THÔNG TIN" 
                        CssClass="button" onclick="btXemBangKe_Click" /></td>
                
            </tr>
            <tr>
                <td colspan="5"></td>
            </tr>
             <tr>
                 <td colspan="5">
                     <asp:GridView ID="dataTongBK" runat="server" BackColor="White" 
                         BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                         AutoGenerateColumns="False" ShowFooter="True" Width="646px" 
                         onrowcommand="dataTongBK_RowCommand">
                         <Columns>
                             <asp:TemplateField HeaderText="SỐ LƯỢNG ĐHN">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="SOLUONGTHAY" runat="server" 
                                         CommandArgument='<%# Bind("SOLUONGTHAY","{0:0,0}") %>' 
                                         CommandName="SOLUONGTHAY" ForeColor="Blue" 
                                         Text='<%# Bind("SOLUONGTHAY","{0:0,0}") %>'></asp:LinkButton>
                                 </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Medium"/>
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Large"  />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="CHƯA THAY ">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="CHUAGAN" runat="server" 
                                         CommandArgument='<%# Bind("CHUAGAN","{0:0,0}") %>' CommandName="CHUAGAN" 
                                         ForeColor="Blue" Text='<%# Bind("CHUAGAN","{0:0,0}") %>'></asp:LinkButton>
                                 </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Large"/>
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Large" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="ĐÃ THAY">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("HOANTAT","{0:0,0}") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:LinkButton ID="HOANTAT" runat="server" 
                                         CommandArgument='<%# Bind("HOANTAT","{0:0,0}") %>' CommandName="HOANTAT" 
                                         ForeColor="Blue" Text='<%# Bind("HOANTAT","{0:0,0}") %>'></asp:LinkButton>
                                 </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Large" />
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Large" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="TRỞ NGẠI">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="TRONGAI" runat="server" 
                                         CommandArgument='<%# Bind("TRONGAI","{0:0,0}") %>' CommandName="TRONGAI" 
                                         ForeColor="Blue" Text='<%# Bind("TRONGAI","{0:0,0}") %>'></asp:LinkButton>
                                 </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Large"/>
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Large" />
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
                 </td>
            </tr>
        </table>    <br /> 
        
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Visible="false"
    Width="1227px">
    <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
    <HeaderTemplate>Danh Dách Trở Ngại Chưa Xử Lý</HeaderTemplate><ContentTemplate>
    <asp:GridView ID="danhsachtrongai" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                            CellPadding="4" ShowFooter="True" Visible="False" Height="180px" 
                            Width="1203px" onrowcreated="danhsachtrongai_RowCreated" 
            onrowdatabound="danhsachtrongai_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="TENBANGKE" HeaderText="BẢNG KÊ">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOBANGKE" HeaderText="SỐ BẢNG KÊ">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DHN_DANHBO" HeaderText="DANH BỘ">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TRONGAI" HeaderText="LÝ DO TRỞ NGẠI">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle VerticalAlign="Middle" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HOTEN" HeaderText="HỌ TÊN">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle  VerticalAlign="Middle" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DIACHI" HeaderText="ĐỊA CHỈ">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle  VerticalAlign="Middle" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NGAYBAO" HeaderText="NGÀY BÁO">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px"  />
                                </asp:BoundField>
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
              </ContentTemplate></ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
    <HeaderTemplate>Danh Dách Trở Ngại Đã Xử Lý</HeaderTemplate><ContentTemplate>
    
    <asp:GridView ID="daxuly" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                            CellPadding="4" ShowFooter="True" Visible="False" Height="180px" 
                            Width="1203px" 
            onrowdatabound="daxuly_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="TENBANGKE" HeaderText="BẢNG KÊ">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SOBANGKE" HeaderText="SỐ BẢNG KÊ">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DHN_DANHBO" HeaderText="DANH BỘ">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TRONGAI" HeaderText="LÝ DO TRỞ NGẠI">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle VerticalAlign="Middle" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOIDUNGXULY" HeaderText="CHUYỄN XỬ LÝ">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="XLT_KETQUA" HeaderText="KẾT QUẢ XỬ LÝ">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HOTEN" HeaderText="HỌ TÊN">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle  VerticalAlign="Middle" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DIACHI" HeaderText="ĐỊA CHỈ">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle  VerticalAlign="Middle" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NGAYBAO" HeaderText="NGÀY BÁO" Visible="False">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px"  />
                                </asp:BoundField>
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
    
    </ContentTemplate></ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
 
                
                <asp:GridView ID="tongBangKe" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                            CellPadding="4" ShowFooter="True" Visible="False" Width="326px">
                            <Columns>
                                <asp:TemplateField HeaderText="BẢNG KÊ">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BANGKE") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("BANGKE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Middle" Width="300px" />
                                    <HeaderStyle  HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                                    <ItemStyle  VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SỐ LƯỢNG">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" 
                                            Text='<%# Bind("SOLUONG","{0:0,0}") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("SOLUONG","{0:0,0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="200px" />
                                    <HeaderStyle  HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                                    <ItemStyle  HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="Red" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                        </asp:GridView>
     
     
     
       <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tungay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>
         <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="denngay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>

    </div>
 
 
 
       </asp:Panel>
   
 </div>     

</asp:Content>
