<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="ChamCong.aspx.cs" Inherits="BaoCao_Web.View.ChamCong" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script language="javascript" type="text/javascript">
          window.document.getElementById("HOME").className = "top_link";
          window.document.getElementById("DHN").className = "top_link";
          window.document.getElementById("CHAMCONG").className = "current_link";
          window.document.getElementById("BDBC").className = "top_link";
    </script>
    <style type="text/css">
        .style1
        {
            width: 117px;
        }
        .style2
        {
            width: 173px;
        }
        .style3
        {
            width: 151px;
            height: 31px;
        }
        .style4
        {
            width: 117px;
            height: 31px;
        }
        .style6
        {
            height: 22px;
        }
        .style7
        {
            height: 31px;
        }
        .style9
        {
            width: 98px;
        }
        .style10
        {
            width: 235px;
        }
        .style11
        {
            width: 75px;
        }
         .style28
            {
            text-align: center;
            border-bottom: 1px #99cc99 solid;
        }
    .style29
    {
        width: 91px;
        height: 31px;
    }
        .style34
        {
            width: 38px;
        }
        .style35
        {
            height: 23px;
            width: 38px;
        }
        .style36
        {
            width: 40px;
        }
        .style37
        {
            height: 23px;
            width: 40px;
        }
        .style38
        {
            width: 164px;
        }
        .style39
        {
            width: 164px;
            height: 23px;
        }
        .style40
        {
            width: 168px;
        }
        .style41
        {
            width: 168px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="title_page" style="height:20px;"><asp:Label ID="title" runat="server" 
        Text="THEO DÕI CHẤM CÔNG CÔNG NHÂN VIÊN "></asp:Label>
    </div>
<div class="block_content">
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1"  />
            <br />
 <fieldset>
  <legend><b>Chọn Tiêu Chí Lọc :</b></legend>
     <table class="table_list_in">
         <tr>
             <td class="style4">
                 PHÒNG BAN ĐỘI :</td>
             <td class="style29">
                 <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" Width="195px">
                     <asp:ListItem Value="1">Tất Cả</asp:ListItem>
                     <asp:ListItem Value="2">To</asp:ListItem>
                     <asp:ListItem Value="3">232</asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td class="style3">
                 <asp:CheckBox ID="ckNV" runat="server" Text="Nhân Viên Văn Phòng" 
                     Checked="True" />
             </td>
             <td class="style7">
                 <asp:CheckBox ID="ckCN" runat="server" Text="Công Nhân Đi Ngoài" />
             </td>            
         </tr>
           <tr>
           <td></td>
           <td colspan="3">
            <table>
                <tr>
                <td class="style6"> <asp:Label ID="Label1" runat="server" Text="Từ Ngày : " CssClass="label"></asp:Label></td>
                <td class="style1"><asp:TextBox runat="server" ID="tungay" autocomplete="off" /></td>
                <td class="style6"> <asp:Label ID="Label2" runat="server" Text="Đến Ngày : " CssClass="label"></asp:Label></td>
                <td class="style2"><asp:TextBox runat="server" ID="denngay" autocomplete="off" /></td>
                <td class="style6">&nbsp;<asp:Button ID="btXemBangKe" runat="server" Text="XEM THÔNG TIN" 
                        CssClass="button" onclick="btXemBangKe_Click" Height="30px"  /></td>
               <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tungay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>
         <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="denngay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>
            </tr>
            </table>
           </td>
           </tr>
     </table>
 </fieldset>
       <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">  
 <asp:Panel ID="Panel2" runat="server" ScrollBars="None">
 
 <div class="block block_left events" style="height:300px; width:100% ; margin-left:10px; margin-bottom:10px; border:1px;">
 	<h2>Kết Quả</h2>
	<div class="block_content">
      
      <!-- Start Show -->

      <table cellpadding="0" cellspacing="0" style=" width:100%; font-family:Times New Roman; font-size:15px;" class="table_list" >
              <tbody>
               
                                    <tr class="head1">
                                        <td class="style11" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;">
                                            MÃ NV</td>
                                        <td class="style10" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;">
                                            HỌ TÊN
                                        </td>
                                        <%
                      string[] arrTitle = (string[])Session["arrTitle"];
                      
                      foreach (string s in arrTitle)
                      {
                        %><td class="style9" colspan="2" style="border-right:2px #99cc99 solid; border-bottom: 2px solid;"><%=s%></td><%
                      }
                   %>
         </tr>
         <%
             DataTable table = new DataTable();
                       if (Session["chamcong"] != null)
                       {
                           //int flag = (int)Session["col"];
                           table = (DataTable)Session["chamcong"];
                           foreach (DataRow row in table.Rows)
                           {
                               
                            %>
                            <tr style="height:25px;">
                            <td class="style28" align="left" style="border-right:2px #99cc99 solid;"><%=row["MANV"].ToString()%></td>
                            <td class="style28"  align="left" style="border-right:2px #99cc99 solid;"><%=row["TENNV"].ToString()%></td>
                               <%
                               foreach (string s in arrTitle)
                               {
                                   if (!"NGÀY CÔNG".Equals(s) && !"TRỂ".Equals(s) && !"SỐ PHÚT".Equals(s))
                                   {
                                       if ("1".Equals(row[s + "TRE"].ToString())) { 
                                        %>
                                        <td class="style28" style="background-color:Yellow;" ><%=row[s].ToString()%></td>
                                        
                                      <%
                                           
                                       }
                                       else { 
                                            if ("CT".Equals(row[s].ToString())) {
                                             %>
                                        <td class="style28" style="background-color:Aqua;" ><%=row[s].ToString()%></td>
                                        
                                      <%
                                      }
                                            else if ("KQ".Equals(row[s].ToString())) { 
                                        %>
                                        <td class="style28" style="background-color:Red;" ><%=row[s].ToString()%></td>
                                        
                                      <%
}
                                            else if ("TH".Equals(row[s + "TYPE"].ToString()) || "TN".Equals(row[s + "TYPE"].ToString()) || "KT".Equals(row[s + "TYPE"].ToString())) {
                                                  %>
                                                <td class="style28" style="background-color:Lavender;" ><%=row[s].ToString()%></td>
                                        
                                              <%
                                            }
                                            else{
                                                  %>
                                                <td class="style28" ><%=row[s].ToString()%></td>
                                     
                                              <%
                                            }                                      
                                       }
                                       
                                       if ("1".Equals(row[s + "SOM"].ToString())) { 
                                        %>
                                        
                                        <td class="style28" style="background-color:Yellow; border-right:2px #99cc99 solid;"><%=row[s + "RA"].ToString()%></td>
                                      <%
                                           
                                       }
                                       else { 
                                           if ("CT".Equals(row[s + "RA"].ToString())) {
                                                 %>
                                            <td class="style28" style="background-color:Aqua;" ><%=row[s + "RA"].ToString()%></td>
                                        
                                          <%
                                          }
                                                else if ("KQ".Equals(row[s + "RA"].ToString())) { 
                                            %>
                                            <td class="style28" style="background-color:Red;" ><%=row[s + "RA"].ToString()%></td>
                                        
                                          <%
}
                                           else if ("TH".Equals(row[s + "TYPE"].ToString()) || "TN".Equals(row[s + "TYPE"].ToString()) || "KT".Equals(row[s + "TYPE"].ToString())) { 
                                            %>
                                                   <td class="style28" style="background-color:Lavender;border-right:2px #99cc99 solid;" ><%=row[s + "RA"].ToString()%></td>
                                     
                                                  <%
                                           }
                                                else{
                                                      %>
                                                    <td class="style28" style="border-right:2px #99cc99 solid;"><%=row[s + "RA"].ToString()%></td>
                                     
                                                  <%
                                                }  
                                        %>
                                        
                                      <%
                                       }

                                   }
                                   else { 
                                     %>
                                        <td class="style28" colspan="2" style="border-right:2px #99cc99 solid;"><%=row[s].ToString()%></td>                                      
                                      <%
                                   }
                                    
                               }
                                %>
                            </tr>
                            <%
                           }                          
                       }        
                 
             
          %>
              </tbody>
            </table>
            <br />
            <asp:Button ID="Button1" runat="server" Text="XUẤT FILE NHÂN VIÊN ĐI TRỂ" 
                        CssClass="button" onclick="Button1_Click" Height="30px" />
      <!-- End Show -->
     </div>
   
    </div>
  </asp:Panel>
</asp:Panel>
<table>
</table>
    <h3>Chú Thích</h3>
      <table cellpadding="0" cellspacing="0" style="font-family:Times New Roman; font-size:15px;" 
            class="table_list"  >
                            <tr style="height:25px;" >
                                        <td style="background-color:Red;border-bottom:2px #99cc99 solid;" class="style34" ></td> 
                                        
                                                <td class="style40" style="border-bottom:2px #99cc99 solid;border-right:2px #99cc99 solid;">
                                                    Không Quẹt Thẻ;</td>
                                        
                                                <td  style="background-color:Lavender;border-bottom:2px #99cc99 solid;" class="style36" ></td>
                                        <td  style=";border-bottom:2px #99cc99 solid;" class="style38">
                                            Xin Về Sớm;</td>
                                        </tr>
                                        <tr>
                                            
                                     
                                        <td style="background-color:Yellow; " class="style35" 
                                    ></td>
                                            <td class="style41" style="border-right:2px #99cc99 solid; " >
                                                Vào Trể/Ra sớm;</td>
                                            <td  style="background-color:Aqua;" class="style37"  ></td>
                                        
                                            <td class="style39">
                                                Đi Công Tác Ngoài;</td>
                                        
                            </tr>
            </table>
<br />
</div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
