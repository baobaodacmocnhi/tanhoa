﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.KhachHang
{
    class CPhuongQuan
    {
        DB_CAPNUOCTANHOADataContext dbCAPNUOCTANHOA = new DB_CAPNUOCTANHOADataContext();

        /// <summary>
        /// Lấy Tên Phường & Quận của Danh Bộ
        /// </summary>
        /// <param name="MaQuan"></param>
        /// <param name="MaPhuong"></param>
        /// <returns></returns>
        public string getPhuongQuanByID(string MaQuan, string MaPhuong)
        {
            try
            {
                string Phuong = ", Phường " + dbCAPNUOCTANHOA.PHUONGs.Single(itemPhuong => itemPhuong.MAQUAN == int.Parse(MaQuan) && itemPhuong.MAPHUONG == MaPhuong).TENPHUONG;
                string Quan = ", Quận " + dbCAPNUOCTANHOA.QUANs.Single(itemQuan => itemQuan.MAQUAN == int.Parse(MaQuan)).TENQUAN;
                return Phuong + Quan;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
}
