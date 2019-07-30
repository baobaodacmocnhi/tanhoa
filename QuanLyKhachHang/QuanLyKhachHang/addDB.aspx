<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addDB.aspx.cs" Inherits="QuanLyKhachHang.addDB" %>
<!DOCTYPE html>
<html>
   <head>
      <title>Vi Tri</title>
      <link rel="stylesheet" type="text/css" href="StyleSheet/style.css"/>
      <link rel="stylesheet" type="text/css" href="css/font-awesome.css"/>
      <link rel="stylesheet" type="text/css" href="css/animate.css"/>
      <!--<link rel="shortcut icon" href="img/fav.ico" type="image/x-icon"/> --->
      <link href="https://fonts.googleapis.com/css?family=Montserrat:700" rel="stylesheet"/>
      <meta charset="utf-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <meta name="description" content="" />
      <meta name="keywords" content=" "/>
      <meta name="author" content="Shrinath Nayak">
      <meta name="robots" content="index, follow" />
      <script>


          function getLocation() {
              if (navigator.geolocation) {
                  navigator.geolocation.getCurrentPosition(showPosition);
              } else {
                  alert('Khong Tim Dia Chi');
              }
          }

          function showPosition(position) {
              document.getElementById("Lat").value = position.coords.latitude;
              document.getElementById("Long").value = position.coords.longitude;

          }


          function save() {
              var _db = document.getElementById("db").value;
              var _Lat = document.getElementById("Lat").value;
              var _Long = document.getElementById("Long").value;
              var newUrl = "addDB.aspx?lat=" + _Lat + "&lng=" + _Long + "&db=" + _db;
              document.location.href = newUrl;


          }

</script>

       <style type="text/css">
           .style1
           {
               height: 27px;
           }
           .style2
           {
               height: 33px;
           }
           .style3
           {
               height: 34px;
           }
           .style4
           {
               height: 38px;
           }
       </style>

   </head>
   <body style="background-image=bg.jpg" >
   
      <!--Card-->
      <div class="card animated fadeIn">
         <center>Kiem Tra DHN</center>
         <hr/>
            <button style="margin-left:20px;" onclick="getLocation()">Lấy Vị Trí</button>
  <form id="Form1"  runat="server" > 
    <table style="margin-left:10px;">
        <tr>
            <td class="style2">
                Danh Bộ :</td>
            <td class="style2">
                <input id="db" name="db" type="text" style="width:150px;" /></td>
        </tr>
        <tr>
            <td class="style3">
                Latitude</td>
            <td class="style3">
                <input id="Lat" name="Lat" type="text" style="width:150px;"  /></td>
        </tr>
        <tr>
            <td class="style4">
                Longitude</td>
            <td class="style4">
                <input id="Long" name="Long"  type="text" style="width:150px;"  /></td>
        </tr>
        <tr>
            <td class="style3">
                </td>
            <td class="style3">
                <asp:Button ID="Button2" runat="server" onclick="Button1_Click1" 
                    Text="Lưu Vị Trí" />
               </td>  
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
               </td>  
        </tr>
    </table>
   </form>
      </div>
      <!--footer-->
      
   </body>
</html>
