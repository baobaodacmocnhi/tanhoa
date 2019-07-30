<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iisstart.aspx.cs" Inherits="QuanLyKhachHang.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<title>mobiForge geolocation demo</title>
<style>
#map {width:100%;height:100%;}
</style>
<script type="text/javascript">

    function initGeolocation() {
        if (navigator && navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(successCallback, errorCallback);
        } else {
            console.log('Geolocation is not supported');
        }
    }

    function errorCallback() { }

    function successCallback(position) {
        var mapUrl = "http://maps.google.com/maps/api/staticmap?center=";
        mapUrl = mapUrl + position.coords.latitude + ',' + position.coords.longitude;
        mapUrl = mapUrl + '&zoom=15&size=512x512&maptype=roadmap&sensor=false';
        var imgElement = document.getElementById("static-map");
        imgElement.src = mapUrl;
    }
</script>
</head>
<body onload="javascript:initGeolocation()">
<div id="map">
  <img id="static-map" src="placeholder.png" />
</div>
</body>
</html>
