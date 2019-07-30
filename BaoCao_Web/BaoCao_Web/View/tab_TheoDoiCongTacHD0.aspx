<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="tab_TheoDoiCongTacHD0.aspx.cs" Inherits="BaoCao_Web.View.tab_TheoDoiCongTacHD0" %>
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
                <td colspan="5">dsdassdaf</td>
            </tr>
             <tr>
                 <td colspan="5">
                     &nbsp;</td>
            </tr>
       <tr>
            <td colspan="5">
            <br />
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
