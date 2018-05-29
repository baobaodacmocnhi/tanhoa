select * from BGW_HOADON where DANHBA=''
select * from BGW_DANGNGAN_UNC where FK_HOADON=(select ID_Hoadon from HOADON where SOHOADON='CT/18P2067889')