<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuaySoMayMan_Web.TrangChu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #background
        {
            background-image: url(../Image/background1.jpg);
            background-attachment: fixed;
            background-size: auto 100%;
            background-position: center;
           
        }
        
        div.company
        {
            margin-top: 60px;
            font-size: 50px;
            font-weight: bold;
            color: Yellow;
        }
        
        div.stt
        {
            margin-top: 30px;
            font-size: 80px;
            font-weight: bold;
            color: Lime;
        }
        
        @media screen and (max-width: 1024px)
        {
            div.company
            {
                margin-top: 60px;
                font-size: 40px;
                font-weight: bold;
                color: Yellow;
            }
        
            div.stt
            {
                margin-top: 30px;
                font-size: 70px;
                font-weight: bold;
                color: Lime;
            }
        }
    </style>
</head>
<body id="background">
    <form id="form1" runat="server">
    <div class="company" align="center">
        <table>
            <tr>
                <td rowspan="2">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/logoctyCP.png" Width="105px"
                        Height="100px" Style="padding-left: 0px" />
                </td>
                <td>
                    CÔNG TY CỔ PHẦN CẤP NƯỚC TÂN HÒA
                </td>
            </tr>
            <tr>
                <td align="center">
                    TIỆC LIÊN HOAN CUỐI NĂM 2023
                </td>
            </tr>
        </table>
    </div>
    <div class="stt" align="center">
        <div style="margin-top: 30px">
            <asp:Label ID="lbSTT" runat="server" Text="STT"></asp:Label>
        </div>
        <div style="margin-top: 30px">
            <asp:Label ID="lbHoTen" runat="server" Text="Họ Tên"></asp:Label>
        </div>
        <div style="margin-top: 30px">
            <asp:Label ID="lbCongTy" runat="server" Text="Công Ty"></asp:Label>
        </div>
    </div>
    <div style="margin-top: 30px">
        <asp:Label ID="Label1" runat="server" Text="Số Trúng Thưởng"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtSoTrungThuong" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnHienThi" runat="server" Text="Hiện Thị" OnClick="btnHienThi_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click" />
    </div>
    </form>
</body>
</html>
