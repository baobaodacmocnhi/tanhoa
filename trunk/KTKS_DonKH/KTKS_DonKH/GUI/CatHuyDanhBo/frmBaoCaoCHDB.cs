﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmBaoCaoCHDB : Form
    {
        string _tuNgay = "", _denNgay = "";
        CCHDB _cCHDB = new CCHDB();

        public frmBaoCaoCHDB()
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

        private void frmBaoCaoCHDB_Load(object sender, EventArgs e)
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

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (radThongKeSoLuong.Checked)
            {
                DataTable dtCTDB = new DataTable();
                DataTable dtCHDB = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                {
                    dtCTDB = _cCHDB.LoadDSCTCTDB(dateTu.Value, dateDen.Value);
                    dtCHDB = _cCHDB.LoadDSCTCHDB(dateTu.Value, dateDen.Value);
                }
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                    {
                        dtCTDB = _cCHDB.LoadDSCTCTDB(dateTu.Value);
                        dtCHDB = _cCHDB.LoadDSCTCHDB(dateTu.Value);
                    }

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();

                int TCTBXuLy = 0;
                int TroNgai = 0;
                int ConLai = 0;
                int DaLapPhieu = 0;
                foreach (DataRow itemRow in dtCTDB.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeCHDB"].NewRow();
                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["LoaiCat"] = "Lập Thông Báo Cắt Tạm";
                    dr["LyDo"] = itemRow["LyDo"];
                    dr["DanhBo"] = itemRow["DanhBo"];
                    if (bool.Parse(itemRow["TCTBXuLy"].ToString()))
                        TCTBXuLy++;
                    else
                        ConLai++;
                    if (bool.Parse(itemRow["TroNgai"].ToString()))
                        TroNgai++;
                    if (bool.Parse(itemRow["DaLapPhieu"].ToString()))
                        DaLapPhieu++;
                    dr["TCTBXuLy"] = TCTBXuLy;
                    dr["ConLai"] = ConLai;
                    dr["TroNgai"] = TroNgai;
                    dr["LapPhieu"] = DaLapPhieu;

                    dsBaoCao.Tables["ThongKeCHDB"].Rows.Add(dr);
                }

                TCTBXuLy = 0;
                TroNgai = 0;
                ConLai = 0;
                DaLapPhieu = 0;
                foreach (DataRow itemRow in dtCHDB.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeCHDB"].NewRow();
                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["LoaiCat"] = "Lập Thông Báo Cắt Hủy";
                    dr["LyDo"] = itemRow["LyDo"];
                    dr["DanhBo"] = itemRow["DanhBo"];
                    if (bool.Parse(itemRow["TCTBXuLy"].ToString()))
                        TCTBXuLy++;
                    else
                        ConLai++;
                    if (bool.Parse(itemRow["TroNgai"].ToString()))
                        TroNgai++;
                    if (bool.Parse(itemRow["DaLapPhieu"].ToString()))
                        DaLapPhieu++;
                    dr["TCTBXuLy"] = TCTBXuLy;
                    dr["ConLai"] = ConLai;
                    dr["TroNgai"] = TroNgai;
                    dr["LapPhieu"] = DaLapPhieu;

                    dsBaoCao.Tables["ThongKeCHDB"].Rows.Add(dr);
                }

                dateTu.Value = DateTime.Now;
                dateDen.Value = DateTime.Now;
                _tuNgay = _denNgay = "";
                
                rptThongKeCHDB rpt = new rptThongKeCHDB();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }
        }

        
    }
}
