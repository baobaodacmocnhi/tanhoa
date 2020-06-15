<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true"
    CodeBehind="pKetQuaBauCuDHCD.aspx.cs" Inherits="DHCD_KiemPhieu.View.pBauCuBanKS" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Focus(object) {
            object.value = "";
        }

    </script>
    <style type="text/css">
        .style1
        {
            height: 76px;
        }
        .style2
        {
            height: 29px;
            font-family: "Times New Roman" , Times, serif;
            font-size: 15pt;
        }
        .style3
        {
            height: 31px;
            font-family: "Times New Roman" , Times, serif;
            font-size: 15pt;
        }
        .style4
        {
            height: 30px;
            font-family: "Times New Roman" , Times, serif;
            font-size: 15pt;
        }
        .style5
        {
            height: 33px;
            font-family: "Times New Roman" , Times, serif;
            font-size: 15pt;
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
    <div class="title_page" style="margin-top: 10px; height: 32px; text-align: center;">
        <asp:Label ID="title" runat="server" Font-Size="X-Large" Text="..:  KẾT QUẢ BẦU CỬ  CÔNG TY CP CẤP NƯỚC TÂN HÒA :.."></asp:Label>
    </div>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
    <br />
    <table cellpadding="0" cellspacing="0" style="font-family: Times New Roman; font-size: 15px;
        margin-left: 20px;" class="table_list">
        <tbody>
            <tr class="head1">
                <td class="style9" style="border-right: 0px #99cc99 solid; border-bottom: 1px solid;">
                    KIỂM PHIẾU
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
                    </asp:DropDownList>
                    &nbsp;
                </td>
                <td class="style10" style="border-right: 0px #99cc99 solid; border-bottom: 1px solid;">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style10" style="border-right: 2px #99cc99 solid; font-size: 10px; font-weight: normal;
                    border-bottom: 1px solid;">
                    &nbsp;<td class="style10" style="border-right: 0px #99cc99 solid; border-bottom: 1px solid;">
                        &nbsp;&nbsp;&nbsp; LẦN&nbsp;:
                    </td>
                    <td class="style10" style="border-right: 2px #99cc99 solid; font-size: 10px; font-weight: normal;
                        border-bottom: 1px solid;">
                        <asp:DropDownList ID="DropDownList2" runat="server" Height="24px" Width="58px" AutoPostBack="True"
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                     <asp:CheckBox ID="an" runat="server" AutoPostBack="True" OnCheckedChanged="an_CheckedChanged" /></td>
            </tr>
        </tbody>
    </table>
    <br />
    <script>
        function showhide(id) {
            document.getElementById("name" + id).style.display = "block";
            document.getElementById("sl" + id).style.display = "block";
            document.getElementById("tl" + id).style.display = "block";
            document.getElementById("cp" + id).style.display = "block";

        }

    </script>
    <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
        <%
            DataTable table = new DataTable();
            if (Session["BAUCU"] != null)
            {
        %>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server">
               
                <table cellpadding="0" cellspacing="0" class="table_list_1" style="font-family: Times New Roman;
                    color: Blue; margin-left: 20px;">
                    <tr class="head1">
                        <td class="style2" style="border-right: 2px #FF0000 solid; font-size: 22px; border-bottom: 1px solid;">
                            - Tổng số cổ đông tham dự họp:
                            <asp:Label ID="txtCDThamDu" runat="server" Font-Bold="True" ForeColor="Red" Text="0"
                                Font-Size="XX-Large"></asp:Label>
                            &nbsp;cổ đông, tương ứng
                            <asp:Label ID="txtCDThamDu_CP" runat="server" Font-Bold="True" ForeColor="Red" Text="0"
                                Font-Size="X-Large"></asp:Label>
                            &nbsp;cổ phần
                        </td>
                    </tr>
                    <tr class="head1">
                        <td class="style3" style="border-right: 2px #FF0000 solid; font-size: 22px; border-bottom: 1px solid;">
                            - Tổng số cổ đông tham gia bỏ phiếu:
                            <asp:Label ID="txtCDBoPhieu" runat="server" Font-Bold="True" ForeColor="Red" Text="0"
                                Font-Size="XX-Large"></asp:Label>
                            &nbsp;cổ đông, tương ứng
                            <asp:Label ID="txtCDBoPhieu_CP" runat="server" Font-Bold="True" ForeColor="Red" Text="0"
                                Font-Size="X-Large"></asp:Label>
                            &nbsp;cổ phần (<asp:Label ID="txtTyLeCDBoPhieu" runat="server" Font-Bold="True"
                                ForeColor="Red" Text="0" Font-Size="X-Large"></asp:Label>)
                        </td>
                    </tr>
                    <tr class="head1">
                        <td class="style2" style="border-right: 2px #FF0000 solid; font-size: 22px; border-bottom: 1px solid;">
                            &nbsp;&nbsp;+ Tổng số phiếu bầu hợp lệ:
                            <asp:Label ID="txtPhieuHopLe" runat="server" Font-Bold="True" ForeColor="Red" Text="0"
                                Font-Size="XX-Large"></asp:Label>
                            &nbsp;phiếu, tương ứng&nbsp;
                            <asp:Label ID="txtPhieuHopLe_CP" runat="server" Font-Bold="True" ForeColor="Red"
                                Text="0" Font-Size="X-Large"></asp:Label>
                            &nbsp;cổ phần (<asp:Label ID="txtTyLePhieuHopLe" runat="server" Font-Bold="True"
                                ForeColor="Red" Text="0" Font-Size="X-Large"></asp:Label>)
                        </td>
                    </tr>
                    <tr class="head1">
                        <td class="style2" style="border-right: 2px #FF0000 solid; font-size: 22px; border-bottom: 1px solid;">
                            &nbsp;&nbsp;+ Tổng số cổ phần không tín nhiệm:
                            <%--<asp:Label ID="txtPhieuKhongTinNhiem" runat="server" Font-Bold="True" ForeColor="Red" 
                                                    Text="0" Font-Size="XX-Large"></asp:Label>
                                            &nbsp;phiếu, tương ứng&nbsp;--%>
                            <asp:Label ID="txtPhieuKhongTinNhiem_CP" runat="server" Font-Bold="True" ForeColor="Red"
                                Text="0" Font-Size="X-Large"></asp:Label>
                            &nbsp;cổ phần (<asp:Label ID="txtTyLePhieuKhongTinNhiem" runat="server" Font-Bold="True"
                                ForeColor="Red" Text="0" Font-Size="X-Large"></asp:Label>)
                        </td>
                    </tr>
                    <tr class="head1">
                        <td class="style4" style="border-right: 2px #FF0000 solid; font-size: 22px; border-bottom: 1px solid;">
                            &nbsp;&nbsp;+ Tổng số phiếu bầu không hợp lệ:
                            <asp:Label ID="txtPhieuKhongHopLe" runat="server" Font-Bold="True" ForeColor="Red"
                                Text="0" Font-Size="XX-Large"></asp:Label>
                            &nbsp;phiếu, tương ứng
                            <asp:Label ID="txtPhieuKhongHopLe_CP" runat="server" Font-Bold="True" ForeColor="Red"
                                Text="0" Font-Size="X-Large"></asp:Label>
                            &nbsp;cổ phần (<asp:Label ID="txtTyLeKhongHopLe" runat="server" Font-Bold="True"
                                ForeColor="Red" Text="0" Font-Size="X-Large"></asp:Label>)
                        </td>
                    </tr>
                    <tr class="head1">
                        <td class="style5" style="border-right: 2px #FF0000 solid; font-size: 22px; border-bottom: 1px solid;">
                            - Tổng số cổ đông không tham gia bầu cử:
                            <asp:Label ID="txtCDKhongBoPhieu" runat="server" Font-Bold="True" ForeColor="Red"
                                Text="0" Font-Size="XX-Large"></asp:Label>
                            &nbsp;cổ đông, tương ứng
                            <asp:Label ID="txtCDKhongBoPhieu_CP" runat="server" Font-Bold="True" ForeColor="Red"
                                Text="0" Font-Size="X-Large"></asp:Label>
                            &nbsp;cổ phần (<asp:Label ID="txtTyLeKhongBoPhieu" runat="server" Font-Bold="True"
                                ForeColor="Red" Text="0" Font-Size="X-Large"></asp:Label>)
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <table cellpadding="0" cellspacing="0" width="98%" class="table_list_1" style="font-family: Times New Roman;
                    font-size: 40px; margin-left: 10px; margin-right: 10px;">
                    <tr class="head1">
                        <td class="style18" style="border-right: 2px #0000FF solid; text-align: center; color: Blue;
                            background-color: #FFFF99; font-size: 25px; border-bottom: 2px #FF0000	 solid;">
                            STT
                        </td>
                        <td class="style17" style="border-right: 2px #0000FF solid; text-align: center; color: Blue;
                            background-color: #FFFF99; font-size: 25px; border-bottom: 2px #FF0000	 solid;">
                            TÊN ỨNG VIÊN&nbsp;
                        </td>
                        <td class="style29" style="border-right: 2px #0000FF solid; text-align: center; color: Blue;
                            background-color: #FFFF99; font-size: 25px; border-bottom: 2px #FF0000	 solid;">
                            <center> SỐ PHIẾU 
                                    <br />
                            ĐỒNG Ý
                        </td>
                        <center>
                                <td class="style29" 
                    
                                    
                                     style="border-right:2px #0000FF solid; text-align:center; color:Blue;  background-color:#FFFF99; font-size:25px; border-bottom: 2px #FF0000	 solid; ">
                                    SỐ CỔ PHẦN 
                                    <br />
                                    ĐỒNG Ý</td>
                                <td class="style16" 
                    
                                    style="border-right:2px #0000FF solid; text-align:center; color:Blue;  background-color:#FFFF99; font-size:25px; border-bottom: 2px #FF0000	 solid; text-align: center;">
                                    TỶ LỆ</td>
                    </tr>
                    <%
int stt = 0;
table = (DataTable)Session["BAUCU"];
foreach (DataRow row in table.Rows)
{
    stt++;
                    %>
                    <tr class="head1">
                        <td style="width: 20px; border-right: 2px #0000FF solid; text-align: center; color: Blue;
                            font-size: 35px; text-align: center; border-bottom-style: solid; border-bottom-color: inherit;
                            border-bottom-width: 1px;" class="style1">
                            <a onclick="showhide(<%=stt%>);" href="#">
                                <%=stt%></a>
                        </td>
                        <td style="border-right: 2px #0000FF solid; text-align: center; color: #0033CC; font-size: 25px;
                            text-align: center; border-bottom-style: solid; border-bottom-color: inherit;
                            border-bottom-width: 1px;" class="style1">
                            <div id='name<%=stt%>' style="display: none;">
                                <%=row["Name"].ToString()%></div>
                        </td>
                        <td class="style1" style="border-right: 2px #0000FF solid; color: #0033CC; font-size: 35px;
                            text-align: center; border-bottom-style: solid; border-bottom-color: inherit;
                            border-bottom-width: 1px;">
                            <div id='sl<%=stt%>' style="display: none;">
                                <%=row["SoPhieu"].ToString()%>
                            </div>
                        </td>
                        <td class="style1" style="border-right: 2px #0000FF solid; color: #0033CC; font-size: 35px;
                            text-align: center; border-bottom-style: solid; border-bottom-color: inherit;
                            border-bottom-width: 1px;">
                            <div id='cp<%=stt%>' style="display: none;">
                                <%=String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", row["CoPhan"])%>
                            </div>
                        </td>
                        <td class="style1" style="border-right: 2px #0000FF solid; color: #0033CC; font-size: 35px;
                            text-align: center; border-bottom-style: solid; border-bottom-color: inherit;
                            border-bottom-width: 1px;">
                            <div id='tl<%=stt%>' style="display: none;">
                                <%=String.Format("{0:0,0.##}", row["Dat"]).Replace(".", ",")%>%
                            </div>
                        </td>
                    </tr>
                    <%
}
                         }
                    %>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
