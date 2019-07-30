<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillData.aspx.cs" Inherits="BaoCao_Web.View.tabSanLuong.FillData" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link href="../../StyleSheet/Menu.css" rel="stylesheet" type="text/css" />
    <link href="../../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../JavaScript/transmenu.js" type="text/javascript"></script>
    <title>DANH SÁCH ĐHN</title>
    <style type="text/css">
        .style3
        {
            width: 151px;
        }
        .style4
        {
            width: 205px;
        }
        .style5
        {
            width: 21px; text-align: center;
        }
        .style6
        {
            width: 31px;
            text-align: center;
        }
        .style7
        {
            width: 88px;
            text-align: center;
        }
        .style8
        {
            width: 34px; text-align: center;
        }
        .style11
        {
            width: 60px;
            height: 21px;
            background-color: #E9E9E9;
        }
        .style12
        {
            width: 22px;
            font-weight: bold;
        }
        .style13
        {
            width: 45px;
            font-weight: bold;
        }
        .style14
        {
            width: 22px;
            height: 21px;
            text-align:center;
        }
        .style15
        {
            width: 45px;
            height: 21px;
        }
        .style17
        {
            width: 31px;
            text-align: center;
            font-weight: bold;
            background-color: #D8D8D8;
        }
        .style18
        {
            width: 21px;
            text-align: center;
            font-weight: bold;
            background-color: #D8D8D8;
        }
        .style19
        {
            width: 205px;
            font-weight: bold;
            background-color: #D8D8D8;
        }
        .style20
        {
            width: 151px;
            font-weight: bold;
            background-color: #D8D8D8;
        }
        .style21
        {
            width: 88px;
            text-align: center;
            font-weight: bold;
            background-color: #D8D8D8;
        }
        .style22
        {
            width: 34px;
            text-align: center;
            font-weight: bold;
            background-color: #D8D8D8;
        }
    </style>
</head>
<body>
  
    <form id="form1" runat="server">
  
  <div class="block block_left events" style=" width:100% ; margin-bottom:10px; border:1px;">
 	<h1 style="height: 46px">
        &nbsp;&nbsp;
        <asp:Button ID="Button1" CssClass="button"  runat="server" Text="Quay Lại" 
            onclick="Button1_Click1" />
&nbsp;<asp:Label ID="lbTt" runat="server" Text=""></asp:Label>
      &nbsp;<asp:TextBox ID="txtDanhBo" runat="server" Visible="False"></asp:TextBox>
&nbsp;<asp:Button ID="btThem" runat="server" onclick="Button1_Click" Text="Thêm" 
            Visible="False" />
        <asp:Button ID="btThem0" runat="server" onclick="btThem0_Click" Text="Xóa" 
            Visible="False" />
      </h1>
      <div style=" color:Red;font-weight:bold;"><i>Click Số Danh Bộ để xem chart sản lượng 12 kỳ đọc số</i></div>
	<div class="block_content">
      
      <!-- Start Show -->

      <table cellpadding="0" cellspacing="0" style="width:100%; font-family:Times New Roman; font-size:15px;" class="table_list" >
              <tbody>
               
         <tr>
               <td  rowspan="2" class="style22" 
                   style="border-right:2px #99cc99 solid; border-bottom: 1px solid; border-top:2px solid;">STT</td>                              
               <td  rowspan="2" class="style22" 
                   style="border-right:2px #99cc99 solid; border-bottom: 1px solid;border-top:2px solid;">ĐỢT</td>
               <td  rowspan="2" class="style21" 
                   style="border-right:2px #99cc99 solid; border-bottom: 1px solid;border-top:2px solid;">DANH BỘ</td>
               <td  rowspan="2" class="style20" 
                   style="border-right:2px #99cc99 solid; border-bottom: 1px solid;border-top:2px solid;"> HỌ TÊN </td>
               <td  rowspan="2" class="style19" 
                   style="border-right:2px #99cc99 solid; border-bottom: 1px solid;border-top:2px solid;"> ĐỊA CHỈ </td>
               <td  rowspan="2" class="style18" 
                   style="border-right:2px #99cc99 solid; border-bottom: 1px solid;border-top:2px solid;" >GB</td>
               <td  rowspan="2" class="style17" 
                   style="border-right:2px #99cc99 solid; border-bottom: 1px solid;border-top:2px solid;" >ĐM</td>  
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid;">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid; ">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid; ">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid; ">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid; ">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid;">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid;">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid;">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid;">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid;">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid;">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid;">&nbsp;</td>
            </tr>
            <tr>
                 <td style=" border-bottom: 1px solid;" class="style12">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;" 
                     class="style13">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
            </tr>
                     
         <%
             DataTable table = new DataTable();
             if (Session["chamcong"] != null)
             {
                 table = (DataTable)Session["chamcong"];
                 for (int i = 0; i < table.Rows.Count; i++)
                 {
                               %>
            <tr>
                
               <td  rowspan="2" class="style8" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;"><%=(i + 1)%></td>                              
               <td  rowspan="2" class="style8" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;"><%=table.Rows[i]["DOT"].ToString()%></td>
               <td  rowspan="2" class="style7" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;"><a title="Click Xem Biểu Đồ Sản Lượng !" href="CharBieuDoSL.aspx?value=<%=table.Rows[i]["DANHBO"].ToString()%>"><%=table.Rows[i]["DANHBO"].ToString()%></a></td>
               <td  rowspan="2" class="style3" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;"><%=table.Rows[i]["HOTEN"].ToString()%></td>
               <td  rowspan="2" class="style4" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;"><%=table.Rows[i]["DIACHI"].ToString()%></td>
               <td  rowspan="2" class="style5" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;" ><%=table.Rows[i]["GB"].ToString()%></td>
               <td  rowspan="2" class="style6" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;" ><%=table.Rows[i]["DM"].ToString()%></td>  
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K1"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K2"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K3"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K4"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K5"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K6"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K7"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K8"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K9"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K10"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K11"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["K12"].ToString()%></td>
            </tr>
            <tr >
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid; text-align:center" 
                     class="style14"><%=table.Rows[i]["C1"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T1"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C2"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T2"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C3"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T3"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C4"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T4"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C5"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T5"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C6"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T6"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C7"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T7"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C8"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T8"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C9"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T9"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C10"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T10"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C11"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T11"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C12"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T12"].ToString()%></td>
            </tr>
                  <%
                 }
             }                           
             
          %>
              </tbody>
            </table>
  
            <br />

      <!-- End Show -->
     </div>
   
    </div>

    </form>

</body>
</html>
