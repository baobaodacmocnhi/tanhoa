<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="tab_TheoDoiHoDon0.aspx.cs" Inherits="BaoCao_Web.View.tab_TheoDoiHoDon0" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
  

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script type="text/javascript" src="https://www.google.com/jsapi"></script><!-- linechart "corechart",-->
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["linechart" ] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
        
            var data = google.visualization.arrayToDataTable(
         <%=Session["hoadon"] %>
        );

            var options = {                
                 width: 630,
                 height: 280
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>

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
        .style9
        {
            text-align: center;
              border-bottom-style: solid;
        border-right:2px #99cc99 solid;
        border-bottom-width: 1px;
            height: 44px;
        }
        .style10
        {
            width: 263px;
            text-align: center;
            border-bottom-style: solid;
            border-right:2px #99cc99 solid;
            border-bottom-width: 1px;
            height: 44px;
        }
        .style13
        {
            text-align: center;
            width: 120px;
              border-bottom-style: solid;
        border-right:2px #99cc99 solid;
        border-bottom-width: 1px;
            height: 44px;
        }
        .style16
        {
            text-align: center;
            width: 164px;
            border-bottom-style: solid;
            border-right: 1px #99cc99 solid;
            border-bottom-width: 1px;
            height: 44px;
        }
        .style18
        {
            width: 263px;
            border-bottom-style: solid;
            border-right: 1px #99cc99 solid;
            border-bottom-width: 1px;
            height: 42px;
        }
        .style19
        {
            width: 120px;
            border-bottom-style: solid;
            border-right: 1px #99cc99 solid;
            border-bottom-width: 1px;
            height: 42px;
        }
        .style20
        {
            width: 164px;
            border-bottom-style: solid;
            border-right: 1px #99cc99 solid;
            border-bottom-width: 1px;
            height: 42px;
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

<div class="title_page"><asp:Label ID="title" runat="server" Text="THEO DÕI CÔNG TÁC GIẢM HÓA ĐƠN = 0M<sup>3</sup>   "></asp:Label></div>
 <asp:Panel ID="Panel1" runat="server" Height="94%" ScrollBars="Both" >  
       <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1"  />     
 <div class="block block_left events" style="width: 1250px; margin-left:10px; margin-bottom:10px;">
 	
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
                         onrowcommand="dataTongBK_RowCommand" style="margin-right: 0px">
                         <Columns>
                             <asp:TemplateField HeaderText="TỔNG KẾT CÔNG TÁC GIẢM HÓA ĐƠN =0<SuP>3</SuP>">
                                 <ItemTemplate>
                                    
                                    
                                     <table style="width:100%; font-family:Times New Roman; font-size:16px; " cellpadding="0" cellspacing="0" 
                class="table_list">
                                         <tr>
                                             <td class="style10">
                                                 </td>
                                             <td class="style13">
                                                 TỔNG CỘNG</td>
                                             <td class="style16">
                                                 CAM KẾT SỬ DỤNG NƯỚC</td>
                                             <td class="style9">
                                                 KHÁCH HÀNG ĐỒNG Ý BẤM CHÌ</td>
                                         </tr>
                                         <tr>
                                             <td class="style18" align="left">
                                                 GỬI THƯ BÁO KHÁCH HÀNG</td>
                                             <td class="style19" align="center"><b>
                                                 <asp:LinkButton ID="SL_GHINHAN" runat="server" 
                                                     CommandName="SOLUONGTHAY" ForeColor="Blue" 
                                                     Text='<%# Bind("SL_GHINHAN","{0:0,0}") %>'></asp:LinkButton></b>
                                             </td>
                                             <td class="style20"  align="center"><b>
                                                 <asp:LinkButton ID="DHN_CAMKET" runat="server" 
                                                     CommandName="SOLUONGTHAY" ForeColor="Blue" 
                                                     Text='<%# Bind("DHN_CAMKET","{0:0,0}") %>'></asp:LinkButton></b>
                                             </td>
                                             <td  class="style20"  align="center"><b>
                                                <asp:LinkButton ID="DHN_BAMCHI" runat="server" 
                                                     CommandName="SOLUONGTHAY" ForeColor="Blue" 
                                                     Text='<%# Bind("DHN_BAMCHI","{0:0,0}") %>'></asp:LinkButton></b></td>
                                         </tr>
                                         <tr>
                                             <td class="style18" align="left">
                                                 KIỂM TRA SỬ DỤNG NƯỚC</td>
                                             <td class="style19"  align="center"><b>
                                                 <asp:LinkButton ID="KTKS_GHINHAN" runat="server" 
                                                     CommandName="SOLUONGTHAY" ForeColor="Blue" 
                                                     Text='<%# Bind("KTKS_GHINHAN","{0:0,0}") %>'></asp:LinkButton></b>
                                             </td>
                                             <td class="style20"  align="center"><b>
                                                <asp:LinkButton ID="KTKS_BAMCHI" runat="server" 
                                                     CommandName="SOLUONGTHAY" ForeColor="Blue" 
                                                     Text='<%# Bind("KTKS_CAMKET","{0:0,0}") %>'></asp:LinkButton></b></td>
                                             <td  class="style20"  align="center"><b>
                                                 <asp:LinkButton ID="KTKS_CAMKET" runat="server" 
                                                     CommandName="SOLUONGTHAY" ForeColor="Blue" 
                                                     Text='<%# Bind("KTKS_BAMCHI","{0:0,0}") %>'></asp:LinkButton></b></td>
                                         </tr>
                                     </table>
                                 </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Medium"/>
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Large"  />
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
       <tr>
            <td colspan="5">
            <br />
            <h3>Biểu Đồ Theo Dõi Hóa Đơn =0 M<sup>3</sup> </h3>
                <div id="chart_div" style="width: 630px; height: 330px;"></div>
            </td>
       </tr>
        </table>
        <br /> 
       <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tungay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>
         <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="denngay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>

    </div>
 
 
 
       </asp:Panel>
   
 </div>     

</asp:Content>
