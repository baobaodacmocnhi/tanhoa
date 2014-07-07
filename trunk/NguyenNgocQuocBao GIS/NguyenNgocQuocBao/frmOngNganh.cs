using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using System.Collections;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;

namespace NguyenNgocQuocBao
{
    public partial class frmOngNganh : Form
    {
        public IFeature pFeature;

        public frmOngNganh()
        {
            InitializeComponent();
        }

        private void frmOngNganh_Load(object sender, EventArgs e)
        {
            LoadDomainTocmb(cmbHieuOng, btnKetNoi.pWS, "DMHieuOngNuoc");
            LoadSubtypeTocmb(cmbCoOng, btnKetNoi.pWS);
            txtChieuDai.Text = pFeature.Value[pFeature.Fields.FindField("ChieuDai")].ToString();
            txtNuocSanXuat.Text = pFeature.Value[pFeature.Fields.FindField("NuocSanXuat")].ToString();
            txtNamLapDat.Text = pFeature.Value[pFeature.Fields.FindField("NamLapDat")].ToString();
            cmbHieuOng.SelectedValue = pFeature.Value[pFeature.Fields.FindField("Hieu")].ToString();
            cmbCoOng.SelectedValue = pFeature.Value[pFeature.Fields.FindField("CoOng")].ToString();
        }

        public void LoadSubtypeTocmb(ComboBox cmb, IWorkspace gWorkspace)
        {
            if (gWorkspace != null)
            {
                IFeatureWorkspace pFeatureWS = (IFeatureWorkspace)gWorkspace;
                IFeatureClass pFeatureClass;
                IFeatureLayer pFLayer = new FeatureLayer();
                pFeatureClass = pFeatureWS.OpenFeatureClass("OngNganh");
                ISubtypes subtypes = (ISubtypes)pFeatureClass;
                IEnumSubtype enumSubtype;
                int subtypeCode;
                string subtypeName;
                if (subtypes.HasSubtype)
                {
                    ArrayList arrLSubtypes = new ArrayList();
                    enumSubtype = subtypes.Subtypes;
                    subtypeName = enumSubtype.Next(out subtypeCode);
                    while (subtypeName != null)
                    {
                        cmb_Item it = new cmb_Item();
                        it.Text = subtypeName;
                        it.Value = subtypeCode.ToString();
                        arrLSubtypes.Add(it);
                        subtypeName = enumSubtype.Next(out subtypeCode);
                    }
                    cmb.DisplayMember = "Text";
                    cmb.ValueMember = "Value";
                    cmb.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmb.DataSource = arrLSubtypes;
                    cmb.SelectedIndex = -1;
                }
            }
        }

        public void LoadDomainTocmb(ComboBox cmb, IWorkspace gWorkspace, string TableName)
        {
            if (gWorkspace != null)
            {
                ICodedValueDomain pCodedValueDomain;
                IWorkspaceDomains pWSDomains;
                IDomain pDomain;
                int i;
                pWSDomains = (IWorkspaceDomains)gWorkspace;
                pDomain = pWSDomains.DomainByName[TableName];
                pCodedValueDomain = (ICodedValueDomain)pDomain;
                if (pCodedValueDomain != null)
                {
                    ArrayList arrLDomain = new ArrayList();
                    for (i = 0; i < pCodedValueDomain.CodeCount; i++)
                    {
                        cmb_Item it = new cmb_Item();
                        it.Text = pCodedValueDomain.Name[i];
                        it.Value = pCodedValueDomain.Value[i].ToString();
                        arrLDomain.Add(it);
                    }
                    cmb.DisplayMember = "Text";
                    cmb.ValueMember = "Value";
                    cmb.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmb.DataSource = arrLDomain;
                    cmb.SelectedIndex = -1;
                }
            }
        }

        public class cmb_Item
        {
            private string mText;
            public string Text
            {
                get { return mText; }
                set { mText = value; }
            }

            private string mValue;
            public string Value
            {
                get { return mValue; }
                set { mValue = value; }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            IEditor pEditor;
            UID pID = new UID();
            pID.Value = "esriEditor.Editor";
            pEditor = (IEditor)btnCapNhatOngNganh.pApp.FindExtensionByCLSID(pID);
            bool bkt = false;
            if (pEditor.EditState != esriEditState.esriStateEditing)
            {
                bkt = true;
                pEditor.StartEditing(btnKetNoi.pWS);
                pEditor.StartOperation();
            }
            pFeature.Value[pFeature.Fields.FindField("ChieuDai")] = int.Parse(txtChieuDai.Text);
            pFeature.Value[pFeature.Fields.FindField("NuocSanXuat")] = txtNuocSanXuat.Text;
            pFeature.Value[pFeature.Fields.FindField("NamLapDat")] = txtNamLapDat.Text;
            if (cmbHieuOng.SelectedIndex != -1)
                pFeature.Value[pFeature.Fields.FindField("Hieu")] = cmbHieuOng.SelectedValue.ToString();
            if (cmbCoOng.SelectedIndex != -1)
                pFeature.Value[pFeature.Fields.FindField("CoOng")] = cmbCoOng.SelectedValue.ToString();
            pFeature.Store();
            if (bkt)
            {
                pEditor.StopOperation("Update");
                pEditor.StopEditing(true);
                pEditor = null;
            }
            MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnCapNhatOngNganh.pActiveView.Refresh();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
