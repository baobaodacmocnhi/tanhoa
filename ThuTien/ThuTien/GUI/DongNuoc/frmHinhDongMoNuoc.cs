using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmHinhDongMoNuoc : Form
    {
        public frmHinhDongMoNuoc()
        {
            InitializeComponent();
        }

        public frmHinhDongMoNuoc(byte[] pData)
        {
            InitializeComponent();
            MemoryStream mStream = new MemoryStream(pData);
            //byte[] pData = entity.Image.ToArray();
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            pictureBox.Image = bm;
        }

        private void frmHinhDongMoNuoc_Load(object sender, EventArgs e)
        {

        }
    }
}
