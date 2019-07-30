<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabSoDocSo.ascx.cs" Inherits="BaoCao_Web.View.tabDHN.tabSoDocSo" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<link href="../../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style2
    {
        height: 40px;
    }
    .style3
    {
        width: 75px;
        height: 40px;
    }
    .style6
    {
         width: 34px;
        height: 26px;
    }
    .style7
    {
    }
    .style10
    {
        width: 125px;
    }
    .style11
    {
        width: 237px;
    }
    .style13
    {
        height: 40px;
        width: 64px;
    }
    .style14
    {
        height: 40px;
        width: 109px;
    }
    .style15
    {
        height: 40px;
        width: 86px;
    }
    .style16
    {
        width: 90px;
    }
    .style19
    {
        width: 28px;
    }
    .style20
    {
        width: 93px;
    }
    .style21
    {
        width: 36px;
        border-bottom: 1px #99cc99 solid;
    }
    .style28
    {
        width: 75px;
         border-bottom: 1px #99cc99 solid;
    }
    .style32
    {
        width: 28px;
        border-bottom: 1px #99cc99 solid;
    }
    .style33
    {
        width: 89px;
        border-bottom: 1px #99cc99 solid;
    }
    .style34
    {
        width: 241px;
        border-bottom: 1px #99cc99 solid;
    }
    .style35
    {
        width: 137px;
        border-bottom: 1px #99cc99 solid;
    }
    .style36
    {
        width: 107px;
        border-bottom: 1px #99cc99 solid;
    }
    .style37
    {
        width: 82px;
    }
    </style>

<div class="block block_left events" 
    style="width: 795px; float:left; height: 544px;">
        <table style="font-size:14px; font-family: Times New Roman;">
            <tr>
                <td class="style13"> 
                    &nbsp;</td>
                <td class="style15"> 
                    <asp:Label ID="Label4" runat="server" Text="NHÂN VIÊN :" 
                        CssClass="label"></asp:Label></td>
                <td class="style14"> 
                    <asp:DropDownList ID="nhanviends" runat="server" Height="30px" Width="121px" 
                        style="margin-left: 0px">
                    </asp:DropDownList>
                </td>
                <td class="style2"> <asp:Label ID="Label1" runat="server" Text="ĐỢT ĐỌC SỐ  : " 
                        CssClass="label"></asp:Label></td>
                <td class="style3">
                    <asp:DropDownList ID="dot" runat="server" Height="20px" Width="56px">
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style2"> 
                    <asp:Label ID="Label5" runat="server" Text="KỲ  : " 
                        CssClass="label"></asp:Label></td>
                <td class="style37">
                    <asp:DropDownList ID="ky" runat="server" Height="20px" Width="47px">
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style2">&nbsp;<asp:Button ID="btXemBangKe" runat="server" Text="XEM THÔNG TIN" 
                        CssClass="button" onclick="btXemBangKe_Click" /></td>
            </tr>
        </table>

 	<h3>&nbsp;
        </h3>
	<div class="block_content">
        
            <table cellpadding="0" cellspacing="0" style="width:100%; font-family:Times New Roman; font-size:15px;" class="table_list" >
              <tbody>
                  <tr class="head" >
                    <td class="style6" >SỐ STT</td>
                    <td class="style10" >
                        DANH BỘ<br />
                        LỘ TRÌNH</td>
                     
                    <td class="style11" >
                       <b>HỌ TÊN <br />
&nbsp;ĐỊA CHỈ</b></td>
                     <td class="style16" >
                         HỢP ĐỒNG<br />
                         GB - ĐM</td>
                 
                     <td class="style19" >
                         CỞ</td>
                 
                     <td class="style20" >
                         HIỆU ĐHN<br />
                         SỐ THÂN</td>
                 
                     <td class="style7" >
                         NĂM GẮN<br />
                         VỊ TRÍ</td>
                 
                </tr>
              </tbody>
            </table>
             
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="429px" 
                Width="788px" BorderWidth="0px" >
                <table cellpadding="0" cellspacing="0" style="width:100%; font-family:Times New Roman; font-size:13px;" class="table_list" >
              <tbody>
               <% 
                       DataTable table = new DataTable();
                       if (Session["sds"] != null)
                       {
                           table = (DataTable)Session["sds"];
                           for (int i = 0; i < table.Rows.Count; i++)
                           {
                           %>
                            <tr >
                    <td class="style21" ><%=table.Rows[i]["STT"]%></td>
                    <td class="style35"  >
                        <%=table.Rows[i]["DANHBO"]%><br />
                        <%=table.Rows[i]["LOTRINH"]%></td>
                     
                    <td class="style34"  >
                       <%=table.Rows[i]["HOTEN"]%> <br />
&nbsp;<%=table.Rows[i]["DCHI"]%></td>
                     <td class="style33"  >
                         <%=table.Rows[i]["HOPDONG"]%><br />
                         <%=table.Rows[i]["GIABIEU"]%>- <%=table.Rows[i]["DINHMUC"]%></td>
                 
                     <td class="style32"  >
                         <%=table.Rows[i]["CODH"]%></td>
                 
                     <td class="style36"  >
                         <%=table.Rows[i]["HIEUDH"]%><br />
                         <%=table.Rows[i]["SOTHANDH"]%></td>
                 
                     <td class="style28" >
                         <%=table.Rows[i]["NAMGAN"]%><br />
                         <%=table.Rows[i]["VITRIDHN"]%></td>
                 
                </tr>
                           <%
}
                       }
                               
                     %>

                  
                
              </tbody>
            </table>
        </asp:Panel>
            </div>
 </div>

 
    