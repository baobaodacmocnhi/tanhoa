<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="pDanhSachCoDong.aspx.cs" Inherits="DHCD_KiemPhieu.View.pDanhSachCoDong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
     window.document.getElementById("HOME").className = "top_link";
     window.document.getElementById("CODONG").className = "current_link";
     window.document.getElementById("KIEMPHIEU").className = "top_link";
     window.document.getElementById("BIEUQUYET").className = "top_link";
     window.document.getElementById("BAUCU").className = "top_link"; 
    </script>
     <div class="title_page" style=" margin-top:10px; height: 26px; text-align:center;"><asp:Label ID="title" runat="server" 
        Text="..: DANH SÁCH CỔ ĐÔNG CÔNG TY CỔ PHẦN CẤP NƯỚC TÂN HÒA :.."></asp:Label>
    </div>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowcommand="GridView1_RowCommand" PageSize="1000" style="margin-right: 0px" 
        Width="100%" onrowediting="GridView1_RowEditing" 
    onrowupdating="GridView1_RowUpdating" onrowdatabound="GridView1_RowDataBound" 
        ShowFooter="True">
        <Columns>
            <asp:TemplateField HeaderText="STT">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("STT") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("STT") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="STTCD" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("STTCD") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("STTCD") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MÃ CỔ ĐÔNG">
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
                <ItemStyle VerticalAlign="Middle" Width="300px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SỔ DKSH">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("CMND") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("CMND") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NGÀY CẤP" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("NGAYCAP") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" 
                        Text='<%# Bind("NGAYCAP", "DD/MM/YYYY") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NƠI CẤP" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NOICAP") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("NOICAP") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ĐỊA CHỈ" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("DIACHI") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("DIACHI") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Middle" Width="270px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CP GIAO DỊCH" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("CDGD") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbCPGD" runat="server" Text='<%# Bind("CDGD","{0:0,0}") %>'></asp:Label>
                </FooterTemplate>
                <HeaderTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: center">
                                CP GIAO DỊCH</td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="TongCPGD" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("CDGD","{0:0,0}") %>'></asp:Label>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CP PHONG TỎA" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("PHONGTOA") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbCPPT" runat="server" Text='<%# Bind("PHONGTOA","{0:0,0}") %>'></asp:Label>
                </FooterTemplate>
                <HeaderTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: center">
                                CP PHONG TỎA</td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="TongCPPT" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("PHONGTOA","{0:0,0}")%>'></asp:Label>  
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TỔNG CỘNG">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("TONGCD") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbCPTC" runat="server" Text='<%# String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Eval("TONGCD")) %>'></asp:Label>
                </FooterTemplate>
                <HeaderTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: center">
                                TỔNG CỘNG</td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="TongCong" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Eval("TONGCD")) %>'></asp:Label>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100px" />
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
    <br />
    <br />
    <br />
    <br />
    </asp:Content>
