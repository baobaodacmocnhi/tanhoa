<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tab_BieuDoDoanhThu.ascx.cs" Inherits="BaoCao_Web.View.tabBieuDo.tab_BieuDoDoanhThu" %>
<html>
  <head>
      <link href="../../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script><!-- linechart "corechart",-->
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["linechart" ] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
        
            var data = google.visualization.arrayToDataTable([
         <%=Session["sanluong"] %>
        ]);

            var options = {                
                 width: 930,
                 height: 430
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>
  </head>
  <body>
  <table border="0" cellpadding="0" cellspacing="0" 
          style="height: 37px;">
 
    <tr><td> <asp:RadioButtonList ID="RadioButtonList1" 
          runat="server" Font-Bold="True" RepeatDirection="Horizontal" 
            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
      <asp:ListItem Selected="True">Theo Năm</asp:ListItem>
      <asp:ListItem>So Sánh Các Năm</asp:ListItem>
      </asp:RadioButtonList></td><td><asp:Panel ID="Panel1" runat="server">
          <asp:TextBox ID="cacnam" runat="server"></asp:TextBox>&nbsp;<asp:Button 
                ID="Button1" runat="server"
              Text="Xem" CssClass="button" onclick="Button1_Click" />
      </asp:Panel></td></tr>
  </table>
      
<div id="chart_div" style="width: 930px; height: 430px;"></div>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
          BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
          CellPadding="4" ShowFooter="True" Width="928px">
          <Columns>
              <asp:BoundField DataField="NAM" HeaderText="NĂM">
              <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="KỲ 01">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("THANG01","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("THANG01","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                   <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 02">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("THANG02","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("THANG02","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 03">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("THANG03","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label4" runat="server" Text='<%# Bind("THANG03","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 04">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("THANG04","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label5" runat="server" Text='<%# Bind("THANG04","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 05">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("THANG05","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  <ItemTemplate>
                      <asp:Label ID="Label6" runat="server" Text='<%# Bind("THANG05","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 06">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("THANG06","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label7" runat="server" Text='<%# Bind("THANG06","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 07">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("THANG07","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label8" runat="server" Text='<%# Bind("THANG07","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 08">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("THANG08","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label9" runat="server" Text='<%# Bind("THANG08","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 09">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("THANG09","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label10" runat="server" Text='<%# Bind("THANG09","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 10">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("THANG10","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label11" runat="server" Text='<%# Bind("THANG10","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 11">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("THANG11","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label12" runat="server" Text='<%# Bind("THANG11","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="KỲ 12">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("THANG12","{0:0,0}") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("THANG12","{0:0,0}") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
  </body>
</html>