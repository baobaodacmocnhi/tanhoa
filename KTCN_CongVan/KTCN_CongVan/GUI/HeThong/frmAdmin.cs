using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTCN_CongVan.DAL.QuanTri;
using KTCN_CongVan.LinQ;

namespace KTCN_CongVan.GUI.HeThong
{
    public partial class frmAdmin : Form
    {
        CMenu _cMenu = new CMenu();
        CNhom _cNhom = new CNhom();
        CUser _cUser = new CUser();
        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
        CPhanQuyenUser _cPhanQuyenNguoiDung = new CPhanQuyenUser();

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
                    if (!_cMenu.checkExist(itemChild.Name))
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
                            phanquyennhom.IDMenu = menu.ID;
                            phanquyennhom.IDNhom = item.ID;
                            phanquyennhom.CreateBy = CUser.ID;
                            phanquyennhom.CreateDate = DateTime.Now;
                            menu.PhanQuyenNhoms.Add(phanquyennhom);
                        }
                        foreach (var item in _cUser.GetDS())
                        {
                            PhanQuyenUser phanquyennguoidung = new PhanQuyenUser();
                            phanquyennguoidung.IDMenu = menu.ID;
                            phanquyennguoidung.IDUser = item.ID;
                            phanquyennguoidung.CreateBy = CUser.ID;
                            phanquyennguoidung.CreateDate = DateTime.Now;
                            if (item.ID == 0)
                            {
                                phanquyennguoidung.Xem = true;
                                phanquyennguoidung.Them = true;
                                phanquyennguoidung.Sua = true;
                                phanquyennguoidung.Xoa = true;
                            }
                            menu.PhanQuyenUsers.Add(phanquyennguoidung);
                        }
                        _cMenu.Them(menu);
                    }
                    else
                    {
                        LinQ.Menu menu = _cMenu.get(itemChild.Name);
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
                    if (!_cPhanQuyenNhom.checkExist(itemMenu.ID, itemNhom.ID))
                    {
                        PhanQuyenNhom phanquyennhom = new PhanQuyenNhom();
                        phanquyennhom.IDMenu = itemMenu.ID;
                        phanquyennhom.IDNhom = itemNhom.ID;
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
                    if (!_cPhanQuyenNguoiDung.checkExist(itemMenu.ID, itemND.ID))
                    {
                        PhanQuyenUser phanquyennguoidung = new PhanQuyenUser();
                        phanquyennguoidung.IDMenu = itemMenu.ID;
                        phanquyennguoidung.IDUser = itemND.ID;
                        if (phanquyennguoidung.IDUser == 0)
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
                dgvResult.DataSource = _cUser.ExecuteQuery_DataTable(txtQuery.Text.Trim());
            }
        }
    }
}
