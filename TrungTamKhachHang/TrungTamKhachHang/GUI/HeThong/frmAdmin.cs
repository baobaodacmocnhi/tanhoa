using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrungTamKhachHang.DAL.QuanTri;
using TrungTamKhachHang.LinQ;

namespace TrungTamKhachHang.GUI.HeThong
{
    public partial class frmAdmin : Form
    {
        CMenu _cMenu = new CMenu();
        CNhom _cNhom = new CNhom();
        CUser _cUser = new CUser();
        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
        CPhanQuyenUser _cPhanQuyenUser = new CPhanQuyenUser();

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
                    if (_cMenu.CheckExist(itemChild.Name)==false)
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
                            phanquyennhom.MaMenu = menu.ID;
                            phanquyennhom.MaNhom = item.ID;
                            phanquyennhom.CreateBy = CUser.MaUser;
                            phanquyennhom.CreateDate = DateTime.Now;
                            menu.PhanQuyenNhoms.Add(phanquyennhom);
                        }
                        foreach (var item in _cUser.GetDS())
                        {
                            PhanQuyenUser phanquyenuser = new PhanQuyenUser();
                            phanquyenuser.MaMenu = menu.ID;
                            phanquyenuser.MaUser = item.ID;
                            phanquyenuser.CreateBy = CUser.MaUser;
                            phanquyenuser.CreateDate = DateTime.Now;
                            if (item.ID == 0)
                            {
                                phanquyenuser.Xem = true;
                                phanquyenuser.Them = true;
                                phanquyenuser.Sua = true;
                                phanquyenuser.Xoa = true;
                            }
                            menu.PhanQuyenUsers.Add(phanquyenuser);
                        }
                        _cMenu.Them(menu);
                    }
                    else
                    {
                        LinQ.Menu menu = _cMenu.Get(itemChild.Name);
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
                    if (!_cPhanQuyenNhom.CheckExist(itemMenu.ID, itemNhom.ID))
                    {
                        PhanQuyenNhom phanquyennhom = new PhanQuyenNhom();
                        phanquyennhom.MaMenu = itemMenu.ID;
                        phanquyennhom.MaNhom = itemNhom.ID;
                        _cPhanQuyenNhom.Them(phanquyennhom);
                    }
                }
            }
        }

        private void btnCapNhatPhanQuyenNguoiDung_Click(object sender, EventArgs e)
        {
            foreach (var itemMenu in _cMenu.GetDS())
            {
                foreach (var itemND in _cUser.GetDS())
                {
                    if (_cPhanQuyenUser.CheckExist(itemMenu.ID, itemND.ID) == false)
                    {
                        PhanQuyenUser phanquyenuser = new PhanQuyenUser();
                        phanquyenuser.MaMenu = itemMenu.ID;
                        phanquyenuser.MaUser = itemND.ID;
                        if (phanquyenuser.MaUser == 0)
                        {
                            phanquyenuser.Xem = true;
                            phanquyenuser.Them = true;
                            phanquyenuser.Sua = true;
                            phanquyenuser.Xoa = true;
                        }
                        _cPhanQuyenUser.Them(phanquyenuser);
                    }
                }
            }
        }

        private void txtQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvResult.DataSource = _cUser.ExecuteQuery_DataTable(txtQuery.Text.Trim());
            }
        }
    }
}
