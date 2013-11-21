using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CGiaNuoc : CDAL
    {
        public List<GiaNuoc> LoadDSGiaNuoc()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    return db.GiaNuocs.ToList();
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemGiaNuoc(GiaNuoc gianuoc)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    if (db.GiaNuocs.Count() > 0)
                        gianuoc.MaGN = db.GiaNuocs.Max(itemGN => itemGN.MaGN) + 1;
                    else
                        gianuoc.MaGN = 1;
                    gianuoc.CreateDate = DateTime.Now;
                    gianuoc.CreateBy = CTaiKhoan.TaiKhoan;
                    db.GiaNuocs.InsertOnSubmit(gianuoc);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaGiaNuoc(GiaNuoc gianuoc)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    gianuoc.ModifyDate = DateTime.Now;
                    gianuoc.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public GiaNuoc getGiaNuocbyID(int MaGN)
        {
            try
            {
                return db.GiaNuocs.Single(itemGN => itemGN.MaGN == MaGN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int TinhTienNuoc(int GiaBieu, int DinhMuc, int TieuThu)
        {
            try
            {
                int TongTien = 0;
                switch (GiaBieu)
                {
                    ///TƯ GIA
                    case 11:///SH thuần túy

                        break;
                    case 12:///SX thuần túy

                        break;
                    case 13:///DV thuần túy

                        break;
                    case 14:///SH + SX

                        break;
                    case 15:///SH + DV

                        break;
                    case 16:///SH + SX + DV

                        break;
                    case 17:///SH ĐB

                        break;
                    case 18:///SH + HCSN

                        break;
                    case 19:///SH + HCSN + SX + DV

                        break;
                    ///TẬP THỂ
                    case 21:///SH thuần túy

                        break;
                    case 22:///SX thuần túy

                        break;
                    case 23:///DV thuần túy

                        break;
                    case 24:///SH + SX

                        break;
                    case 25:///SH + DV

                        break;
                    case 26:///SH + SX + DV

                        break;
                    case 27:///SH ĐB

                        break;
                    case 28:///SH + HCSN

                        break;
                    case 29:///SH + HCSN + SX + DV

                        break;
                    ///CƠ QUAN
                    case 31:///SHVM thuần túy

                        break;
                    case 32:///SX

                        break;
                    case 33:///DV

                        break;
                    case 34:///HCSN + SX

                        break;
                    case 35:///HCSN + DV

                        break;
                    case 36:///HCSN + SX + DV

                        break;
                    case 38:///SH + HCSN

                        break;
                    case 39:///SH + HCSN + SX + DV

                        break;
                    ///NƯỚC NGOÀI
                    case 41:///SHVM thuần túy

                        break;
                    case 42:///SX

                        break;
                    case 43:///DV

                        break;
                    case 44:///SH + SX

                        break;
                    case 45:///SH + DV

                        break;
                    case 46:///SH + SX + DV

                        break;
                    ///BÁN SỈ
                    case 51:///sỉ khu dân cư

                        break;
                    case 52:///sỉ khu công nghiệp

                        break;
                    case 53:///sỉ KD - TM

                        break;
                    case 54:///sỉ HCSN

                        break;
                    case 59:///sỉ phức tạp

                        break;
                    case 68:///SH giá sỉ - KD giá lẻ

                        break;
                }
                return TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
