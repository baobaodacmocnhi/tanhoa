using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    public class CDataTransfer
    {
        private string _Loai;
        private decimal _MaDon;
        private int _MaDonMoi;
        private int _STT;
        private string _DanhBo;
        private string _HoTen;
        private string _DiaChi;
        private string _MaCT;
        private int _MaLCT;
        private string _Quan;
        private string _Phuong;

        public string Loai
        {
            get { return _Loai; }
            set { _Loai = value; }
        }
        public decimal MaDon
        {
            get { return _MaDon; }
            set { _MaDon = value; }
        }
        public int MaDonMoi
        {
            get { return _MaDonMoi; }
            set { _MaDonMoi = value; }
        }
        public int STT
        {
            get { return _STT; }
            set { _STT = value; }
        }
        public string DanhBo
        {
            get { return _DanhBo; }
            set { _DanhBo = value; }
        }
        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        public string MaCT
        {
            get { return _MaCT; }
            set { _MaCT = value; }
        }
        public int MaLCT
        {
            get { return _MaLCT; }
            set { _MaLCT = value; }
        }
        public string Quan
        {
            get { return _Quan; }
            set { _Quan = value; }
        }
        public string Phuong
        {
            get { return _Phuong; }
            set { _Phuong = value; }
        }

        public CDataTransfer()
        {
            _Loai = "";
            _MaDon = -1;
            _MaDonMoi = -1;
            _STT = -1;
            _DanhBo = "";
            _HoTen = "";
            _DiaChi = "";
            _MaCT = "";
            _MaLCT = -1;
            _Quan = "";
            _Phuong = "";
        }
    }
}
