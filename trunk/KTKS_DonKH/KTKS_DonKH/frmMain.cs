using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraBars.Helpers;

namespace KTKS_DonKH
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XmlDocument data = new XmlDocument();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            SkinHelper.InitSkinPopupMenu(barSubItem_Giaodien);
            
        }
    }
}
