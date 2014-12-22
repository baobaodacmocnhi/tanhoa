using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;

namespace ThuTien.GUI.HeThong
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
            {
                int STT = 1;
                if (itemParent.Name == "mnuHeThong")
                    continue;
                foreach (ToolStripMenuItem itemChild in itemParent.DropDownItems)
                {
                    if (!_cMenu.CheckExistByTenMenu(itemChild.Name))
                    {
                        TT_Menu menu = new TT_Menu();
                        menu.STT = STT++;
                        menu.TenMenu = itemChild.Name;
                        menu.TextMenu = itemChild.Text;
                        menu.TenMenuCha = itemParent.Name;
                        menu.TextMenuCha = itemParent.Text;
                        foreach (var item in _cNhom.GetDSNhom())
                        {
                            TT_PhanQuyenNhom phanquyennhom = new TT_PhanQuyenNhom();
                            phanquyennhom.MaMenu = menu.MaMenu;
                            phanquyennhom.MaNhom = item.MaNhom;
                            menu.TT_PhanQuyenNhoms.Add(phanquyennhom);
                        }
                        foreach (var item in _cNguoiDung.GetDSNguoiDung())
                        {
                            TT_PhanQuyenNguoiDung phanquyennguoidung = new TT_PhanQuyenNguoiDung();
                            phanquyennguoidung.MaMenu = menu.MaMenu;
                            phanquyennguoidung.MaND = item.MaND;
                            menu.TT_PhanQuyenNguoiDungs.Add(phanquyennguoidung);
                        }
                        _cMenu.Them(menu);
                    }
                    else
                    {
                        TT_Menu menu = _cMenu.GetMenuByTenMenu(itemChild.Name);
                        menu.STT = STT++;
                        _cMenu.Sua(menu);
                    }
                }
                     
            }
            
        }

        private void btnCapNhatPhanQuyenNhom_Click(object sender, EventArgs e)
        {
            foreach (var itemMenu in _cMenu.GetDSMenu())
            {
                foreach (var itemNhom in _cNhom.GetDSNhom())
                {
                    if (!_cPhanQuyenNhom.CheckPhanQuyenNhomByMaMenuMaNhom(itemMenu.MaMenu, itemNhom.MaNhom))
                    {
                        TT_PhanQuyenNhom phanquyennhom = new TT_PhanQuyenNhom();
                        phanquyennhom.MaMenu = itemMenu.MaMenu;
                        phanquyennhom.MaNhom = itemNhom.MaNhom;
                        _cPhanQuyenNhom.Them(phanquyennhom);
                    }
                }
            }
        }

        private void btnCapNhatPhanQuyenNguoiDung_Click(object sender, EventArgs e)
        {
            foreach (var itemMenu in _cMenu.GetDSMenu())
            {
                foreach (var itemND in _cNguoiDung.GetDSNguoiDung())
                {
                    if (!_cPhanQuyenNguoiDung.CheckPhanQuyenNguoiDungByMaMenuMaND(itemMenu.MaMenu, itemND.MaND))
                    {
                        TT_PhanQuyenNguoiDung phanquyennguoidung = new TT_PhanQuyenNguoiDung();
                        phanquyennguoidung.MaMenu = itemMenu.MaMenu;
                        phanquyennguoidung.MaND = itemND.MaND;
                        _cPhanQuyenNguoiDung.Them(phanquyennguoidung);
                    }
                }
            }
        }
    }
}
