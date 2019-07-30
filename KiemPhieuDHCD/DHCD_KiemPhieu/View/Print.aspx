<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="DHCD_KiemPhieu.View.Print" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script language="javascript">
    title_tmp1 = document.title
    if (title_tmp1.indexOf(">>") != -1) {
        title_tmp2 = title_tmp1.split(">>");
        title_last = "*~*" + title_tmp2[1];
        title_last = title_last + "*~*" + title_tmp2[2];
    } else {

        if (title_tmp1.indexOf("*~*") != -1) {
            title_tmp2 = title_tmp1.split("*~*");
            title_last = "*~*" + title_tmp2[1];
            if (title_last == "*~*") { title_last = "*~*" };
            if (title_last == "*~*") { title_last = "*~*" };
        }
        else { title_last = " ĐẠI HỘI " }
    }


    title_new = "" + title_last + ""
    step = 0

    function flash_title() {
        step++
        if (step == 8) { step = 1 }
        if (step == 1) { document.title = '[----*' + title_new + '*----]' }
        if (step == 2) { document.title = '[---*-' + title_new + '-*---]' }
        if (step == 3) { document.title = '[--*--' + title_new + '--*--]' }
        if (step == 4) { document.title = '[-*---' + title_new + '---*-]' }
        if (step == 5) { document.title = '[--*--' + title_new + '--*--]' }
        if (step == 6) { document.title = '[---*-' + title_new + '-*---]' }
        if (step == 7) { document.title = '[----*' + title_new + '*----]' }
        setTimeout("flash_title()", 180);
    }
    flash_title()

        
    </script>

<head runat="server">
    <title> ĐẠI HỘI </title>

    

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
              <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="inKQBieuQuyet.rpt">
        </Report>
    </CR:CrystalReportSource>
    
    </div>
    </form>
    
</body>
</html>
