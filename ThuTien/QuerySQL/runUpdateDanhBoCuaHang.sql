USE [msdb]
GO

/****** Object:  Job [runUpdateDanhBoCuaHang]    Script Date: 26/11/2020 2:33:44 PM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 26/11/2020 2:33:44 PM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'runUpdateDanhBoCuaHang', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'No description available.', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'sa', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [run]    Script Date: 26/11/2020 2:33:44 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'run', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'declare @Nam int,@Ky int
if(MONTH(GETDATE())=1)
	begin
		set @Nam=YEAR(GETDATE())-1
		set @Ky=12
	end
else
	begin
		set @Nam=YEAR(GETDATE())
		set @Ky=MONTH(GETDATE())-1
	end
insert into TT_DichVuThu_DanhBo_CuaHang select DanhBo=DANHBA
,CuaHangThuHo1=(select top 1 [Name]+'': ''+DiaChi from TT_DichVuThu_CuaHang where hd.DOT=(select top 1 Dot from HOADON where DANHBA=DanhBo order by CreateDate desc) and hd.MaNV_HanhThu=(select top 1 MaNV_HanhThu from HOADON where DANHBA=DanhBo order by CreateDate desc))
,CuaHangThuHo2=(select top 1 [Name]+'': ''+DiaChi from TT_DichVuThu_CuaHang where hd.DOT=(select top 1 Dot from HOADON where DANHBA=DanhBo order by CreateDate desc) and hd.MaNV_HanhThu=(select top 1 MaNV_HanhThu from HOADON where DANHBA=DanhBo order by CreateDate desc) and ID not in((select top 1 ID from TT_DichVuThu_CuaHang where hd.DOT=(select top 1 Dot from HOADON where DANHBA=DanhBo order by CreateDate desc) and hd.MaNV_HanhThu=(select top 1 MaNV_HanhThu from HOADON where DANHBA=DanhBo order by CreateDate desc))))
,''ModifyDate''=GETDATE()
from HOADON hd where hd.NAM=@Nam and hd.KY=@Ky', 
		@database_name=N'HOADON_TA', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'run', 
		@enabled=1, 
		@freq_type=16, 
		@freq_interval=1, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=1, 
		@active_start_date=20201126, 
		@active_end_date=99991231, 
		@active_start_time=10000, 
		@active_end_time=235959, 
		@schedule_uid=N'8a91c29d-6e30-4a13-8a6f-f9d1883ed002'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:
GO


