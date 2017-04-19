using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.CallCenter
{
    public partial class frmViewPdf : Form
    {
        public frmViewPdf(string danhbo)
        {
            InitializeComponent();
            string varPathToNewLocation = AppDomain.CurrentDomain.BaseDirectory + @"\Test.pdf";

            try
            {

                dbDocSoDataContext db = new dbDocSoDataContext();


                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();

                SqlConnection sqlCon;
                sqlCon = new SqlConnection(db.Connection.ConnectionString);
                sqlCon.Open();
                using (var sqlQuery = new SqlCommand(@"SELECT DataBlob FROM HOSOGOC WHERE DBDongHoNuoc='" + danhbo + "' ", sqlCon))
                {

                    using (var sqlQueryResult = sqlQuery.ExecuteReader())
                        if (sqlQueryResult != null)
                        {
                            sqlQueryResult.Read();
                            var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                            sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                            using (var fs = new FileStream(varPathToNewLocation, FileMode.Create, FileAccess.Write))
                                fs.Write(blob, 0, blob.Length);
                        }
                }
                sqlCon.Close();
                string local = varPathToNewLocation.Replace(@"\\", @"\");
                //MessageBox.Show(this, local);
                axAcroPDF3.LoadFile(local);


            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, "Lỗi ");
            }
        }

    }
}
