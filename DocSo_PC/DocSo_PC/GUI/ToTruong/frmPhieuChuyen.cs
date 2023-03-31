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
using DocSo_PC.DAL;
using DocSo_PC.BaoCao;
using DocSo_PC.BaoCao.ToTruong;
using DocSo_PC.GUI.BaoCao;
using DocSo_PC.DAL.Doi;
using DocSo_PC.DAL.MaHoa;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmPhieuChuyen : Form
    {
        string _mnu = "mnuPhieuChuyen";
        CTo _cTo = new CTo();
        CDHN _cDHN = new CDHN();
        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        CPhieuChuyen _cPhieuChuyen = new CPhieuChuyen();
        CDonTu _cDonTu = new CDonTu();
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();

        public frmPhieuChuyen()
        {
            InitializeComponent();
        }

        private void frmPhieuChuyen_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvBaoCao.AutoGenerateColumns = false;
            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;
                List<To> lst = _cTo.getDS_HanhThu();
                To en = new To();
                en.MaTo = 0;
                en.TenTo = "Tất Cả";
                lst.Insert(0, en);
                cmbTo.DataSource = lst;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
            }
            //DataTable dt = _cDonTu.getDS_PhieuChuyenApp_KhongLapDon();
            //DataRow dr = dt.NewRow();
            //dr["Name"] = "Tất Cả";
            //dt.Rows.InsertAt(dr, 0);
            //cmbLoai.DataSource = dt;
            //cmbLoai.DisplayMember = "Name";
            //cmbLoai.ValueMember = "Name";
            //cmbLoai.SelectedIndex = 0;
            DataTable dt = _cPhieuChuyen.getDS_PhieuChuyen();
            DataRow dr = dt.NewRow();
            dr["Name"] = "Tất Cả";
            dt.Rows.InsertAt(dr, dt.Rows.Count);
            cmbLoai.DataSource = dt;
            cmbLoai.DisplayMember = "Name";
            cmbLoai.ValueMember = "Name";
            cmbVeViec.DataSource = dt;
            cmbVeViec.DisplayMember = "Name";
            cmbVeViec.ValueMember = "Name";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
            {
                dgvDanhSach.DataSource = _cPhieuChuyen.getDS(txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", ""));
            }
            else
                if (CNguoiDung.Doi)
                    dgvDanhSach.DataSource = _cPhieuChuyen.getDS(cmbTo.SelectedValue.ToString(), cmbLoai.SelectedValue.ToString(), dateTuNgay.Value, dateDenNgay.Value);
                else
                    dgvDanhSach.DataSource = _cPhieuChuyen.getDS(CNguoiDung.MaTo.ToString(), cmbLoai.SelectedValue.ToString(), dateTuNgay.Value, dateDenNgay.Value);
            //switch (cmbLoai.SelectedValue.ToString())
            //{
            //    case "Âm Sâu":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_AmSau(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_AmSau(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_AmSau(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Xây Dựng":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_XayDung(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_XayDung(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_XayDung(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Đứt Chì Góc":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_DutChiGoc(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_DutChiGoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_DutChiGoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Đứt Chì Thân":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_DutChiThan(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_DutChiThan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_DutChiThan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Ngập Nước":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_NgapNuoc(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_NgapNuoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_NgapNuoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Kẹt Tường":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_KetTuong(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_KetTuong(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_KetTuong(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Lấp Khóa Góc":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_LapKhoaGoc(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_LapKhoaGoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_LapKhoaGoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Bể HBV":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_BeHBV(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_BeHBV(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_BeHBV(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Bể Nấp, Mất Nấp HBV":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_BeNapMatNapHBV(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_BeNapMatNapHBV(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_BeNapMatNapHBV(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Gãy Tay Van":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_GayTayVan(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_GayTayVan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_GayTayVan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Trở Ngại Thay":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_TroNgaiThay(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_TroNgaiThay(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_TroNgaiThay(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    case "Đấu Chung Máy Bơm":
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_DauChungMayBom(dateTuNgay.Value, dateDenNgay.Value);
            //            else
            //                dgvDanhSach.DataSource = _cPhieuChuyen.getDS_DauChungMayBom(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        else
            //        {
            //            dgvDanhSach.DataSource = _cPhieuChuyen.getDS_DauChungMayBom(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
            //        }
            //        break;
            //    default:
            //        DataTable dt = new DataTable();
            //        if (CNguoiDung.Doi)
            //        {
            //            if (cmbTo.SelectedIndex == 0)
            //            {
            //                dt.Merge(_cPhieuChuyen.getDS_AmSau(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_XayDung(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_DutChiGoc(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_DutChiThan(dateTuNgay.Value, dateDenNgay.Value));
            //                //dt.Merge(_cDHN.getDS_DutChiGocThan(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_NgapNuoc(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_KetTuong(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_LapKhoaGoc(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_BeHBV(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_BeNapMatNapHBV(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_GayTayVan(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_TroNgaiThay(dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_DauChungMayBom(dateTuNgay.Value, dateDenNgay.Value));
            //            }
            //            else
            //            {
            //                dt.Merge(_cPhieuChuyen.getDS_AmSau(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_XayDung(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_DutChiGoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_DutChiThan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                //dt.Merge(_cDHN.getDS_DutChiGocThan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_NgapNuoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_KetTuong(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_LapKhoaGoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_BeHBV(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_BeNapMatNapHBV(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_GayTayVan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_TroNgaiThay(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //                dt.Merge(_cPhieuChuyen.getDS_DauChungMayBom(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
            //            }
            //        }
            //        else
            //        {
            //            dt.Merge(_cPhieuChuyen.getDS_AmSau(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_XayDung(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_DutChiGoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_DutChiThan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            //dt.Merge(_cPhieuChuyen.getDS_DutChiGocThan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_NgapNuoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_KetTuong(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_LapKhoaGoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_BeHBV(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_BeNapMatNapHBV(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_GayTayVan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_TroNgaiThay(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //            dt.Merge(_cPhieuChuyen.getDS_DauChungMayBom(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
            //        }
            //        dgvDanhSach.DataSource = dt;
            //        break;
            //}
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    _cTo.viewImage(_cTo.imageToByteArray(_cTo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa(dgvDanhSach["Folder", e.RowIndex].Value.ToString(), "", dgvDanhSach["DanhBo", e.RowIndex].Value.ToString() + ".jpg"))));
                }
                
            }
            catch
            {
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                List<MaHoa_PhieuChuyen_LichSu> lst = new List<MaHoa_PhieuChuyen_LichSu>();
                int SoPhieu = _cPhieuChuyen.getSoPhieuNext();
                int SoPhieu2 = _cPhieuChuyen.getSoPhieuNextNext();
                bool flagNgoai = false, flagTrong = false;
                foreach (DataGridViewRow item in dgvDanhSach.Rows)
                    if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                        if (string.IsNullOrEmpty(item.Cells["SoPhieu"].Value.ToString()) && item.Cells["TinhTrang"].Value.ToString() == "Tồn" && item.Cells["TinhTrang"].Value.ToString() != "Xóa")
                        {
                            if (bool.Parse(item.Cells["ViTriDHN_Ngoai"].Value.ToString()))
                                flagNgoai = true;
                            else
                                flagTrong = true;
                        }
                foreach (DataGridViewRow item in dgvDanhSach.Rows)
                    if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                        if (string.IsNullOrEmpty(item.Cells["SoPhieu"].Value.ToString()))
                        {
                            if (item.Cells["TinhTrang"].Value.ToString() == "Tồn" && item.Cells["TinhTrang"].Value.ToString() != "Xóa")
                            {
                                MaHoa_PhieuChuyen_LichSu pc = _cPhieuChuyen.get(int.Parse(item.Cells["ID"].Value.ToString()));
                                pc.SoPhieu = SoPhieu;
                                pc.SoPhieu_Ngay = DateTime.Now;
                                if (pc.VeViec == null || pc.VeViec == "")
                                {
                                    pc.VeViec = "ĐỒNG HỒ NƯỚC " + pc.NoiDung.ToUpper();
                                    switch (pc.NoiDung)
                                    {
                                        case "Âm Sâu":
                                            if (bool.Parse(item.Cells["ViTriDHN_Ngoai"].Value.ToString()))
                                            {
                                                pc.KinhGui = "Phòng KHĐT";
                                                pc.VeViec = "ĐỒNG HỒ NƯỚC " + pc.NoiDung.ToUpper() + " NGOÀI BẤT ĐỘNG SẢN";
                                                if (flagNgoai && flagTrong)
                                                    pc.SoPhieu = SoPhieu;
                                                else
                                                    pc.SoPhieu = SoPhieu;
                                            }
                                            else
                                            {
                                                pc.KinhGui = "Phòng Thương Vụ";
                                                pc.VeViec = "ĐỒNG HỒ NƯỚC " + pc.NoiDung.ToUpper() + " TRONG BẤT ĐỘNG SẢN";
                                                if (flagNgoai && flagTrong)
                                                    pc.SoPhieu = SoPhieu2;
                                                else
                                                    pc.SoPhieu = SoPhieu;
                                            }
                                            break;
                                        case "Kẹt Tường":
                                            pc.KinhGui = "Phòng Thương Vụ, Đội TCTB";
                                            break;
                                        case "Ngập Nước":
                                            pc.KinhGui = "Đội TCTB";
                                            break;
                                        //case "Lấp Khóa Góc":
                                        //    pc.KinhGui = "Phòng Thương Vụ";
                                        //    break;
                                        default:
                                            pc.KinhGui = "Phòng Thương Vụ";
                                            break;
                                    }
                                }
                                if (CNguoiDung.Doi)
                                {
                                    if (cmbTo.SelectedIndex == 0)
                                        pc.SoPhieu_In = "Số:" + pc.SoPhieu + "/PC-ĐỘI-QLĐHN";
                                    else
                                        pc.SoPhieu_In = "Số:" + pc.SoPhieu + "/PC-" + _cTo.get(int.Parse(cmbTo.SelectedValue.ToString())).KyHieu + "-QLĐHN";
                                }
                                else
                                {
                                    pc.SoPhieu_In = "Số:" + pc.SoPhieu + "/PC-" + _cTo.get(CNguoiDung.MaTo).KyHieu + "-QLĐHN";
                                }
                                pc.NoiNhan = "Như trên\nLưu";
                                _cPhieuChuyen.sua(pc);
                            }
                        }
                        else
                            if (!lst.Any(itemlst => itemlst.SoPhieu == int.Parse(item.Cells["SoPhieu"].Value.ToString())))
                                lst = lst.Concat(_cPhieuChuyen.getDS(int.Parse(item.Cells["SoPhieu"].Value.ToString()))).ToList();

                lst = lst.Concat(_cPhieuChuyen.getDS(SoPhieu)).ToList();
                foreach (MaHoa_PhieuChuyen_LichSu item in lst)
                    if (item.TinhTrang != "Xóa")
                    {
                        TB_DULIEUKHACHHANG ttkh = _cDHN.get(item.DanhBo);
                        if (ttkh != null)
                        {
                            //DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                            //dr["TenPhong"] = CNguoiDung.TenPhong;
                            //if (CNguoiDung.Doi)
                            //{
                            //    if (cmbTo.SelectedIndex == 0)
                            //        dr["SoPhieu"] = "Số:" + item.SoPhieu + "/PC-QLĐHN";
                            //    else
                            //        dr["SoPhieu"] = "Số:" + item.SoPhieu + "/PC-" + _cTo.get(int.Parse(cmbTo.SelectedValue.ToString())).KyHieu + "-QLĐHN";
                            //}
                            //else
                            //{
                            //    dr["SoPhieu"] = "Số:" + item.SoPhieu + "/PC-" + _cTo.get(CNguoiDung.MaTo).KyHieu + "-QLĐHN";
                            //}
                            //dr["TieuDe"] = "DANH SÁCH ĐỒNG HỒ NƯỚC " + item.NoiDung.ToUpper();
                            //switch (item.NoiDung)
                            //{
                            //    case "Âm Sâu":
                            //        if (ttkh.ViTriDHN_Ngoai)
                            //        {
                            //            dr["TieuDe"] = "DANH SÁCH ĐỒNG HỒ NƯỚC " + item.NoiDung.ToUpper() + " NGOÀI BẤT ĐỘNG SẢN";
                            //            dr["NoiNhan"] = "P. KHĐT\nLưu";
                            //        }
                            //        else
                            //        {
                            //            dr["TieuDe"] = "DANH SÁCH ĐỒNG HỒ NƯỚC " + item.NoiDung.ToUpper() + " TRONG BẤT ĐỘNG SẢN";
                            //            dr["NoiNhan"] = "P. Thương Vụ\nLưu";
                            //        }
                            //        break;
                            //    case "Kẹt Tường":
                            //        dr["NoiNhan"] = "P. Thương Vụ\nĐ. TCTB\nLưu";
                            //        break;
                            //    case "Ngập Nước":
                            //        dr["NoiNhan"] = "Đ. TCTB\nLưu";
                            //        break;
                            //    case "Lấp Khóa Góc":
                            //        dr["NoiNhan"] = "P. Thương Vụ\nLưu";
                            //        break;
                            //    default:
                            //        dr["NoiNhan"] = "P. Thương Vụ: thực hiện\nLưu";
                            //        break;
                            //}
                            //dr["ThoiGian"] = "Từ ngày " + dateTuNgay.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateDenNgay.Value.ToString("dd/MM/yyyy");
                            //dr["DanhBo"] = ttkh.DANHBO.Insert(7, " ").Insert(4, " ");
                            //dr["MLT"] = ttkh.LOTRINH;
                            //dr["HoTen"] = ttkh.HOTEN;
                            //dr["DiaChi"] = ttkh.SONHA + " " + ttkh.TENDUONG + _cDHN.getPhuongQuan(ttkh.QUAN, ttkh.PHUONG);
                            //HOADON hd = _cThuTien.GetMoiNhat(ttkh.DANHBO);
                            //if (hd != null)
                            //    dr["HopDong"] = hd.SO + " " + hd.DUONG + _cDHN.getPhuongQuan(hd.Quan, hd.Phuong);
                            //dr["Hieu"] = ttkh.HIEUDH;
                            //dr["Co"] = ttkh.CODH;
                            //dr["SoThan"] = ttkh.SOTHANDH;
                            //dr["ViTri"] = ttkh.VITRIDHN;
                            //DocSo docso = _cDocSo.get_DocSo_MoiNhat(ttkh.DANHBO);
                            //dr["ChiSo"] = docso.CSMoi;
                            //dr["TieuThu"] = docso.TieuThuMoi;
                            //if (item.ID.ToString() != "")
                            //    dr["NoiDung"] = "Mã: " + item.ID.ToString();
                            //else
                            //    dr["NoiDung"] = "Mã: Lỗi, kiểm tra lại";
                            //dr["GhiChu"] = item.GhiChu;
                            //dr["ChucVu"] = CNguoiDung.ChucVu.ToUpper();
                            //dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                            //dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                            DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                            dr["TenPhong"] = CNguoiDung.TenPhong;
                            dr["SoPhieu"] = item.SoPhieu_In;
                            dr["KinhTrinh"] = item.KinhGui;
                            dr["VeViec"] = item.VeViec;
                            dr["NoiNhan"] = item.NoiNhan;
                            dr["DanhBo"] = ttkh.DANHBO.Insert(7, " ").Insert(4, " ");
                            dr["MLT"] = ttkh.LOTRINH;
                            dr["HoTen"] = ttkh.HOTEN;
                            dr["DiaChi"] = ttkh.SONHA + " " + ttkh.TENDUONG + _cDHN.getPhuongQuan(ttkh.QUAN, ttkh.PHUONG);
                            HOADON hd = _cThuTien.GetMoiNhat(ttkh.DANHBO);
                            if (hd != null)
                                dr["HopDong"] = hd.SO + " " + hd.DUONG + _cDHN.getPhuongQuan(hd.Quan, hd.Phuong);
                            if (item.ID.ToString() != "")
                                dr["MaDon"] = "Mã: " + item.ID.ToString();
                            else
                                dr["MaDon"] = "Mã: Lỗi, kiểm tra lại";
                            dr["NoiDung"] = item.VanBan;
                            dr["GhiChu"] = item.GhiChu;
                            dr["ChucVu"] = CNguoiDung.ChucVu.ToUpper();
                            dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                            dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                        }
                    }
                rptPhieuChuyen rpt = new rptPhieuChuyen();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
                //btnXem.PerformClick();
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", "").Length == 11)
            {
                btnXem.PerformClick();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvDanhBo.Rows)
                            if (item.Cells["DanhBo_Nhap"].Value != null && item.Cells["DanhBo_Nhap"].Value.ToString() != "")
                            {
                                MaHoa_PhieuChuyen_LichSu en = new MaHoa_PhieuChuyen_LichSu();
                                en.KinhGui = txtKinhGui.Text.Trim();
                                en.NoiDung = cmbVeViec.SelectedValue.ToString();
                                en.VeViec = en.NoiDung.ToUpper();
                                en.DanhBo = item.Cells["DanhBo_Nhap"].Value.ToString();
                                en.TinhTrang = "Tồn";
                                if (item.Cells["VanBan_Nhap"].Value != null && item.Cells["VanBan_Nhap"].Value.ToString() != "")
                                    en.VanBan = item.Cells["VanBan_Nhap"].Value.ToString();
                                if (item.Cells["GhiChu_Nhap"].Value != null && item.Cells["GhiChu_Nhap"].Value.ToString() != "")
                                    en.GhiChu = item.Cells["GhiChu_Nhap"].Value.ToString();
                                _cPhieuChuyen.them(en);
                            }
                        dgvDanhBo.Rows.Clear();
                        DataTable dt = _cPhieuChuyen.getGroup_NoiDung();
                        DataRow dr = dt.NewRow();
                        dr["NoiDung"] = "Tất Cả";
                        dt.Rows.InsertAt(dr, dt.Rows.Count);
                        cmbLoai.DataSource = dt;
                        cmbLoai.DisplayMember = "NoiDung";
                        cmbLoai.ValueMember = "NoiDung";
                        MessageBox.Show("Thành công\nVui lòng load lại Danh Sách và bấm nút In Phiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn chắc chắn???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TB_DULIEUKHACHHANG ttkh = _cDHN.get(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString());
                        if (ttkh != null)
                        {
                            switch (dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString())
                            {
                                case "Âm Sâu":
                                    ttkh.AmSau = false;
                                    ttkh.AmSau_Ngay = null;
                                    break;
                                case "Xây Dựng":
                                    ttkh.XayDung = false;
                                    ttkh.XayDung_Ngay = null;
                                    break;
                                case "Đứt Chì Góc":
                                    ttkh.DutChi_Goc = false;
                                    ttkh.DutChi_Goc_Ngay = null;
                                    break;
                                case "Đứt Chì Thân":
                                    ttkh.DutChi_Than = false;
                                    ttkh.DutChi_Than_Ngay = null;
                                    break;
                                case "Ngập Nước":
                                    ttkh.NgapNuoc = false;
                                    ttkh.NgapNuoc_Ngay = null;
                                    break;
                                case "Kẹt Tường":
                                    ttkh.KetTuong = false;
                                    ttkh.KetTuong_Ngay = null;
                                    break;
                                case "Lấp Khóa Góc":
                                    ttkh.LapKhoaGoc = false;
                                    ttkh.LapKhoaGoc_Ngay = null;
                                    break;
                                case "Bể HBV":
                                    ttkh.BeHBV = false;
                                    ttkh.BeHBV_Ngay = null;
                                    break;
                                case "Bể Nấp, Mất Nấp HBV":
                                    ttkh.BeNapMatNapHBV = false;
                                    ttkh.BeNapMatNapHBV_Ngay = null;
                                    break;
                                case "Gãy Tay Van":
                                    ttkh.GayTayVan = false;
                                    ttkh.GayTayVan_Ngay = null;
                                    break;
                                case "Trở Ngại Thay":
                                    ttkh.TroNgaiThay = false;
                                    ttkh.TroNgaiThay_Ngay = null;
                                    break;
                                case "Đấu Chung Máy Bơm":
                                    ttkh.DauChungMayBom = false;
                                    ttkh.DauChungMayBom_Ngay = null;
                                    break;
                                default:
                                    break;
                            }
                            _cDHN.SubmitChanges();
                            CDocSo._cDAL.ExecuteNonQuery("update MaHoa_PhieuChuyen_LichSu set TinhTrang=N'Xóa' where ID=" + dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString());
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //DataTable dt = CPhieuChuyen._cDAL.ExecuteQuery_DataTable("select * from capnuoctanhoa.dbo.TB_DULIEUKHACHHANG where DauChungMayBom=1 and DANHBO not in (select danhbo from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where NoiDung=N'Đấu Chung Máy Bơm')");
                        //foreach (DataRow item in dt.Rows)
                        //{
                        //    string ID = "";
                        //    object checkExists = CDocSo._cDAL.ExecuteQuery_ReturnOneValue("select top 1 ID from MaHoa_PhieuChuyen_LichSu where ID like '" + DateTime.Now.ToString("yy") + "%'");
                        //    if (checkExists != null)
                        //    {
                        //        object stt = CDocSo._cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),3,5))+1 from MaHoa_PhieuChuyen_LichSu where ID like '" + DateTime.Now.ToString("yy") + "%'");
                        //        if (stt != null)
                        //            ID = DateTime.Now.ToString("yy") + ((int)stt).ToString("00000");
                        //    }
                        //    else
                        //    {
                        //        ID = DateTime.Now.ToString("yy") + 1.ToString("00000");
                        //    }
                        //    CDocSo._cDAL.ExecuteNonQuery("insert into MaHoa_PhieuChuyen_LichSu(ID,DanhBo,NoiDung,GhiChu,CreateBy,CreateDate,TinhTrang)values(" + ID + ",'" + item["DanhBo"].ToString() + "',N'Đấu Chung Máy Bơm',N'bổ sung'," + CNguoiDung.MaND + ",'" + DateTime.Parse(item["DauChungMayBom_Ngay"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "','')");
                        //}
                        //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvDanhSach.Columns[e.ColumnIndex].Name == "TinhTrang")
                    {
                        if (CPhieuChuyen._cDAL.ExecuteNonQuery("update MaHoa_PhieuChuyen_LichSu set TinhTrang=N'" + dgvDanhSach["TinhTrang", e.RowIndex].Value.ToString() + "' where ID=" + dgvDanhSach["ID", e.RowIndex].Value.ToString()))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvDanhSach.Rows)
                            if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                                if (!string.IsNullOrEmpty(item.Cells["SoPhieu"].Value.ToString()))
                                {
                                    MaHoa_PhieuChuyen_LichSu pc = _cPhieuChuyen.get(int.Parse(item.Cells["ID"].Value.ToString()));
                                    pc.SoPhieu = null;
                                    pc.SoPhieu_Ngay = null;
                                    _cPhieuChuyen.SubmitChanges();
                                }
                        btnXem.PerformClick();
                        MessageBox.Show("Đã xử lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvDanhBo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "DanhBo_Nhap" && dgvDanhBo["DanhBo_Nhap", e.RowIndex].Value != null)
            {
                for (int i = 0; i < dgvDanhBo.Rows.Count; i++)
                    if (i != e.RowIndex && dgvDanhBo["DanhBo_Nhap", i].Value != null && dgvDanhBo["DanhBo_Nhap", e.RowIndex].Value != null && dgvDanhBo["DanhBo_Nhap", i].Value.ToString() != "" && dgvDanhBo["DanhBo_Nhap", i].Value.ToString() == dgvDanhBo["DanhBo_Nhap", e.RowIndex].Value.ToString())
                    {
                        MessageBox.Show("Danh Bộ đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                if (dgvDanhBo["DanhBo_Nhap", e.RowIndex].Value != null && dgvDanhBo["DanhBo_Nhap", e.RowIndex].Value.ToString() != "")
                {
                    TB_DULIEUKHACHHANG ttkh = _cDHN.get(dgvDanhBo["DanhBo_Nhap", e.RowIndex].Value.ToString());
                    if (ttkh != null)
                    {
                        dgvDanhBo["HoTen_Nhap", e.RowIndex].Value = ttkh.HOTEN;
                        dgvDanhBo["DiaChi_Nhap", e.RowIndex].Value = ttkh.SONHA + " " + ttkh.TENDUONG;
                    }
                    else
                    {
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
            {
                if (chkAll.Checked)
                    item.Cells["Chon"].Value = true;
                else
                    item.Cells["Chon"].Value = false;
            }

        }

        private void btnPasteFromXuLy_Click(object sender, EventArgs e)
        {
            string[] DanhBos = CNguoiDung.DanhBos.Split(',');
            foreach (string item in DanhBos)
            {
                TB_DULIEUKHACHHANG ttkh = _cDHN.get(item);
                if (ttkh != null)
                {
                    var index = dgvDanhBo.Rows.Add();
                    dgvDanhBo.Rows[index].Cells["DanhBo_Nhap"].Value = ttkh.DANHBO;
                    dgvDanhBo.Rows[index].Cells["HoTen_Nhap"].Value = ttkh.HOTEN;
                    dgvDanhBo.Rows[index].Cells["DiaChi_Nhap"].Value = ttkh.SONHA + " " + ttkh.TENDUONG;
                }
            }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            dgvBaoCao.DataSource = _cPhieuChuyen.getBaoCao(dateTu_BaoCao.Value, dateDen_BaoCao.Value);
        }


    }
}
