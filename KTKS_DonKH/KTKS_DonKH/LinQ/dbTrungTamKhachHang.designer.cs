﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KTKS_DonKH.LinQ
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TRUNGTAMKHACHHANG")]
	public partial class dbTrungTamKhachHangDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertZalo(Zalo instance);
    partial void UpdateZalo(Zalo instance);
    partial void DeleteZalo(Zalo instance);
    partial void InsertSuCoNgungCungCapNuoc(SuCoNgungCungCapNuoc instance);
    partial void UpdateSuCoNgungCungCapNuoc(SuCoNgungCungCapNuoc instance);
    partial void DeleteSuCoNgungCungCapNuoc(SuCoNgungCungCapNuoc instance);
    #endregion
		
		public dbTrungTamKhachHangDataContext() : 
				base(global::KTKS_DonKH.Properties.Settings.Default.TRUNGTAMKHACHHANGConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbTrungTamKhachHangDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbTrungTamKhachHangDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbTrungTamKhachHangDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbTrungTamKhachHangDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Zalo> Zalos
		{
			get
			{
				return this.GetTable<Zalo>();
			}
		}
		
		public System.Data.Linq.Table<SuCoNgungCungCapNuoc> SuCoNgungCungCapNuocs
		{
			get
			{
				return this.GetTable<SuCoNgungCungCapNuoc>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Zalo")]
	public partial class Zalo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private decimal _IDZalo;
		
		private string _DanhBo;
		
		private string _HoTen;
		
		private string _DiaChi;
		
		private string _DienThoai;
		
		private string _KyHieuPhong;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDZaloChanging(decimal value);
    partial void OnIDZaloChanged();
    partial void OnDanhBoChanging(string value);
    partial void OnDanhBoChanged();
    partial void OnHoTenChanging(string value);
    partial void OnHoTenChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    partial void OnDienThoaiChanging(string value);
    partial void OnDienThoaiChanged();
    partial void OnKyHieuPhongChanging(string value);
    partial void OnKyHieuPhongChanged();
    partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateDateChanged();
    #endregion
		
		public Zalo()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDZalo", DbType="Decimal(20,0) NOT NULL", IsPrimaryKey=true)]
		public decimal IDZalo
		{
			get
			{
				return this._IDZalo;
			}
			set
			{
				if ((this._IDZalo != value))
				{
					this.OnIDZaloChanging(value);
					this.SendPropertyChanging();
					this._IDZalo = value;
					this.SendPropertyChanged("IDZalo");
					this.OnIDZaloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DanhBo", DbType="Char(11) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string DanhBo
		{
			get
			{
				return this._DanhBo;
			}
			set
			{
				if ((this._DanhBo != value))
				{
					this.OnDanhBoChanging(value);
					this.SendPropertyChanging();
					this._DanhBo = value;
					this.SendPropertyChanged("DanhBo");
					this.OnDanhBoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoTen", DbType="NVarChar(500)")]
		public string HoTen
		{
			get
			{
				return this._HoTen;
			}
			set
			{
				if ((this._HoTen != value))
				{
					this.OnHoTenChanging(value);
					this.SendPropertyChanging();
					this._HoTen = value;
					this.SendPropertyChanged("HoTen");
					this.OnHoTenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="NVarChar(500)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DienThoai", DbType="VarChar(10)")]
		public string DienThoai
		{
			get
			{
				return this._DienThoai;
			}
			set
			{
				if ((this._DienThoai != value))
				{
					this.OnDienThoaiChanging(value);
					this.SendPropertyChanging();
					this._DienThoai = value;
					this.SendPropertyChanged("DienThoai");
					this.OnDienThoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KyHieuPhong", DbType="VarChar(10)")]
		public string KyHieuPhong
		{
			get
			{
				return this._KyHieuPhong;
			}
			set
			{
				if ((this._KyHieuPhong != value))
				{
					this.OnKyHieuPhongChanging(value);
					this.SendPropertyChanging();
					this._KyHieuPhong = value;
					this.SendPropertyChanged("KyHieuPhong");
					this.OnKyHieuPhongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SuCoNgungCungCapNuoc")]
	public partial class SuCoNgungCungCapNuoc : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _NoiDung;
		
		private string _DanhBos;
		
		private string _DMAs;
		
		private System.Nullable<System.DateTime> _DateStart;
		
		private System.Nullable<System.DateTime> _DateEnd;
		
		private System.Nullable<int> _CreateBy;
		
		private System.DateTime _CreateDate;
		
		private System.Nullable<int> _ModifyBy;
		
		private System.Nullable<System.DateTime> _ModifyDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNoiDungChanging(string value);
    partial void OnNoiDungChanged();
    partial void OnDanhBosChanging(string value);
    partial void OnDanhBosChanged();
    partial void OnDMAsChanging(string value);
    partial void OnDMAsChanged();
    partial void OnDateStartChanging(System.Nullable<System.DateTime> value);
    partial void OnDateStartChanged();
    partial void OnDateEndChanging(System.Nullable<System.DateTime> value);
    partial void OnDateEndChanged();
    partial void OnCreateByChanging(System.Nullable<int> value);
    partial void OnCreateByChanged();
    partial void OnCreateDateChanging(System.DateTime value);
    partial void OnCreateDateChanged();
    partial void OnModifyByChanging(System.Nullable<int> value);
    partial void OnModifyByChanged();
    partial void OnModifyDateChanging(System.Nullable<System.DateTime> value);
    partial void OnModifyDateChanged();
    #endregion
		
		public SuCoNgungCungCapNuoc()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoiDung", DbType="NVarChar(200)")]
		public string NoiDung
		{
			get
			{
				return this._NoiDung;
			}
			set
			{
				if ((this._NoiDung != value))
				{
					this.OnNoiDungChanging(value);
					this.SendPropertyChanging();
					this._NoiDung = value;
					this.SendPropertyChanged("NoiDung");
					this.OnNoiDungChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DanhBos", DbType="VarChar(MAX)")]
		public string DanhBos
		{
			get
			{
				return this._DanhBos;
			}
			set
			{
				if ((this._DanhBos != value))
				{
					this.OnDanhBosChanging(value);
					this.SendPropertyChanging();
					this._DanhBos = value;
					this.SendPropertyChanged("DanhBos");
					this.OnDanhBosChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DMAs", DbType="VarChar(MAX)")]
		public string DMAs
		{
			get
			{
				return this._DMAs;
			}
			set
			{
				if ((this._DMAs != value))
				{
					this.OnDMAsChanging(value);
					this.SendPropertyChanging();
					this._DMAs = value;
					this.SendPropertyChanged("DMAs");
					this.OnDMAsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateStart", DbType="Date")]
		public System.Nullable<System.DateTime> DateStart
		{
			get
			{
				return this._DateStart;
			}
			set
			{
				if ((this._DateStart != value))
				{
					this.OnDateStartChanging(value);
					this.SendPropertyChanging();
					this._DateStart = value;
					this.SendPropertyChanged("DateStart");
					this.OnDateStartChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateEnd", DbType="Date")]
		public System.Nullable<System.DateTime> DateEnd
		{
			get
			{
				return this._DateEnd;
			}
			set
			{
				if ((this._DateEnd != value))
				{
					this.OnDateEndChanging(value);
					this.SendPropertyChanging();
					this._DateEnd = value;
					this.SendPropertyChanged("DateEnd");
					this.OnDateEndChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateBy", DbType="Int")]
		public System.Nullable<int> CreateBy
		{
			get
			{
				return this._CreateBy;
			}
			set
			{
				if ((this._CreateBy != value))
				{
					this.OnCreateByChanging(value);
					this.SendPropertyChanging();
					this._CreateBy = value;
					this.SendPropertyChanged("CreateBy");
					this.OnCreateByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyBy", DbType="Int")]
		public System.Nullable<int> ModifyBy
		{
			get
			{
				return this._ModifyBy;
			}
			set
			{
				if ((this._ModifyBy != value))
				{
					this.OnModifyByChanging(value);
					this.SendPropertyChanging();
					this._ModifyBy = value;
					this.SendPropertyChanged("ModifyBy");
					this.OnModifyByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ModifyDate
		{
			get
			{
				return this._ModifyDate;
			}
			set
			{
				if ((this._ModifyDate != value))
				{
					this.OnModifyDateChanging(value);
					this.SendPropertyChanging();
					this._ModifyDate = value;
					this.SendPropertyChanged("ModifyDate");
					this.OnModifyDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
