<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="pBieuQuyetDHCD.aspx.cs" Inherits="DHCD_KiemPhieu.View.pBieuQuyetDHCD" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script type="text/javascript">
          function Focus(object) {
              object.value = "";
          }

    </script>

    <style type="text/css">
        .style4
        {
            height: 129px;
            width: 474px;
        }
        .style5
        {
            width: 133px;
        }
        .style6
        {
            height: 40px;
        }
        .style8
        {
            height: 18px;
        }
        .style9
        {
            height: 39px;
            text-align: right;
        }
        .style10
        {
            height: 126px;
        }
        .style11
        {
            height: 125px;
        }
        .style12
        {
        }
        .style21
        {
            height: 44px;
        }
        .style22
        {
            width: 552px;
        }
        .style23
        {
            width: 54px;
            }
        .style24
        {
            width: 85px;
        }
        .style26
        {
            width: 239px;
        }
        .style27
        {
            width: 92px;
        }
        .style28
        {
            width: 474px;
        }
        .style30
        {
        }
        .style31
        {
            width: 54px;
        }
        </style>
     

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
        window.document.getElementById("HOME").className = "top_link";
     window.document.getElementById("CODONG").className = "top_link";
     window.document.getElementById("KIEMPHIEU").className = "top_link";
     window.document.getElementById("BIEUQUYET").className = "current_link";
     window.document.getElementById("BAUCU").className = "top_link"; 
    </script>

     <div class="title_page" style=" margin-top:10px; height: 26px; text-align:center;">
         <asp:Label ID="title" runat="server" 
        Text="..: BIỀU QUYẾT CỔ ĐÔNG CÔNG TY CỔ PHẦN CẤP NƯỚC TÂN HÒA :.."></asp:Label>
    </div>
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1"  />
  <table style="width:95%; margin-left:20px; " border="0">
        <tr>
            <td class="style28" rowspan="2"  valign=top>
       <table cellpadding="0" cellspacing="0" style="font-family:Times New Roman; font-size:15px; margin-left:20px;" class="table_list" >
        <tbody>
           <tr class="head1">
               <td class="style11" style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                                            &nbsp;BIỂU QUYẾT LẦN : </td>
               <td class="style11" style="border-right:2px #99cc99 solid; border-bottom: 1px solid;">
                                            <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="43px" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                                <asp:ListItem>----</asp:ListItem>
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
                <td class="style10" style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                                            &nbsp;&nbsp;&nbsp; NGÀY&nbsp;: </td>
                <td class="style5" 
                   style="border-right:2px #99cc99 solid; font-size:10px; font-weight:normal;   border-bottom: 1px solid;">
                                            <asp:TextBox ID="tungay"  runat="server" autocomplete="off" />
                              <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tungay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>              
               </td>
             </tr>
           <tr class="head1">
               <td class="style6" 
                   style="border-right:2px #99cc99 solid; border-bottom: 1px solid; height:3px;" 
                   colspan="4">
                                            <br />
               </td>
             </tr>
           <tr class="head1">
               <td class="style11" 
                   style="border-right:2px #99cc99 solid;background-color:Lavender; border-bottom: 1px solid;" colspan="3">
                                            MÃ CỔ ĐÔNG </td>
                <td class="style5" 
                   style="border-right:2px #99cc99 solid; background-color:Lavender; border-bottom: 1px solid;">
                                            <asp:TextBox ID="txtCoDong" runat="server" AutoPostBack="True" 
                                              onfocus="Focus(this)"    ontextchanged="txtCoDong_TextChanged"></asp:TextBox>
               </td>
             </tr>
          </tbody>
    </table>
                
                <asp:DetailsView ID="dtThongTinCD" CssClass=g2 runat="server" AutoGenerateRows="False" 
                    CellPadding="4" HeaderText="THÔNG TIN CỔ ĐÔNG" Height="150px" Width="84%" 
                    ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
                    <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
                    <Fields>
                        <asp:BoundField DataField="MACD" HeaderText="Mã Cổ Đông">
                        <HeaderStyle Width="90px" />
                        <ItemStyle VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TENCD" HeaderText="Tên Cổ Đông">
                        <ItemStyle VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TONGCD" DataFormatString="{0:0,0}" 
                            HeaderText="Số Cổ Phiếu">
                        <ItemStyle VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Fields>
                    <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" 
                        Width="30px" Font-Size="Large" HorizontalAlign="Center" 
                        VerticalAlign="Middle" />
                    <PagerStyle ForeColor="#333333" HorizontalAlign="Center" BackColor="#FFCC66" />
                    <RowStyle ForeColor="#333333" BackColor="#FFFBD6" />
                </asp:DetailsView>
                
    </td>
            <td class="style12">
                <table cellpadding="0" cellspacing="0" class="table_list_2" 
                    style="font-family:Times New Roman; font-size:15px; width: 538px;">
                    <tr class="head">
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            1.<br />
&nbsp; </td>
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            Thông qua Báo cáo hoạt động của Hội đồng quản trị năm 2015 và kế hoạch hoạt động 
                            năm 2016</td>
                    </tr>
                    <tr class="head1">
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid; margin-bottom:10px;">
                            &nbsp;</td>
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid; margin-bottom:10px;">
                            <asp:RadioButtonList ID="r1" runat="server" Height="16px" 
                                RepeatDirection="Horizontal" Width="501px">
                                <asp:ListItem Value="1">Đồng  ý</asp:ListItem>
                                <asp:ListItem Value="2">Không đồng ý</asp:ListItem>
                                <asp:ListItem Value="3">Không có ý kiến</asp:ListItem>
                                <asp:ListItem Value="4">Không hợp lệ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr class="head">
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            2.<br />
                            <br />
                        </td>
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            Thông qua Báo cáo hoạt động của Ban kiểm soát Công ty CP Cấp nước Tân Hòa năm 
                            2015</td>
                    </tr>
                    <tr class="head1">
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            &nbsp;</td>
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            <asp:RadioButtonList ID="r2" runat="server" RepeatDirection="Horizontal" 
                                Width="496px" Height="14px">
                                <asp:ListItem Value="1">Đồng  ý</asp:ListItem>
                                <asp:ListItem Value="2">Không đồng ý</asp:ListItem>
                                <asp:ListItem Value="3">Không có ý kiến</asp:ListItem>
                                <asp:ListItem Value="4">Không hợp lệ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr class="head">
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            3.<br />
                            <br />
                        </td>
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            Thông qua Báo cáo tổng kết hoạt động sản xuất kinh doanh năm 2015 và Phương 
                            hướng hoạt động sản xuất kinh doanh năm 2016</td>
                    </tr>
                    <tr class="head1">
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            &nbsp;</td>
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            <asp:RadioButtonList ID="r3" runat="server" RepeatDirection="Horizontal" 
                                Width="495px">
                                <asp:ListItem Value="1">Đồng  ý</asp:ListItem>
                                <asp:ListItem Value="2">Không đồng ý</asp:ListItem>
                                <asp:ListItem Value="3">Không có ý kiến</asp:ListItem>
                                <asp:ListItem Value="4">Không hợp lệ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

                         <tr class="head">
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            4.<br />
                            <br />
                        </td>
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            Thông qua Báo cáo tài chính tóm tắt năm 2015 (đã kiểm toán) và Kế hoạch tài 
                            chính năm 2016</td>
                    </tr>
                    <tr class="head1">
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            &nbsp;</td>
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            <asp:RadioButtonList ID="r4" runat="server" RepeatDirection="Horizontal" 
                                Width="495px" Height="14px">
                                <asp:ListItem Value="1">Đồng  ý</asp:ListItem>
                                <asp:ListItem Value="2">Không đồng ý</asp:ListItem>
                                <asp:ListItem Value="3">Không có ý kiến</asp:ListItem>
                                <asp:ListItem Value="4">Không hợp lệ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

     <tr class="head">
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            5.<br />
                            <br />
                        </td>
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            Thông qua Tờ trình sửa đổi, bổ sung Điều lệ Công ty theo Luật doanh nghiệp năm 
                            2014</td>
                    </tr>
                    <tr class="head1">
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            &nbsp;</td>
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            <asp:RadioButtonList ID="r5" runat="server" RepeatDirection="Horizontal" 
                                Width="499px" Height="16px">
                                <asp:ListItem Value="1">Đồng  ý</asp:ListItem>
                                <asp:ListItem Value="2">Không đồng ý</asp:ListItem>
                                <asp:ListItem Value="3">Không có ý kiến</asp:ListItem>
                                <asp:ListItem Value="4">Không hợp lệ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

     <tr class="head">
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            6.<br />
                        </td>
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            Thông qua Ủy quyền cho HĐQT lựa chọn đơn vị kiểm toán năm 2016</td>
                    </tr>
                    <tr class="head1">
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            &nbsp;</td>
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            <asp:RadioButtonList ID="r6" runat="server" RepeatDirection="Horizontal" 
                                Width="494px" Height="16px">
                                <asp:ListItem Value="1">Đồng  ý</asp:ListItem>
                                <asp:ListItem Value="2">Không đồng ý</asp:ListItem>
                                <asp:ListItem Value="3">Không có ý kiến</asp:ListItem>
                                <asp:ListItem Value="4">Không hợp lệ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

     <tr class="head">
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            7.<br />
                            <br />
                        </td>
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            Thông qua Tờ trình phương án phân phối lợi nhuận, trích lập các quỹ và chi cổ 
                            tức năm 2015</td>
                    </tr>
                    <tr class="head1">
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            &nbsp;</td>
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            <asp:RadioButtonList ID="r7" runat="server" RepeatDirection="Horizontal" 
                                Width="503px" Height="14px">
                                <asp:ListItem Value="1">Đồng  ý</asp:ListItem>
                                <asp:ListItem Value="2">Không đồng ý</asp:ListItem>
                                <asp:ListItem Value="3">Không có ý kiến</asp:ListItem>
                                <asp:ListItem Value="4">Không hợp lệ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

     <tr class="head">
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            8.<br />
                            <br />
                        </td>
                        <td class="style8" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            Thông qua Báo cáo&nbsp; thù lao của HĐQT, BKS, Thư ký năm 2015 và Kế hoạch thù 
                            lao HĐQT, BKS, Thư ký năm 2015</td>
                    </tr>
                    <tr class="head1">
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            &nbsp;</td>
                        <td class="style11" 
                            style="border-right:0px #99cc99 solid; border-bottom: 1px solid;">
                            <asp:RadioButtonList ID="r8" runat="server" RepeatDirection="Horizontal" 
                                Width="498px" Height="14px">
                                <asp:ListItem Value="1">Đồng  ý</asp:ListItem>
                                <asp:ListItem Value="2">Không đồng ý</asp:ListItem>
                                <asp:ListItem Value="3">Không có ý kiến</asp:ListItem>
                                <asp:ListItem Value="4">Không hợp lệ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>


               
                </table>
            </td>
        </tr>
        
        <tr>
            <td class="style9" style="text-align:left;" >
                <asp:Button ID="btSubmit" runat="server"  Text="Biểu Quyết" Width="103px" 
                     CssClass="button1" Height="28px" onclick="btSubmit_Click"/>
                <br />
                <br />
                <br />
            </td>
        </tr>
        
        <tr>
            <td class="style9" colspan="2" >
               <table cellpadding="0" cellspacing="0" 
    class="table_list_1" 
    style="font-family:Times New Roman; font-size:15px; width: 1011px;">
                            <tr class="head1">
                                <td class="style21" 
            
                                    
                                    
                                    style="border-right:1px #FF0000 solid; height:40px;  background-color:#CCFFFF; font-size:large; border-bottom: 2px #FF0000 solid ">
                                    <center>
                                        KẾT QUẢ BIỂU QUYẾT CỔ ĐÔNG CÔNG TY CỔ PHẨN CẤP NƯỚC TÂN HÒA
                                    </center>
                                </td>
                            </tr>
                            <tr class="head1">
                                <td class="style21" 
            
                                    
                                    
                                    style="border-right:1px #FF0000 solid; height:40px;font-size:large; border-bottom: 2px #FF0000 solid ">
                                    <table cellpadding="0" cellspacing="0" class="table_list" 
                                        style="font-family:Times New Roman; font-size:15px; margin-left:20px;">
                                        <tr class="head1">
                                            <td class="style26" 
                                                style="border-right:2px #FF0000 solid; border-bottom: 1px solid; ">
                                                SỐ LƯỢNG CỔ ĐÔNG THAM DỰ :</td>
                                            <td class="style27" 
                                                style="border-right:1px #FF0000 solid; border-bottom: 1px solid;background-color:#FFFF99; text-align:right;">
                                                <asp:Label ID="tc_td" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="head1">
                                            <td class="style26" 
                                                style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                                SỐ CỔ PHIẾU CỔ ĐÔNG THAM DỰ:</td>
                                            <td class="style27" 
                                                style="border-right:1px #FF0000 solid; border-bottom: 1px solid;background-color:#FFFF99; text-align:right;">
                                                <asp:Label ID="tc_cophieu" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="head1">
                                            <td class="style26" 
                                                style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                                SỐ THẺ BIỂU QUYẾT PHÁT RA :&nbsp;<asp:TextBox ID="txtTheTV" runat="server" 
                                                    AutoPostBack="True" ontextchanged="txtTheTV_TextChanged" Width="23px">0</asp:TextBox>
                                            </td>
                                            <td class="style27" 
                                                style="border-right:1px #FF0000 solid; border-bottom: 1px solid;background-color:#FFFF99;text-align:right;">
                                                <asp:Label ID="tc_phatra" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="head1">
                                            <td class="style26" 
                                                style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                                SỔ THẺ BIỂU QUYẾT THU VÀO :</td>
                                            <td class="style27" 
                                                style="border-right:1px #FF0000 solid; border-bottom: 1px solid;background-color:#FFFF99;text-align:right;">
                                                <asp:Label ID="tc_thuvao" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            </table>
                
                
                
                <asp:DataList ID="DataListKQ" runat="server" style="text-align: left">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" class="table_list_1" style="font-family:Times New Roman; font-size:15px; width: 1011px;">
                            <tr  class="head1">
                                <td class="style30" 
            
                                    
                                    
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid" 
                                    colspan="2">
                                    &nbsp;</td>
                                <td class="style21" 
                                    
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid " 
                                    colspan="3">
                                    <center>Đồng ý</center></td>
                                <td class="style21" 
                                    
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid " 
                                    colspan="3">
                                    <center>Không đồng ý</center></td>
                                <td class="style21" 
                                    
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid " 
                                    colspan="3">
                                    <center>Không có ý kiến</center></td>
                                <td class="style21" colspan="3" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ">
                                    <center>
                                        Không hợp lệ</center>
                                </td>
                            </tr>
                            <tr ;="" class="head1">
                                <td class="style30" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid; border-right:0px;">
                                    1.<br /> <br /> </td>
                                <td class="style22" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid">
                                    Thông qua Báo cáo hoạt động của Hội đồng quản trị năm 2015 và kế hoạch hoạt động 
                                    năm 2016</td>
                                <td class="style23"                                     
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center><asp:Label ID="c1" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_1C1") %>'></asp:Label></center>
                                </td>
                                <td class="style24"
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align:right;">
                                    <asp:Label ID="s1" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_1S1","{0:0,0}") %>'></asp:Label>
                                </td>
                                 <td class="style23"                                     
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t1" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Bind("_1T1") %>'></asp:Label></center>
                                </td>

                                <td class="style23"
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c4" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_1C2") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24"
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid; text-align:right; ">
                                    <asp:Label ID="s4" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_1S2","{0:0,0}") %>'></asp:Label>
                                </td>
                                 <td class="style23"                                     
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t4" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_1T2") %>'></asp:Label></center>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c7" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_1C3") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s7" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_1S3","{0:0,0}") %>'></asp:Label>
                                </td>
                                 <td class="style23"                                     
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t7" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_1T3") %>'></asp:Label></center>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c25" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_1C4") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; height: 40px; text-align: right;">
                                    <asp:Label ID="s27" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_1S4","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t25" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_1T4") %>'></asp:Label>
                                    </center>
                                </td>
                            </tr>
                            <tr ;="" class="head1">
                                <td class="style30" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid; border-right:0px;">
                                    2.<br /> </td>
                                <td class="style22" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid">                                    
                                    Thông qua Báo cáo hoạt động của Ban kiểm soát Công ty CP Cấp nước Tân Hòa năm 
                                    2015</td>
                                <td class="style23" 
                                    
                                    
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                   <center>
                                       <asp:Label ID="c2" runat="server" Font-Size="Large" ForeColor="Red" 
                                           Text='<%# Eval("_2C1") %>'></asp:Label></center>
                                </td>
                                <td class="style24" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align:right;">
                                    <asp:Label ID="s2" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_2S1","{0:0,0}") %>'></asp:Label>
                                </td>
                                 <td class="style23"                                     
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t2" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_2T1") %>'></asp:Label></center>
                                </td>
                                <td 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c5" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_2C2") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s5" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_2S2","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23"                                     
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t5" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_2T2") %>'></asp:Label></center>
                                </td>
                                <td  
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    
                                    <center>
                                        <asp:Label ID="c8" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_2C3") %>'></asp:Label>
                                    </center>
                                    
                                </td>
                               
                                <td 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s8" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_2S3","{0:0,0}") %>'></asp:Label>
                                </td>
                                  <td class="style23"                                     
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t8" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_2T3") %>'></asp:Label></center>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c26" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_2C4") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; height: 40px; text-align: right;">
                                    <asp:Label ID="s28" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_2S4","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t26" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_2T4") %>'></asp:Label>
                                    </center>
                                </td>
                            </tr>
                            <tr ;="" class="head1">
                                <td class="style30" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid; border-right:0px;">
                                    3.<br /> <br /> </td>
                                <td class="style22" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid">
                                    Thông qua Báo cáo tổng kết hoạt động sản xuất kinh doanh năm 2015 và Phương 
                                    hướng hoạt động sản xuất kinh doanh năm 2016</td>
                                <td class="style23" 
                                    
                                    
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c3" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_3C1") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align:right;">
                                    <asp:Label ID="s3" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_3S1","{0:0,0}") %>'></asp:Label>
                                </td>
                                 <td class="style23"                                     
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t3" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_3T1") %>'></asp:Label></center>
                                </td>
                                <td 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c6" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_3C2") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s6" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_3S2","{0:0,0}") %>'></asp:Label>
                                </td>
                                 <td class="style23"                                     
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t6" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_3T2") %>'></asp:Label></center>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c9" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_3C3") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s9" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_3S3","{0:0,0}") %>'></asp:Label>
                                </td>
                                 <td class="style23"                                     
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t9" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_3T3") %>'></asp:Label></center>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c27" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_3C4") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; height: 40px; text-align: right;">
                                    <asp:Label ID="s29" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_3S4","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t27" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_3T4") %>'></asp:Label>
                                    </center>
                                </td>
                            </tr>
                            <tr ;="" class="head1">
                                <td class="style30" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid; border-right:0px;">
                                    4.<br />
                                </td>
                                <td class="style22" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid">Thông qua Báo cáo tài chính tóm tắt năm 2015 (đã kiểm toán) và Kế hoạch tài 
                                    chính năm 2016</td>
                                <td class="style23" 
                                    
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                   <center> 
                                       <asp:Label ID="c10" runat="server" Font-Size="Large" ForeColor="Red" 
                                        style="text-align: center" Text='<%# Eval("_4C1") %>'></asp:Label></center>
                                </td>
                                <td class="style24" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align:right;">
                                    <asp:Label ID="s10" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_4S1","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style31" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="t10" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_4T1") %>'></asp:Label>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="c15" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_4C2") %>'></asp:Label>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s15" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_4S2","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style31" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="t15" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_4T2") %>'></asp:Label>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="c20" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_3C3") %>'></asp:Label>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s20" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_4S3","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="t20" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_4T3") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <center>
                                        <asp:Label ID="c28" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_4C4") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: right; height: 40px;">
                                    <asp:Label ID="s30" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_4S4","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <center>
                                        <asp:Label ID="t28" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_4T4") %>'></asp:Label>
                                    </center>
                                </td>
                            </tr>
                            <tr ;="" class="head1">
                                <td class="style30" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid; border-right:0px;">
                                    5.<br />
                                </td>
                                <td class="style22" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid">Thông qua Tờ trình sửa đổi, bổ sung Điều lệ Công ty theo Luật doanh nghiệp năm 2014</td>
                                <td class="style23" 
                                    
                                    
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="c11" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_5C1") %>'></asp:Label>
                                </td>
                                <td class="style24" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align:right;">
                                    <asp:Label ID="s11" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_5S1","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style31" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="t11" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_5T1") %>'></asp:Label>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="c16" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_5C2") %>'></asp:Label>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s16" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_5S2","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style31" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="t16" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_5T2") %>'></asp:Label>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="c21" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_5C3") %>'></asp:Label>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s21" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_5S3","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="t21" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_5T3") %>' style="text-align: center"></asp:Label>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <center>
                                        <asp:Label ID="c29" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_5C4") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: right; height: 40px;">
                                    <asp:Label ID="s31" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_5S4","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <center>
                                        <asp:Label ID="t29" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_5T4") %>'></asp:Label>
                                    </center>
                                </td>
                            </tr>
                            <tr ;="" class="head1">
                                <td class="style30" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid; border-right:0px;">
                                    6.<br />
                                </td>
                                <td class="style22" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid">
                                    Thông qua Ủy quyền cho HĐQT lựa chọn đơn vị kiểm toán năm 2016</td>
                                <td class="style23" 
                                    
                                    
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="c12" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_6C1") %>'></asp:Label>
                                </td>
                                <td class="style24" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align:right;">
                                    <asp:Label ID="s12" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_6S1","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style31" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="t12" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_6T1") %>'></asp:Label>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="c17" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_6C2") %>'></asp:Label>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s17" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_6S2","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style31" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="t17" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_6T2") %>'></asp:Label>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="c22" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_6C3") %>'></asp:Label>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s22" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_6S3","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="t22" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_6T3") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <center>
                                        <asp:Label ID="c30" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_6C4") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: right; height: 40px;">
                                    <asp:Label ID="s32" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_6S4","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <center>
                                        <asp:Label ID="t30" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_6T4") %>'></asp:Label>
                                    </center>
                                </td>
                            </tr>
                            <tr ;="" class="head1">
                                <td class="style30" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid; border-right:0px;">
                                    7.<br />
                                </td>
                                <td class="style22" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid">
                                    Thông qua Tờ trình phương án phân phối lợi nhuận, trích lập các quỹ và chi cổ 
                                    tức năm 2015</td>
                                <td class="style23" 
                                    
                                    
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="c13" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_7C1") %>'></asp:Label>
                                </td>
                                <td class="style24" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align:right;">
                                    <asp:Label ID="s13" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_7S1","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style31" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="t13" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_7T1") %>'></asp:Label>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align: center;">
                                    <asp:Label ID="c18" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_7C2") %>'></asp:Label>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s18" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_7S2","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style31" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center><asp:Label ID="t18" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_7T2") %>'></asp:Label></center>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                 <center>   <asp:Label ID="c23" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_7C3") %>'></asp:Label></center>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s23" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_7S3","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                   <center> <asp:Label ID="t23" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_7T3") %>'></asp:Label></center>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c31" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_7C4") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; height: 40px; text-align: right;">
                                    <asp:Label ID="s33" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_7S4","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; ">
                                    <center>
                                        <asp:Label ID="t31" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_7T4") %>'></asp:Label>
                                    </center>
                                </td>
                            </tr>
                            <tr ;="" class="head1">
                                <td class="style30" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid; border-right:0px;">
                                    8.<br />
                                </td>
                                <td class="style22" 
                                    style="border-right:1px #FF0000 solid; border-bottom: 2px #FF0000 solid">
                                    Thông qua Báo cáo&nbsp; thù lao của HĐQT, BKS, Thư ký năm 2015 và Kế hoạch thù lao 
                                    HĐQT, BKS, Thư ký năm 2015</td>
                                <td class="style23" 
                                    
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                  <center>  
                                      <asp:Label ID="c14" runat="server" 
                                          Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_8C1") %>'></asp:Label></center>
                                </td>
                                <td class="style24" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; text-align:right;">
                                    <asp:Label ID="s14" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_8S1","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style31" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center><asp:Label ID="t14" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_8T1") %>'></asp:Label></center>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center><asp:Label ID="c19" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_8C2") %>'></asp:Label></center>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s19" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_8S2","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style31" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                  <center>  <asp:Label ID="t19" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_8T2") %>'></asp:Label></center>
                                </td>
                                <td style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                   <center> <asp:Label ID="c24" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_8C3") %>'></asp:Label></center>
                                </td>
                                <td class="style21" 
                                    style="border-right:1px #FF0000 solid; height:40px; font-size:large; border-bottom: 2px #FF0000 solid ; text-align:right;">
                                    <asp:Label ID="s24" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_8S3","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid"><center>
                                    <asp:Label ID="t24" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_8T3") %>'></asp:Label></center>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="c32" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_8C4") %>'></asp:Label>
                                    </center>
                                </td>
                                <td class="style24" 
                                    
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid; height: 40px; text-align: right;">
                                    <asp:Label ID="s34" runat="server" Font-Size="Large" ForeColor="Red" 
                                        Text='<%# Eval("_8S4","{0:0,0}") %>'></asp:Label>
                                </td>
                                <td class="style23" 
                                    style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid">
                                    <center>
                                        <asp:Label ID="t32" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Text='<%# Eval("_8T4") %>'></asp:Label>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
               
                </td>
        </tr>
        <tr>
            <td colspan="2"  style=" text-align:left">
             
                <br />
               <b><a href="Print.aspx?page=BQ" style="margin-top:10PX;">
                <asp:Label ID="lbTongCong" Text="IN KẾT QUẢ" runat="server" Font-Size="Large" 
                    style="text-align: left"></asp:Label>
                </a></b>
                
                <br />
                <br />
                
                </td>
        </tr>
        <tr>
            <td style="border-right:0px #000044 solid;" valign="top" colspan="2" >
    <asp:GridView ID="G_KDY" runat="server" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="1000" style="margin-right: 0px" 
        Width="100%" onrowcommand="G_KDY_RowCommand">
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
            <asp:TemplateField HeaderText="MÃ CỔ ĐÔNG">
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
            <asp:TemplateField HeaderText="SỐ CP">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("TONGCD") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbCPTC0" runat="server" Text='<%# Bind("TONGCD","{0:0,0}") %>'></asp:Label>
                </FooterTemplate>
                <HeaderTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: center">
                               SỐ CP</td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="TongCong0" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label16" runat="server" Text='<%# Bind("TONGCD","{0:0,0}")%>'></asp:Label>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50px" />
            </asp:TemplateField>
            <asp:BoundField DataField="C1" HeaderText="Câu 1">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="C2" HeaderText="Câu 2">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="C3" HeaderText="Câu 3">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="C4" HeaderText="Câu 4">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="C5" HeaderText="Câu 5">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="C6" HeaderText="Câu 6">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="C7" HeaderText="Câu 7">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="C8" HeaderText="Câu 8">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="TRONGAI" runat="server" CommandArgument='<%# Bind("ID") %>' 
                        CommandName="TRONGAI" ForeColor="Blue" 
                        onclientclick="if(confirm('Bạn có muốn xóa ?') == false)return false;">Xóa</asp:LinkButton>
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
        </tr>
    </table>
    <br />
    
    </asp:Content>
