<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true"
    CodeBehind="ChamCongDoiMatKhau.aspx.cs" Inherits="BaoCao_Web.View.ChamCongDoiMatKhau" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        window.document.getElementById("HOME").className = "top_link";
        window.document.getElementById("DHN").className = "top_link";
        window.document.getElementById("CHAMCONG").className = "current_link";
        window.document.getElementById("BDBC").className = "top_link";

        function Reset1_onclick() {

        }


    </script>
    <style type="text/css">
        .style4
        {
            color: #CC0000;
            font-size: x-large;
        }
        .style7
        {
            width: 252px;
        }
        .style8
        {
        }
        .style12
        {
        }
        .style13
        {
            width: 169px;
        }
        .style14
        {
            width: 157px;
        }
        .style15
        {
        }
        .style16
        {
            width: 169px;
            height: 28px;
        }
        .style17
        {
            height: 28px;
        }
        .style20
        {
            width: 140px;
            height: 28px;
        }
        .style21
        {
            width: 252px;
            height: 28px;
        }
        .style22
        {
            width: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="title_page" style="height: 20px;">
        <asp:Label ID="title" runat="server" Text=""></asp:Label>
    </div>
    <div class="block_content">
        <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1" />
        <center>
    <table border="0"  style="width:30%;">
        <tr>
            <td colspan="2">
                <table class="dangkytop" border="0" cellpadding="0" cellspacing="0" id="TABLE1">
                    <tr>
                        <td class="dkt1" style="height: 32px">
                        </td>
                        <td class="dkt2" style="width: 524px; height: 32px">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="ĐỔI MẬT KHẨU XEM CHẤM CÔNG"></asp:Label></td>
                        <td  class="dkt3" style="height: 32px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 15px; height: 21px" valign="top">
                <asp:Label ID="Label2" runat="server" Text="Mật khẩu hiện tại :" Width="150px" 
                    style="text-align: right"></asp:Label></td>
            <td style="height: 30px; width: 1366px; text-align: left;" valign="top">
                <asp:TextBox ID="txtPassword_Old" runat="server" Width="159px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="(*)" ControlToValidate="txtPassword_Old" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 15px; text-align: right;" valign="top">
                <asp:Label ID="Label3" runat="server" Text="Mật khẩu mới :" Width="150px"></asp:Label></td>
            <td style="width: 1366px; text-align: left;" valign="top">
                <asp:TextBox ID="txtPassword_New" runat="server" TextMode="Password"
                    Width="159px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="(*)" ControlToValidate="txtPassword_New" ForeColor="Red"></asp:RequiredFieldValidator></td>
               
        </tr>
        <tr>
            <td style="width: 15px; text-align: right;" valign="top">
                <asp:Label ID="Label4" runat="server" Text="Mật khẩu xác nhận lại :" Width="150px"></asp:Label></td>
            <td style="width: 1366px; text-align: left;" valign="top">
                <asp:TextBox ID="txtPassword_Conf" runat="server" TextMode="Password"
                    Width="159px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="(*)" ControlToValidate="txtPassword_Conf" ForeColor="Red"></asp:RequiredFieldValidator></td>
                
        </tr>
        <tr>
            <td colspan="2" style="height: 35px">
                <asp:Button ID="Button1" runat="server"  Text="&nbsp;Thay Đổi&nbsp;" Width="103px" 
                    onclick="Button1_Click" CssClass="button" Height="25px"/>
                &nbsp;&nbsp;&nbsp;
                <input id="Reset1" style="width: 95px" type="reset" value="Hủy bỏ" 
                    class="button" onclick="return Reset1_onclick()"/><br />
                <br />
                <asp:Label ID="mess" runat="server" ForeColor="Red" 
                    Text="(*) Đổi Mật Khẩu Thất Bại" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
   </center>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
