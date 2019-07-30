<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillDataDMA.aspx.cs" Inherits="BaoCao_Web.View.tabSanLuong.FillDataDMA" %>
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
        &nbsp;<asp:Label ID="lbTt" runat="server" Text=""></asp:Label>
      &nbsp;&nbsp;
        <asp:Button ID="chart" runat="server" onclick="chart_Click" 
            Text="Biểu Đồ Sản Lượng 12 Kỳ Đọc Số" 
            PostBackUrl="~/View/tabSanLuong/CharDMA.aspx" />
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
             int T1 = 0;
             int T2 = 0;
             int T3 = 0;
             int T4 = 0;
             int T5 = 0;
             int T6 = 0;
             int T7 = 0;
             int T8 = 0;
             int T9 = 0;
             int T10 = 0;
             int T11 = 0;
             int T12 = 0;
             string ky1 = ""; string ky2 = ""; string ky3 = ""; string ky4 = ""; string ky5 = ""; string ky6 = ""; string ky7 = ""; string ky8 = ""; string ky9 = ""; string ky10 = ""; string ky11 = ""; string ky12 = "";
             DataTable table = new DataTable();
             if (Session["chamcong"] != null)
             {
                 table = (DataTable)Session["chamcong"];
                 for (int i = 0; i < table.Rows.Count; i++)
                 {
                      T1 += (table.Rows[i]["T1"].ToString() != "" ? int.Parse(table.Rows[i]["T1"].ToString()) : 0);
                      T2 += (table.Rows[i]["T2"].ToString() != "" ? int.Parse(table.Rows[i]["T2"].ToString()) : 0);
                      T3 += (table.Rows[i]["T3"].ToString() != "" ? int.Parse(table.Rows[i]["T3"].ToString()) : 0);
                      T4 += (table.Rows[i]["T4"].ToString() != "" ? int.Parse(table.Rows[i]["T4"].ToString()) : 0);
                      T5 += (table.Rows[i]["T5"].ToString() != "" ? int.Parse(table.Rows[i]["T5"].ToString()) : 0);
                      T6 += (table.Rows[i]["T6"].ToString() != "" ? int.Parse(table.Rows[i]["T6"].ToString()) : 0);
                      T7 += (table.Rows[i]["T7"].ToString() != "" ? int.Parse(table.Rows[i]["T7"].ToString()) : 0);
                      T8 += (table.Rows[i]["T8"].ToString() != "" ? int.Parse(table.Rows[i]["T8"].ToString()) : 0);
                      T9 += (table.Rows[i]["T9"].ToString() != "" ? int.Parse(table.Rows[i]["T9"].ToString()) : 0);
                      T10 += (table.Rows[i]["T10"].ToString() != "" ? int.Parse(table.Rows[i]["T10"].ToString()) : 0);
                      T11 += (table.Rows[i]["T11"].ToString() != "" ? int.Parse(table.Rows[i]["T11"].ToString()) : 0);
                      T12 += (table.Rows[i]["T12"].ToString() != "" ? int.Parse(table.Rows[i]["T12"].ToString()) : 0);
                      ky1 = table.Rows[i]["K1"].ToString();
                      ky2 = table.Rows[i]["K2"].ToString();
                      ky3 = table.Rows[i]["K3"].ToString();
                      ky4 = table.Rows[i]["K4"].ToString();
                      ky5 = table.Rows[i]["K5"].ToString();
                      ky6 = table.Rows[i]["K6"].ToString();
                      ky7 = table.Rows[i]["K7"].ToString();
                      ky8 = table.Rows[i]["K8"].ToString();
                      ky9 = table.Rows[i]["K9"].ToString();
                      ky10 = table.Rows[i]["K10"].ToString();
                      ky11 = table.Rows[i]["K11"].ToString();
                      ky12 = table.Rows[i]["K12"].ToString();
                     
                    
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
                    class="style11"><%=ky1%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky2%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky3%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky4%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky5%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky6%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky7%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky8%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky9%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky10%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky11%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=ky12%></td>
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
          <tr style="background-color:#00CC00;font-weight:bold;font-size:large" >
                  <td colspan="7" rowspan="2" style="border-right:2px #99cc99 solid; border-bottom: 2px outset; text-align:center" 
                     class="style14">&nbsp;TỔNG CỘNG </td>
                 <td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed; text-align:center"  class="style14"><%=String.Format("{0:0,0}",T1)%></td>
                <% if (T1 > T2)
                   {%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center;background-color:Red;"  class="style14"><%=String.Format("{0:0,0}",T2)%></td><%}
                   else{%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center"  class="style14"><%=String.Format("{0:0,0}",T2)%></td><%}
                 %>
                 <% if (T1 > T3)
                   {%><td rowspan="2" colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 2px outset;text-align:center;background-color:Red;" class="style14"><%=String.Format("{0:0,0}",T3)%></td><%}
                   else{%><td rowspan="2" colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 2px outset;text-align:center" class="style14"><%=String.Format("{0:0,0}",T3)%></td><%}
                 %>
                 <% if (T1 > T4)
                   {%><td rowspan="2" colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 2px outset;text-align:center;background-color:Red;" class="style14"><%=String.Format("{0:0,0}",T4)%></td><%}
                   else{%><td rowspan="2" colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 2px outset;text-align:center" class="style14"><%=String.Format("{0:0,0}",T4)%></td><%}
                 %>
                 <% if (T1 > T5)
                   {%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed; text-align:center;background-color:Red;" class="style14"><%=String.Format("{0:0,0}",T5)%></td><%}
                   else{%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed; text-align:center" class="style14"><%=String.Format("{0:0,0}",T5)%></td><%}
                 %>
                 <% if (T1 > T6)
                   {%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center;background-color:Red;"  class="style14"><%=String.Format("{0:0,0}",T6)%></td>     <%}
                   else{%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center"  class="style14"><%=String.Format("{0:0,0}",T6)%></td>     <%}
                 %>
                 <% if (T1 > T7)
                   {%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center;background-color:Red;"  class="style14"><%=String.Format("{0:0,0}",T7)%></td> <%}
                   else{%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center"  class="style14"><%=String.Format("{0:0,0}",T7)%></td> <%}
                 %>                 <% if (T1 > T8)
                   {%> <td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center;background-color:Red;"  class="style14"><%=String.Format("{0:0,0}",T8)%></td><%}
                   else{%> <td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center"  class="style14"><%=String.Format("{0:0,0}",T8)%></td><%}
                 %>
                
                 <% if (T1 > T9)
                   {%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center;background-color:Red;"  class="style14"><%=String.Format("{0:0,0}",T9)%></td> <%}
                   else{%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center"  class="style14"><%=String.Format("{0:0,0}",T9)%></td> <%}
                 %>
                 <% if (T1 > T10)
                   {%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center;background-color:Red;"  class="style14"><%=String.Format("{0:0,0}",T10)%></td><%}
                   else{%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center"  class="style14"><%=String.Format("{0:0,0}",T10)%></td><%}
                 %>
                 <% if (T1 > T11)
                   {%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center;background-color:Red;"  class="style14"><%=String.Format("{0:0,0}",T11)%></td><%}
                   else{%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center"  class="style14"><%=String.Format("{0:0,0}",T11)%></td><%}
                 %>
                 <% if (T1 > T12)
                   {%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center;background-color:Red;"  class="style14"><%=String.Format("{0:0,0}",T12)%></td> <%}
                   else{%><td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center"  class="style14"><%=String.Format("{0:0,0}",T12)%></td> 
                   <%}
                   string title = "['KỲ','SẢN LƯỢNG']";
                   title += ", ['" + ky1 + "'," + T1 + "]";
                   title += ", ['" + ky2 + "'," + T2 + "]";
                   title += ", ['" + ky3 + "'," + T3 + "]";
                   title += ", ['" + ky4 + "'," + T4 + "]";
                   title += ", ['" + ky5 + "'," + T5 + "]";
                   title += ", ['" + ky6 + "'," + T6 + "]";
                   title += ", ['" + ky7 + "'," + T7 + "]";
                   title += ", ['" + ky8 + "'," + T8 + "]";
                   title += ", ['" + ky9 + "'," + T9 + "]";
                   title += ", ['" + ky10 + "'," + T10 + "]";
                   title += ", ['" + ky11 + "'," + T11 + "]";
                   title += ", ['" + ky12 + "'," + T12 + "]";
                   Session["sldma"] = title;                                                                                                                                                                    
                                                                                                                                                                                        
                                                                                                                                                                                        
                 %>
            </tr>

              </tbody>
            </table>
  
            <br />

      <!-- End Show -->
     </div>
   
    </div>

    </form>

</body>
</html>
