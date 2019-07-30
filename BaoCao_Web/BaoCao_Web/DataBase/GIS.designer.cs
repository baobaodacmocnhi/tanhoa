﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaoCao_Web.DataBase
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TANHOAGIS")]
	public partial class GISDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public GISDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TANHOAGISConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public GISDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GISDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GISDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GISDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<t_Channel_Configuration> t_Channel_Configurations
		{
			get
			{
				return this.GetTable<t_Channel_Configuration>();
			}
		}
		
		public System.Data.Linq.Table<DATALOGGER> DATALOGGERs
		{
			get
			{
				return this.GetTable<DATALOGGER>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_Channel_Configurations")]
	public partial class t_Channel_Configuration
	{
		
		private string _ChannelId;
		
		private string _LoggerId;
		
		private string _ChannelName;
		
		private string _Unit;
		
		private string _Description;
		
		private System.Nullable<bool> _Pressure1;
		
		private System.Nullable<bool> _Pressure2;
		
		private System.Nullable<bool> _ForwardFlow;
		
		private System.Nullable<bool> _ReverseFlow;
		
		private System.Nullable<System.DateTime> _TimeStamp;
		
		private System.Nullable<double> _LastValue;
		
		private System.Nullable<System.DateTime> _IndexTimeStamp;
		
		private System.Nullable<double> _LastIndex;
		
		private int _ObjectID;
		
		public t_Channel_Configuration()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChannelId", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ChannelId
		{
			get
			{
				return this._ChannelId;
			}
			set
			{
				if ((this._ChannelId != value))
				{
					this._ChannelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoggerId", DbType="VarChar(50)")]
		public string LoggerId
		{
			get
			{
				return this._LoggerId;
			}
			set
			{
				if ((this._LoggerId != value))
				{
					this._LoggerId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChannelName", DbType="NVarChar(50)")]
		public string ChannelName
		{
			get
			{
				return this._ChannelName;
			}
			set
			{
				if ((this._ChannelName != value))
				{
					this._ChannelName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Unit", DbType="NVarChar(50)")]
		public string Unit
		{
			get
			{
				return this._Unit;
			}
			set
			{
				if ((this._Unit != value))
				{
					this._Unit = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(4000)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pressure1", DbType="Bit")]
		public System.Nullable<bool> Pressure1
		{
			get
			{
				return this._Pressure1;
			}
			set
			{
				if ((this._Pressure1 != value))
				{
					this._Pressure1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pressure2", DbType="Bit")]
		public System.Nullable<bool> Pressure2
		{
			get
			{
				return this._Pressure2;
			}
			set
			{
				if ((this._Pressure2 != value))
				{
					this._Pressure2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ForwardFlow", DbType="Bit")]
		public System.Nullable<bool> ForwardFlow
		{
			get
			{
				return this._ForwardFlow;
			}
			set
			{
				if ((this._ForwardFlow != value))
				{
					this._ForwardFlow = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReverseFlow", DbType="Bit")]
		public System.Nullable<bool> ReverseFlow
		{
			get
			{
				return this._ReverseFlow;
			}
			set
			{
				if ((this._ReverseFlow != value))
				{
					this._ReverseFlow = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeStamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> TimeStamp
		{
			get
			{
				return this._TimeStamp;
			}
			set
			{
				if ((this._TimeStamp != value))
				{
					this._TimeStamp = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastValue", DbType="Float")]
		public System.Nullable<double> LastValue
		{
			get
			{
				return this._LastValue;
			}
			set
			{
				if ((this._LastValue != value))
				{
					this._LastValue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IndexTimeStamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> IndexTimeStamp
		{
			get
			{
				return this._IndexTimeStamp;
			}
			set
			{
				if ((this._IndexTimeStamp != value))
				{
					this._IndexTimeStamp = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastIndex", DbType="Float")]
		public System.Nullable<double> LastIndex
		{
			get
			{
				return this._LastIndex;
			}
			set
			{
				if ((this._LastIndex != value))
				{
					this._LastIndex = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ObjectID", DbType="Int NOT NULL")]
		public int ObjectID
		{
			get
			{
				return this._ObjectID;
			}
			set
			{
				if ((this._ObjectID != value))
				{
					this._ObjectID = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DATALOGGER")]
	public partial class DATALOGGER
	{
		
		private int _OBJECTID;
		
		private string _IDDiemApLuc;
		
		private string _ViTriDiemApLuc;
		
		private System.Nullable<decimal> _ToaDo_X;
		
		private System.Nullable<decimal> _ToaDo_Y;
		
		private string _TenDiem;
		
		private System.Nullable<decimal> _ThoiGianDo;
		
		private System.Nullable<decimal> _ApLucDo;
		
		private string _SoNha;
		
		private string _MaDuong;
		
		private string _MaPhuong;
		
		private string _MaQuan;
		
		private string _GhiChu;
		
		private System.Guid _GlobalID;
		
		private System.Nullable<short> _NamLapDat;
		
		private System.Nullable<short> _TinhTrangSuDung;
		
		private System.Nullable<System.DateTime> _NgayCapNhat;
		
		private string _NguoiCapNhat;
		
		private string _MaDMA;
		
		private string _CheckTool;
		
		private string _SoDienThoai;
		
		private string _SoSeri;
		
		private System.Nullable<short> _BoTruyenTinHieu;
		
		private System.Nullable<decimal> _GiaTriLN;
		
		private System.Nullable<decimal> _GiaTriNN;
		
		private string _Status;
		
		private System.Nullable<int> _SHAPE;
		
		public DATALOGGER()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OBJECTID", DbType="Int NOT NULL")]
		public int OBJECTID
		{
			get
			{
				return this._OBJECTID;
			}
			set
			{
				if ((this._OBJECTID != value))
				{
					this._OBJECTID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDiemApLuc", DbType="NVarChar(20)")]
		public string IDDiemApLuc
		{
			get
			{
				return this._IDDiemApLuc;
			}
			set
			{
				if ((this._IDDiemApLuc != value))
				{
					this._IDDiemApLuc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ViTriDiemApLuc", DbType="NVarChar(100)")]
		public string ViTriDiemApLuc
		{
			get
			{
				return this._ViTriDiemApLuc;
			}
			set
			{
				if ((this._ViTriDiemApLuc != value))
				{
					this._ViTriDiemApLuc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToaDo_X", DbType="Decimal(38,8)")]
		public System.Nullable<decimal> ToaDo_X
		{
			get
			{
				return this._ToaDo_X;
			}
			set
			{
				if ((this._ToaDo_X != value))
				{
					this._ToaDo_X = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToaDo_Y", DbType="Decimal(38,8)")]
		public System.Nullable<decimal> ToaDo_Y
		{
			get
			{
				return this._ToaDo_Y;
			}
			set
			{
				if ((this._ToaDo_Y != value))
				{
					this._ToaDo_Y = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenDiem", DbType="NVarChar(50)")]
		public string TenDiem
		{
			get
			{
				return this._TenDiem;
			}
			set
			{
				if ((this._TenDiem != value))
				{
					this._TenDiem = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThoiGianDo", DbType="Decimal(38,8)")]
		public System.Nullable<decimal> ThoiGianDo
		{
			get
			{
				return this._ThoiGianDo;
			}
			set
			{
				if ((this._ThoiGianDo != value))
				{
					this._ThoiGianDo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApLucDo", DbType="Decimal(38,8)")]
		public System.Nullable<decimal> ApLucDo
		{
			get
			{
				return this._ApLucDo;
			}
			set
			{
				if ((this._ApLucDo != value))
				{
					this._ApLucDo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoNha", DbType="NVarChar(50)")]
		public string SoNha
		{
			get
			{
				return this._SoNha;
			}
			set
			{
				if ((this._SoNha != value))
				{
					this._SoNha = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaDuong", DbType="NVarChar(10)")]
		public string MaDuong
		{
			get
			{
				return this._MaDuong;
			}
			set
			{
				if ((this._MaDuong != value))
				{
					this._MaDuong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaPhuong", DbType="NVarChar(10)")]
		public string MaPhuong
		{
			get
			{
				return this._MaPhuong;
			}
			set
			{
				if ((this._MaPhuong != value))
				{
					this._MaPhuong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaQuan", DbType="NVarChar(10)")]
		public string MaQuan
		{
			get
			{
				return this._MaQuan;
			}
			set
			{
				if ((this._MaQuan != value))
				{
					this._MaQuan = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GhiChu", DbType="NVarChar(200)")]
		public string GhiChu
		{
			get
			{
				return this._GhiChu;
			}
			set
			{
				if ((this._GhiChu != value))
				{
					this._GhiChu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GlobalID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid GlobalID
		{
			get
			{
				return this._GlobalID;
			}
			set
			{
				if ((this._GlobalID != value))
				{
					this._GlobalID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NamLapDat", DbType="SmallInt")]
		public System.Nullable<short> NamLapDat
		{
			get
			{
				return this._NamLapDat;
			}
			set
			{
				if ((this._NamLapDat != value))
				{
					this._NamLapDat = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TinhTrangSuDung", DbType="SmallInt")]
		public System.Nullable<short> TinhTrangSuDung
		{
			get
			{
				return this._TinhTrangSuDung;
			}
			set
			{
				if ((this._TinhTrangSuDung != value))
				{
					this._TinhTrangSuDung = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayCapNhat", DbType="DateTime2")]
		public System.Nullable<System.DateTime> NgayCapNhat
		{
			get
			{
				return this._NgayCapNhat;
			}
			set
			{
				if ((this._NgayCapNhat != value))
				{
					this._NgayCapNhat = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiCapNhat", DbType="NVarChar(50)")]
		public string NguoiCapNhat
		{
			get
			{
				return this._NguoiCapNhat;
			}
			set
			{
				if ((this._NguoiCapNhat != value))
				{
					this._NguoiCapNhat = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaDMA", DbType="NVarChar(20)")]
		public string MaDMA
		{
			get
			{
				return this._MaDMA;
			}
			set
			{
				if ((this._MaDMA != value))
				{
					this._MaDMA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckTool", DbType="NVarChar(50)")]
		public string CheckTool
		{
			get
			{
				return this._CheckTool;
			}
			set
			{
				if ((this._CheckTool != value))
				{
					this._CheckTool = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoDienThoai", DbType="NVarChar(20)")]
		public string SoDienThoai
		{
			get
			{
				return this._SoDienThoai;
			}
			set
			{
				if ((this._SoDienThoai != value))
				{
					this._SoDienThoai = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoSeri", DbType="NVarChar(50)")]
		public string SoSeri
		{
			get
			{
				return this._SoSeri;
			}
			set
			{
				if ((this._SoSeri != value))
				{
					this._SoSeri = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BoTruyenTinHieu", DbType="SmallInt")]
		public System.Nullable<short> BoTruyenTinHieu
		{
			get
			{
				return this._BoTruyenTinHieu;
			}
			set
			{
				if ((this._BoTruyenTinHieu != value))
				{
					this._BoTruyenTinHieu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GiaTriLN", DbType="Decimal(38,8)")]
		public System.Nullable<decimal> GiaTriLN
		{
			get
			{
				return this._GiaTriLN;
			}
			set
			{
				if ((this._GiaTriLN != value))
				{
					this._GiaTriLN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GiaTriNN", DbType="Decimal(38,8)")]
		public System.Nullable<decimal> GiaTriNN
		{
			get
			{
				return this._GiaTriNN;
			}
			set
			{
				if ((this._GiaTriNN != value))
				{
					this._GiaTriNN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="NVarChar(20)")]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this._Status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SHAPE", DbType="Int")]
		public System.Nullable<int> SHAPE
		{
			get
			{
				return this._SHAPE;
			}
			set
			{
				if ((this._SHAPE != value))
				{
					this._SHAPE = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
