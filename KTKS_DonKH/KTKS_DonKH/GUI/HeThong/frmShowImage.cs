using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KTKS_DonKH.GUI.HeThong
{
    public partial class frmShowImage : Form
    {
        byte[] _file;
        public frmShowImage()
        {
            InitializeComponent();
        }

        public frmShowImage(byte[] file)
        {
            InitializeComponent();
            _file = file;
        }

        private void frmShowImage_Load(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream(_file);
                Image image = Image.FromStream(ms);
                ms.Dispose();
                pictureBox1.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
