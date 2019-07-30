<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhanTichThayDHN.aspx.cs" Inherits="BaoCao_Web.View.tabSanLuong.PhanTichThayDHN" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../StyleSheet/Menu.css" rel="stylesheet" type="text/css" />
    <link href="../../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../JavaScript/transmenu.js" type="text/javascript"></script>
    <title>PHÂN TÍCH DANH SÁCH ĐHN</title>
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
 	<h1>
        <asp:Label ID="lbTt" runat="server" Text="PHÂN TÍCH DANH SÁCH ĐHN  "></asp:Label>
      &nbsp;&nbsp;</h1>
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
                <td  colspan="2" style="border-right:2px #99cc99 solid;background-color: #ccff66; border-top:2px solid; ">&nbsp;</td>
                <td  colspan="2" style="border-right:2px #99cc99 solid; border-top:2px solid; ">&nbsp;</td>
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
                 <td style=" border-bottom: 1px solid;background-color: #ccff66;" >&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;background-color: #ccff66;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 <td style=" border-bottom: 1px solid;">&nbsp;</td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">&nbsp;</td>
                 
            </tr>
                     
         <%
             int sumT1 = 0;
             int sumT2 = 0;
             int sumT3 = 0;
             int sumTT1 = 0;
             int sumTT2 = 0;
             int sumTT3 = 0;
             int sumMid = 0;
             DataTable table = new DataTable();
             if (Session["chamcong"] != null)
             {
                 table = (DataTable)Session["chamcong"];
                         
                 for (int i = 0; i < table.Rows.Count; i++)
                 {
                     int t1=(table.Rows[i]["T1"].ToString() != "" ? int.Parse(table.Rows[i]["T1"].ToString()) : 0);
                     int t2=(table.Rows[i]["T2"].ToString() != "" ? int.Parse(table.Rows[i]["T2"].ToString()) : 0);
                     int t3=(table.Rows[i]["T3"].ToString() != "" ? int.Parse(table.Rows[i]["T3"].ToString()) : 0);
                     int tt1=(table.Rows[i]["TT1"].ToString() != "" ? int.Parse(table.Rows[i]["TT1"].ToString()) : 0);
                     int tt2=(table.Rows[i]["TT2"].ToString() != "" ? int.Parse(table.Rows[i]["TT2"].ToString()) : 0);
                     int tt3=(table.Rows[i]["TT3"].ToString() != "" ? int.Parse(table.Rows[i]["TT3"].ToString()) : 0);
                     sumT1 += t1;
                     sumT2 += t2;
                     sumT3 += t3;
                     sumTT1 += tt1;
                     sumTT2 += tt2;
                     sumTT3 += tt3;
                     sumMid += (table.Rows[i]["TIEUTHU"].ToString() != "" ? int.Parse(table.Rows[i]["TIEUTHU"].ToString()) : 0);
                     double avgTruoc = (t1 + t2 + t3 ) / 3;
                     double avgSau = (tt1 + tt2 +tt3 ) / 3;
                  
              %> 
            <tr>
                
               <td  rowspan="2" class="style8" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;"><%=(i + 1)%></td>                              
               <td  rowspan="2" class="style8" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;"><%=table.Rows[i]["DOT"].ToString()%></td>
               <td  rowspan="2" class="style7" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;"><a title="Click Xem Biểu Đồ Sản Lượng !" href="CharBieuDoSL.aspx?value=<%=table.Rows[i]["DANHBA"].ToString()%>"><%=table.Rows[i]["DANHBA"].ToString()%></a></td>
               <td  rowspan="2" class="style3" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;"><%=table.Rows[i]["TENKH"].ToString()%></td>
               <td  rowspan="2" class="style4" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;"><%=table.Rows[i]["DIACHI"].ToString()%></td>
               <td  rowspan="2" class="style5" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;" ><%=table.Rows[i]["GB"].ToString()%></td>
               <td  rowspan="2" class="style6" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;" ><%=table.Rows[i]["DM"].ToString()%></td>  
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
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted; background-color: #ccff66 " 
                    class="style11"><b><%=table.Rows[i]["KY"].ToString()%></b></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["TK1"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["TK2"].ToString()%></td>
                <td  colspan="2" 
                    style="border-right:2px #99cc99 solid; text-align: center; border-bottom: 1px dotted;" 
                    class="style11"><%=table.Rows[i]["TK3"].ToString()%></td>                
            </tr>
            <tr >
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed; text-align:center" 
                     class="style14"><%=table.Rows[i]["C1"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style15"><%=table.Rows[i]["T1"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style14"><%=table.Rows[i]["C2"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style15"><%=table.Rows[i]["T2"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style14"><%=table.Rows[i]["C3"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style15"><%=table.Rows[i]["T3"].ToString()%></td>
                 <td rowspan="2" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;background-color: #ccff66;text-align:center" 
                     class="style14"><b><%=table.Rows[i]["CODE"].ToString()%> </b></td>
                 <td rowspan="2" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;background-color: #ccff66;text-align:center" 
                     class="style15"><b><%=table.Rows[i]["TIEUTHU"].ToString()%></b></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style14"><%=table.Rows[i]["TC1"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style15"><%=table.Rows[i]["TT1"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style14"><%=table.Rows[i]["TC2"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style15"><%=table.Rows[i]["TT2"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style14"><%=table.Rows[i]["TC3"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style15"><%=table.Rows[i]["TT3"].ToString()%></td>                 
            </tr>
            <tr >
                 <td colspan="7" style="border-right:2px #99cc99 solid; border-bottom: 2px solid; text-align:center" 
                     class="style14">&nbsp;</td>
                 <td colspan="6"  style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=avgTruoc%> </td>
                 <%--
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C2"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T2"].ToString()%></td>--%>                 <%
                     if (avgSau <= avgTruoc)
                     {
                          %>
                         <td colspan="6"  style="border-right:2px #99cc99 solid; background-color:#FF6600; border-bottom: 2px solid;text-align:center" 
                             class="style14"><%=avgSau%>  </td>
                 <%
                     }
                     else
                     {
                     %>
                     <td colspan="6"  style="border-right:2px #99cc99 solid; background-color:#33FFFF; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=avgSau%>  </td>
                 <%} %> 
            </tr>
                  <%
                 }
             }                           
             
          %>
          <tr style="background-color:#00CC00;font-weight:bold;font-size:large" >
                  <td colspan="7" rowspan="2" style="border-right:2px #99cc99 solid; border-bottom: 2px outset; text-align:center" 
                     class="style14">&nbsp;TỔNG CỘNG </td>
                 <td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed; text-align:center" 
                     class="style14"><%=sumT1%></td>
                
                 <td  colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style14"><%=sumT2%></td>
               
                 <td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style14"><%=sumT3%></td>
               
                 <td rowspan="2" colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 2px outset;background-color: #ccff66;text-align:center" 
                     class="style14"><%=sumMid%></td>
                
                 <td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed; text-align:center" 
                     class="style14"><%=sumTT1%></td>
                
                 <td  colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style14"><%=sumTT2%></td>
               
                 <td colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 1px dashed;text-align:center" 
                     class="style14"><%=sumTT3%></td>               
            </tr>

            <tr style="background-color:#00CC00;font-weight:bold;font-size:large" >
                 <td colspan="6"  style="border-right:2px #99cc99 solid; border-bottom: 2px outset;text-align:center" 
                     class="style15"><%=(sumT1+sumT2+sumT3)/3%> </td>
                 <%--
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style14"><%=table.Rows[i]["C2"].ToString()%></td>
                 <td style="border-right:2px #99cc99 solid; border-bottom: 2px solid;text-align:center" 
                     class="style15"><%=table.Rows[i]["T2"].ToString()%></td>--%>
                <td colspan="6"  style="border-right:2px #99cc99 solid;  border-bottom: 2px outset;text-align:center" 
                    class="style14"><%=(sumTT1+sumTT2+sumTT3)/3%>  </td>
                     
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
