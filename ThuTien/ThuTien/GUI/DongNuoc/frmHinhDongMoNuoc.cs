using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ThuTien.DAL.DongNuoc;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmHinhDongMoNuoc : Form
    {
        string _mnu = "mnuKQDongNuoc";
        string Loai = "";
        TT_KQDongNuoc _kqdongnuoc = null;
        CDongNuoc _cDongNuoc = new CDongNuoc();
        //string _pathHinh = @"\\rackstation\HinhDHN\ThuTien";
        wrThuTien.wsThuTien _wsThuTien = new wrThuTien.wsThuTien();

        public frmHinhDongMoNuoc()
        {
            InitializeComponent();
        }

        public frmHinhDongMoNuoc(string Loai, TT_KQDongNuoc kqdongnuoc)
        {
            InitializeComponent();
            this.Loai = Loai;
            _kqdongnuoc = kqdongnuoc;
        }

        private void frmHinhDongMoNuoc_Load(object sender, EventArgs e)
        {
            loaddgvHinh();
        }

        public void loaddgvHinh()
        {
            if (_kqdongnuoc != null)
            {
                dgvHinh.Rows.Clear();
                List<TT_KQDongNuoc_Hinh> lst = new List<TT_KQDongNuoc_Hinh>();
                switch (Loai)
                {
                    case "DongNuoc":
                        lst = _kqdongnuoc.TT_KQDongNuoc_Hinhs.Where(item => item.DongNuoc == true).ToList();
                        break;
                    case "DongNuoc2":
                        lst = _kqdongnuoc.TT_KQDongNuoc_Hinhs.Where(item => item.DongNuoc2 == true).ToList();
                        break;
                    case "MoNuoc":
                        lst = _kqdongnuoc.TT_KQDongNuoc_Hinhs.Where(item => item.MoNuoc == true).ToList();
                        break;
                    default:
                        break;
                }
                foreach (TT_KQDongNuoc_Hinh item in lst)
                {
                    var index = dgvHinh.Rows.Add();
                    byte[] bytes = null;
                    //if (item.Hinh == null)
                    //    switch (Loai)
                    //    {
                    //        case "DongNuoc":
                    //            bytes = item.HinhDN.ToArray();
                    //            break;
                    //        case "DongNuoc2":
                    //            bytes = item.HinhDN1.ToArray();
                    //            break;
                    //        case "MoNuoc":
                    //            bytes = item.HinhMN.ToArray();
                    //            break;
                    //        default:
                    //            break;
                    //    }
                    //else
                    //    bytes = item.Hinh.ToArray();
                    bytes = _wsThuTien.get_Hinh_ThuTien("DongNuoc", _kqdongnuoc.MaKQDN.ToString(), item.ID + ".jpg");
                    MemoryStream ms = new MemoryStream(bytes);
                    Image img = Image.FromStream(ms);
                    dgvHinh.Rows[index].Cells["ID"].Value = item.ID;
                    dgvHinh.Rows[index].Cells["Hinh"].Value = img;
                    dgvHinh.Rows[index].Cells["Bytes"].Value = Convert.ToBase64String(bytes);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_kqdongnuoc != null)
                    if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                    {
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                        dialog.Multiselect = false;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            byte[] bytes = System.IO.File.ReadAllBytes(dialog.FileName);
                            MemoryStream ms = new MemoryStream(bytes);
                            Image img = Image.FromStream(ms);

                            //var index = dgvHinh.Rows.Add();
                            //dgvHinh.Rows[index].Cells["Hinh"].Value = img;
                            //dgvHinh.Rows[index].Cells["Bytes"].Value = Convert.ToBase64String(bytes);

                            TT_KQDongNuoc_Hinh en = new TT_KQDongNuoc_Hinh();
                            en.MaKQDN = _kqdongnuoc.MaKQDN;
                            //en.Hinh = bytes;
                            switch (Loai)
                            {
                                case "DongNuoc":
                                    en.DongNuoc = true;
                                    break;
                                case "DongNuoc2":
                                    en.DongNuoc2 = true;
                                    break;
                                case "MoNuoc":
                                    en.MoNuoc = true;
                                    break;
                                default:
                                    break;
                            }
                            if (_cDongNuoc.ThemKQ_Hinh(en) == true)
                            {
                                _wsThuTien.ghi_Hinh_ThuTien("DongNuoc", _kqdongnuoc.MaKQDN.ToString(), en.ID + ".jpg", bytes);
                                _kqdongnuoc.TT_KQDongNuoc_Hinhs.Add(en);
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loaddgvHinh();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _cDongNuoc.viewImage(Convert.FromBase64String(dgvHinh.CurrentRow.Cells["Bytes"].Value.ToString()));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (_kqdongnuoc != null)
                    if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            if (_cDongNuoc.XoaKQ_Hinh(_cDongNuoc.getHinh(int.Parse(dgvHinh.CurrentRow.Cells["ID"].Value.ToString()))) == true)
                            {
                                _wsThuTien.xoa_Hinh_ThuTien("DongNuoc", _kqdongnuoc.MaKQDN.ToString(), dgvHinh.CurrentRow.Cells["ID"].Value.ToString() + ".jpg");
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loaddgvHinh();
                            }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
