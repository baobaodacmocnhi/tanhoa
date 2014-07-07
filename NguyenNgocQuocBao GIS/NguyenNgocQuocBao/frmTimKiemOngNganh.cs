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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;

namespace NguyenNgocQuocBao
{
    public partial class frmTimKiemOngNganh : Form
    {
        public IFeature pFeature;

        public frmTimKiemOngNganh()
        {
            InitializeComponent();
        }

        private void frmTimKiemOngNganh_Load(object sender, EventArgs e)
        {
            LoadDomainTocmb(cmbHieuOng, btnKetNoi.pWS, "DMHieuOngNuoc");
            LoadSubtypeTocmb(cmbCoOng, btnKetNoi.pWS);
            LoadQuaninTocmb(cmbQuan, btnKetNoi.pWS);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            if (cmbQuan.SelectedIndex != -1)
            {
                if (strWhere != "")
                    strWhere = strWhere + " and MaQuan='" + cmbQuan.SelectedValue + "'";
                else
                    strWhere = "MaQuan='" + cmbQuan.SelectedValue + "'";
            }
            if (cmbPhuong.SelectedIndex != -1)
            {
                if (strWhere != "")
                    strWhere = strWhere + " and MaPhuong='" + cmbPhuong.SelectedValue + "'";
                else
                    strWhere = "MaPhuong='" + cmbPhuong.SelectedValue + "'";
            }
            if (cmbHieuOng.SelectedIndex != -1)
            {
                if (strWhere != "")
                    strWhere = strWhere + " and Hieu=" + cmbHieuOng.SelectedValue;
                else
                    strWhere = "Hieu=" + cmbHieuOng.SelectedValue;
            }
            if (cmbCoOng.SelectedIndex != -1)
            {
                if (strWhere != "")
                    strWhere = strWhere + " and CoOng=" + cmbCoOng.SelectedValue;
                else
                    strWhere = "CoOng=" + cmbCoOng.SelectedValue;
            }
            LoadListView(strWhere);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        public class cmb_QuanPhuong
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

            private List<cmb_Item> mlstPhuong = new List<cmb_Item>();
            public List<cmb_Item> lstPhuong
            {
                get { return mlstPhuong; }
                set { mlstPhuong = value; }
            }
        }

        public void LoadListView(string strWhere)
        {
            IFeature pfeature;
            IQueryFilter pQueryFilter;
            int stt = 0;
            int length = 0;
            IFeatureLayer pFeatureLayer;
            IFeatureSelection pFeatureSelection = null;
            ICursor cursor;
            IFeatureCursor pFeatureCursor;
            ISelectionSet pSelectionset;
            if (strWhere.Trim() == "")
            {
                MessageBox.Show("Vui long chon tieu chi tim kiem", "Thong Bao");
                return;
            }
            for (int i = 0; i < btnCapNhatOngNganh.pMap.LayerCount - 1; i++)
            {
                pFeatureLayer = (IFeatureLayer)btnCapNhatOngNganh.pMap.Layer[i];
                if (pFeatureLayer.FeatureClass.AliasName == "OngNganh")
                    pFeatureSelection = (IFeatureSelection)pFeatureLayer;
            }
            if (pFeatureSelection == null)
            {
                MessageBox.Show("Khong tim thay lop du lieu Dong Ho Khach Hang tren ArcMap de xu ly", "Thong Bao");
                return;
            }
            pQueryFilter = new QueryFilter();
            pQueryFilter.WhereClause = strWhere;
            pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            ZoomToFeatureUseUID();
            if (pFeatureSelection.SelectionSet.Count == 0)
            {
                MessageBox.Show("Khong co doi tuong nao thoa tieu chi", "Thong Bao");
                lstKetQua.Items.Clear();
                return;
            }
            pSelectionset = pFeatureSelection.SelectionSet;
            pSelectionset.Search(pQueryFilter, false, out cursor);
            pFeatureCursor = (IFeatureCursor)cursor;
            ///
            pfeature = pFeatureCursor.NextFeature();
            ListViewItem lv;
            while (pfeature != null)
            {
                lv = lstKetQua.Items.Add((stt + 1).ToString());
                if (pfeature.Value[pfeature.Fields.FindField("ChieuDai")].ToString() != "")
                    length += int.Parse(pfeature.Value[pfeature.Fields.FindField("ChieuDai")].ToString());
                lv.Tag = pfeature.Value[pfeature.Fields.FindField("ObjectID")].ToString();
                lv.SubItems.Add(ReturnName(pfeature.Value[pfeature.Fields.FindField("CoOng")].ToString(), (ArrayList)cmbCoOng.DataSource));
                lv.SubItems.Add(ReturnName(pfeature.Value[pfeature.Fields.FindField("Hieu")].ToString(), (ArrayList)cmbHieuOng.DataSource));
                lv.SubItems.Add(pfeature.Value[pfeature.Fields.FindField("ChieuDai")].ToString());
                pfeature = pFeatureCursor.NextFeature();
                stt++;
            }
            MessageBox.Show("Tim kiem duoc " + stt.ToString() + " doi tuong\n Va Tong chieu dai: "+length+" m", "Thong Bao");
        }

        public void ZoomToFeatureUseUID()
        {
            ICommandItem sSelectTool;
            ICommandBars sCommandBars;
            IUID u = new UID();
            u.Value = "{AB073B49-DE5E-11D1-AA80-00C04FA37860}";
            sCommandBars = btnCapNhatOngNganh.pApp.Document.CommandBars;
            sSelectTool = sCommandBars.Find(u);
            sSelectTool.Execute();
        }

        public string ReturnName(string s, ArrayList arr)
        {
            cmb_Item cmb;
            for (int i = 0; i < arr.Count - 1; i++)
            {
                cmb = (cmb_Item)arr[i];
                if (cmb.Value == s)
                    return cmb.Text;
            }
            return "";
        }

        public List<cmb_QuanPhuong> list = new List<cmb_QuanPhuong>();

        public void LoadQuaninTocmb(ComboBox cmb, IWorkspace gWorkspace)
        {
            if (gWorkspace != null)
            {
                ITable pTable;
                IFeatureWorkspace pWS;
                pWS = (IFeatureWorkspace)gWorkspace;
                pTable = pWS.OpenTable("HanhChinh");

                ICursor pCursor;
                IRow pRow;
                IQueryFilter pQueryFilter = new QueryFilter();
                pCursor = pTable.Search(null, true);
                pRow = pCursor.NextRow();

                while (pRow != null)
                {
                    cmb_QuanPhuong quan = new cmb_QuanPhuong();
                    quan.Value = pRow.Value[pRow.Fields.FindField("MaHuyen")].ToString();
                    quan.Text = pRow.Value[pRow.Fields.FindField("TenQuan")].ToString();
                    if (!list.Any(k => k.Value == pRow.Value[pRow.Fields.FindField("MaHuyen")].ToString()))
                    {
                        cmb_Item phuong = new cmb_Item();
                        phuong.Value = pRow.Value[pRow.Fields.FindField("IDHanhChinh")].ToString();
                        phuong.Text = pRow.Value[pRow.Fields.FindField("TenHanhChinh")].ToString();
                        if (!quan.lstPhuong.Any(p => p.Value == pRow.Value[pRow.Fields.FindField("IDHanhChinh")].ToString()))
                            quan.lstPhuong.Add(phuong);
                        list.Add(quan);
                    }
                    else
                    {
                        cmb_Item phuong = new cmb_Item();
                        phuong.Value = pRow.Value[pRow.Fields.FindField("IDHanhChinh")].ToString();
                        phuong.Text = pRow.Value[pRow.Fields.FindField("TenHanhChinh")].ToString();
                        if (!list.SingleOrDefault(q => q.Value == pRow.Value[pRow.Fields.FindField("MaHuyen")].ToString()).lstPhuong.Any(p => p.Value == pRow.Value[pRow.Fields.FindField("IDHanhChinh")].ToString()))
                            list.SingleOrDefault(q => q.Value == pRow.Value[pRow.Fields.FindField("MaHuyen")].ToString()).lstPhuong.Add(phuong);
                    }
                    pRow = pCursor.NextRow();
                }
                cmb.DisplayMember = "Text";
                cmb.ValueMember = "Value";
                cmb.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmb.DataSource = list;
                cmb.SelectedIndex = -1;

                //ICodedValueDomain pCodedValueDomain;
                //IWorkspaceDomains pWSDomains;
                //IDomain pDomain;
                //int i;
                //pWSDomains = (IWorkspaceDomains)gWorkspace;
                //pDomain = pWSDomains.DomainByName[TableName];
                //pCodedValueDomain = (ICodedValueDomain)pDomain;
                //if (pCodedValueDomain != null)
                //{
                //    ArrayList arrLDomain = new ArrayList();
                //    for (i = 0; i < pCodedValueDomain.CodeCount; i++)
                //    {
                //        cmb_Item it = new cmb_Item();
                //        it.Text = pCodedValueDomain.Name[i];
                //        it.Value = pCodedValueDomain.Value[i].ToString();
                //        arrLDomain.Add(it);
                //    }
                //    cmb.DisplayMember = "Text";
                //    cmb.ValueMember = "Value";
                //    cmb.AutoCompleteMode = AutoCompleteMode.Suggest;
                //    cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
                //    cmb.DataSource = arrLDomain;
                //    cmb.SelectedIndex = -1;
                //}
            }
        }

        private void cmbQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQuan.SelectedIndex != -1)
            {
                cmbPhuong.DisplayMember = "Text";
                cmbPhuong.ValueMember = "Value";
                cmbPhuong.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbPhuong.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbPhuong.DataSource = list.SingleOrDefault(q => q.Value == cmbQuan.SelectedValue).lstPhuong;
                cmbPhuong.SelectedIndex = -1;
            }
        }

    }
}
