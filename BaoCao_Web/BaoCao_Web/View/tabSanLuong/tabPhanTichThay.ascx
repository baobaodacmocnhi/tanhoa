<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabPhanTichThay.ascx.cs" Inherits="BaoCao_Web.View.tabSanLuong.tabPhanTichThay" %>
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
    .style4
    {
        width: 66px;
        height: 40px;
    }
    .style5
    {
        width: 66px;
    }
    </style>

<div class="block block_left events" style="width: 100%; float:left;">
        <table style="font-size:14px; font-family: Times New Roman;">
            <tr>
                <td class="style2"> 
                    Hiệu&nbsp; </td>
                <td class="style2"> 
                    <asp:DropDownList ID="cbHieu" runat="server" Height="20px" Width="84px">
                    </asp:DropDownList>
                </td>
                <td class="style2"> 
                    &nbsp;&nbsp; Code&nbsp;</td>
                <td class="style2"> &nbsp;</td>
                <td class="style3">
                    <asp:DropDownList ID="code" runat="server" Height="20px" Width="47px">
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>81</asp:ListItem>
                        <asp:ListItem>82</asp:ListItem>
                        <asp:ListItem>83</asp:ListItem>                        
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>N</asp:ListItem>
                        <asp:ListItem>Q</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                        <asp:ListItem>F1</asp:ListItem>
                        <asp:ListItem>F2</asp:ListItem>
                        <asp:ListItem>F3</asp:ListItem>
                        <asp:ListItem>F4</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>
                        <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>5F</asp:ListItem>
                        <asp:ListItem>5K</asp:ListItem>
                        <asp:ListItem>5N</asp:ListItem>
                        <asp:ListItem>5Q</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style2"> 
                    <asp:Label ID="Label2" runat="server" Text="Kỳ" 
                        CssClass="label"></asp:Label></td>
                <td class="style4">
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
                <td>
                    <asp:Label ID="Label3" runat="server" Text="NĂM" 
                        CssClass="label"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="nam" runat="server" Height="20px" Width="50px"></asp:TextBox>
                </td>
                <td class="style2">&nbsp;<asp:Button ID="btXemBangKe" runat="server" Text="XEM THÔNG TIN" 
                        CssClass="button" onclick="btXemBangKe_Click"  /></td>
            </tr>
        </table>

 	<h3>&nbsp;
        </h3>
        </div>
        
	