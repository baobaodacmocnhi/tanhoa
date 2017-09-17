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