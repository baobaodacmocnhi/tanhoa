<?php
	require_once("lib/nusoap.php");
	$server=new nusoap_server();
	$server->configureWSDL("TimKiemDonKH","urn:TimKiemDonKH");
	$server->wsdl->addComplexType("KetQua","complexType","struct","all","",
								array(
									"Error"=>array("name"=>"Error","type"=>"xsd:string"),
									"shs"=>array("name"=>"shs","type"=>"xsd:string"),
									"HoTen"=>array("name"=>"HoTen","type"=>"xsd:string"),
									"DiaChi"=>array("name"=>"DiaChi","type"=>"xsd:string"),
									"DienThoai"=>array("name"=>"DienThoai","type"=>"xsd:string"),
									"NgayNhanHS"=>array("name"=>"NgayNhanHS","type"=>"xsd:string"),
									"LoaiHS"=>array("name"=>"LoaiHS","type"=>"xsd:string"),
									"DotNhanDon"=>array("name"=>"DotNhanDon","type"=>"xsd:string"),
									"NgayLenDotNhanDon"=>array("name"=>"NgayLenDotNhanDon","type"=>"xsd:string"),
									"NgayChuyenTTK"=>array("name"=>"NgayChuyenTTK","type"=>"xsd:string"),
									"NgayGiaoSDV"=>array("name"=>"NgayGiaoSDV","type"=>"xsd:string"),
									"SDVTK"=>array("name"=>"SDVTK","type"=>"xsd:string"),
									"NgayLapBG"=>array("name"=>"NgayLapBG","type"=>"xsd:string"),
									"NgayDongTien"=>array("name"=>"NgayDongTien","type"=>"xsd:string"),
									"SoTien"=>array("name"=>"SoTien","type"=>"xsd:string"),
									"NgayTrinhKyGD"=>array("name"=>"NgayTrinhKyGD","type"=>"xsd:string"),
									"NgayHoanTat"=>array("name"=>"NgayHoanTat","type"=>"xsd:string"),
									"NgayTraHS"=>array("name"=>"NgayTraHS","type"=>"xsd:string"),
									"TCTuNgay"=>array("name"=>"TCTuNgay","type"=>"xsd:string"),
									"TCDenNgay"=>array("name"=>"TCDenNgay","type"=>"xsd:string")
									));
	$server->register("getDonKH",
						array("shs"=>"xsd:string"),
						array("return"=>"tns:KetQua"),
						"urn:TimKiemDonKH",
						"urn:TimKiemDonKH#getDonKH",
						"rpc",
						"encoded",
						"Tim Kiem Don Khach Hang"
						);				
	function getDonKH($shs)
	{
		try
		{
			$conn = new PDO("sqlsrv:server=192.168.90.9;Database=TANHOA_WATER","sa","123@tanhoa");
			$conn->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );
			$conn->setAttribute( PDO::SQLSRV_ATTR_QUERY_TIMEOUT, 1 );
		}
		catch(Exception $ex)
		{ 
			return array("Error"=>"Could not connect.\n".print_r( $ex->getMessage(), true));
		}
		try
		{
			$sql_TTKH="SELECT bn.SHS,bn.HOTEN,(SONHA+' '+DUONG+', P.'+p.TENPHUONG+', Q.'+q.TENQUAN) as 'DIACHI',DIENTHOAI,CONVERT(VARCHAR(20),bn.NGAYNHAN,103) AS 'NGAYNHAN',lhs.TENLOAI as 'LOAIHS' FROM QUAN q,PHUONG p,BIENNHANDON bn, LOAI_HOSO lhs WHERE bn.SHS='".$shs."' AND bn.QUAN=q.MAQUAN AND q.MAQUAN=p.MAQUAN AND bn.PHUONG=p.MAPHUONG AND lhs.MALOAI=bn.LOAIDON";
		
			$result_TTKH = $conn->prepare($sql_TTKH, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
    		$result_TTKH->execute();
			if($result_TTKH->rowCount()==0)
				return array("Error"=>"KHÔNG CÓ DỮ LIỆU");
    		$row_TTKH = $result_TTKH->fetch(PDO::FETCH_ASSOC);
    		$result_TTKH = null;
			
			////////////////////////////////////DON_KHACHHANG
			$sql_DonKH="SELECT MADOT,CONVERT(VARCHAR(10),CREATEDATE,103)CREATEDATE,CONVERT(VARCHAR(10),NGAYCHUYEN_HOSO,103)NGAYCHUYEN_HOSO,HOSOCHA,CONVERT(VARCHAR(10),NGAYDONGTIEN,103)NGAYDONGTIEN,SOTIEN FROM DON_KHACHHANG WHERE SHS='".$shs."'";
			
			$result_DonKH = $conn->prepare($sql_DonKH, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
    		$result_DonKH->execute();
			if($result_DonKH->rowCount()==0)
				return array("Error"=>"KHÔNG CÓ DỮ LIỆU");
    		$row_DonKH = $result_DonKH->fetch(PDO::FETCH_ASSOC);
			if($row_DonKH["HOSOCHA"]!="")
			{
				$sql_DonKH="SELECT MADOT,CONVERT(VARCHAR(10),CREATEDATE,103)CREATEDATE,CONVERT(VARCHAR(10),NGAYCHUYEN_HOSO,103)NGAYCHUYEN_HOSO,HOSOCHA,CONVERT(VARCHAR(10),NGAYDONGTIEN,103)NGAYDONGTIEN,SOTIEN FROM DON_KHACHHANG WHERE SHS='".$row_DonKH["HOSOCHA"]."'";
			
				$result_DonKH = $conn->prepare($sql_DonKH, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
				$result_DonKH->execute();
				if($result_DonKH->rowCount()==0)
					return array("Error"=>"KHÔNG CÓ DỮ LIỆU");
				$row_DonKH = $result_DonKH->fetch(PDO::FETCH_ASSOC);
				$shs=$row_DonKH["SHS"];///Gán lại biến shs cha
			}
    		$result_DonKH = null;
			$SoTienDong=$row_DonKH["SOTIEN"];///Lấy Số Tiền Phải Đóng
			if($row_DonKH["NGAYCHUYEN_HOSO"]!="")///Kiểm tra có chuyển cho Tổ Thiết Kế chưa
			{
				////////////////////////////////////TOTHIETKE
				$sql_TTK="SELECT SODOVIEN,CONVERT(VARCHAR(10),NGAYGIAOSDV,103)NGAYGIAOSDV,TRONGAITHIETKE,NOIDUNGTRONGAI,CONVERT(VARCHAR(10),NGAYHOANTATTK,103)NGAYHOANTATTK,CONVERT(VARCHAR(10),NGAYTRAHS,103)NGAYTRAHS,CONVERT(VARCHAR(10),NGAYTKGD,103)NGAYTKGD FROM TOTHIETKE WHERE SHS='".$shs."'";
				
				$result_TTK = $conn->prepare($sql_TTK, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
				$result_TTK->execute();
				if($result_TTK->rowCount()!=0)
				{	
					$row_TTK = $result_TTK->fetch(PDO::FETCH_ASSOC);
					$result_TTK = null;
					if($row_TTK["SODOVIEN"]!="")
					{						
						$sql_User="SELECT FULLNAME FROM USERS WHERE USERNAME='".$row_TTK["SODOVIEN"]."'";
				
						$result_User = $conn->prepare($sql_User, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
						$result_User->execute();
						$row_User = $result_User->fetch(PDO::FETCH_ASSOC);
						$result_User = null;				
						if($row_TTK["TRONGAITHIETKE"]=="True")
						{
							$error=$row_TTK["NOIDUNGTRONGAI"];
							$NgayHoanTat=$row_TTK["NGAYHOANTATTK"];
							$NgayTraHS=$row_TTK["NGAYTRAHS"];
						}
						else
						{
							////////////////////////////////////BG_KHOILUONGXDCB
							$sql_XDCB="SELECT CONVERT(VARCHAR(10),CREATEDATE,103)CREATEDATE,PARSENAME(Convert(varchar,Convert(money,CAST(ROUND(TONGIATRI, 2, 1) AS DECIMAL(9,0))),1),2)TONGIATRI FROM BG_KHOILUONGXDCB WHERE SHS='".$shs."'";
							
							$result_XDCB = $conn->prepare($sql_XDCB, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
							$result_XDCB->execute();
							if($result_XDCB->rowCount()!=0)
							{
								$row_XDCB = $result_XDCB->fetch(PDO::FETCH_ASSOC);
								$result_XDCB = null;
								$SoTienDong=$row_XDCB["TONGIATRI"];
							}
							////////////////////////////////////KH_DOTTHICONG
							//Lấy thời gian thì công từ ngày nào đến ngày nào
							$sql_DotTC="select CONVERT(VARCHAR(10),TCTUNGAY,103)TCTUNGAY,CONVERT(VARCHAR(10),TCDENNGAY,103)TCDENNGAY from KH_DOTTHICONG where MADOTTC=(select MADOTTC from KH_HOSOKHACHHANG where SHS='".$shs."')";
							$result_DotTC = $conn->prepare($sql_DotTC, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
							$result_DotTC->execute();
							if($result_DotTC->rowCount()!=0)
							{
								$row_DotTC = $result_DotTC->fetch(PDO::FETCH_ASSOC);
							}
						}
					}
					else
					{
						////////////////////////////////////TMP_TAIXET
						$sql_TaiXet="SELECT SODOVIEN,CONVERT(VARCHAR(10),NGAYGIAOSDV,103)NGAYGIAOSDV FROM TOTHIETKE WHERE SHS='".$shs."'";
					
						$result_TaiXet = $conn->prepare($sql_TaiXet, array(PDO::ATTR_CURSOR => PDO::CURSOR_SCROLL));
						$result_TaiXet->execute();
						if($result_TaiXet->rowCount()!=0)
							$error="CHƯA GIAO HỒ SƠ CHO SƠ ĐỒ VIÊN <br/> ĐƠN ĐANG ĐƯỢC TÁI XÉT";
						else
							$error="CHƯA GIAO HỒ SƠ CHO SƠ ĐỒ VIÊN";
					}
				}
				else
					$error="TỔ THIẾT KẾ KHÔNG NHẬN HỒ SƠ NÀY";
			}
			else
			{
				$error="HỒ SƠ CHƯA CHUYỂN CHO TỔ THIẾT KẾ";
			}
			return array(
						"Error"=>$error,
						"shs"=>$row_TTKH["SHS"],
						"HoTen"=>$row_TTKH["HOTEN"],
						"DiaChi"=>$row_TTKH["DIACHI"],
						"DienThoai"=>$row_TTKH["DIENTHOAI"],
						"NgayNhanHS"=>$row_TTKH["NGAYNHAN"],
						"LoaiHS"=>$row_TTKH["LOAIHS"],
						"DotNhanDon"=>$row_DonKH["MADOT"],
						"NgayLenDotNhanDon"=>$row_DonKH["CREATEDATE"],
						"NgayChuyenTTK"=>$row_DonKH["NGAYCHUYEN_HOSO"],
						"NgayGiaoSDV"=>$row_TTK["NGAYGIAOSDV"],
						"SDVTK"=>$row_User["FULLNAME"],
						"NgayLapBG"=>$row_XDCB["CREATEDATE"],
						"NgayDongTien"=>$row_DonKH["NGAYDONGTIEN"],
						"SoTien"=>$SoTienDong,
						"NgayTrinhKyGD"=>$row_TTK["NGAYTKGD"],
						"NgayHoanTat"=>$row_TTK["NGAYHOANTATTK"],
						"NgayTraHS"=>$row_TTK["NGAYTRAHS"],
						"TCTuNgay"=>$row_DotTC["TCTUNGAY"],
						"TCDenNgay"=>$row_DotTC["TCDENNGAY"]
						);
		}
		catch(Exception $ex)
		{ 
			return array("Error"=>"Error in query preparation/execution.\n".print_r( $ex->getMessage(), true));
		}
		
		
		
		/*
		$serverName = "192.168.90.9";
		$connectionInfo = array("UID"=>"sa","PWD"=>"123@tanhoa","Database"=>"TANHOA_WATER");
		$conn = sqlsrv_connect($serverName, $connectionInfo);
		if( $conn == false )
			return array("ERROR"=>"Could not connect.\n".print_r( sqlsrv_errors(), true));
		$sql_TTKH="SELECT bn.SHS,bn.HOTEN,(SONHA+' '+DUONG+', P.'+p.TENPHUONG+', Q.'+q.TENQUAN) as 'DIACHI',DIENTHOAI,CONVERT(VARCHAR(20),bn.NGAYNHAN,103) AS 'NGAYNHAN',lhs.TENLOAI as 'LOAIHS' FROM QUAN q,PHUONG p,BIENNHANDON bn, LOAI_HOSO lhs WHERE bn.SHS='".$shs."' AND bn.QUAN=q.MAQUAN AND q.MAQUAN=p.MAQUAN AND bn.PHUONG=p.MAPHUONG AND lhs.MALOAI=bn.LOAIDON";
		$result_TTKH = sqlsrv_query($conn,$sql_TTKH,array(),array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		if($result_TTKH == false)
			return array("ERROR"=>"Error in query preparation/execution.\n".print_r( sqlsrv_errors(), true));
		else
		{
			$row_count=sqlsrv_num_rows($result_TTKH);
			if ($row_count=="0")
				return array("ERROR"=>"1");
			else
				$row_TTKH=sqlsrv_fetch_array($result_TTKH,SQLSRV_FETCH_ASSOC);
		}
		sqlsrv_free_stmt($result_TTKH);
		sqlsrv_close($conn);
		return array(
					"ERROR"=>"0",
					"SHS"=>$row_TTKH["SHS"],
					"HOTEN"=>$row_TTKH["HOTEN"],
					"DIACHI"=>$row_TTKH["DIACHI"],
					"DIENTHOAI"=>$row_TTKH["DIENTHOAI"],
					"NGAYNHAN"=>$row_TTKH["NGAYNHAN"],
					"LOAIHS"=>$row_TTKH["LOAIHS"],
					);
		*/
	}
	$HTTP_RAW_POST_DATA=isset($HTTP_RAW_POST_DATA)? $HTTP_RAW_POST_DATA : "";
	$server->service($HTTP_RAW_POST_DATA);
?>