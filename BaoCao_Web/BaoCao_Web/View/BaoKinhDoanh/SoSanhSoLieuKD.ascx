<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SoSanhSoLieuKD.ascx.cs" Inherits="BaoCao_Web.View.BaoKinhDoanh.SoSanhSoLieuKD" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<link href="../../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="BaoCao_Web.Class" %>

<style type="text/css">
    .style2
    {
        width: 132px;
    }
    .style3
    {
        width: 42px;
    }
    .style6
    {
        width: 97px;
    }
    .style10
    {
        width: 117px;
    }
    .style14
    {
        width: 79px;
    }
    .style24
    {
        width: 107px;
        border-left:1px #99cc99 solid;
        border-right:1px #99cc99 solid;
          border-bottom-style: dotted;     
        border-bottom-width: 1px;
    }
    .style25
    {
        width: 89px;
        height: 28px;
        border-right:1px #99cc99 solid;
        border-left:1px #99cc99 solid;
        text-align: center;
    }
    .style30
    {
        width: 69px;        
        border-left:1px #99cc99 solid;
        border-bottom-style: dotted;     
        border-bottom-width: 1px;
        text-align: right;
    }
    .style4001
    {
        border-left:1px #99cc99 solid;
        border-right:1px #99cc99 solid;
        text-align: right;
        border-bottom-style: dotted;     
        border-bottom-width: 1px;
       
    }
    
    .style40
    {
        text-align: right;
         border-bottom-style: dotted;     
        border-bottom-width: 1px;
       
    }
    .style54
    {
        width: 44px;
        border-bottom-style: dotted;     
        border-bottom-width: 1px;
        text-align: center;
    }
    .style55
    {
        width: 52px;
        text-align: center;
        border-left:1px #99cc99 solid;
        border-right:1px #99cc99 solid;
        border-bottom-style: dotted;     
        border-bottom-width: 1px;
    }
    .style59
    {
        width: 114px;
    }
    .style402
    {
        text-align: right;
    }
    .style405
    {
        height: 28px;
        border-left: 1px #99cc99 solid;
        border-right: 1px #99cc99 solid;
        text-align: center;
    }
    .style406
    {
        width: 43px;
    }
    .style662
    {
       
        width: 52px;
        text-align: center;
        border-left: 1px #99cc99 solid;
        border-right: 1px #99cc99 solid;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
        
    }
    .style663
    {
        width: 1247px;
        height: 147px;
    }
    .style664
    {
        width: 52px;
        height: 49px;
        text-align: center;
        border-right: 2px solid #99cc99;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
    }
    .style666
    {
        width: 76px;
        height: 21px;
        border-left: 1px #99cc99 solid;
        text-align: center;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
    }
    .style667
    {
        width: 64px;
        height: 21px;
        border-bottom-style: dotted;
        border-right: 1px #99cc99 solid;
        border-bottom-width: 1px;
        text-align: center;
    }
    .style668
    {
        width: 52px;
        height: 21px;
        border-left: 1px #99cc99 solid;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
        text-align: center;
    }
    .style669
    {
        width: 74px;
        height: 21px;
        border-right: 1px #99cc99 solid;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
        text-align: center;
        
    }
    .style670
    {
        width: 89px;
        height: 21px;
        border-right: 1px #99cc99 solid;
        border-left: 1px #99cc99 solid;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
        text-align: center;
    }
    .style671
    {
        height: 24px;
        border-left: 1px #99cc99 solid;
        border-right: 1px #99cc99 solid;
        text-align: center;
    }
    .style672
    {
        width: 89px;
        height: 24px;
        border-right: 1px #99cc99 solid;
        border-left: 1px #99cc99 solid;
        text-align: center;
    }
    .style673
    {
        width: 52px;
        height: 53px;
        text-align: center;
        border-right: 2px solid #99cc99;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
    }
    .style674
    {
        width: 57px;
        height: 53px;
        border-right: 1px #99cc99 solid;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
        text-align: center;
    }
    .style676
    {
        width: 76px;
        height: 25px;
        border-left: 1px #99cc99 solid;
        text-align: center;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
    }
    .style677
    {
        width: 64px;
        height: 25px;
        border-bottom-style: dotted;
        border-right: 1px #99cc99 solid;
        border-bottom-width: 1px;
        text-align: center;
    }
    .style678
    {
        width: 52px;
        height: 25px;
        border-left: 1px #99cc99 solid;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
        text-align: center;
    }
    .style679
    {
        width: 74px;
        height: 25px;
        border-right: 1px #99cc99 solid;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
        text-align: center;
    }
    .style680
    {
        width: 89px;
        height: 25px;
        border-right: 1px #99cc99 solid;
        border-left: 1px #99cc99 solid;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
        text-align: center;
    }
    .style4004
    {
        width: 57px;
        height: 49px;
        border-right: 1px #99cc99 solid;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
        text-align: center;
    }
    .style4005
    {
        text-align: right;
        border-bottom-style: dotted;
        border-bottom-width: 1px;
        width: 112px;
    }
    .style4006
    {
        width: 116px;
    }
    .style4007
    {
        width: 95px;
    }
    </style>
<div class="title_page" style="hight:20px;"><asp:Label ID="title" runat="server" 
        Text="SO SÁNH SỐ LIỆU KINH DOANH NĂM"></asp:Label>&nbsp;<asp:DropDownList 
        ID="year" runat="server" Font-Bold="True" Font-Size="13pt" 
        ForeColor="#006600" AutoPostBack="True">

    </asp:DropDownList>
    &nbsp;<asp:Label ID="title0" runat="server" Text="VỚI"></asp:Label>&nbsp;&nbsp;<asp:DropDownList 
        ID="year0" runat="server" Font-Bold="True" Font-Size="13pt" 
        ForeColor="#006600" AutoPostBack="True" 
        onselectedindexchanged="year_SelectedIndexChanged">

    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
<div class="block_content">
   <asp:Panel ID="dsad" runat="server" ScrollBars="Auto" 
        BorderWidth="0px" Width="1285px" >      
          <table cellpadding="0" cellspacing="0" 
                style="font-family:Times New Roman; font-size:15px; width: 1249px;" 
                class="table_list" >
              <tbody>
                  <tr class="head" >
                    <td rowspan="2" class="style406"  >KỲ</td>
                      <td class="style3" rowspan="2">
                          NĂM</td>
                    <td rowspan="2" class="style2"  >
                        DOANH THU<br />
                        TỈ LỆ DOANH THU</td>
                     
                    <td  rowspan="2" class="style6" >
                        SẢN LƯỢNG</td>
                     <td rowspan="2" class="style10"  >
                         ĐỒNG HỒ NƯỚC </td>
                 
                     <td  rowspan="2" class="style14" >
                         GIÁ BQ</td>
                 
                     <td  rowspan="2" class="style59"  >
                         HÓA ĐƠN
                         <br />
                         TB</td>
                 
                     <td  colspan="2" >
                         HÓA ĐƠN =0</td>
                 
                     <td  rowspan="2" >
                         TỒN THU</td>
                 
                </tr>
                  <tr class="head" >
                 
                     <td class="style4006"   >
                         0m<sup>3</sup></td>
                 
                     <td class="style4007"  >
                         4m<sup>3</sup></td>
                 
                </tr>
              </tbody>
            </table>
          <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto"  
                BorderWidth="0px" Width="1275px"  >
             
            <table border="0" cellpadding="0" cellspacing="0" class="style663" >
                             <% 
                       DataTable table = new DataTable();
                       if (Session["BAOKD"] != null)
                       {
                           table = (DataTable)Session["BAOKD"];
                           for (int i = 0; i < table.Rows.Count; i++)
                           {
                           %>
                <tr> 
                    <td class="style55" rowspan="6" style="border-bottom: 2px solid;">
                      <span style="font:17px; font-weight:bold"><%=table.Rows[i]["KY"]%></span></td>
                    <td class="style55" rowspan="2">
                      <span style="color:#000000;">  <b><%=table.Rows[i]["NAM"]%></b></span></td><td  colspan="2" class="style671"  >
                      <span style="color:#000000;" title="Tiền Nước Chuẩn Thu Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["DOANHTHU"])%></span> </td>
                    <td style="text-align: center" class="style24" rowspan="2" >
                       <span style="color:#000000;" title="Lượng Nước Chuẩn Thu Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SANLUONG"])%></span></td>
                    <td  colspan="2" class="style671">
                       <span style="color:#000000;" title="Số Đồng Hồ Nước Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SLDHN"])%></span></td>
                    <td class="style672" >
                       <span style="color:#000000;" title="Giá Bán Bình Quân Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["GIABQ"])%></span></td>
                    <td rowspan="2" class="style30">
                        <div class="style402">
                            <span style="color:#000000;" title="Tổng HĐ Trung Bình Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HDTB"])%></span>&nbsp;</div>
                    </td>
                    <td class="style673" rowspan="2"><span style="color:#000000;">
                        <% double HDTB_TANG = Format.ConvertDouble(table.Rows[i]["HDTB_TANG"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/up.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(table.Rows[i]["HDTB_TANG"])%>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/down.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(HDTB_TANG)%>
                        <%
                       } 
                     %></span>
                        </td>
                    <td  rowspan="2" class="style40">
                        <div class="" >                          
                        <span style="color:#000000;" title="Tổng HĐ 0m3 Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON0"])%>&nbsp;</span></div>
                    </td>
                    <td class="style674" rowspan="2" ><span style="color:#000000;">
                        <% double HOADON0_TG = Format.ConvertDouble(table.Rows[i]["HOADON0_TG"]);
                        if (HOADON0_TG > 0)
                        {
                        %>
                        <img src="../../Image/up.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(table.Rows[i]["HOADON0_TG"])%>
                        <%
                         }
                         else if (HOADON0_TG < 0)
                        {
                           HOADON0_TG = HOADON0_TG * (-1);
                        %>
                        <img src="../../Image/down.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(HOADON0_TG)%>
                        <%
                       } 
                      %></span>
                    </td>
                    <td  rowspan="2" class="style40">
                        <div class="">
                           
                        <span style="color:#000000;" title="Tổng HĐ 4m3 Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON4"])%>&nbsp;</span></div>
                    </td>
                    <td class="style673" rowspan="2" ><span style="color:#000000;">
                        <% double HOADON4_TG = Format.ConvertDouble(table.Rows[i]["HOADON4_TG"]);
                             if (HOADON4_TG > 0)
                            {
                            %>
                        <img src="../../Image/up.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(table.Rows[i]["HOADON4_TG"])%>
                        <%
                           }
                           else if (HOADON4_TG < 0)
                           {
                               HOADON4_TG = HOADON4_TG * (-1);
                            %>
                        <img src="../../Image/down.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(HOADON4_TG)%>
                        <%
                           } 
                         %></span>
                    </td>
                    <td rowspan="2" class="style54">
                       <span style="color:#000000;" style="font:17px; font-weight:bold" title="Số Lượng Hóa Đơn Tồn Các Kỳ Trước"><%=Format.NumberFormat(table.Rows[i]["HDTON_TRUOC"])%>&nbsp;</span></td>
                    <td rowspan="2" class="style4005" >
                        <div  ><span style="color:#000000;" 
                                title='Tổng Hóa Đơn Tồn Kỳ <%=table.Rows[i]["KY"]%>'>
                            <%=Format.NumberFormat(table.Rows[i]["HDTON_TONG"])%></span>&nbsp;&nbsp;</div>
                    </td>
                    <td rowspan="2" class="style4001" >
                       <span style="color:#000000;" title="Tổng Doanh Thu Tồn Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SLTON_TONG"])%></span>&nbsp;&nbsp;&nbsp;
                    </td>

                </tr>
                <tr>
                    <td class="style676" >
                       <span style="color:#000000;" title="Tỉ Lệ Thực Thu 4 Kỳ"><%=Format.PhanTram(table.Rows[i]["DT_4KY"])%></span></td>
                    <td class="style677" >
                       <span style="color:#000000;" title="Tỉ Lệ Thực Thu Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.PhanTram(table.Rows[i]["DT_KY"])%></span></td>
                    <td class="style678" >
                        <span style="color:#000000;" title="ĐHN Tăng"><%=Format.NumberFormat(table.Rows[i]["TANGDHN"])%></span></td>
                    <td class="style679" >
                        <span style="color:#000000;" title="Số Lượng Hóa Đơn <4m3 Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["DHN_NHO3"])%></span>&nbsp;
                    </td>
                    <td class="style680" >
                        <span style="color:#000000;" title="Tổng Hóa Đơn Định Mức Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["TONG_DM"])%></span>&nbsp;&nbsp;</td>
                            
               </tr>
            

                <tr>
                    
                    <td class="style55" rowspan="2">
                        <span style="color:#000000;"> <b><%=table.Rows[i]["NAM1"]%></b></span>  
                    </td>
                    <td  colspan="2" class="style405" >
                       <span style="color:#000000;" title="Tiền Nước Chuẩn Thu Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["DOANHTHU1"])%></span> </td>
                    <td style="text-align: center" class="style24" rowspan="2" >
                       <span style="color:#000000;" title="Lượng Nước Chuẩn Thu Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SANLUONG1"])%></span></td>
                    <td  colspan="2" class="style405">
                       <span style="color:#000000;" title="Số Đồng Hồ Nước Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SLDHN1"])%></span></td>
                    <td class="style25" >
                       <span style="color:#000000;" title="Giá Bán Bình Quân Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["GIABQ1"])%></span></td>
                    <td rowspan="2" class="style30">
                        <div class="style402">
                            <span style="color:#000000;" title="Tổng HĐ Trung Bình Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HDTB1"])%></span>&nbsp;</div>
                    </td>
                    <td class="style664" rowspan="2"><span style="color:#000000;">
                        <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["HDTB_TANG1"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/up.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(table.Rows[i]["HDTB_TANG1"])%>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/down.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(HDTB_TANG)%>
                        <%
                       } 
                     %></span>
                        </td>
                    <td  rowspan="2" class="style40">
                        <div class="" >                          
                        <span style="color:#000000;" title="Tổng HĐ 0m3 Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON01"])%>&nbsp;</span></div>
                    </td>
                    <td class="style4004" rowspan="2" ><span style="color:#000000;">
                        <%  HOADON0_TG = Format.ConvertDouble(table.Rows[i]["HOADON0_TG1"]);
                        if (HOADON0_TG > 0)
                        {
                        %>
                        <img src="../../Image/up.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(table.Rows[i]["HOADON0_TG1"])%>
                        <%
                         }
                         else if (HOADON0_TG < 0)
                        {
                           HOADON0_TG = HOADON0_TG * (-1);
                        %>
                        <img src="../../Image/down.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(HOADON0_TG)%>
                        <%
                       } 
                      %></span>
                    </td>
                    <td  rowspan="2" class="style40">
                        <div class="">
                           
                        <span style="color:#000000;" title="Tổng HĐ 4m3 Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON41"])%>&nbsp;</span></div>
                    </td>
                    <td class="style664" rowspan="2" ><span style="color:#000000;">
                        <%  HOADON4_TG = Format.ConvertDouble(table.Rows[i]["HOADON4_TG1"]);
                             if (HOADON4_TG > 0)
                            {
                            %>
                        <img src="../../Image/up.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(table.Rows[i]["HOADON4_TG1"])%>
                        <%
                           }
                           else if (HOADON4_TG < 0)
                           {
                               HOADON4_TG = HOADON4_TG * (-1);
                            %>
                        <img src="../../Image/down.png" width="15px" height="15px" />
                        <%=Format.NumberFormat(HOADON4_TG)%>
                        <%
                           } 
                         %></span>
                    </td>
                    <td rowspan="2" class="style54">
                       <span style="color:#000000;" style="font:17px; font-weight:bold" title="Số Lượng Hóa Đơn Tồn Các Kỳ Trước"><%=Format.NumberFormat(table.Rows[i]["HDTON_TRUOC1"])%>&nbsp;</span></td>
                    <td rowspan="2" class="style4005" >
                        <div  > 
                          <span style="color:#000000;" title="Tổng Hóa Đơn Tồn Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HDTON_TONG1"])%></span>&nbsp;&nbsp;</div>
                    </td>
                    <td rowspan="2" class="style4001"  >
                        <span style="color:#000000;" title="Tổng Doanh Thu Tồn Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SLTON_TONG1"])%></span>&nbsp;&nbsp;&nbsp;
                    </td>

                </tr>
                <tr>
                    <td class="style666" >
                       <span style="color:#000000;" title="Tỉ Lệ Thực Thu 4 Kỳ"><%=Format.PhanTram(table.Rows[i]["DT_4KY1"])%></span></td>
                    <td class="style667" >
                       <span style="color:#000000;" title="Tỉ Lệ Thực Thu Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.PhanTram(table.Rows[i]["DT_KY1"])%></span></td>
                    <td class="style668" >
                         <span style="color:#000000;" title="ĐHN Tăng"><%=Format.NumberFormat(table.Rows[i]["TANGDHN1"])%></span></td>
                    <td class="style669" >
                        <span style="color:#000000;" title="Số Lượng Hóa Đơn <4m3 Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["DHN_NHO31"])%></span>&nbsp;
                    </td>
                    <td class="style670" >
                        <span style="color:#000000;" title="Tổng Hóa Đơn Định Mức Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["TONG_DM1"])%></span>&nbsp;&nbsp;</td>
                            
               </tr>


                <tr>                    
                    <td class="style662" rowspan="2" style="border-bottom: 2px solid;background:#F5F5F5;">
                     <span style="color:blue;"> <b>SO SÁNH</b></span>  
                       </td>
                    <td  colspan="2" class="style405" style="background:#F5F5F5;" >                   
                      <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["DOANHTHU2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["DOANHTHU2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>
                     </td>
                    <td style="text-align: center;border-bottom: 2px solid; background:#F5F5F5;" class="style24" rowspan="2">
                       <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["SANLUONG2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["SANLUONG2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>
                    </td>
                    <td  colspan="2" class="style405" style="background:#F5F5F5;">
                    <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["SLDHN2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["SLDHN2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>
                    </td>
                    <td class="style25" style="background:#F5F5F5;">
                    <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["GIABQ2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["GIABQ2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>
                    </td>
                    <td rowspan="2" class="style30" style="border-bottom: 2px solid; background:#F5F5F5;">
                        <div class="style402">
                        <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["HDTB2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["HDTB2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>
                     </div>
                     </td>
                    <td class="style664" rowspan="2" style="border-bottom: 2px solid; background:#F5F5F5;"><span style="color:blue;">
                       
                     </span>
                        </td>
                    <td  rowspan="2" class="style40" style="border-bottom: 2px solid; background:#F5F5F5;">
                        <div class="" >    
                        <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["HOADON02"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["HOADON02"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>

                       </div>
                    </td>
                    <td class="style4004" rowspan="2" style="border-bottom: 2px solid; background:#F5F5F5;">
                       <span style="color:blue;">
                       </span>
                    </td>
                    <td  rowspan="2" class="style40" style="border-bottom: 2px solid; background:#F5F5F5;">
                        <div class="">
                        <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["HOADON42"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["HOADON42"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>
                       </div>
                    </td>
                    <td class="style664" rowspan="2" style="border-bottom: 2px solid; background:#F5F5F5;">
                     <span style="color:blue;">
                      </span>
                    </td>
                    <td rowspan="2" class="style54"style="border-bottom: 2px solid; background:#F5F5F5;">

                    <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["HDTON_TRUOC2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["HDTON_TRUOC2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>
                     </td>
                    <td rowspan="2" style="border-bottom-style: solid; border-bottom-color: inherit; border-bottom-width: 2px; background:#F5F5F5;" 
                        class="style4005">
                         <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["HDTON_TONG2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["HDTON_TONG2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>  
                    </td>
                    <td rowspan="2" class="style4001" style="border-bottom: 2px solid; background:#F5F5F5;">
                      <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["SLTON_TONG2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["SLTON_TONG2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>
                        &nbsp;&nbsp;
                    </td>

                </tr>
                <tr>
                    <td class="style666" style="border-bottom: 2px solid; background:#F5F5F5;" >
                    <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["DT_4KY2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.PhanTram(table.Rows[i]["DT_4KY2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.PhanTram(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %></td>
                    <td class="style667" style="border-bottom: 2px solid; background:#F5F5F5;">
                    <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["DT_KY2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.PhanTram(table.Rows[i]["DT_KY2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.PhanTram(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>
                       </td>
                    <td class="style668" style="border-bottom: 2px solid; background:#F5F5F5;">
                       <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["HDTB_TANG2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["HDTB_TANG2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                      %>
                    </td>
                    <td class="style669" style="border-bottom: 2px solid; background:#F5F5F5;">
                     <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["DHN_NHO32"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["DHN_NHO32"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>
                     &nbsp;
                    </td>
                    <td class="style670" style="border-bottom: 2px solid; background:#F5F5F5;">
                     <%  HDTB_TANG = Format.ConvertDouble(table.Rows[i]["TONG_DM2"]);
                       if (HDTB_TANG > 0) {
                        %>
                        <img src="../../Image/ss-TANG.png" width="15px" height="15px" />
                        <span style="color:#32CD32;"><b><%=Format.NumberFormat(table.Rows[i]["TONG_DM2"])%></b></span>
                        <%
                       }
                       else if (HDTB_TANG < 0)
                       {
                           HDTB_TANG = HDTB_TANG * (-1);
                        %>
                        <img src="../../Image/ss-GIAM.png" width="15px" height="15px" />
                       <span style="color:#FF0000;"><b><%=Format.NumberFormat(HDTB_TANG)%></b></span>
                        <%
                       } 
                     %>&nbsp;&nbsp;</td>
              <%}
            } %>
         </tr>
            
           
            
            </table>
        </asp:Panel>   
       </asp:Panel>
</div>



 
    