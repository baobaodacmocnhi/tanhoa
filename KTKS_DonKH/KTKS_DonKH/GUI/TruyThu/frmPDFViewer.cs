using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KTKS_DonKH.GUI.TruyThu
{
    public partial class frmPDFViewer : Form
    {
        byte[] _file;

        public frmPDFViewer()
        {
            InitializeComponent();
        }

        public frmPDFViewer(byte[] file)
        {
            InitializeComponent();
            _file = file;
        }

        private void frmPDFViewer_Load(object sender, EventArgs e)
        {
            var stream = new MemoryStream(_file);
            pdfViewer1.LoadDocument(stream);
        }
    }
}
