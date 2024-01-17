<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="countdown.aspx.cs" Inherits="QuaySoMayMan_Web.countdown" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">
    var sec = 0;
    var min = 0;
    var hour = 0;
    var t;

    function pad(num, size) {
        var s = num + "";
        while (s.length < size) s = "0" + s;
        return s;
    }

    function countdown() {
        sec -= 1
        if ((sec == 0) && (min == 0) && (hour == 0)) {
            //if a popup window is used:
            //            setTimeout("self.close()", 1000);
            //            return;
            document.getElementById("lbTime").style.backgroundColor = "red";
        }
        if (sec < 0) {
            sec = 59;
            min -= 1;
        }
        if (min < 0) {
            min = 59;
            hour -= 1;
        }
        else
            document.getElementById("lbTime").innerHTML = pad(min, 2) + ":" + pad(sec, 2);
        t = setTimeout("countdown()", 1000);
    }

    function countup() {
        sec += 1
        if (sec == 60) {
            sec = 0;
            min += 1;
        }
        if (min >= 8) {
            if (document.getElementById("lbTime").style.backgroundColor == "yellow")
                document.getElementById("lbTime").style.backgroundColor = "blue";
            else
                document.getElementById("lbTime").style.backgroundColor = "yellow"
        }
        else
            document.getElementById("lbTime").style.backgroundColor = "";
        document.getElementById("lbTime").innerHTML = pad(min, 2) + ":" + pad(sec, 2);
        t = setTimeout("countup()", 1000);
    }
    //    window.onload = display;
    function end() {
        clearInterval(t);
    }


</script>
<body style="background-image: url(../Image/background1.jpg); background-attachment: fixed;
    background-size: auto 100%; background-position: center;">
    <form id="form1" runat="server">
    <div style="margin-top: 50px">
        <div style="margin-top: 30px; font-size: 100px; font-weight: bold; color: #FFFF00;"
            align="center">
            <asp:Label ID="lbPhong" runat="server" Text="Phòng"></asp:Label>
        </div>
        <div style="margin-top: 20px; font-size: 300px; font-weight: bold;" align="center">
            <asp:Label ID="lbTime" runat="server" Text="Thời Gian" ForeColor="#00FF00"></asp:Label>
        </div>
        <div style="margin-top: 50px;">
            <asp:DropDownList ID="cmbPhong" runat="server" OnSelectedIndexChanged="cmbPhong_SelectedIndexChanged"
                AutoPostBack="True">
                <asp:ListItem>Phòng</asp:ListItem>
                <asp:ListItem>1. Phòng Khách Hàng</asp:ListItem>
                <asp:ListItem>2. Phòng Kế Toán Đầu Tư</asp:ListItem>
                <asp:ListItem>3. Phòng Tổ Chức Hành Chính</asp:ListItem>
                <asp:ListItem>4. Đội Thu Tiền</asp:ListItem>
                <asp:ListItem>5. Phòng Thương Vụ</asp:ListItem>
                <asp:ListItem>6. Phòng Kỹ Thuật Công Nghệ</asp:ListItem>
                <asp:ListItem>7. Đội Thi Công Xây Lắp</asp:ListItem>
                <asp:ListItem>8. Phòng Kế Hoạch Đầu Tư</asp:ListItem>
                <asp:ListItem>9. Phòng Giảm Nước Không Doanh Thu</asp:ListItem>
                <asp:ListItem>10. Đội Thi Công Tu Bổ</asp:ListItem>
                <asp:ListItem>11. Đội Quản Lý Đồng Hồ Nước</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnStart" runat="server" Text="Bắt Đầu" OnClientClick="countup(); return false;" />
            <asp:Button ID="btnEnd" runat="server" Text="Dừng" OnClientClick="end(); return false;" />
        </div>
    </div>
    <div>
    </div>
    </form>
</body>
</html>
