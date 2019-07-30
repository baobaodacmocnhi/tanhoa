<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewKinhDoanh.ascx.cs" Inherits="BaoCao_Web.View.BaoKinhDoanh.ViewKinhDoanh" %>
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
    .style4
    {
        width: 76px;
        height: 2px;
        border-left:1px #99cc99 solid;
        text-align: center;
        border-bottom-style: solid;
        border-bottom-width: 2px;
    }
    .style5
    {
        width: 64px;
        height: 2px;
        border-bottom-style: solid;
        border-right:1px #99cc99 solid;
        border-bottom-width: 2px;
        text-align: center;
    }
    .style6
    {
        width: 97px;
    }
    .style10
    {
        width: 117px;
    }
    .style11
    {
        width: 53px;
        border-right:1px #99cc99 solid;
    }
    .style12
    {
        width: 74px;
        height: 2px;
        border-right:1px #99cc99 solid;
        border-bottom-style: solid;     
        border-bottom-width: 2px;
        text-align: center;
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
        border-bottom: 2px solid;
    }
    .style25
    {
        width: 89px;
        height: 42px;
        border-right:1px #99cc99 solid;
        border-left:1px #99cc99 solid;
        text-align: center;
    }
    .style30
    {
        width: 69px;        
        border-left:1px #99cc99 solid;
        border-bottom-style: solid;     
        border-bottom-width: 2px;
        text-align: right;
    }
    .style32
    {
        width: 56px;
    }
    .style35
    {
        width: 92px;
    }
    .style400
    {
        text-align: right;
         border-bottom-style: solid;     
        border-bottom-width: 2px;
       
    }
    .style401
    {
        text-align: right;
        border-bottom-style: solid;     
        border-bottom-width: 2px;
        border-left:1px #99cc99 solid;
        border-right:1px #99cc99 solid;
       
    }
    .style40
    {
        text-align: right;
         border-bottom-style: solid;     
        border-bottom-width: 2px;
       
    }
    .style41
    {
        width: 48px;
       
    }
    .style45
    {
        width: 52px;
        height: 2px;
        border-left:1px #99cc99 solid;
        border-bottom-style: solid;     
        border-bottom-width: 2px;
        text-align: center;
    }
    .style46
    {
        width: 89px;
        height: 2px;
        border-right:1px #99cc99 solid;
        border-left:1px #99cc99 solid;
        border-bottom-style: solid;     
        border-bottom-width: 2px;
        text-align: center;
    }
    .style54
    {
        width: 44px;
        border-bottom-style: solid;     
        border-bottom-width: 2px;
        text-align: center;
    }
    .style55
    {
        width: 52px;
        text-align: center;
        border-left:1px #99cc99 solid;
        border-right:1px #99cc99 solid;
        border-bottom-style: solid;     
        border-bottom-width: 2px;
    }
    .style58
    {
        height: 42px;
          border-left:1px #99cc99 solid;
        border-right:1px #99cc99 solid;
        text-align: center;
    }
    .style59
    {
        width: 114px;
    }
    .style61
    {
        width: 52px;
        border-right: 2px #99cc99 solid;
    }
    .style62
    {
        width: 52px;
        height: 2px;
        border-bottom-style: solid;
        border-bottom-width: 2px;
        border-right: 2px #99cc99 solid;
        
    }
    .style63
    {
        width: 53px;
        height: 2px;
        border-right: 1px #99cc99 solid;
        border-bottom-style: solid;
        border-bottom-width: 2px;
    }
    .style402
    {
        text-align: right;
    }
    </style>
<div class="title_page" style="hight:50px;"><asp:Label ID="title" runat="server" Text="SỐ LIỆU KINH DOANH NĂM"></asp:Label>&nbsp;<asp:DropDownList 
        ID="year" runat="server" Font-Bold="True" Font-Size="13pt" 
        ForeColor="#006600" AutoPostBack="True" 
        onselectedindexchanged="year_SelectedIndexChanged">

    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <!--<asp:Button ID="btIN" runat="server" onclick="btIn_Click" Text="IN" 
        Width="59px" CssClass="button" />-->
    </div>
<div class="block_content">
   <asp:Panel ID="DuLieuNam" runat="server" ScrollBars="Auto"   
        BorderWidth="0px" Width="1143px" >      
          <table cellpadding="0" cellspacing="0" 
                style="font-family:Times New Roman; font-size:15px; width: 1115px;" 
                class="table_list" >
              <tbody>
                  <tr class="head" >
                    <td rowspan="2" class="style3"  >KỲ</td>
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
                 
                     <td class="style35"   >
                         0m<sup>3</sup></td>
                 
                     <td class="style6"  >
                         4m<sup>3</sup></td>
                 
                </tr>
              </tbody>
            </table>
          <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto"  
                BorderWidth="0px" Width="1120px" Height="100%" >
             
            <table border="0" cellpadding="0" cellspacing="0" 
                style="width: 1114px;" >
                             <% 
                       DataTable table = new DataTable();
                       if (Session["BAOKD"] != null)
                       {
                           table = (DataTable)Session["BAOKD"];
                           for (int i = 0; i < table.Rows.Count; i++)
                           {
                           %>
                <tr>
                    <td class="style55" rowspan="2" >
                      <span style="font:17px; font-weight:bold">
                      <% 
                         if (this.year.Text.Equals(table.Rows[i]["NAM"].ToString()))
                         {%><%=table.Rows[i]["KY"]%><%                             
                         }
                         else
                         {
                             %><%=table.Rows[i]["KY"]%>/<%=table.Rows[i]["NAM"]%><%
                         }
                       %></span></td>
                    <td  colspan="2" class="style58" >
                       <span title="Tiền Nước Chuẩn Thu Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["DOANHTHU"])%></span> </td>
                    <td style="text-align: center" class="style24" rowspan="2" >
                       <span title="Lượng Nước Chuẩn Thu Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SANLUONG"])%></span></td>
                    <td  colspan="2" class="style58">
                       <span title="Số Đồng Hồ Nước Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SLDHN"])%></span></td>
                    <td class="style25" >
                       <span title="Giá Bán Bình Quân Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["GIABQ"])%></span></td>
                    <td rowspan="2" class="style30">
                        <div class="style402">
                            <span title="HĐ Trung Bình Q.Phú Nhuận Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HDTB_PN"])%></span>&nbsp;<br />
                            <span title="HĐ Trung Bình Q.Tân Bình Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HDTB_TB"])%></span>&nbsp;<br />
                            <span title="HĐ Trung Bình Q.Tân Phú Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HDTB_TP"])%></span>&nbsp;</div>
                        <hr style="height: 0px; margin-bottom:0px; margin-top:0px; width: 63px;" />
                        <div class="style402">
                            <span title="Tổng HĐ Trung Bình Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HDTB"])%></span>&nbsp;</div>
                    </td>
                    <td class="style61">
                        </td>
                    <td  rowspan="2" class="style41">
                        <div class="style40" >
                           <span title="HĐ 0m3 Q.Phú Nhuận Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON0_PN"])%></span>&nbsp;<br /> 
                           <span title="HĐ 0m3 Q.Tân Bình Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON0_TB"])%></span>&nbsp;<br />
                           <span title="HĐ 0m3 Q.Tân Phú Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON0_TP"])%></span>&nbsp;
                        <hr style="height: 0px; margin-bottom:0px; margin-top:0px; width: 44px;" />
                        <span title="Tổng HĐ 0m3 Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON0"])%>&nbsp;</span></div>
                    </td>
                    <td class="style11" >
                    </td>
                    <td  rowspan="2" class="style32">
                        <div class="style40">
                            <span title="HĐ 4m3 Q.Phú Nhuận Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON4_PN"])%></span>&nbsp;<br /> 
                            <span title="HĐ 4m3 Q.Tân Bình Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON4_TB"])%></span>&nbsp;<br />
                            <span title="HĐ 4m3 Q.Tân Phú Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON4_TP"])%></span>&nbsp;
                        <hr style="height: 0px; margin-bottom:0px; margin-top:0px; width: 47px;" />
                        <span title="Tổng HĐ 4m3 Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HOADON4"])%>&nbsp;</span></div>
                    </td>
                    <td class="style61" >
                    </td>
                    <td rowspan="2" class="style54">
                       <span style="font:17px; font-weight:bold" title="Số Lượng Hóa Đơn Tồn Các Kỳ Trước"><%=Format.NumberFormat(table.Rows[i]["HDTON_TRUOC"])%>&nbsp;</span></td>
                    <td rowspan="2" style="width:80px" >
                        <div class="style400" >&nbsp;&nbsp;<br /> 
                            <span title="Hóa Đơn Tồn Tư Gia Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HDTON_TG"])%></span>&nbsp;&nbsp;<br />
                            <span title="Hóa Đơn Tồn Cơ Quan Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HDTON_CQ"])%></span>&nbsp;&nbsp;
                            <hr style="height: 0px; margin-bottom:0px; margin-top:0px; width:70px;" />                       
                            <span title="Tổng Hóa Đơn Tồn Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["HDTON_TONG"])%></span>&nbsp;&nbsp;</div>
                    </td>
                    <td rowspan="2" style="border:1px;">
                        <div class="style401" >&nbsp;&nbsp;&nbsp;<br />
                        <span title="Doanh Thu Tồn Tư Gia Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SLTON_TG"])%></span>&nbsp;&nbsp;&nbsp;<br />
                        <span title="Doanh Thu Tồn Cơ Quan Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SLTON_CQ"])%></span>&nbsp;&nbsp;&nbsp;
                        <hr style="height: 0px; margin-bottom:0px; margin-top:0px; width: 110px;" />
                            <span title="Tổng Doanh Thu Tồn Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["SLTON_TONG"])%></span>&nbsp;&nbsp;&nbsp;</div>
                    </td>

                </tr>
                <tr>
                    <td class="style4" >
                       <span title="Tỉ Lệ Thực Thu 4 Kỳ"><%=Format.PhanTram(table.Rows[i]["DT_4KY"])%></span></td>
                    <td class="style5" >
                       <span title="Tỉ Lệ Thực Thu Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.PhanTram(table.Rows[i]["DT_KY"])%></span></td>
                    <td class="style45" >
                         <span title="ĐHN Tăng"><%=Format.NumberFormat(table.Rows[i]["TANGDHN"])%></span></td>
                    <td class="style12" >
                        <span title="Số Lượng Hóa Đơn <4m3 Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["DHN_NHO3"])%></span>&nbsp;
                    </td>
                    <td class="style46" >
                        <span title="Tổng Hóa Đơn Định Mức Kỳ <%=table.Rows[i]["KY"]%>"><%=Format.NumberFormat(table.Rows[i]["TONG_DM"])%></span>&nbsp;&nbsp;</td>
                    <td class="style62" >
                    <% double HDTB_TANG = Format.ConvertDouble(table.Rows[i]["HDTB_TANG"]);
                       if (HDTB_TANG > 0)
                       {
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
                     %>
                            </td><td class="style63">
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
                      %>
                                </td>
                                <td class="style62">
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
                         %>
                                </td>
                                <%}
            } %>
                            </tr>
            </tr>   
            </table>
              <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="rpt_tkKinhDoanh.rpt">
        </Report>
    </CR:CrystalReportSource>
        </asp:Panel>   
       </asp:Panel>
</div>



 
    