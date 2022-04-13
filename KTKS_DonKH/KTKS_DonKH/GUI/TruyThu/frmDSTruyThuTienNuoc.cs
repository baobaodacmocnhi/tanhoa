using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.TruyThu;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.TruyThu
{
    public partial class frmDSTruyThuTienNuoc : Form
    {
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();

        public frmDSTruyThuTienNuoc()
        {
            InitializeComponent();
        }

        private void frmQLTruyThuTienNuoc_Load(object sender, EventArgs e)
        {
            dgvDSTruyThuTienNuoc.AutoGenerateColumns = false;
            cmbTimTheo.SelectedItem = "Ngày";
        }

        private void CountdgvDSTruyThuTienNuoc()
        {
            int Tongm3 = 0;
            long TongTien = 0;
            foreach (DataGridViewRow item in dgvDSTruyThuTienNuoc.Rows)
            {
                if (item.Cells["Tongm3"].Value.ToString()!="")
                Tongm3 += int.Parse(item.Cells["Tongm3"].Value.ToString());
                TongTien += long.Parse(item.Cells["TongTien"].Value.ToString());
            }
            txtTongm3.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Tongm3);
            txtTongTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTien);
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Số Phiếu":
                    txtNoiDungTimKiem.Visible = true;
                    //txtNoiDungTimKiem2.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Danh Bộ":
                case "Số Tiền":
                    txtNoiDungTimKiem.Visible = true;
                    //txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvDSTruyThuTienNuoc.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (radTruyThu.Checked == true)
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Số Phiếu":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSTruyThuTienNuoc.DataSource = _cTTTN.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                        break;
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSTruyThuTienNuoc.DataSource = _cTTTN.getDS(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                        break;
                    case "Ngày":
                        dgvDSTruyThuTienNuoc.DataSource = _cTTTN.getDS(dateTu.Value, dateDen.Value);
                        break;
                    case "Số Tiền":
                        dgvDSTruyThuTienNuoc.DataSource = _cTTTN.getDS_SoTien(int.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                        break;
                    default:
                        break;
                }
            else
                if (radThuMoi.Checked == true)
                    dgvDSTruyThuTienNuoc.DataSource = _cTTTN.getDS_ThuMoi(dateTu.Value, dateDen.Value);
            CountdgvDSTruyThuTienNuoc();
        }

        private void dgvDSTruyThuTienNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "MaDon")
            //{
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "IDCT" && e.Value != null && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "Tongm3")
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dgvDSTruyThuTienNuoc["Tongm3", e.RowIndex].Value.ToString()));
            }
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TongTien")
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dgvDSTruyThuTienNuoc["TongTien", e.RowIndex].Value.ToString()));
            }
        }

        private void dgvDSTruyThuTienNuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSTruyThuTienNuoc.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmTruyThuTienNuoc frm = new frmTruyThuTienNuoc(int.Parse(dgvDSTruyThuTienNuoc["IDCT", dgvDSTruyThuTienNuoc.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void dgvDSTruyThuTienNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSTruyThuTienNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataGridViewRow item in dgvDSTruyThuTienNuoc.Rows)
            {
                DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["MaDon"] = item.Cells["MaDon"].Value.ToString();
                dr["SoCongVan"] = item.Cells["SoCongVan"].Value;
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["NoiDung"] = item.Cells["NoiDung"].Value;

                dr["TieuThuMoi"] = item.Cells["Tongm3"].Value.ToString();
                dr["TongCongMoi"] = item.Cells["TongTien"].Value.ToString();
                dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
            }

            rptDSTruyThuTienNuoc rpt = new rptDSTruyThuTienNuoc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
                for (int i = 0; i < dgvDSTruyThuTienNuoc.Rows.Count; i++)
                {
                    dgvDSTruyThuTienNuoc["In", i].Value = true;
                }
            else
                for (int i = 0; i < dgvDSTruyThuTienNuoc.Rows.Count; i++)
                {
                    dgvDSTruyThuTienNuoc["In", i].Value = false;
                }
        }

        private void btnInNhan_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao1 = new DataSetBaoCao();
            DataSetBaoCao dsBaoCao2 = new DataSetBaoCao();
            bool flag = true;///in 2 bên

            for (int i = 0; i < dgvDSTruyThuTienNuoc.Rows.Count; i++)
                if (dgvDSTruyThuTienNuoc["In", i].Value != null && bool.Parse(dgvDSTruyThuTienNuoc["In", i].Value.ToString()) == true)
                    if (flag == true)
                    {
                        DataRow dr = dsBaoCao1.Tables["ThaoThuTraLoi"].NewRow();

                        //TTTL_ChiTiet cttttl = _cTTTL.GetCT(decimal.Parse(dgvDSTruyThuTienNuoc["MaCTTTTL", i].Value.ToString()));

                        dr["DanhBo"] = dgvDSTruyThuTienNuoc["DanhBo", i].Value.ToString();
                        dr["HoTen"] = dgvDSTruyThuTienNuoc["HoTen", i].Value.ToString();
                        dr["DiaChi"] = dgvDSTruyThuTienNuoc["DiaChi", i].Value.ToString();
                        dr["SoPhieu"] = dgvDSTruyThuTienNuoc["DienThoai", i].Value.ToString();

                        dsBaoCao1.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                        flag = false;
                    }
                    else
                    {
                        DataRow dr = dsBaoCao2.Tables["ThaoThuTraLoi"].NewRow();

                        //TTTL_ChiTiet cttttl = _cTTTL.GetCT(decimal.Parse(dgvDSTruyThuTienNuoc["MaCTTTTL", i].Value.ToString()));

                        dr["DanhBo"] = dgvDSTruyThuTienNuoc["DanhBo", i].Value.ToString();
                        dr["HoTen"] = dgvDSTruyThuTienNuoc["HoTen", i].Value.ToString();
                        dr["DiaChi"] = dgvDSTruyThuTienNuoc["DiaChi", i].Value.ToString();
                        dr["SoPhieu"] = dgvDSTruyThuTienNuoc["DienThoai", i].Value.ToString();

                        dsBaoCao2.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                        flag = true;
                    }
            rptKinhGui rpt = new rptKinhGui();
            rpt.Subreports[0].SetDataSource(dsBaoCao1);
            rpt.Subreports[1].SetDataSource(dsBaoCao2);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void txtNoiDungTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtNoiDungTimKiem.Text.Trim() != "")
                btnXem.PerformClick();
        }


    }
}
