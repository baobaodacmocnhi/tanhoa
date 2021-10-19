using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDanhSachDocLoChiSoNuoc : Form
    {
        CDocSo _cDocSo = new CDocSo();

        public frmDanhSachDocLoChiSoNuoc()
        {
            InitializeComponent();
        }

        private void frmDanhSachDocLoChiSoNuoc_Load(object sender, EventArgs e)
        {
            gridControl.LevelTree.Nodes.Add("Chi Tiết", gridViewChiTiet);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            gridControl.DataSource = _cDocSo.getDS_DocLoChiSoNuoc(int.Parse(txtNam.Text.Trim()), int.Parse(txtKy.Text.Trim()), int.Parse(txtDot.Text.Trim())).Tables["Parent"];

            for (int i = 0; i < gridView.DataRowCount; i++)
            {
                DataRow row = gridView.GetDataRow(i);
                DataRow[] childRows = row.GetChildRows("Chi Tiết");
                int GiaiTrach = 0;

                //tính chỉ số lố
                foreach (DataRow itemChild in childRows)
                {
                    if (itemChild["CodeMoi"].ToString().Contains("4") == true || itemChild["CodeMoi"].ToString().Contains("5") == true || itemChild["CodeMoi"].ToString().Contains("8") == true)
                    {
                        row["TieuThuLo"] = int.Parse(row["CSM"].ToString()) - int.Parse(itemChild["CSM"].ToString());
                        break;
                    }
                }
                int TieuThuLo = int.Parse(row["TieuThuLo"].ToString());
                foreach (DataRow itemChild in childRows)
                {
                    //xét hđ tồn
                    if (itemChild["NgayGiaiTrach"].ToString() != "")
                        GiaiTrach++;

                    //tính khấu trừ
                    if (itemChild["NgayGiaiTrach"].ToString() == "" && itemChild["CodeMoi"].ToString().Contains("4") == false && itemChild["CodeMoi"].ToString().Contains("5") == false && itemChild["CodeMoi"].ToString().Contains("8") == false)
                    {
                        if (TieuThuLo > 0)
                        {
                            if (TieuThuLo >= int.Parse(itemChild["TieuThu"].ToString()))
                            {
                                itemChild["TieuThuDC"] = 0;
                                TieuThuLo -= int.Parse(itemChild["TieuThu"].ToString());
                            }
                            else
                                if (TieuThuLo < int.Parse(itemChild["TieuThu"].ToString()))
                                {
                                    itemChild["TieuThuDC"] = (int.Parse(itemChild["TieuThu"].ToString()) - TieuThuLo);
                                    TieuThuLo = 0;
                                }
                        }
                    }
                }
                row["TieuThuLoConLai"] = TieuThuLo;
                if (childRows.Count() != GiaiTrach)
                    row["TinhTrang"] = "Tồn";
                //gridView.SetRowCellValue(i, "TinhTrang", "Tồn");
                else
                    row["TinhTrang"] = "Đã Đăng Ngân";
                //gridView.SetRowCellValue(i, "TinhTrang", "Đã Đăng Ngân");
            }
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }


    }
}
