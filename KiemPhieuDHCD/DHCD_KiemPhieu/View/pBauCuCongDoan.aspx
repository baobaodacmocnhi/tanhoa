<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true"
    CodeBehind="pBauCuCongDoan.aspx.cs" Inherits="DHCD_KiemPhieu.View.pBauCuCongDoan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Focus(object) {
            object.value = "";
        }

    </script>
    <style type="text/css">
        .style1
        {
            height: 38px;
        }
        .style2
        {
            width: 310px;
        }
        .style3
        {
            width: 203px;
        }
        .style4
        {
            width: 68px;
        }
        .style5
        {
            width: 903px;
        }
        .style6
        {
            width: 184px;
        }
        .style7
        {
            width: 429px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        window.document.getElementById("HOME").className = "top_link";
        // window.document.getElementById("CODONG").className = "top_link";
        /// window.document.getElementById("KIEMPHIEU").className = "top_link";
        window.document.getElementById("BIEUQUYET").className = "current_link";
        // window.document.getElementById("BAUCU").className = "top_link"; 
    </script>
    <div class="title_page" style="margin-top: 10px; height: 26px; text-align: center;">
        <asp:Label ID="title" runat="server" Text="..: KIỂM PHIẾU BẦU CỬ  :.."></asp:Label>
    </div>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
    <br />
    <table cellpadding="0" cellspacing="0" style="font-family: Times New Roman; font-size: 15px;
        margin-left: 20px;" class="table_list">
        <tbody>
            <tr class="head1">
                <td class="style11" style="border-right: 0px #99cc99 solid; border-bottom: 1px solid;">
                    &nbsp;&nbsp;&nbsp;&nbsp; BẦU CỬ LẦN :
                </td>
                <td class="style11" style="border-right: 2px #99cc99 solid; border-bottom: 1px solid;">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="58px" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                </td>
                <td class="style10" style="border-right: 0px #99cc99 solid; border-bottom: 1px solid;">
                    &nbsp;&nbsp;&nbsp; NGÀY&nbsp;:
                </td>
                <td class="style10" style="border-right: 2px #99cc99 solid; font-size: 10px; font-weight: normal;
                    border-bottom: 1px solid;">
                    <asp:TextBox ID="tungay" runat="server" autocomplete="off" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tungay"
                        Format="dd/MM/yyyy">
                    </ajaxToolkit:CalendarExtender>
                </td>
            </tr>
            <tr class="head1">
                <td class="style11" style="border-right: 2px #99cc99 solid; border-bottom: 1px solid;"
                    colspan="4">
                    <asp:CheckBox ID="an" runat="server" AutoPostBack="True" OnCheckedChanged="an_CheckedChanged" />
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td class="style5">
                <asp:Panel ID="Panel1" runat="server">
                    <table cellpadding="0" cellspacing="0" class="table_list_1" style="font-family: Times New Roman;
                        margin-left: 50px; font-size: 15px; width: 500px;">
                        <tr class="head1">
                            <td class="style21" style="border-right: 1px #FF0000 solid; height: 40px; background-color: #CCFFFF;
                                font-size: large; border-bottom: 2px #FF0000 solid">
                                <center>
                                    DANH SÁCH ỨNG CỬ
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: 1px #FF0000 solid; height: 40px; font-size: large; border-bottom: 2px #FF0000 solid">
                                <asp:CheckBoxList CssClass="checklist" ID="checkName" runat="server" Height="148px"
                                    AutoPostBack="True" Font-Overline="False" Font-Strikeout="False" OnSelectedIndexChanged="checkName_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" align="center">
                                <asp:Button ID="btSubmit" runat="server" Text="Biểu Quyết" Width="103px" CssClass="button1"
                                    Height="28px" OnClick="btSubmit_Click" />
                                <asp:Label ID="err" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDanhSachDaNhap" runat="server" Text="Danh Sách Đã Nhập" OnClick="btnDanhSachDaNhap_Click" />
                                <div style="height: 150px; width: 500px; overflow: scroll;">
                                    <asp:GridView ID="dgvDaBau" runat="server" OnRowDeleting="dgvDaBau_RowDeleting" CellPadding="4"
                                        ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="STT" HeaderText="STT" />
                                            <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" />
                                            <asp:CheckBoxField DataField="KhongHopLe" HeaderText="Không Hợp Lệ" />
                                            <asp:BoundField DataField="SoLuong" HeaderText="Số Lượng" />
                                            <asp:BoundField DataField="ID" HeaderText="ID" />
                                            <asp:CommandField ShowDeleteButton="True" />
                                        </Columns>
                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                        <SortedDescendingHeaderStyle BackColor="#820000" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <br />
            </td>
        </tr>
        <tr>
            <td class="style5">
                <table cellpadding="0" cellspacing="0" class="table_list_1" style="font-family: Times New Roman;
                    font-size: 15px; width: 754px; margin-left: 50px;">
                    <tr class="head1">
                        <td class="style21" style="border-right: 1px #FF0000 solid; height: 40px; background-color: #FFFF99;
                            font-size: x-large; border-bottom: 2px #FF0000 solid; text-align: center;" colspan="3">
                            <asp:Label ID="lbKetqua" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="head1">
                        <td class="style21" style="border-right: 1px #FF0000 solid; height: 40px; font-size: large;
                            border-bottom: 2px #FF0000 solid" colspan="3">
                            <table cellpadding="0" cellspacing="0" class="table_list" style="font-family: Times New Roman;
                                font-size: 15px; margin-left: 20px;">
                                <tr class="head1">
                                    <td class="style26" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                        SỔ PHIẾU THU VÀO :
                                    </td>
                                    <td class="style4" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                        background-color: #FFFF99; text-align: right;">
                                        <asp:Label ID="tc_thuvao" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                    </td>
                                    <td class="style6" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                        background-color: #FFFF99; text-align: right;">
                                        &nbsp;
                                    </td>
                                    <td class="style4" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                        background-color: #FFFF99; text-align: right;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr class="head1">
                                    <td class="style26" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;">
                                        SỐ PHIẾU HỢP LỆ
                                    </td>
                                    <td class="style4" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                        background-color: #FFFF99; text-align: right;">
                                        <asp:Label ID="tc_hople" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                    </td>
                                    <td class="style6" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                        text-align: right;">
                                        SỐ PHIẾU KHÔNG HỢP LỆ
                                    </td>
                                    <td class="style4" style="border-right: 1px #FF0000 solid; border-bottom: 1px solid;
                                        background-color: #FFFF99; text-align: right;">
                                        <asp:Label ID="tc_khople" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                    </td>
                                </tr>
                                <tr class="head1">
                                    <td class="style26" style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;"
                                        colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="head1">
                        <td class="style2" style="border-right: 1px #FF0000 solid; font-size: large; border-bottom-style: none;
                            border-bottom-color: inherit; border-bottom-width: 0px;">
                            &nbsp;
                        </td>
                        <td class="style3" style="border-right: 1px #FF0000 solid; font-size: large; border-bottom-style: none;
                            border-bottom-color: inherit; border-bottom-width: 0px; text-align: center;">
                            ĐỒNG Ý
                        </td>
                        <td class="style21" style="border-right: 1px #FF0000 solid; height: 40px; font-size: large;
                            text-align: center; border-bottom-style: none; border-bottom-color: inherit;
                            border-bottom-width: 0px;">
                            KHÔNG ĐỒNG Ý
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:GridView ID="gTK" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Style="margin-left: 50px;
                    font-family: 'Times New Roman', Times, serif; font-size: large" AllowSorting="True"
                    Width="751px">
                    <Columns>
                        <asp:BoundField DataField="STT" HeaderText="STT">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TENBC" HeaderText="Họ Tên">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Số lượng">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DY") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="lSort" runat="server" ForeColor="White" OnClick="lSort_Click">Số lượng</asp:LinkButton>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("DY") %>' Font-Bold="True" Font-Overline="False"
                                    Font-Size="Large" ForeColor="Red"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tỷ lệ">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TLDY") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("TLDY","{0:0.##}")%>' Font-Bold="True"
                                    Font-Size="Large" ForeColor="Red"></asp:Label>
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="Large"
                                    ForeColor="Red" Text="%"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Số lượng">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("KDY") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("KDY") %>' Font-Bold="True"
                                    Font-Size="Large" ForeColor="Red"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tỷ lệ">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("TLKDY") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("TLKDY","{0:0.##}") %>' Font-Bold="True"
                                    Font-Size="Large" ForeColor="Red"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="Large"
                                    ForeColor="Red" Text="%"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
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
            <td align="left" valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                <table>
                    <tr>
                        <td>
                            <br />
                            <asp:Button ID="btKetQua" runat="server" Text="Kết Quả" Width="103px" CssClass="button1"
                                Height="28px" OnClick="btKetQua_Click" Visible="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownList3" runat="server" Height="24px" Width="58px" AutoPostBack="True"
                                OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            <b><a href="Print.aspx?page=TDT">
                                <asp:Label ID="lbTongCong" Text="IN KẾT QUẢ" runat="server" Font-Size="Large" Style="text-align: left"></asp:Label>
                            </a></b>
                        </td>
                        <td class="style7" style="text-align: right">
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="24px" Width="58px" AutoPostBack="True"
                                OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
