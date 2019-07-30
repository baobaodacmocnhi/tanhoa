<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/View/HomePageDMA.Master" AutoEventWireup="true" CodeBehind="QuanLyDMA.aspx.cs" Inherits="BaoCao_Web.View.KTCN.QuanLyDMA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<div class="Content">

   
<table width="100%" cellpadding="0" cellspacing="0" border="1" >
 <tr align="justify">
    <td valign="top" style="width:10%; height:700px;" >
      <div> <table width="100%" cellspacing="0" cellpadding="0" border="0">
                 <tbody><tr>
                   <td bgcolor="#DDEDFB" style="border-bottom:1pt #67aeef solid"><table width="100%" cellspacing="0" cellpadding="0" border="0">
                     <tbody><tr>
                       <td width="33">
                           <asp:CheckBox ID="cAll" runat="server" AutoPostBack="True" 
                               oncheckedchanged="cAll_CheckedChanged" /></td>
                       <td width="10">&nbsp;</td>
                       <td><b>MÃ DMA</b> </td>
                     </tr>
                   </tbody></table></td>
                 </tr>
               </tbody>
           </table>
       </div>
       <div style="overflow :auto; height :650px ">
       <asp:CheckBoxList ID="listDMA" runat="server" AutoPostBack="true"   ClientIDMode="Static"
               onselectedindexchanged="listDMA_SelectedIndexChanged"  >
        </asp:CheckBoxList>
       </div>
        
     </td>
    <td valign="top" style="width: 90%">

 <style type="text/css">
  .outer {
    position: relative;
   
  }

 .topright {
    position: absolute;
    top: 1em;
    right: 15em;
    width: 140px;
    padding: 4px;
    background-color: #fff;
    font-weight: bold;
    font-size: 11px;
  }

</style>

<table cellpadding="0" cellspacing="0"  style="width:100%; background-color:White; font-family:Times New Roman; font-size:15px;" class="table_list" >
         <tbody>
          <tr>
              <%
                  DataTable table = new DataTable();
                  if (Session["chamcong"] != null)
                  {
                      table = (DataTable)Session["chamcong"];
                      for (int i = 0; i < table.Rows.Count; i++)
                      {
                          string dma = table.Rows[i]["MADMA"].ToString();
                          string img = @"../Image/DMA/" + dma + @".png";
                     %><td>       
                          <div class="outer">                    
                           <img  height="300" width="400" src="<%=img%> " />                          
                            <table class="topright" border="1" style="background-color:#98FB98;" cellpadding="0" cellspacing="0" >
                                <tr style="height:20px;"> <td rowspan="2">Áp Lực</td> 
                         <%
                          string ChannelID = "";
                          string sq = "SELECT *  FROM [t_Channel_Configurations]  where LEFT([Description],5)='" + dma.Replace("TH-", "") + "' AND ChannelName='Pressure'";
                          string sqLL = "SELECT *  FROM [t_Channel_Configurations]  where LEFT([Description],5)='" + dma.Replace("TH-", "") + "' AND ChannelName='Flow'";
                          string sqTB = "SELECT *  FROM [DATALOGGER]  where MaDMA='" + dma.Replace("TH-", "").Replace("-", ".") + "' ";
                          DataTable t2 = BaoCao_Web.Class.LinQConnectionGis.getDataTable(sqTB);

                          string ALMin = "";
                          string ALMax = "";
                          if (t2.Rows.Count > 0)
                          {
                              ALMin = string.Format("{0:0.##}", t2.Rows[0]["GiaTriNN"]);
                              ALMax = string.Format("{0:0.##}", t2.Rows[0]["GiaTriLN"]);
                          }

                          DataTable t1 = BaoCao_Web.Class.LinQConnectionGis.getDataTable(sq);
                          if (t1.Rows.Count > 0)
                          {
                              ChannelID = t1.Rows[0]["ChannelId"].ToString();
                              %>
                              
                              <%
                              if (t1.Rows[0]["LastValue"] == null || t1.Rows[0]["LastValue"].ToString() == "0")
                              {
                                         %><td rowspan="2"  style="background-color:Red;text-align:center">0</td><%
                              }
                              else
                              {
                                  if (DateTime.Now.Date == DateTime.Parse(t1.Rows[0]["TimeStamp"].ToString()).Date)
                                  {
                                    %><td rowspan="2" style="text-align:center"><a title="Click Xem Biểu Đồ !" href="QuanLyDMA_Chart.aspx?value=<%=ChannelID%>"><%=t1.Rows[0]["LastValue"]%></a> </td><%
                                  }
                                  else
                                  { 
                                    %><td rowspan="2" style="background-color:Yellow;text-align:center"><a title="Click Xem Biểu Đồ !" href="QuanLyDMA_Chart.aspx?value=<%=ChannelID%>"><%=t1.Rows[0]["LastValue"]%></a></td><%
                                  }
                              }

                          }
                          else
                          { 
                                %><td rowspan="2"  style="background-color:Red;text-align:center">-</td><%
                          }
                          %>
                                     
                                     <td style="text-align:center"><%=ALMin%></td> 
                                 </tr>
                                <tr>
                                 <td style="text-align:center; border-top:2px;"><%=ALMax%></td> 
                               </tr>
                               <%
                                   
                          DataTable t3 = BaoCao_Web.Class.LinQConnectionGis.getDataTable(sqLL);
                          if (t3.Rows.Count > 0)
                          {
                              try
                              {
                                  ChannelID = t3.Rows[0]["ChannelId"].ToString();
                              }
                              catch (Exception)
                              {
                                  
                                
                              }
                              
                              
                                              %><tr > <td>Lưu Lượng</td>
                                              <td colspan="2" style="height:20px; text-align:center;vertical-align:middle"><a title="Click Xem Biểu Đồ !" href="QuanLyDMA_ChartLL.aspx?value=<%=ChannelID%>"><%=String.Format("{0:0.##}", t3.Rows[0]["LastValue"])%></a></td></tr><%
                          }     
                               %>
                                 
                            </table>                            
                            </div>
                          <%
                          DataTable tb = BaoCao_Web.Class.LinQConnection.getDataTable("SELECT  * FROM TONGDHN_DMA WHERE MADMA='" + dma + "'  ");
                          if (tb.Rows.Count > 0)
                          {
                          %>
                          <table cellpadding="0" cellspacing="0" style="width:100%; font-family:Times New Roman; font-size:10px;" class="table_list" >
                             <tbody>
                                     <tr style="background-color:#E6E6FA" class="head11"  ><td >DHN Hiện Hữu </td><td>15</td><td>20</td><td>25</td><td>40</td><td>50</td><td>80</td><td>100</td><td>150</td><td>200</td></tr>
                                     <tr class="head11" ><td><%=String.Format("{0:0,0}", tb.Rows[0]["TONG"])%>
                                     <br /> <a  href="Print.aspx?page=DMA&madma=<%=dma%>" > Danh sách Khách Hàng </a> </td><td><%=String.Format("{0:0,0}", tb.Rows[0]["CO15"])%></td><td><%=tb.Rows[0]["CO20"]%></td><td><%=tb.Rows[0]["CO25"]%></td>
                                     <td><%=tb.Rows[0]["CO40"]%></td><td><%=tb.Rows[0]["CO50"]%></td><td><%=tb.Rows[0]["CO80"]%></td><td><%=tb.Rows[0]["CO100"]%></td><td><%=tb.Rows[0]["CO150"]%></td><td><%=tb.Rows[0]["CO200"]%></td></tr>
                             </tbody>
                             </table>  
                          
                          <%
                          }
                          string sqlSanLuong = " SELECT MaDMA, SUM(CASE WHEN KY=1 THEN TIEUTHU ELSE NULL END) AS SL1,COUNT(CASE WHEN KY=1 THEN 1 ELSE NULL END) AS DHN1,  ";
                          sqlSanLuong += " SUM(CASE WHEN KY=2 THEN TIEUTHU ELSE NULL END) AS SL2,COUNT(CASE WHEN KY=2 THEN 1 ELSE NULL END) AS DHN2,";
                          sqlSanLuong += " SUM(CASE WHEN KY=3 THEN TIEUTHU ELSE NULL END) AS SL3,COUNT(CASE WHEN KY=3 THEN 1 ELSE NULL END) AS DHN3,";
                          sqlSanLuong += " SUM(CASE WHEN KY=4 THEN TIEUTHU ELSE NULL END) AS SL4,COUNT(CASE WHEN KY=4 THEN 1 ELSE NULL END) AS DHN4,";
                          sqlSanLuong += " SUM(CASE WHEN KY=5 THEN TIEUTHU ELSE NULL END) AS SL5,COUNT(CASE WHEN KY=5 THEN 1 ELSE NULL END) AS DHN5,";
                          sqlSanLuong += " SUM(CASE WHEN KY=6 THEN TIEUTHU ELSE NULL END) AS SL6,COUNT(CASE WHEN KY=6 THEN 1 ELSE NULL END) AS DHN6,";
                          sqlSanLuong += " SUM(CASE WHEN KY=7 THEN TIEUTHU ELSE NULL END) AS SL7,COUNT(CASE WHEN KY=7 THEN 1 ELSE NULL END) AS DHN7,";
                          sqlSanLuong += " SUM(CASE WHEN KY=8 THEN TIEUTHU ELSE NULL END) AS SL8,COUNT(CASE WHEN KY=8 THEN 1 ELSE NULL END) AS DHN8,";
                          sqlSanLuong += " SUM(CASE WHEN KY=9 THEN TIEUTHU ELSE NULL END) AS SL9,COUNT(CASE WHEN KY=9 THEN 1 ELSE NULL END) AS DHN9,";
                          sqlSanLuong += " SUM(CASE WHEN KY=10 THEN TIEUTHU ELSE NULL END) AS SL10,COUNT(CASE WHEN KY=10 THEN 1 ELSE NULL END) AS DHN10,";
                          sqlSanLuong += " SUM(CASE WHEN KY=11 THEN TIEUTHU ELSE NULL END) AS SL11,COUNT(CASE WHEN KY=11 THEN 1 ELSE NULL END) AS DHN11,";
                          sqlSanLuong += " SUM(CASE WHEN KY=12 THEN TIEUTHU ELSE NULL END) AS SL12,COUNT(CASE WHEN KY=12 THEN 1 ELSE NULL END) AS DHN12";
                          sqlSanLuong += " FROM HOADON WHERE NAM=" + Session["year"] + "  AND MADMA='" + dma + "' ";
                          sqlSanLuong += " GROUP BY MaDMA ";
                           tb = BaoCao_Web.Class.LinQConnectionTT.getDataTable(sqlSanLuong);
                          if (tb.Rows.Count > 0)
                          {
                          %>
                          <table cellpadding="0" cellspacing="0" style="width:100%; font-family:Times New Roman; font-size:10px;" class="table_list_2" >
                             <tbody>
                                     <tr style=" color: #0000FF;" class="head"  ><td > Năm    
                                         <asp:DropDownList ID="DropDownList1" runat="server" 
                                             onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                                             AutoPostBack="True">
                                         </asp:DropDownList>
                                         </td>
                                     <td>KỲ 1</td><td>KỲ 2</td><td>KỲ 3</td><td>KỲ 4</td><td>KỲ 5</td><td>KỲ 6</td><td>KỲ 7</td><td>KỲ 8</td><td>KỲ 9</td><td>KỲ 10</td><td>KỲ 11</td><td>KỲ 12</td></tr>

                                     <tr class="head1" ><td >ĐHN </td><td><%=String.Format("{0:0,0}", tb.Rows[0]["DHN1"])%></td><td><%=String.Format("{0:0,0}", tb.Rows[0]["DHN2"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["DHN3"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["DHN4"])%></td>
                                     <td><%=String.Format("{0:0,0}",tb.Rows[0]["DHN5"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["DHN6"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["DHN7"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["DHN8"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["DHN9"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["DHN10"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["DHN11"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["DHN12"])%></td>
                                     </tr>

                                     <tr class="head1"  style="color: #0000FF;">
                                     <td >SẢN LƯỢNG </td><td><%=String.Format("{0:0,0}", tb.Rows[0]["SL1"])%></td><td><%=String.Format("{0:0,0}", tb.Rows[0]["SL2"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["SL3"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["SL4"])%></td>
                                     <td><%=String.Format("{0:0,0}",tb.Rows[0]["SL5"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["SL6"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["SL7"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["SL8"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["SL9"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["SL10"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["SL11"])%></td><td><%=String.Format("{0:0,0}",tb.Rows[0]["SL12"])%></td>
                                     </tr>

                             </tbody>
                             </table>
                              <hr noshade />               
                           </td>
                          <%
                          }
                          
                          if ((i + 1) % 2 == 0)
                          {
                              %></tr><tr>  <%
                          }                          
                      }
                  }
             %>
            </tr>
         </tbody>
        </table>
   
        
    </td>
 </tr>
</table>

</div>


</asp:Content>
