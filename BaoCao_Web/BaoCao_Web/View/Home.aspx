<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BaoCao_Web.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-size: x-large;
            font-family: "Times New Roman", Times, serif;
        }
        .style2
        {
            color: #0000FF;
        }
        .style3
        {
            font-family: "Times New Roman", Times, serif;
            font-size: 45px;
            color: #CC0000;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Pages_content"><!--
<div class="title_page"><asp:Label ID="title" runat="server" Text="BÁO CÁO TỔNG KẾT"></asp:Label>
    </div>
		<div class="pages_contain" style="margin-top:10px; margin-left:10px; margin-right:10px;">        


        </div>--><center>
            <br />
            <span class="style1"><span class="style2">
            <br />
         TỔNG CÔNG TY CẤP NƯỚC SÀI GÒN</span><br class="style2" />
            <span class="style2"><strong>&nbsp;TRÁCH NHIỆM HỮU HẠN MỘT THÀNH VIÊN </strong>
            </span>
            <br class="style2" />
            <span class="style2">CÔNG TY CỔ PHẦN CẤP NƯỚC TÂN HÒA</span><br 
                class="style2" />
            <span class="style2">------------//------------</span></span><br />
            <br />
            <span class="style3"><strong>
            <img  src="../Image/Logo%20Tan%20Hoa.png" style="height: 290px; width: 307px" /><br />
            <br />
            THỐNG KÊ SỐ LIỆU</strong></span><br />
            <br />
            
       
        <br />
          <div id="wrap" class="menu" align="center" style=" margin-left:3px; margin-bottom:5px;">
         </center>
     </div>
   <script type="text/javascript">
            <!--
       if (TransMenu.isSupported()) {
           var ms = new TransMenuSet(TransMenu.direction.right, 0, 0, TransMenu.reference.topRight);
           var menu4 = ms.addMenu(document.getElementById("menu4"));
           menu4.addItem("&nbsp;&nbsp; THỐNG KÊ ĐỒNG HỒ NƯỚC &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ", "QuanLyDHN.aspx?page=DHN&type=DTTDK", "0");
           menu4.addItem("&nbsp;&nbsp; THEO DÕI BÁO THAY ĐHN ", "tab_TheoDoiTDK.aspx?page=DHN", "0");
           menu4.addItem("&nbsp;&nbsp; THEO DÕI SẢN LƯỢNG ", "QuanLyDHN.aspx?page=DHN&type=TDSL", "0");
           menu4.addItem("&nbsp;&nbsp; THEO DÕI TIÊU THỤ THẤP", "QuanLyDHN.aspx?page=DHN&type=TDTT", "0");
           menu4.addItem("&nbsp;&nbsp; THEO DÕI CODE ĐỌC SỐ", "QuanLyDHN.aspx?page=DHN&type=CODE", "0");
           menu4.addItem("&nbsp;&nbsp; PHÂN TÍCH CODE ĐỌC SỐ", "QuanLyDHN.aspx?page=DHN&type=CTCODE", "0");
           menu4.addItem("&nbsp;&nbsp; KẾT QUẢ BIÊN ĐỌC CHỈ SỐ", "QuanLyDHN.aspx?page=DHN&type=CS", "0");
           menu4.addItem("&nbsp;&nbsp; THEO DÕI HÓA ĐƠN = 0M<sup>3</sup> ", "tab_PhanTichHoaDon0.aspx?page=DHN", "0");
           

           var menu6 = ms.addMenu(document.getElementById("menu6"));
           menu6.addItem("&nbsp;&nbsp; SỐ LIỆU KINH DOANH THEO NĂM &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ", "KinhDoanh.aspx?page=KD&type=V", "0");
           menu6.addItem("&nbsp;&nbsp; SO SÁNH SỐ LIỆU KINH DOANH", "KinhDoanh.aspx?page=KD&type=S", "0");

          /*  var menu5 = ms.addMenu(document.getElementById("menu5"));
           menu5.addItem("&nbsp;&nbsp; BIẾN ĐỘNG ĐHN &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ", "BieuDoBaoCao.aspx?page=BDBC&type=BDDHN", "0");
           menu5.addItem("&nbsp;&nbsp; BIẾN ĐỘNG SẢN LƯỢNG", "BieuDoBaoCao.aspx?page=BDBC&type=BDSLUONG", "0");
           menu5.addItem("&nbsp;&nbsp; BIẾN ĐỘNG DOANH THU", "BieuDoBaoCao.aspx?page=BDBC&type=BDDTHU", "0");

          
          var menu46 = ms.addMenu(document.getElementById("menu46"));
           menu46.addItem("Menu 7.1", "#", "0");
           menu46.addItem("Menu 7.2", "#", "1");
           menu46.addItem("Menu 7.3", "#", "0");
           menu46.addItem("Menu 7.4", "#", "0");
           menu46.addItem("Menu 7.5", "#", "0");
           var menu7 = ms.addMenu(document.getElementById("menu7"));
           menu7.addItem("Menu 8.1", "javascript:void(0);", "0");
           /* Level 2 */
           /*  var menu47 = menu7.addMenu(menu7.items[0], 0, 0);
           menu47.addItem("Menu 8.1.1", "#", "0");
           menu47.addItem("Menu 8.1.2", "#", "0");
           menu47.addItem("Menu 8.1.3", "#", "0");
           menu47.addItem("Menu 8.1.4", "#", "0");
                    
           menu7.addItem("Menu 9.1", "javascript:void(0);", "0");
           var menu51 = menu7.addMenu(menu7.items[1], 0, 0);
           menu51.addItem("Menu 9.1.1", "#", "0");
           menu51.addItem("Menu 9.1.2", "#", "0");
           */
           function init() {
               if (TransMenu.isSupported()) {
                   TransMenu.initialize();
                   menu5.onactivate = function () { document.getElementById("menu5").className = "hover"; };
                   menu5.ondeactivate = function () { document.getElementById("menu5").className = ""; };
                   menu4.onactivate = function () { document.getElementById("menu4").className = "hover"; };
                   menu4.ondeactivate = function () { document.getElementById("menu4").className = ""; };
                   menu6.onactivate = function () { document.getElementById("menu6").className = "hover"; };
                   menu6.ondeactivate = function () { document.getElementById("menu6").className = ""; };
                   menu46.onactivate = function () { document.getElementById("menu46").className = "hover"; };
                   menu46.ondeactivate = function () { document.getElementById("menu46").className = ""; };
                   menu7.onactivate = function () { document.getElementById("menu7").className = "hover"; };
                   menu7.ondeactivate = function () { document.getElementById("menu7").className = ""; };
                   menu8.onactivate = function () { document.getElementById("menu8").className = "hover"; };
                   menu8.ondeactivate = function () { document.getElementById("menu8").className = ""; };
                   menu9.onactivate = function () { document.getElementById("menu9").className = "hover"; };
                   menu9.ondeactivate = function () { document.getElementById("menu9").className = ""; };
                   document.getElementById("menu81").onmouseover = function () {
                       ms.hideCurrent();
                       this.className = "hover";
                   }
                   document.getElementById("menu81").onmouseout = function () { this.className = ""; }
                   document.getElementById("menu176").onmouseover = function () {
                       ms.hideCurrent();
                       this.className = "hover";
                   }
                   document.getElementById("menu176").onmouseout = function () { this.className = ""; }
                   menu79.onactivate = function () { document.getElementById("menu79").className = "hover"; };
                   menu79.ondeactivate = function () { document.getElementById("menu79").className = ""; };
               }
           }
           TransMenu.dingbatSize = 0;
           TransMenu.spacerGif = "";
           TransMenu.dingbatOn = "";
           TransMenu.dingbatOff = "";
           TransMenu.sub_indicator = false;
           TransMenu.menuPadding = 0;
           TransMenu.itemPadding = 0;
           TransMenu.shadowSize = 2;
           TransMenu.shadowOffset = 3;
           TransMenu.shadowColor = "#888";
           TransMenu.backgroundColor = "#4180b5";
           TransMenu.hideDelay = 600;
           TransMenu.slideTime = 300;
           TransMenu.selecthack = 0;
           TransMenu.autoposition = 0;
           TransMenu.renderAll();
           if (typeof window.addEventListener != "undefined")
               window.addEventListener("load", init, false);
           else if (typeof window.attachEvent != "undefined") {
               window.attachEvent("onload", init);
           } else {
               if (window.onload != null) {
                   var oldOnload = window.onload;
                   window.onload = function (e) {
                       oldOnload(e);
                       init();
                   }
               } else
                   window.onload = init();
           }
       }
            -->
            </script>
</asp:Content>
