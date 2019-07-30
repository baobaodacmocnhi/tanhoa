<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DHCD_KiemPhieu.View.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 
<head runat="server">
    <link href="../StyleSheet/Menu.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../JavaScript/transmenu.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <center>
    <table border="0"  style="width:30%; border-bottom: #ff0033 thick double;">
        <tr>
            <td colspan="2">
                <table class="dangkytop" border="0" cellpadding="0" cellspacing="0" id="TABLE1">
                    <tr>
                        <td class="dkt1" style="height: 32px">
                        </td>
                        <td class="dkt2" style="width: 524px; height: 32px">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="THÔNG TIN ĐĂNG NHẬP"></asp:Label></td>
                        <td  class="dkt3" style="height: 32px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 15px; height: 21px" valign="top">
                <asp:Label ID="Label2" runat="server" Text="Tên đăng nhập :" Width="112px" 
                    style="text-align: right"></asp:Label></td>
            <td style="height: 30px; width: 1366px; text-align: left;" valign="top">
                <asp:TextBox ID="txtusername" runat="server" Width="159px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="(*)" ControlToValidate="txtusername" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 15px; text-align: right;" valign="top">
                <asp:Label ID="Label3" runat="server" Text="Mật khẩu  :" Width="80px"></asp:Label></td>
            <td style="width: 1366px; text-align: left;" valign="top">
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"
                    Width="159px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 35px">
                <asp:Button ID="Button1" runat="server"  Text="&nbsp;Đăng Nhập&nbsp;" Width="103px" 
                    onclick="Button1_Click" CssClass="button" Height="25px"/>
                &nbsp;&nbsp;&nbsp;
                <input id="Reset1" style="width: 95px" type="reset" value="Hủy bỏ" 
                    class="button" /><br />
                <br />
                <asp:Label ID="mess" runat="server" ForeColor="Red" 
                    Text="(*) Đăng Nhập Thất Bại" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
   </center>
    </form>
</body>
</body>
</html>
<script language="javascript">
    title_tmp1 = document.title
    if (title_tmp1.indexOf(">>") != -1) {
        title_tmp2 = title_tmp1.split(">>");
        title_last = "*~*" + title_tmp2[1];
        title_last = title_last + "*~*" + title_tmp2[2];
    } else {

        if (title_tmp1.indexOf("*~*") != -1) {
            title_tmp2 = title_tmp1.split("*~*");
            title_last = "*~*" + title_tmp2[1];
            if (title_last == "*~*") { title_last = "*~*" };
            if (title_last == "*~*") { title_last = "*~*" };
        }
        else { title_last = " ĐẠI HỘI " }
    }


    title_new = "" + title_last + ""
    step = 0

    function flash_title() {
        step++
        if (step == 8) { step = 1 }
        if (step == 1) { document.title = '[----*' + title_new + '*----]' }
        if (step == 2) { document.title = '[---*-' + title_new + '-*---]' }
        if (step == 3) { document.title = '[--*--' + title_new + '--*--]' }
        if (step == 4) { document.title = '[-*---' + title_new + '---*-]' }
        if (step == 5) { document.title = '[--*--' + title_new + '--*--]' }
        if (step == 6) { document.title = '[---*-' + title_new + '-*---]' }
        if (step == 7) { document.title = '[----*' + title_new + '*----]' }
        setTimeout("flash_title()", 180);
    }
    flash_title()

    function HamThoiGian() {
        var ThoiGian = new Date();
        var Gio = ThoiGian.getHours();
        var Phut = ThoiGian.getMinutes();
        var Giay = ThoiGian.getSeconds();
        if (Gio < 10) {
            Gio = "0" + Gio;
        }
        if (Phut < 10) {
            Phut = "0" + Phut;
        }
        if (Giay < 10) {
            Giay = "0" + Giay;
        }
        var ngay = ThoiGian.getDate();
        var thang = ThoiGian.getMonth() + 1;
        var nam = ThoiGian.getFullYear();
        if (ngay < 10)
            ngay = "0" + ngay;
        if (thang < 10)
            thang = "0" + thang;

        document.getElementById("clock").innerHTML = ngay + "/" + thang + "/" + nam + "  " + Gio + ":" + Phut + ":" + Giay;

    }
    setInterval("HamThoiGian()", 1000); // S? d?ng setInterval d? g?i l?p di l?p l?i hàm HamThoiGian sau 1 giây.
</script>