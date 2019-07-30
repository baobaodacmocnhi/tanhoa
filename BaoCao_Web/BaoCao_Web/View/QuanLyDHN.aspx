<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="QuanLyDHN.aspx.cs" Inherits="BaoCao_Web.View.QuanLyDHN" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script language="javascript" type="text/javascript">
           window.document.getElementById("HOME").className = "top_link";
           window.document.getElementById("DHN").className = "current_link";
           window.document.getElementById("HSKH").className = "top_link";
           window.document.getElementById("BDBC").className = "top_link";
    </script>
<div class="Pages_content">
<div class="title_page"><asp:Label ID="title" runat="server" Text=""></asp:Label></div>
 <asp:Panel ID="Panel1" runat="server" Height="94%" ScrollBars="Auto" 
        Width="99%" CssClass="panel" >


    </asp:Panel>
</asp:Content>
