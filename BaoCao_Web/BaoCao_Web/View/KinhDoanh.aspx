<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="KinhDoanh.aspx.cs" Inherits="BaoCao_Web.View.KinhDoanh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<script language="javascript" type="text/javascript">
    window.document.getElementById("HOME").className = "top_link";
    window.document.getElementById("KINHDOANH").className = "current_link";
    window.document.getElementById("HSKH").className = "top_link";
    window.document.getElementById("BDBC").className = "top_link";
    window.document.getElementById("DHN").className = "top_link";
    </script>
<div  style="width:100%; height:600px;">

<asp:Panel ID="Panel1" runat="server" Height="100%" ScrollBars="Auto" 
        Width="99%" CssClass="panel" >
        </asp:Panel>
        </div>
</asp:Content>
