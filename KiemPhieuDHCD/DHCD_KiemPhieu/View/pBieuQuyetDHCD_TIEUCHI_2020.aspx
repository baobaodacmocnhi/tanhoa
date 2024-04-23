<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true"
    CodeBehind="pBieuQuyetDHCD_TIEUCHI_2020.aspx.cs" Inherits="DHCD_KiemPhieu.View.pKiemPhieuDHCD_2020" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Focus(object) {
            object.value = "";
        }

    </script>
    <style type="text/css">
        .style2
        {
            width: 311px;
        }
        .style5
        {
            width: 75px;
        }
        .style8
        {
            width: 850px;
        }
        .style10
        {
            width: 317px;
        }
        .style16
        {
            width: 90px;
        }
        .style17
        {
            width: 829px;
        }
        .style18
        {
            width: 1396px;
        }
        .style20
        {
            width: 137px;
        }
        .style21
        {
            width: 86px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        window.document.getElementById("HOME").className = "top_link";
        window.document.getElementById("CODONG").className = "top_link";
        window.document.getElementById("KIEMPHIEU").className = "current_link";
        window.document.getElementById("BIEUQUYET").className = "top_link";
        window.document.getElementById("BAUCU").className = "top_link"; 
    </script>
    <!--  <div class="title_page" style=" margin-top:10px; height: 26px; text-align:center;">
         <asp:Label ID="title" runat="server" 
        Text="..: KIỂM PHIẾU BIỀU QUYẾT CỔ ĐÔNG CÔNG TY CỔ PHẦN CẤP NƯỚC TÂN HÒA :.."></asp:Label>
    </div> -->
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
    <br />
    <table cellpadding="0" cellspacing="0" style="font-family: Times New Roman; font-size: 15px;
        width: 100%;" class="table_list">
        <tbody>
            <tr class="head1">
                <td style="border-right-style: solid; border-right-color: inherit; border-right-width: 2px;
                    border-bottom-style: solid; border-bottom-color: inherit; border-bottom-width: 1px;"
                    class="style16">
                    BIỂU QUYẾT
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="68px" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Bold="True">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style8" style="border-right: 2px #99cc99 solid; border-bottom: 1px solid;
                    background-color: #FFFFCC;">
                    <asp:Label ID="lbTitle" runat="server" ForeColor="Blue" Style="font-size: 45px; text-align: left"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <table style="width: 100%" border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 250px;">
                <table cellpadding="0" cellspacing="0" style="font-family: Times New Roman; font-size: 15px;"
                    class="table_list">
                    <tbody>
                        <tr class="head1">
                            <td class="style17" style="border-right: 2px #99cc99 solid; color: Black; background-color: #99FFCC;
                                text-align: center; border-bottom-style: solid; border-bottom-color: inherit;
                                border-bottom-width: 1px;">
                                NHẬP STT CỔ ĐÔNG TÁN THÀNH
                            </td>
                            <td class="style10" style="border-right: 2px #99cc99 solid; background-color: #99FFCC;
                                border-bottom: 1px solid;">
                                <asp:TextBox ID="txtCoDong" onfocus="Focus(this)" runat="server" AutoPostBack="True"
                                    OnTextChanged="txtCoDong_TextChanged" Width="99px"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td style="width: 250px;">
                <table cellpadding="0" cellspacing="0" class="table_list" style="font-family: Times New Roman;
                    font-size: 15px;">
                    <tr class="head1">
                        <td class="style18" style="border-right: 2px #99cc99 solid; color: Black; background-color: #99FFCC;
                            text-align: center; border-bottom-style: solid; border-bottom-color: inherit;
                            border-bottom-width: 1px;">
                            NHẬP STT CỔ ĐÔNG KHÔNG TÁN THÀNH
                        </td>
                        <td class="style10" style="border-right: 2px #99cc99 solid; background-color: #99FFCC;
                            border-bottom: 1px solid;">
                            <asp:TextBox ID="txtCoDong0" runat="server" AutoPostBack="True" onfocus="Focus(this)"
                                OnTextChanged="txtCoDong0_TextChanged" Width="101px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
             <td style="width: 250px;">
                <table cellpadding="0" cellspacing="0" class="table_list" style="font-family: Times New Roman;
                    font-size: 15px;">
                    <tr class="head1">
                        <td class="style18" style="border-right: 2px #99cc99 solid; color: Black; background-color: #99FFCC;
                            text-align: center; border-bottom-style: solid; border-bottom-color: inherit;
                            border-bottom-width: 1px;">
                            NHẬP STT CỔ ĐÔNG KHÔNG HỢP LỆ
                        <td class="style10" style="border-right: 2px #99cc99 solid; background-color: #99FFCC;
                            border-bottom: 1px solid;">
                            <asp:TextBox ID="txtKhongHopLe" runat="server" AutoPostBack="True" onfocus="Focus(this)"
                                OnTextChanged="txtKhongHopLe_TextChanged" Width="101px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style2">
                NGÀY&nbsp;:
                <asp:TextBox ID="tungay" runat="server" autocomplete="off" Height="19px" Width="75px" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tungay"
                    Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" width="100%" cellspacing="0" class="table_list_1" style="font-family: Times New Roman;
                    font-size: 15px;">
                    <tr id="" class="head1" style="height: 17px;">
                        <td class="style5" colspan="2" style="border-right: 1px #FF0000 solid; color: Red;
                            background-color: #FFFF99; font-size: 20px; border-bottom: 2px #FF0000	 solid;">
                            CỔ ĐÔNG TÁN THÀNH
                        </td>
                    </tr>
                    <tr class="head1">
                        <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                            SỐ LƯỢNG CỔ ĐÔNG
                        </td>
                        <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                            background-color: #FFFF99">
                            <asp:Label ID="kdy_sl" runat="server" Font-Size="XX-Large" ForeColor="Red" Font-Bold="True">0</asp:Label>
                        </td>
                    </tr>
                    <tr class="head1">
                        <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                            TỔNG SỐ CỔ PHIẾU :
                        </td>
                        <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                            background-color: #FFFF99">
                            <asp:Label ID="kdy_cp" runat="server" Font-Size="XX-Large" ForeColor="Red" Font-Bold="True">0</asp:Label>
                        </td>
                    </tr>
                    <tr class="head1">
                        <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                            TỈ LỆ :
                        </td>
                        <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                            background-color: #FFFF99">
                            <asp:Label ID="kdy_tl" runat="server" Font-Size="XX-Large" ForeColor="Red" Font-Bold="True">0</asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table cellpadding="0" width="100%" cellspacing="0" style="font-family: Times New Roman;
                    font-size: 15px;" class="table_list_1">
                    <tbody>
                        <tr class="head1" style="height: 17px;">
                            <td class="style5" style="border-right: 1px #FF0000 solid; background-color: #D3D3D3;
                                font-size: 19px; border-bottom: 2px #FF0000	 solid;" colspan="2">
                                CỔ ĐÔNG KHÔNG TÁN THÀNH
                            </td>
                        </tr>
                        <tr class="head1">
                            <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                SỐ LƯỢNG CỔ ĐÔNG
                            </td>
                            <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                background-color: #D3D3D3;">
                                <asp:Label ID="ky_sl0" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red"
                                    Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr class="head1">
                            <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                TỔNG SỐ CỔ PHIẾU :
                            </td>
                            <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                background-color: #D3D3D3;">
                                <asp:Label ID="ky_cp0" runat="server" Font-Size="XX-Large" ForeColor="Red" Text="0"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr class="head1">
                            <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                TỈ LỆ :
                            </td>
                            <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                background-color: #D3D3D3;">
                                <asp:Label ID="ky_tl0" runat="server" Font-Size="XX-Large" ForeColor="Red" Text="0"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td>
                <table cellpadding="0" width="100%" cellspacing="0" style="font-family: Times New Roman;
                    font-size: 15px;" class="table_list_1">
                    <tbody>
                        <tr class="head1" style="height: 17px;">
                            <td class="style5" style="border-right: 1px #FF0000 solid; background-color: #D3D3D3;
                                font-size: 19px; border-bottom: 2px #FF0000	 solid;" colspan="2">
                                CỔ ĐÔNG KHÔNG HỢP LỆ
                            </td>
                        </tr>
                        <tr class="head1">
                            <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                SỐ LƯỢNG CỔ ĐÔNG
                            </td>
                            <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                background-color: #D3D3D3;">
                                <asp:Label ID="khl_sl" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red"
                                    Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr class="head1">
                            <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                TỔNG SỐ CỔ PHIẾU :
                            </td>
                            <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                background-color: #D3D3D3;">
                                <asp:Label ID="khl_cp" runat="server" Font-Size="XX-Large" ForeColor="Red" Text="0"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr class="head1">
                            <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                TỈ LỆ :
                            </td>
                            <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                background-color: #D3D3D3;">
                                <asp:Label ID="khl_tyle" runat="server" Font-Size="XX-Large" ForeColor="Red" Text="0"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td style="width: 250px;">
                <table cellpadding="0" width="100%" cellspacing="0" style="font-family: Times New Roman;
                    font-size: 15px;" class="table_list_1">
                    <tbody>
                        <tr class="head1" style="height: 17px;">
                            <td class="style5" style="border-right: 1px #FF0000 solid; background-color: #CCFFFF;
                                font-size: 22px; border-bottom: 2px #FF0000	 solid;" colspan="2">
                                <center> CỔ ĐÔNG KHÔNG BỎ PHIẾU</center>
                            </td>
                        </tr>
                        <tr class="head1">
                            <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                SỐ LƯỢNG CỔ ĐÔNG
                            </td>
                            <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                background-color: #CCFFFF;">
                                <asp:Label ID="dy_sl" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red"
                                    Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr class="head1">
                            <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                TỔNG SỐ CỔ PHIẾU :
                            </td>
                            <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                background-color: #CCFFFF;">
                                <asp:Label ID="dy_cp" runat="server" Font-Size="XX-Large" ForeColor="Red" Text="0"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr class="head1">
                            <td class="style20" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                TỈ LỆ :
                            </td>
                            <td class="style21" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                background-color: #CCFFFF;">
                                <asp:Label ID="dy_tl" runat="server" Font-Size="XX-Large" ForeColor="Red" Text="0"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:GridView ID="G_KDY" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="1000"
                    Style="margin-right: 0px" Width="99%" OnRowCommand="G_KDY_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("STT") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("STT") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STTCD" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("STTCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("STTCD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MÃ CỔ ĐÔNG" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("MACD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("MACD") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TÊN CỔ ĐÔNG">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("TENCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("TENCD") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TỔNG CỘNG">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("TONGCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbCPTC0" runat="server" Text='<%# Bind("TONGCD","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <HeaderTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center">
                                            TỔNG CỘNG
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:Label ID="TongCong0" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label16" runat="server" Text='<%# String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",Eval("TONGCD")) %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="TRONGAI" runat="server" CommandArgument='<%# Bind("ID") %>' CommandName="TRONGAI"
                                    ForeColor="Blue" OnClientClick="if(confirm('Bạn có muốn xóa ?') == false)return false;">Xóa</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
            </td>
            <td valign="top">
                <asp:GridView ID="G_KYK" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="1000"
                    Style="margin-right: 0px" Width="100%" OnRowCommand="G_KYK_RowCommand" ForeColor="Black"
                    GridLines="Horizontal">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("STT") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%# Bind("STT") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STTCD" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("STTCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label18" runat="server" Text='<%# Bind("STTCD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MÃ CỔ ĐÔNG" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("MACD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label19" runat="server" Text='<%# Bind("MACD") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TÊN CỔ ĐÔNG">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("TENCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label20" runat="server" Text='<%# Bind("TENCD") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TỔNG CỘNG">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("TONGCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbCPTC1" runat="server" Text='<%# Bind("TONGCD","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <HeaderTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center">
                                            TỔNG CỘNG
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:Label ID="TongCong1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",Eval("TONGCD")) %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="TRONGAI0" runat="server" CommandArgument='<%# Bind("ID") %>'
                                    CommandName="TRONGAI" ForeColor="Blue" OnClientClick="if(confirm('Bạn có muốn xóa ?') == false)return false;">Xóa</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="DarkBlue" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </td>
             <td valign="top">
                <asp:GridView ID="G_KHL" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="1000"
                    Style="margin-right: 0px" Width="100%" OnRowCommand="G_KHL_RowCommand" ForeColor="Black"
                    GridLines="Horizontal">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("STT") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%# Bind("STT") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STTCD" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("STTCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label18" runat="server" Text='<%# Bind("STTCD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MÃ CỔ ĐÔNG" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("MACD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label19" runat="server" Text='<%# Bind("MACD") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TÊN CỔ ĐÔNG">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("TENCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label20" runat="server" Text='<%# Bind("TENCD") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TỔNG CỘNG">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("TONGCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbCPTC1" runat="server" Text='<%# Bind("TONGCD","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <HeaderTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center">
                                            TỔNG CỘNG
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:Label ID="TongCong1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",Eval("TONGCD")) %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="TRONGAI0" runat="server" CommandArgument='<%# Bind("ID") %>'
                                    CommandName="TRONGAI" ForeColor="Blue" OnClientClick="if(confirm('Bạn có muốn xóa ?') == false)return false;">Xóa</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </td>
            <td valign="top" class="style2">
                <asp:GridView ID="G_DY" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" PageSize="1000"
                    Style="margin-right: 0px" Width="100%" Height="161px">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("STT") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("STT") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STTCD" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("STTCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("STTCD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MÃ CỔ ĐÔNG" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("MACD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("MACD") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TÊN CỔ ĐÔNG">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("TENCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("TENCD") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" Width="250px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TỔNG CỘNG">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("TONGCD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbCPTC" runat="server" Text='<%# Bind("TONGCD","{0:0,0}") %>'></asp:Label>
                            </FooterTemplate>
                            <HeaderTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center">
                                            TỔNG CỘNG
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:Label ID="TongCong" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",Eval("TONGCD")) %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120px" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
