<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dmaApLuc.aspx.cs" Inherits="BaoCao_Web.View.dmaApLuc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>..: ÁP LỰC DMA :..</title>
 
    
<script type="text/javascript">
    init_reload();
    function init_reload(){
        setInterval( function() {
                   window.location.reload();

               }, 900000);
    }
    </script>

     

</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Số cột"></asp:Label>
              <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged" 
                 Width="60px">5</asp:TextBox>
        </td>
        <td>
             <asp:Label ID="Label2" runat="server" Text="Áp lực = 0 : " Visible="False"></asp:Label>   
             <asp:CheckBox ID="check0" runat="server" 
                 oncheckedchanged="check0_CheckedChanged" AutoPostBack="True"  Visible="False" /> 
        &nbsp;</td>
         <td>
             <asp:Label ID="Label3" runat="server" Text="Áp lực lỗi : " Visible="False"></asp:Label>    
             <asp:CheckBox ID="checkLoi" runat="server" 
                 oncheckedchanged="checkLoi_CheckedChanged" AutoPostBack="True" 
                 Visible="False" />
        </td>

        </tr>
    </table>
    
&nbsp;<table width="100%" cellpadding="0" cellspacing="0" border="1" >  
 <tr align="justify">
    <td valign="top" style="width:7%; height:100%" >
      <div> <table width="100%" cellspacing="0" cellpadding="0" border="0">
                 <tbody><tr>
                   <td bgcolor="#DDEDFB" style="border-bottom:1pt #67aeef solid"><table width="100%" cellspacing="0" cellpadding="0" border="0">
                     <tbody><tr>
                       <td width="33">
                           <asp:CheckBox ID="cAll" runat="server" AutoPostBack="True" 
                               oncheckedchanged="cAll_CheckedChanged" /></td>
                       <td width="10">&nbsp;</td>
                       <td><b>DMA</b> </td>
                     </tr>
                   </tbody></table></td>
                 </tr>
               </tbody>
           </table>
       </div>
       <div style="overflow :auto; height:720px;">
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

     .style1
     {
         width: 68px;
         height: 31px;
     }

 </style>

<table cellpadding="0" cellspacing="0" border=2  style="width:100%; background-color:White; font-family:Times New Roman; font-size:15px;" class="table_list" >
         <tbody>
          <tr>
              <%
                  DataTable table = new DataTable();
                  if (Session["chamcongAL"] != null)
                  {
                      table = (DataTable)Session["chamcongAL"];
                      for (int i = 0; i < table.Rows.Count; i++)
                      {
                          string dma = table.Rows[i]["MADMA"].ToString();
                          string img = @"../Image/DMA/" + dma + @".png";
                     %><td>       
                          <div class="outer">                    
                           <img  height="300" width="500" src="<%=img%> " />                          
                            <table width="300;" class="topright" border="1" style="background-color:#CCFFCC; text-align:center; margin-top:30px; margin-left:20px; font-size:20px;" cellpadding="0" cellspacing="0" >
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
                               if (t1.Rows[0]["LastValue"] == null)
                              {
                                         %><td rowspan="2"   style=" background-color:White;width:50px; text-align:center"><a title="Click Xem Biểu Đồ !" href="QuanLyDMA_Chart.aspx?value=<%=ChannelID%>"><img alt="" class="style1" src="../Image/error.gif" /></a></td><%
                              }
                              else if (t1.Rows[0]["LastValue"].ToString() == "0")
                              { 
                              %>
                                <td rowspan="2"   style=" background-color:Red;width:50px; text-align:center"><a title="Click Xem Biểu Đồ !" href="QuanLyDMA_Chart.aspx?value=<%=ChannelID%>">0</a></td><%
                              }
                              else
                              {
                                  if (DateTime.Now.Date == DateTime.Parse(t1.Rows[0]["TimeStamp"].ToString()).Date)
                                  {
                                    %><td rowspan="2" style="text-align:center;width:100px; color:Red;"><a title="Click Xem Biểu Đồ !" href="QuanLyDMA_Chart.aspx?value=<%=ChannelID%>"><%=t1.Rows[0]["LastValue"]%></a> </td><%
                                  }
                                  else
                                  { 
                                    %><td rowspan="2" style="background-color:Yellow;width:50px;text-align:center"><a title="Click Xem Biểu Đồ !" href="QuanLyDMA_Chart.aspx?value=<%=ChannelID%>"><%=t1.Rows[0]["LastValue"]%></a></td><%
                                  }
                              }

                          }
                          else
                          { 
                                %><td rowspan="2"  style="background-color:White;width:50px;text-align:center"><img alt="" class="style1" src="../Image/error.gif" /></td><%
                          }
                          %>
                                     
                                     <td style="text-align:center;width:50px;"><%=ALMin%></td> 
                                 </tr>
                                <tr>
                                 <td style="text-align:center; border-top:2px;width:50px;"><%=ALMax%></td> 
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
                          int col = int.Parse(Session["col"].ToString());
                          if ((i + 1) % col == 0)
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
   

    </form>
</body>
</html>
