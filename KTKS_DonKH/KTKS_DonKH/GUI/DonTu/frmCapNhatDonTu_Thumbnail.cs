using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmCapNhatDonTu_Thumbnail : Form
    {
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CDonTu _cDonTu = new CDonTu();
        DonTu_ChiTiet _dontu_ChiTiet = null;

        public frmCapNhatDonTu_Thumbnail()
        {
            InitializeComponent();
        }

        public frmCapNhatDonTu_Thumbnail(DonTu_ChiTiet dontu_ChiTiet)
        {
            InitializeComponent();
            _dontu_ChiTiet = dontu_ChiTiet;
        }

        private void frmCapNhanDonTu_Thumbnail_Load(object sender, EventArgs e)
        {
            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS("DonTuChuyen");
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.SelectedIndex = -1;

            chkcmbNoiNhan.Properties.DataSource = _cNoiChuyen.GetDS("DonTuNhan");
            chkcmbNoiNhan.Properties.ValueMember = "ID";
            chkcmbNoiNhan.Properties.DisplayMember = "Name";

            if (_dontu_ChiTiet != null)
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDon.Text = _dontu_ChiTiet.MaDon.Value.ToString();
                else
                    txtMaDon.Text = _dontu_ChiTiet.MaDon.Value.ToString() + "." + _dontu_ChiTiet.STT.Value.ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dontu_ChiTiet != null)
                {
                    bool flag = false;//ghi nhận có chọn checkcombobox
                    if (chkcmbNoiNhan.Properties.Items.Count > 0)
                    {
                        for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                            if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                //đi KTXM
                                if (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5")
                                {

                                    //for (int j = 0; j < chkcmbNoiNhanKTXM.Properties.Items.Count; j++)
                                    //    if (chkcmbNoiNhanKTXM.Properties.Items[j].CheckState == CheckState.Checked)
                                    //    {
                                    //        DonTu_LichSu entity = new DonTu_LichSu();
                                    //        entity.NgayChuyen = dateChuyen.Value;
                                    //        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    //        entity.NoiChuyen = cmbNoiChuyen.Text;
                                    //        entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    //        entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    //        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                    //        entity.MaDon = _dontu.MaDon;
                                    //        entity.STT = 1;
                                    //        entity.ID_KTXM = int.Parse(chkcmbNoiNhanKTXM.Properties.Items[j].Value.ToString());
                                    //        entity.KTXM = chkcmbNoiNhanKTXM.Properties.Items[j].ToString();
                                    //        _cDonTu.Them_LichSu(entity);
                                    //    }
                                }
                                else
                                {
                                    DonTu_LichSu entity = new DonTu_LichSu();
                                    entity.NgayChuyen = dateChuyen.Value;
                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                    entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                    entity.MaDon = _dontu_ChiTiet.MaDon;
                                    entity.STT = _dontu_ChiTiet.STT;
                                    _cDonTu.Them_LichSu(entity);
                                }
                                flag = true;
                            }
                        if (flag == false)
                        {
                            DonTu_LichSu entity = new DonTu_LichSu();
                            entity.NgayChuyen = dateChuyen.Value;
                            entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                            entity.NoiChuyen = cmbNoiChuyen.Text;
                            //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                            //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                            entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                            entity.MaDon = _dontu_ChiTiet.MaDon;
                            entity.STT = _dontu_ChiTiet.STT;
                            _cDonTu.Them_LichSu(entity);
                        }
                    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
