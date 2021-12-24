create trigger trSetDate on HoaDon after insert,update
as
begin

UPDATE HoaDon
SET HoaDon.NgayCapNhat =GETDATE()
FROM HoaDon X
JOIN inserted i ON x.HoaDonID = i.HoaDonID
end

create trigger trSetDate2 on BienDong after insert,update
as
begin

UPDATE BienDong
SET BienDong.NgayCapNhat =GETDATE()
FROM BienDong X
JOIN inserted i ON x.BienDongID = i.BienDongID
end


alter trigger trSetDate3 on DocSo after insert
as
begin

UPDATE DocSo
SET DocSo.NgayTaoDS = CONVERT(VARCHAR(10),GETDATE(),104)
FROM DocSo X
JOIN inserted i ON x.DocSoID = i.DocSoID
end

