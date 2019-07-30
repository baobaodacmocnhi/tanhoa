<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabTraCuu.ascx.cs" Inherits="BaoCao_Web.View.tabDHN.tabTraCuu" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<link href="../../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style2
    {
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
        width: 200px;
    }
    .style13
    {
        height: 40px;
        width: 47px;
    }
    .style14
    {
        height: 40px;
        width: 109px;
    }
    .style16
    {
        width: 74px;
    }
    .style19
    {
        width: 28px;
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
        width: 255px;
        border-bottom: 1px #99cc99 solid;
    }
    .style35
    {
        width: 137px;
        border-bottom: 1px #99cc99 solid;
    }
    .style37
    {
        height: 40px;
        width: 110px;
    }
    .style38
    {
        width: 68px;
    }
    .style39
    {
        width: 68px;
        border-bottom: 1px #99cc99 solid;
    }
    </style>

<div class="block block_left events" 
    style="width: 795px; float:left; height: 544px;">
        <table style="font-size:14px; font-family: Times New Roman;">
            <tr>
                <td class="style13"> 
                    &nbsp;</td>
                <td class="style37"> 
                    <asp:Label ID="Label4" runat="server" Text="LOẠI TÌM KIẾM:" 
                        CssClass="label"></asp:Label></td>
                <td class="style14"> 
                    <asp:DropDownList ID="dot" runat="server" Height="17px" Width="109px">
                        <asp:ListItem Value="0">Số Thân</asp:ListItem>
                        <asp:ListItem Value="1">Địa Chỉ</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style2"> 
                    <asp:TextBox ID="txtLoai" runat="server"></asp:TextBox>
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
                 
                     <td class="style38" >
                         HIỆU ĐHN<br />
                         SỐ THÂN</td>
                 
                     <td class="style7" >
                         NĂM GẮN<br />
                         VỊ TRÍ</td>
                         <td class="style7" >
                         CHỈ SỐ<br />
                         KỲ TRƯỚC</td>
                 
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
                          </td>
                 
                     <td class="style32"  >
                         <%=table.Rows[i]["CODH"]%></td>
                 
                     <td class="style39"  >
                         <%=table.Rows[i]["HIEUDH"]%><br />
                         <%=table.Rows[i]["SOTHANDH"]%></td>
                 
                     <td class="style28" >
                         <%=table.Rows[i]["NAMGAN"]%><br />
                         <%=table.Rows[i]["VITRIDHN"]%></td>
                       <td  class="style28" >
                         <%=table.Rows[i]["CHISOKYTRUOC"]%></td>
                 
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

 
    