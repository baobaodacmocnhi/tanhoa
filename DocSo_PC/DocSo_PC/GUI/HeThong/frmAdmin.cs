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
using System.Net;
using System.IO;

namespace DocSo_PC.GUI.HeThong
{
    public partial class frmAdmin : Form
    {
        CMenu _cMenu = new CMenu();
        CNhom _cNhom = new CNhom();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
        CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();

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
                    if (!_cMenu.CheckExistByTenMenu(itemChild.Name))
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
                            phanquyennhom.MaMenu = menu.MaMenu;
                            phanquyennhom.MaNhom = item.MaNhom;
                            phanquyennhom.CreateBy = CNguoiDung.MaND;
                            phanquyennhom.CreateDate = DateTime.Now;
                            menu.PhanQuyenNhoms.Add(phanquyennhom);
                        }
                        foreach (var item in _cNguoiDung.GetDS())
                        {
                            PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                            phanquyennguoidung.MaMenu = menu.MaMenu;
                            phanquyennguoidung.MaND = item.MaND;
                            phanquyennguoidung.CreateBy = CNguoiDung.MaND;
                            phanquyennguoidung.CreateDate = DateTime.Now;
                            if (item.MaND == 0)
                            {
                                phanquyennguoidung.Xem = true;
                                phanquyennguoidung.Them = true;
                                phanquyennguoidung.Sua = true;
                                phanquyennguoidung.Xoa = true;
                            }
                            menu.PhanQuyenNguoiDungs.Add(phanquyennguoidung);
                        }
                        _cMenu.Them(menu);
                    }
                    else
                    {
                        LinQ.Menu menu = _cMenu.GetByTenMenu(itemChild.Name);
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
                    if (!_cPhanQuyenNhom.CheckByMaMenuMaNhom(itemMenu.MaMenu, itemNhom.MaNhom))
                    {
                        PhanQuyenNhom phanquyennhom = new PhanQuyenNhom();
                        phanquyennhom.MaMenu = itemMenu.MaMenu;
                        phanquyennhom.MaNhom = itemNhom.MaNhom;
                        _cPhanQuyenNhom.Them(phanquyennhom);
                    }
                }
            }
        }

        private void btnCapNhatPhanQuyenNguoiDung_Click(object sender, EventArgs e)
        {
            foreach (var itemMenu in _cMenu.GetDS())
            {
                foreach (var itemND in _cNguoiDung.GetDS())
                {
                    if (!_cPhanQuyenNguoiDung.CheckByMaMenuMaND(itemMenu.MaMenu, itemND.MaND))
                    {
                        PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                        phanquyennguoidung.MaMenu = itemMenu.MaMenu;
                        phanquyennguoidung.MaND = itemND.MaND;
                        if (phanquyennguoidung.MaND == 0)
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
                dgvResult.DataSource = CNguoiDung._cDAL.ExecuteQuery_DataTable(txtQuery.Text.Trim());
            }
        }

        private void btnChuyenHinhDHN_Click(object sender, EventArgs e)
        {
            try
            {
                wrDHN.wsDHN wsDHN = new wrDHN.wsDHN();
                //DataTable dt = CMenu._cDAL.ExecuteQuery_DataTable(txtQuery.Text.Trim());
                //foreach (DataRow item in dt.Rows)
                //{
                //    DataTable dtTemp = CMenu._cDAL.ExecuteQuery_DataTable("select Hinh from Temp_HinhDHN where ID='" + item["ID"].ToString() + "'");
                //    if (wsDHN.ghi_Hinh(item["ID"].ToString(), dtTemp.Rows[0]["Hinh"].ToString()) == true)
                //        CMenu._cDAL.ExecuteNonQuery("delete Temp_HinhDHN where ID='" + item["ID"].ToString() + "'");
                //}

                DataTable dt = CMenu._cDAL.ExecuteQuery_DataTable("select DanhBo=DanhBa,CSMoi,GIOGHI from sDHN.dbo.DHTM_NGHIEMTHU_TD td,DocSo ds"
+ " where ds.DanhBa=td.DANHBO and Dot in (15,16) and nam=2023 and ky=5 and SUBSTRING(CodeMoi,1,1)='4'");
                foreach (DataRow item in dt.Rows)
                {
                    byte[] hinh = wsDHN.get_Hinh("202305" + item["DanhBo"].ToString());
                    if (hinh != null)
                        System.IO.File.WriteAllBytes(@"C:\Users\BaoBao\Desktop\TanHoa.DocSo.19052023\" + item["DanhBo"].ToString() + ".jpg", hinh);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnUpdatesDHNTCT_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable dtExcel = _cMenu.ExcelToDataTable(dialog.FileName);
                    foreach (DataRow item in dtExcel.Rows)
                        if (item[1].ToString().Replace(" ", "").Length == 11)
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:23993/api/DocSo/suaDHN_TCT?DanhBo=" + item[1].ToString().Replace(" ", "") + "&checksum=tanho@2022");
                            request.Method = "GET";
                            request.ContentType = "application/json; charset=utf-8";

                            HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                            if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                            {
                                StreamReader read = new StreamReader(respuesta.GetResponseStream());
                                string result = read.ReadToEnd();
                                read.Close();
                                respuesta.Close();
                            }
                        }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnExportsDHN_Click(object sender, EventArgs e)
        {
            try
            {
                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                oSheet.Name = "Sheet1";

                //DataTable dt = CMenu._cDAL.ExecuteQuery_DataTable(txtQuery.Text.Trim());
                DataTable dt = CMenu._cDAL.ExecuteQuery_DataTable("select CodeMoi,DanhBo=DanhBa,CSMoi,GIOGHI,KyHD=CONVERT(char(4),Nam)+''+CONVERT(char(2),Ky) from sDHN.dbo.Lech td,DocSo ds where ds.DanhBa=td.DANHBO and nam=2023 and ky=9");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    oSheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        oSheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                    }
                }

                //xuất file hình
                wrDHN.wsDHN wsDHN = new wrDHN.wsDHN();
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.Description = "Chọn Thư Mục Chứa File";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            byte[] hinh = wsDHN.get_Hinh(item["KyHD"].ToString() + item["DanhBo"].ToString());
                            if (hinh != null)
                                System.IO.File.WriteAllBytes(@"" + dlg.SelectedPath + @"\" + item["DanhBo"].ToString() + ".jpg", hinh);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
