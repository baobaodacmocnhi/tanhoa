using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.HeThong
{
    public partial class frmAdmin : Form
    {
        CMenu _cMenu = new CMenu();
        CNhom _cNhom = new CNhom();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
        CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnCapNhatMenu_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            foreach (ToolStripMenuItem itemParent in frm.MainMenuStrip.Items)
            {
                int STT = 1;
                if (itemParent.Name == "mnuHeThong")
                    continue;
                foreach (ToolStripMenuItem itemChild in itemParent.DropDownItems)
                {
                    if (!_cMenu.CheckExistByTenMenu(itemChild.Name))
                    {
                        LinQ.Menu menu = new LinQ.Menu();
                        menu.STT = STT++;
                        menu.TenMenu = itemChild.Name;
                        menu.TextMenu = itemChild.Text;
                        menu.TenMenuCha = itemParent.Name;
                        menu.TextMenuCha = itemParent.Text;
                        foreach (var item in _cNhom.GetDS())
                        {
                            PhanQuyenNhom phanquyennhom = new PhanQuyenNhom();
                            phanquyennhom.MaMenu = menu.MaMenu;
                            phanquyennhom.MaNhom = item.MaNhom;
                            phanquyennhom.CreateBy = CTaiKhoan.MaUser;
                            phanquyennhom.CreateDate = DateTime.Now;
                            menu.PhanQuyenNhoms.Add(phanquyennhom);
                        }
                        foreach (var item in _cTaiKhoan.GetDS())
                        {
                            PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                            phanquyennguoidung.MaMenu = menu.MaMenu;
                            phanquyennguoidung.MaND = item.MaU;
                            phanquyennguoidung.CreateBy = CTaiKhoan.MaUser;
                            phanquyennguoidung.CreateDate = DateTime.Now;
                            if (item.MaU == 0)
                            {
                                phanquyennguoidung.Xem = true;
                                phanquyennguoidung.Them = true;
                                phanquyennguoidung.Sua = true;
                                phanquyennguoidung.Xoa = true;
                            }
                            menu.PhanQuyenNguoiDungs.Add(phanquyennguoidung);
                        }
                        _cMenu.Them(menu);
                    }
                    else
                    {
                        LinQ.Menu menu = _cMenu.GetByTenMenu(itemChild.Name);
                        menu.STT = STT++;
                        _cMenu.Sua(menu);
                    }
                }

            }
        }

        private void txtQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvResult.DataSource = _cMenu.ExecuteQuery_DataTable(txtQuery.Text.Trim());
            }
        }

        private void btnCapNhatPhanQuyenNhom_Click(object sender, EventArgs e)
        {
            foreach (var itemMenu in _cMenu.GetDS())
            {
                foreach (var itemNhom in _cNhom.GetDS())
                {
                    if (!_cPhanQuyenNhom.CheckByMaMenuMaNhom(itemMenu.MaMenu, itemNhom.MaNhom))
                    {
                        PhanQuyenNhom phanquyennhom = new PhanQuyenNhom();
                        phanquyennhom.MaMenu = itemMenu.MaMenu;
                        phanquyennhom.MaNhom = itemNhom.MaNhom;
                        _cPhanQuyenNhom.Them(phanquyennhom);
                    }
                }
            }
        }

        private void btnCapNhatPhanQuyenNguoiDung_Click(object sender, EventArgs e)
        {
            foreach (var itemMenu in _cMenu.GetDS())
            {
                foreach (var itemND in _cTaiKhoan.GetDS())
                {
                    if (!_cPhanQuyenNguoiDung.CheckByMaMenuMaND(itemMenu.MaMenu, itemND.MaU))
                    {
                        PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                        phanquyennguoidung.MaMenu = itemMenu.MaMenu;
                        phanquyennguoidung.MaND = itemND.MaU;
                        if (phanquyennguoidung.MaND == 0)
                        {
                            phanquyennguoidung.Xem = true;
                            phanquyennguoidung.Them = true;
                            phanquyennguoidung.Sua = true;
                            phanquyennguoidung.Xoa = true;
                        }
                        _cPhanQuyenNguoiDung.Them(phanquyennguoidung);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wsThuongVu.wsThuongVu ws = new wsThuongVu.wsThuongVu();
            DataTable dt = _cMenu.ExecuteQuery_DataTable(textBox1.Text.Trim());
            foreach (DataRow item in dt.Rows)
            {
                DataTable dtt = _cMenu.ExecuteQuery_DataTable("select Hinh from " + item["TableName"].ToString() + " where ID=" + item["ID"].ToString());
                if (ws.ghi_Hinh(item["TableName"].ToString(), item["IDCT"].ToString(), item["Name"].ToString() + ".jpg", (byte[])dtt.Rows[0]["Hinh"]) == true)
                    _cMenu.ExecuteNonQuery("update " + item["TableName"].ToString() + " set Loai=1 where ID=" + item["ID"].ToString());
            }
            MessageBox.Show("Thành Công");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wsThuongVu.wsThuongVu ws = new wsThuongVu.wsThuongVu();
            DataTable dt = _cMenu.ExecuteQuery_DataTable(textBox1.Text.Trim());
            foreach (DataRow item in dt.Rows)
            {
                DataTable dtt = _cMenu.ExecuteQuery_DataTable("select Hinh from " + item["TableName"].ToString() + " where ID=" + item["ID"].ToString());
                System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])dtt.Rows[0]["Hinh"]);
                Image image = Image.FromStream(ms);
                Bitmap resizedImage = _cMenu.resizeImage(image, 0.5m);
                ImageConverter converter = new ImageConverter();
                byte[] hinh = (byte[])converter.ConvertTo(resizedImage, typeof(byte[]));
                
                if (ws.ghi_Hinh(item["TableName"].ToString(), item["IDCT"].ToString(), item["Name"].ToString() + ".jpg", hinh) == true)
                    _cMenu.ExecuteNonQuery("update " + item["TableName"].ToString() + " set Loai=1 where ID=" + item["ID"].ToString());
            }
            MessageBox.Show("Thành Công");
        }
    }
}
