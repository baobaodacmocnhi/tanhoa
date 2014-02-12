using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraBars.Helpers;
using KTKS_DonKH.GUI.HeThong;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XmlDocument data = new XmlDocument();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            SkinHelper.InitSkinPopupMenu(barSubItem_Giaodien);
            barbtnDangNhap.PerformClick();
        }

        public void GetLoginResult(bool result)
        {
            if (result)
            {
                barbtnDangNhap.Enabled = false;
                barbtnDangXuat.Enabled = true;
                barbtnDoiMatKhau.Enabled = true;
                
            }
        }

        private void barbtnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.GetLoginResult = new frmDangNhap.GetValue(GetLoginResult);
            frm.ShowDialog();
        }

        private void barbtnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTaiKhoan _CTaiKhoan = new CTaiKhoan();
            _CTaiKhoan.DangXuat();

            barbtnDangNhap.Enabled = true;
            barbtnDangXuat.Enabled = false;
            barbtnDoiMatKhau.Enabled = false;
            barbtnDangNhap_ItemClick(sender, e);
        }

        private void barbtnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        /// <summary>
        /// Kiểm tra tabpage có tồn tại hay không.
        /// </summary>
        /// <param name="tabControlName">Tên tabControl để kiểm tra.</param>
        /// <param name="tabName">Tên tabpage cần kiểm tra.</param>
        /// <returns></returns>
        private int KiemTraTonTai(DevExpress.XtraTab.XtraTabControl tabControlName, string tabName)
        {
            int re = -1;
            for (int i = 0; i < tabControlName.TabPages.Count; i++)
            {
                if (tabControlName.TabPages[i].Name == tabName)
                {
                    re = i;
                    break;
                }
            }
            return re;
        }

        /// <summary>
        /// Tạo thêm tab mới
        /// </summary>
        /// <param name="tabControl">Tên TabControl để add thêm tabpage mới vào</param>
        /// <param name="Text">Tiêu đề tabpage mới</param>
        /// <param name="Name">Tên tabpage mới</param>
        /// <param name="form">Tên form con của tab mới</param>
        /// <param name="imageIndex">index của icon</param>
        public void TabCreating(DevExpress.XtraTab.XtraTabControl tabControl, string Text, string Name, System.Windows.Forms.Form form)
        {
            int index = KiemTraTonTai(tabControl, Name);
            if (index >= 0)
            {
                tabControl.SelectedTabPage = tabControl.TabPages[index];
                tabControl.SelectedTabPage.Text = Text;
            }
            else
            {
                DevExpress.XtraTab.XtraTabPage tabpage = new DevExpress.XtraTab.XtraTabPage { Text = Text, Name = Name };
                tabControl.TabPages.Add(tabpage);
                tabControl.SelectedTabPage = tabpage;

                form.TopLevel = false;
                form.Parent = tabpage;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void barbtnTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTaiKhoan frm = new frmTaiKhoan();
            TabCreating(TabControl, frm.Text, frm.Name, frm);
        }
    }
}
