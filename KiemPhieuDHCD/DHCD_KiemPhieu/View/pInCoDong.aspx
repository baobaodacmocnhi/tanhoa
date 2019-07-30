<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="pInCoDong.aspx.cs" Inherits="DHCD_KiemPhieu.View.pInCoDong" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
            function Focus(object) {
                object.value = "";
            }

    </script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
     window.document.getElementById("HOME").className = "top_link";
     window.document.getElementById("CODONG").className = "current_link";
     window.document.getElementById("KIEMPHIEU").className = "top_link";
     window.document.getElementById("BIEUQUYET").className = "top_link";
     window.document.getElementById("BAUCU").className = "top_link"; 
    </script>
     <div class="title_page" style=" margin-top:10px; height: 26px; text-align:center;">
         <asp:Label ID="title" runat="server" 
        Text="..: IN PHIẾU CỔ ĐÔNG THAM DỰ ĐẠI HỘI :.."></asp:Label>
    </div>
    <br />
    <table style="width:1024px;">
        <tr>
            <td>
     <table cellpadding="0" cellspacing="0" style="font-family:Times New Roman; font-size:15px; margin-left:40px;" class="table_list" >
        <tbody>
           <tr class="head1">
               <td class="style11" style="border-right:2px #99cc99 solid;background-color:Lavender; border-bottom: 1px solid;">
                   LOẠI PHIẾU IN :</td>
                <td class="style10" style="border-right:2px #99cc99 solid; background-color:Lavender; border-bottom: 1px solid;">
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                                <asp:ListItem>THẺ ĐỒNG Ý</asp:ListItem>
                                                <asp:ListItem>THẺ KHÔNG ĐỒNG Ý</asp:ListItem>
                                                <asp:ListItem>THẺ TRẮNG</asp:ListItem>
                                            </asp:DropDownList>
               </td>
                <td class="style10" style="border-right:2px #99cc99 solid; background-color:Lavender; border-bottom: 1px solid;">
                <asp:Button ID="btSubmit" runat="server"  Text="Biểu Quyết" Width="103px" 
                     CssClass="button1" Height="28px" onclick="btSubmit_Click"/>
               </td>
             </tr>
          </tbody>
    </table>
    
            </td>
        </tr>
        <tr>
            <td>

                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    </asp:Content>
