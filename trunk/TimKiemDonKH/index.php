<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Tìm Kiếm Đơn Khách Hàng</title>
<script type="text/javascript" src="lib/jquery-1.10.2.min.js"></script>
<script>
////Disable F5
	document.onkeydown = function() 
	{
		switch (event.keyCode) 
		{
			case 116 : //F5 button
				event.returnValue = false;
				event.keyCode = 0;
				return false;
			case 82 : //R button
				if (event.ctrlKey) 
				{
					event.returnValue = false;
					event.keyCode = 0;
					return false;
				}
		}
}
</script>
</head>

<body>
<br/>
<form method="post">
  <table align="center">
    <tr>
      <td>Số SHS:</td>
      <td><input name="txtSHSNhap" type="text" value='13000686'/></td>
      <td><input name="btnTimKiem" type="submit" value="Tìm Kiếm"/></td>
    </tr>
  </table>
</form>
<br/>
<br/>
<?php
	if(isset($_REQUEST["btnTimKiem"])&&isset($_REQUEST["txtSHSNhap"]))
	{
		$shs=$_REQUEST['txtSHSNhap'];
		require("lib/nusoap.php");
		$client=new nusoap_client("http://localhost:1221/timkiemdonkh/server.php?wsdl",true);
		$error=$client->getError();
		if($error)
		{
			echo "<h2>Constructor error 1</h2><pre>".$error."</pre>";
		}
		$result=$client->call("getDonKH",array("shs"=>$shs));
		if($client->fault)
		{
			echo "<h2>Fault</h2><pre>";
			print_r($result);
    		echo "</pre>";
		}
		else
		{
			$error=$client->getError();
			if($error)
			{
				echo "<h2>Constructor error 2</h2><pre>".$error."</pre>";
			}
			else
			{
				//echo "<h2>Result</h2><pre>";
    			//echo "</pre>";
				//$txtSHS=$result["SHS"];
				echo 
					"<table align='center' border='1'>
					   <tr>
						<td><strong>Số HS</strong></td>
						<td>";echo $result["shs"];echo"</td>
						<td><strong>Họ Tên</strong</td>
						<td>";echo $result["HoTen"];echo"</td>
						<td><strong>Điện Thoại</strong></td>
						<td>";echo $result["DienThoai"];echo"</td>
					  </tr>
					  <tr>
						<td><strong>Địa Chỉ</strong></td>
						<td colspan='5'>";echo $result["DiaChi"];echo"</td>
					  </tr>
					 </table>";
				echo "<br/>";
				echo "<table align='center' border='1'>
					  <tr>
						<td><strong>Loại HS</strong></td>
						<td>";echo $result["LoaiHS"];echo"</td>
						<td><strong>Ngày Nhận</strong></td>
						<td>";echo $result["NgayNhanHS"];echo"</td>
					  </tr>
					  <tr>
						<td><strong>Đợt Nhận Đơn</strong></td>
						<td>";echo $result["DotNhanDon"];echo"</td>
						<td><strong>Ngày</strong></td>
						<td>";echo $result["NgayLenDotNhanDon"];echo"</td>
					  </tr>
					  <tr>
						<td><strong>Ngày Chuyển TTK</strong></td>
						<td>";echo $result["NgayChuyenTTK"];echo"</td>
						<td><strong>Ngày Giao SĐV</strong></td>
						<td>";echo $result["NgayGiaoSDV"];echo"</td>
					  </tr>
					  <tr>
						<td><strong>SĐV TK</strong></td>
						<td>";echo $result["SDVTK"];echo"</td>
						<td><strong>Lập BG</strong></td>
						<td>";echo $result["NgayLapBG"];echo"</td>
					  </tr>
					  <tr>
						<td><strong>Ngày Đống Tiền</strong></td>
						<td>";echo $result["NgayDongTien"];echo"</td>
						<td><strong>Số Tiền</strong></td>
						<td>";echo $result["SoTien"];echo"</td>
					  </tr>
					  <tr>
						<td><strong>Trình Kỳ Giám Đốc</strong></td>
						<td>";echo $result["NgayTrinhKyGD"];echo"</td>
						<td><strong>Ngày Hoàn Tất</strong></td>
						<td>";echo $result["NgayHoanTat"];echo"</td>
					  </tr>
					  <tr>
						<td><strong>Thi Công Từ Ngày</strong></td>
						<td>";echo $result["TCTuNgay"];echo"</td>
						<td><strong>Thi Công Đến Ngày</strong></td>
						<td>";echo $result["TCDenNgay"];echo"</td>
					  </tr>
					  <tr>
						<td><strong>Ngày Trả Hồ Sơ KH</strong></td>
						<td colspan='3'>";echo $result["NgayTraHS"];echo"</td>
					  </tr>
					   <tr>
						<td><strong>Kết Quả</strong></td>
						<td colspan='3'>";echo $result["Error"];echo"</td>
					  </tr>
					</table>";
			}
		}
	}
?>

</body>
</html>