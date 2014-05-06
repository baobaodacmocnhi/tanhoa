using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.BaoCao.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmBaoCaoKTXM : Form
    {
        string _tuNgay = "", _denNgay = "";
        CKTXM _cKTXM = new CKTXM();

        public frmBaoCaoKTXM()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmBaoCaoKTXM_Load(object sender, EventArgs e)
        {

        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
        }

        class ThongKeBienBan
        {
            string _loaiBienBan = "";
            public string LoaiBienBan
            {
                get { return _loaiBienBan; }
                set { _loaiBienBan = value; }
            }

            int _tongDanhBo = 0;
            public int TongDanhBo
            {
                get { return _tongDanhBo; }
                set { _tongDanhBo = value; }
            }

            int _toKH = 0;
            public int ToKH
            {
                get { return _toKH; }
                set { _toKH = value; }
            }

            int _toXuLy = 0;
            public int ToXuLy
            {
                get { return _toXuLy; }
                set { _toXuLy = value; }
            }

            int _dongTienBoiThuong = 0;
            public int DongTienBoiThuong
            {
                get { return _dongTienBoiThuong; }
                set { _dongTienBoiThuong = value; }
            }
        };

        ThongKeBienBan[] a = new ThongKeBienBan[5];

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (radThongKeBienBan.Checked)
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                    dt = _cKTXM.LoadDSCTKTXM(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                        dt = _cKTXM.LoadDSCTKTXM(CTaiKhoan.MaUser, dateTu.Value);

                for (int i = 0; i < 5; i++)
                {
                    a[i] = new ThongKeBienBan();
                }

                foreach (DataRow itemRow in dt.Rows)
                {
                    if (itemRow["LoaiBienBan"].ToString().Contains("bồi thường") && !itemRow["LoaiBienBan"].ToString().Contains("không"))
                    {
                        a[0].LoaiBienBan = "BB bồi thường";
                        a[0].TongDanhBo++;
                        if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                            a[0].ToKH++;
                        if (!string.IsNullOrEmpty(itemRow["MaDonTXL"].ToString()))
                            a[0].ToXuLy++;
                        if (bool.Parse(itemRow["DongTienBoiThuong"].ToString()))
                            a[0].DongTienBoiThuong++;
                    }
                    else
                        if (itemRow["LoaiBienBan"].ToString().Contains("gian lận"))
                        {
                            a[1].LoaiBienBan = "BB gian lận";
                            a[1].TongDanhBo++;
                        }
                        else
                            if (itemRow["LoaiBienBan"].ToString() == "BB chạy ngược")
                            {
                                a[2].LoaiBienBan = "BB chạy ngược";
                                a[2].TongDanhBo++;
                            }
                            else
                                if (itemRow["LoaiBienBan"].ToString() == "BB tái lập Danh Bộ")
                                {
                                    a[3].LoaiBienBan = "BB tái lập Danh Bộ";
                                    a[3].TongDanhBo++;
                                }
                                else
                                    if (itemRow["LoaiBienBan"].ToString() == "BB hủy Danh Bộ")
                                    {
                                        a[4].LoaiBienBan = "BB hủy Danh Bộ";
                                        a[4].TongDanhBo++;
                                    }
                }
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();

                for (int i = 0; i < 5; i++)
                    ///nếu không có if thì sẽ in ra hết 5 loaibienban (có những cái sẽ không có)
                    if (!string.IsNullOrEmpty(a[i].LoaiBienBan))
                    {
                        DataRow dr = dsBaoCao.Tables["ThongKeBienBanKTXM"].NewRow();

                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        dr["LoaiBienBan"] = a[i].LoaiBienBan;
                        dr["TongDanhBo"] = a[i].TongDanhBo;
                        ///if chỗ này để không cho xuất hiện bên report nếu = 0
                        if (a[i].ToKH == 0)
                            dr["ToKH"] = "";
                        else
                            dr["ToKH"] = a[i].ToKH;

                        if (a[i].ToXuLy == 0)
                            dr["ToXuLy"] = "";
                        else
                            dr["ToXuLy"] = a[i].ToXuLy;

                        if (a[i].DongTienBoiThuong == 0)
                            dr["DongTienBoiThuong"] = "";
                        else
                            dr["DongTienBoiThuong"] = a[i].DongTienBoiThuong;

                        dsBaoCao.Tables["ThongKeBienBanKTXM"].Rows.Add(dr);
                    }

                dateTu.Value = DateTime.Now;
                dateDen.Value = DateTime.Now;
                _tuNgay = _denNgay = "";

                rptThongKeBienBanKTXM rpt = new rptThongKeBienBanKTXM();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}
