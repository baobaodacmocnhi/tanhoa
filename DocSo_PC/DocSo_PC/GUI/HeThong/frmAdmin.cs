using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;

namespace DocSo_PC.GUI.HeThong
{
    public partial class frmAdmin : Form
    {
        CMenu _cMenu = new CMenu();
        CNhom _cNhom = new CNhom();
        CNguoiDung _cNguoiDung = new CNguoiDung();
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
                if (itemParent.Visible == true)
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
                                phanquyennhom.CreateBy = CNguoiDung.MaND;
                                phanquyennhom.CreateDate = DateTime.Now;
                                menu.PhanQuyenNhoms.Add(phanquyennhom);
                            }
                            foreach (var item in _cNguoiDung.GetDS())
                            {
                                PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                                phanquyennguoidung.MaMenu = menu.MaMenu;
                                phanquyennguoidung.MaND = item.MaND;
                                phanquyennguoidung.CreateBy = CNguoiDung.MaND;
                                phanquyennguoidung.CreateDate = DateTime.Now;
                                if (item.MaND == 0)
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
                foreach (var itemND in _cNguoiDung.GetDS())
                {
                    if (!_cPhanQuyenNguoiDung.CheckByMaMenuMaND(itemMenu.MaMenu, itemND.MaND))
                    {
                        PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                        phanquyennguoidung.MaMenu = itemMenu.MaMenu;
                        phanquyennguoidung.MaND = itemND.MaND;
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

        private void txtQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvResult.DataSource = CNguoiDung._cDAL.ExecuteQuery_SqlDataAdapter_DataTable(txtQuery.Text.Trim());
            }
        }
    }
}
