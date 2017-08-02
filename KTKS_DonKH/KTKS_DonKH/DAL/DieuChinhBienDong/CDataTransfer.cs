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
        private string _MaDonMoi;
        private string _DanhBo;
        private string _HoTen;
        private string _DiaChi;
        private string _MaCT;
        private int _MaLCT;

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
        public string MaDonMoi
        {
            get { return _MaDonMoi; }
            set { _MaDonMoi = value; }
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

        public CDataTransfer()
        {
            _Loai = "";
            _MaDon = -1;
            _MaDonMoi = "";
            _DanhBo = "";
            _HoTen = "";
            _DiaChi = "";
            _MaCT = "";
            _MaLCT = -1;
        }
    }
}
