using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.VanThu;
using DocSo_PC.DAL;
using DocSo_PC.DAL.QuanTri;
using System.Drawing.Drawing2D;

namespace DocSo_PC.GUI.VanThu
{
    public partial class frmShowCongVan : Form
    {
        string _mnu = "mnuCongVanDen";
        CongVanDen _enCVD = null;
        CCongVanDen _cCVD = new CCongVanDen();
        CThuongVu _cThuongVu = new CThuongVu();
        Image image1;

        public frmShowCongVan(string TableName, int IDCT)
        {
            InitializeComponent();
            _enCVD = _cCVD.get(TableName, IDCT);
        }

        private void frmShowCongVan_Load(object sender, EventArgs e)
        {
            try
            {
                if (_enCVD != null)
                {
                    object image = null;
                    //switch (_enCVD.TableName)
                    //{
                    //    //case "KTXM_ChiTiet":
                    //    //    image = _cThuongVu.getHinh_KTXM(_enCVD.IDCT.Value);
                    //    //    break;
                    //    //case "ToTrinh_ChiTiet":
                    //    //    image = _cThuongVu.getHinh_ToTrinh(_enCVD.IDCT.Value);
                    //    //    break;
                    //}
                    if (image != null)
                        //pictureBox.Image = _cCVD.byteArrayToImage((byte[])image);
                        image1 = _cCVD.byteArrayToImage((byte[])image);
                    else
                        MessageBox.Show("Không có File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkTinhTieuThu.Checked = _enCVD.TinhTieuThu;
                    //chkBaoThay.Checked = _enCVD.BaoThay;
                    //chkBaoThayThu.Checked = _enCVD.BaoThayThu;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_enCVD != null)
                    {
                        _enCVD.TinhTieuThu = chkTinhTieuThu.Checked;
                        //_enCVD.BaoThay = chkBaoThay.Checked;
                        //_enCVD.BaoThayThu = chkBaoThayThu.Checked;
                        if (_cCVD.Sua(_enCVD) == true)
                            this.Close();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Matrix transform;
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (image1 != null)
            {
                var g = e.Graphics;
                if (transform != null)
                    g.Transform = transform;
                e.Graphics.DrawImage(image1, 0, 0, pictureBox.Width, pictureBox.Height);
            }
        }

        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            pictureBox.Focus();
            if (pictureBox.Focused == true && e.Delta != 0)
            {
                // Map the Form-centric mouse location to the PictureBox client coordinate system
                Point pictureBoxPoint = pictureBox.PointToClient(PointToScreen(e.Location));
                transform = ImageUtil.ZoomScroll(pictureBoxPoint, e.Delta > 0);
                if (transform != null)
                    pictureBox.Invalidate();
            }
        }

        bool mDown = false;
        Point location = new Point();
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mDown = true;
            location.X = e.X;
            location.Y = e.Y;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mDown = false;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mDown)
            {
                var dX = e.X - location.X;
                var dY = e.Y - location.Y;
                location.X = e.X;
                location.Y = e.Y;
                transform = ImageUtil.DragScroll(dX, dY);
                if (transform != null)
                    pictureBox.Invalidate();
            }
        }
    }
}
