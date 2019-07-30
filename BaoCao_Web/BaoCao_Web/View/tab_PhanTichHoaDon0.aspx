<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="tab_PhanTichHoaDon0.aspx.cs" Inherits="BaoCao_Web.View.tab_PhanTichHoaDon0" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="BaoCao_Web.Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script type="text/javascript" src="https://www.google.com/jsapi"></script><!-- linechart "corechart",-->
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["linechart" ] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
        
            var data = google.visualization.arrayToDataTable(
         <%=Session["hoadon"] %>
        );

                var options = {
                 width: 730,
                 height: 430,
                 title: '',
                 hAxis: {title: 'Kỳ', titleTextStyle: {color: 'red'}}
        };

        var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
        chart.draw(data, options);
        }
    </script>

    <style type="text/css">
        .style24
        {
            width: 84px;
        }
        .style25
        {
            width: 65px;
        }
        .style26
        {
            width: 78px;
        }
        .style27
        {
            width: 65px;
            height: 35px;
        }
        .style28
        {
            height: 35px;
        }
        .style29
        {
            width: 78px;
            height: 35px;
        }
        .style31
        {
            height: 28px;
        }
        .style32
        {
            height: 265px;
        }
        .style33
        {
            width: 115px;
        }
        .style59
        {
            height: 28px;
            border-left: 1px #99cc99 solid;
            border-right: 1px #99cc99 solid;
            text-align: center;
            width: 115px;
        }
        .style62
        {
            width: 110px;
        }
        .style63
        {
            height: 28px;
            border-left: 1px #99cc99 solid;
            border-right: 1px #99cc99 solid;
            text-align: center;
            width: 110px;
        }
        .style67
        {
            height: 28px;
            border-left: 1px #99cc99 solid;
            border-right: 1px #99cc99 solid;
            text-align: center;
        }
        .style68
        {
            width: 126px;
        }
        .style69
        {
            height: 28px;
            border-left: 1px #99cc99 solid;
            border-right: 1px #99cc99 solid;
            text-align: center;
            width: 126px;
        }
        
        .style676
        {
            border-left: 1px #99cc99 solid;
            border-right: 1px #99cc99 solid;
            border-top: 1px #99cc99 solid;
            border-bottom: 1px #99cc99 solid;
            text-align: left;
            vertical-align:middle;
            height: 25px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script language="javascript" type="text/javascript">
           window.document.getElementById("HOME").className = "top_link";
           window.document.getElementById("DHN").className = "current_link";
           window.document.getElementById("HSKH").className = "top_link";
           window.document.getElementById("BDBC").className = "top_link";
    </script>
   <div class="Pages_content">

<div class="title_page"><asp:Label ID="title" runat="server" Text="PHÂN TÍCH HÓA ĐƠN = 0M<sup>3</sup>   "></asp:Label></div>
 <asp:Panel ID="Panel1" runat="server" Height="94%" ScrollBars="Both" >  
       <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1"  />     
 <div class="block block_left events" style="width: 100%;">
 	
	<div class="block_content" >
        <table style="font-size:14px; font-family: Times New Roman;">
            <tr>
                <td   class="style24"></td>
                <td class="style25" >Kỳ Đọc Số</td>
                <td > </td>
                <td class="style26" >Kỳ Đọc Số</td>
                <td ></td>
                
            </tr>
            <tr>
            <td ><asp:Label ID="Label7" runat="server" 
                        Text="SO SÁNH" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                <td class="style27" >
                    <asp:TextBox ID="tungay" runat="server" autocomplete="off" Width="75px" />
                </td>
                <td class="style28" >
                    <asp:DropDownList ID="sosanh" runat="server">
                        <asp:ListItem Value="and">Và</asp:ListItem>
                        <asp:ListItem Value="To">Đến</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style29">
                    <asp:TextBox ID="denngay" runat="server" autocomplete="off" Width="84px" />
                </td>
                <td class="style28">
                    &nbsp;<asp:Button ID="btXemBangKe" runat="server" CssClass="button" 
                        onclick="btXemBangKe_Click" Text="XEM THÔNG TIN" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="5"  style="border-top: 2px #99cc99 solid;"></td>
            </tr>
             <tr>
                 <td colspan="5" class="style32" valign="top" >

                <asp:Panel ID="panelAnd" runat="server" Width="780px" Visible="false"><% 
                       DataTable table = new DataTable();
                       if (Session["PHANTICH"] != null)
                       {
                           table = (DataTable)Session["PHANTICH"];
                           %><table cellpadding="0" cellspacing="0"  style="font-family:Times New Roman; font-size:15px; width: 100%;" 
                                class="table_list" >
                              <tbody>   
                                  <tr class="head" >                    
                                     <td  colspan="2" class="style31" >
                                         TỔNG HĐ 0m<sup>3</sup></td>                 
                                     <td  rowspan="2" >
                                         TĂNG GIẢM</td>
                 
                                 <td rowspan="2" class="style33">HĐ 0m<sup>3 </sup><br />2 KỲ</td>
                                      <td class="style3" rowspan="2">
                                          TỔNG HĐ<br /> SỬ DỤNG LẠI </td>
                                    <td rowspan="2" class="style2"  >
                                        TỔNG HĐ<br />
                                        PHÁT SINH </td>
                                </tr>
                                  <tr class="head" >
                                     <td class="style62"   >
                                         <%=table.Columns[0].ColumnName%></td>
                                     <td class="style68"  >
                                        <%=table.Columns[1].ColumnName%></td>
                                </tr>
                                <tr >
                                <td  class="style63" ><b><a  href="Print.aspx?page=TK" ><%=Format.NumberFormat(table.Rows[0][0])%></a></b>
                               
                               </td>
                                <td  class="style69" ><b><a  href="Print.aspx?page=DK" ><%=Format.NumberFormat(table.Rows[0][1])%></a></b>
                                </td>
                                <td  class="style67" ><b><a  href="#"><%=Format.NumberFormat(table.Rows[0]["TĂNG GIẢM"])%></a></b></td>
                                <td  class="style59" ><b><a  href="Print.aspx?page=2K" ><%=Format.NumberFormat(table.Rows[0]["=0 2 KỲ"])%></a></b></td>
                                <td  class="style67" ><b><a  href="Print.aspx?page=DL" ><%=Format.NumberFormat(table.Rows[0]["SỬ DỤNG LẠI"])%></a></b><br />
                                   <b> SẢN LƯỢNG: <%=Format.NumberFormat(table.Rows[0]["SANLUONG"])%> m<sup>3 </sup></b></td>
                                <td  class="style67" ><b><a  href="Print.aspx?page=PS" ><%=Format.NumberFormat(table.Rows[0]["PHÁT SINH"])%></a></b><br />
                                  <b><%=Format.NumberFormat(table.Rows[0]["SANLUONGGIAM"])%> m<sup>3 </sup></b>
                                </td>
                                </tr>
                                <tr >
                                    <td class="style676" colspan="6"><h3>PHÂN TÍCH THEO MÃ CODE</h3></td>
                                </tr>
                                 <tr >
                                <td  class="style63" valign="top" align="center">
                                    <asp:GridView ID="Gtuky" runat="server" AutoGenerateColumns="False" 
                                        Width="110px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" 
                                        BorderWidth="1px" CellPadding="4">
                                        <Columns>
                                            <asp:BoundField DataField="CODE" HeaderText="CODE">
                                            <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                                <td  class="style69" valign="top" align="center">
                                    <asp:GridView ID="Gdenky" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="4" Width="110px">
                                        <Columns>
                                            <asp:BoundField DataField="CODE" HeaderText="CODE">
                                            <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                                <td  class="style67">
                                    <asp:GridView ID="GridView2" runat="server">
                                    </asp:GridView>
                                     </td>
                                <td  class="style59" valign="top" align="center">
                                    <asp:GridView ID="Ghd02" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="4" Width="103px">
                                        <Columns>
                                            <asp:BoundField DataField="CODE" HeaderText="CODE">
                                            <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                                <td  class="style67" valign="top" align="center">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="4" Width="120px">
                                        <Columns>
                                            <asp:BoundField DataField="CODE" HeaderText="CODE">
                                            <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                                <td  class="style67" valign="top" align="center">
                                    <asp:GridView ID="Gphatsinh" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="4" Width="90px">
                                        <Columns>
                                            <asp:BoundField DataField="CODE" HeaderText="CODE">
                                            <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                                </tr>
                                <tr >
                                    <td class="style676" colspan="6"><h3>PHÂN TÍCH THEO ĐỐI TƯỢNG SỬ DỤNG NƯỚC</h3></td>
                                </tr>
                                 <tr >
                                <td  class="style63" valign="top" align="center">
                                    <asp:GridView ID="Gdoituongtu1" runat="server" AutoGenerateColumns="False" 
                                        Width="110px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                                        BorderWidth="1px" CellPadding="3">
                                        <Columns>
                                            <asp:BoundField DataField="GIABIEU" HeaderText="GB">
                                            <ItemStyle Width="90px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                                <td  class="style69" valign="top" align="center">
                                    <asp:GridView ID="Gdoituongden" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="110px">
                                        <Columns>
                                            <asp:BoundField DataField="GIABIEU" HeaderText="GB">
                                            <ItemStyle Width="90px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                                <td  class="style67"></td>
                                <td  class="style59" valign="top" align="center">
                                    <asp:GridView ID="Gdoituong2ky" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="110px">
                                        <Columns>
                                            <asp:BoundField DataField="GIABIEU" HeaderText="GB">
                                            <ItemStyle Width="90px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                                <td  class="style67"  valign="top" align="center">
                                <asp:GridView ID="SanLuongDT" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="165px">
                                        <Columns>
                                            <asp:BoundField DataField="GIABIEU" HeaderText="GB">
                                            <ItemStyle Width="40px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SẢN LƯỢNG">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                
                                </td>
                                <td  class="style67" valign="top" align="center">
                                    <asp:GridView ID="Gdoituongphatsinh" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="110px">
                                        <Columns>
                                            <asp:BoundField DataField="GIABIEU" HeaderText="GB">
                                            <ItemStyle Width="90px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                                    </asp:GridView></td>
                                </tr>

                             <tr >
                                    <td class="style676" colspan="6"><h3>PHÂN TÍCH THEO QUẬN PHƯỜNG <asp:Button ID="inQuanPhuong" runat="server" CssClass="button" OnClick="inQuanPhuong_Click"
                        Text=" IN " /></h3></td>
                             </tr>
                             <tr >
                                <td  class="style63" valign="top" align="center">
                                    <asp:GridView ID="QPTUKY" runat="server" AutoGenerateColumns="False" 
                                        Width="110px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                                        BorderWidth="1px" CellPadding="3">
                                        <Columns>
                                            <asp:BoundField DataField="QP" HeaderText="QP">
                                            <ItemStyle Width="90px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                         <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                     </td>
                                <td  class="style69" valign="top" align="center">
                                    <asp:GridView ID="QPDENKY" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="110px">
                                        <Columns>
                                            <asp:BoundField DataField="QP" HeaderText="QP">
                                            <ItemStyle Width="90px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                     </td>
                                <td  class="style67"></td>
                                <td  class="style59" valign="top" align="center">
                                    <asp:GridView ID="QP02KY" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="110px">
                                        <Columns>
                                            <asp:BoundField DataField="QP" HeaderText="QP">
                                            <ItemStyle Width="90px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                         <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                    </td>
                                <td  class="style67"  valign="top" align="center">
                                <asp:GridView ID="QPSANLUONG" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="165px">
                                        <Columns>
                                            <asp:BoundField DataField="QP" HeaderText="QP">
                                            <ItemStyle Width="40px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SẢN LƯỢNG">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                
                                </td>
                                <td  class="style67" valign="top" align="center">
                                    <asp:GridView ID="QPPHATSINH" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="110px">
                                        <Columns>
                                            <asp:BoundField DataField="QP" HeaderText="QP">
                                            <ItemStyle Width="90px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView></td>
                                </tr>
                             
                             <tr >
                                    <td class="style676" colspan="6"><h3>PHÂN TÍCH THEO NHÂN VIÊN ĐỌC SỐ <asp:Button ID="inNhanVien" runat="server" CssClass="button" OnClick="inNhanVien_Click"
                        Text=" IN " /></h3></td>
                             </tr>
                             <tr class="head" >
                               <td  class="style62" valign="top" align="center" colspan="2"> <%=table.Columns[0].ColumnName%></td>
                               <td  class="style67"></td>
                               <td  class="style68" valign="top" align="center" colspan="2"> <%=table.Columns[1].ColumnName%></td>
                               <td  class="style67"  valign="top" align="center">TĂNG/GIẢM</td>
                               </tr>

                             <tr >
                               <td  class="style62" valign="top" align="center" colspan="2"> 
                                <asp:GridView ID="HDONHANVIENTU" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="MAYDS" HeaderText="MÁY">
                                            <ItemStyle Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FULLNAME" HeaderText="TÊN NV">
                                            <ItemStyle Width="250px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SOLUONG","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SOLUONG","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="30px" />
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
                               <td  class="style67"></td>
                               <td  class="style68" valign="top" align="center" colspan="2">
                                <asp:GridView ID="HDONHANVIENDEN" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="MAYDS" HeaderText="MÁY ĐS">
                                            <ItemStyle Width="90px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FULLNAME" HeaderText="TÊN NV">
                                            <ItemStyle Width="250px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SOLUONG","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SOLUONG","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                               <td  class="style67"  valign="top" align="center">
                               
                               <asp:GridView ID="sosanhnv" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Width="100%">
                                        <Columns>                                           
                                            <asp:TemplateField HeaderText="SL">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SOLUONG","{0:0,0}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SOLUONG","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" />
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
                             </tbody>
                            </table>

                           <%
                              
                       }
                       %>
                </asp:Panel>
             
           <asp:Panel ID="panelTu" runat="server" Width="780px" Visible="false" >     
                  <span style="margin-top: 10px"> <b>  <a  href="Print.aspx?page=TU""><asp:Label ID="lbTongCong" runat="server" 
                          Font-Size="Large"></asp:Label></a></b></span>
   
                    <br />
                   <h3>Biểu Đồ Theo Dõi Hóa Đơn =0 M<sup>3</sup> </h3>
                <div id="chart_div" style="width: 730px; height: 430px;"></div> 

             <h3>PHÂN TÍCH HÓA ĐƠN</h3>              
                   <table>
                    <tr>
                        <td style="vertical-align:top">
                            <asp:GridView ID="GridViewTuCode" runat="server" AutoGenerateColumns="False" 
                                        Width="200px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" 
                                        BorderWidth="1px" CellPadding="4">
                                        <Columns>
                                            <asp:TemplateField HeaderText="MÃ CODE">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CODE") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CODE") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SỐ LƯỢNG">
                                                <ItemTemplate>
                                                  <a  href='<%# Eval("CODE","Print.aspx?page=CODE&ma={0}") %>' ><asp:Label ID="Label1" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label> </a>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
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
                        <td>              </td>
                         <td style="vertical-align:top">
                            <asp:GridView ID="GridViewTuQP" runat="server" AutoGenerateColumns="False" 
                                        Width="200px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                                        BorderWidth="1px" CellPadding="3">
                                        <Columns>
                                            <asp:TemplateField HeaderText="MÃ QP">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("QP") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("QP") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SỐ LƯỢNG">
                                                <ItemTemplate>
                                                <a  href='<%# Eval("QP","Print.aspx?page=QP&ma={0}") %>' >      <asp:Label ID="Label1" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:Label></a>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SL","{0:0,0}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
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
                             
                  </asp:Panel>

             
                 </td>
            </tr>
       <tr>
            <td colspan="5">
            <br />
            </td>
       </tr>
        </table>
    </div>
 </div>
</asp:Panel>
       <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="rpt_DongHoHieuCu.rpt">
        </Report>
       </CR:CrystalReportSource>
</asp:Content>
