using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.GUI.Loading;
using System.Data.OleDb;

namespace KTKS_DonKH.GUI.CapNhat
{
    public partial class frmTTKH : Form
    {
        CTTKH _cTTKH = new CTTKH();
        string _fileName = "";

        public frmTTKH()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmTTKH_Load(object sender, EventArgs e)
        {
            dgvDSTTKHDate.AutoGenerateColumns = false;
            dgvDSTTKHDate.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSTTKHDate.Font, FontStyle.Bold);
            dgvDSTTKHDate.DataSource = _cTTKH.LoadDSTTKhachHangDate();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.dat)|*.dat";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = dialog.FileName;
                _fileName = dialog.SafeFileName;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtDuongDan.Text.Trim() != "")
            {
                ///Theo Kỳ
                if(_fileName.Length==10)
                    if (_cTTKH.CapNhatTTKHs(txtDuongDan.Text.Trim()))
                    {
                        dgvDSTTKHDate.DataSource = _cTTKH.LoadDSTTKhachHangDate();
                        txtDuongDan.Text = "";
                    }
                ///Theo Đợt
                if(_fileName.Length==12)
                    if (_cTTKH.CapNhatTTKH(txtDuongDan.Text.Trim()))
                    {
                        dgvDSTTKHDate.DataSource = _cTTKH.LoadDSTTKhachHangDate();
                        txtDuongDan.Text = "";
                    }
            }
        }

        private void btnXuatAccess_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //The connection strings needed: One for SQL and one for Access
                String accessConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+saveFileDialog.FileName+".accdb;";
                //String sqlConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Your_Catalog;Integrated Security=True";

                //Make adapters for each table we want to export
                //SqlDataAdapter adapter1 = new SqlDataAdapter("select * from Table1", sqlConnectionString);
                System.Data.SqlClient.SqlDataAdapter adapter2 = new System.Data.SqlClient.SqlDataAdapter("select * from TTKhachHang where Ky=" + dgvDSTTKHDate.CurrentRow.Cells["Ky"].Value.ToString() + " and Dot=" + dgvDSTTKHDate.CurrentRow.Cells["Dot"].Value.ToString(), "Data Source=192.168.90.9;Initial Catalog=KTKS_DonKH;Persist Security Info=True;User ID=sa;Password=123@tanhoa");

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                //adapter1.Fill(dataSet, "Table1");
                adapter2.Fill(dataSet, "Table2");

                //Create an empty Access file that we will fill with data from the data set
                ADOX.Catalog catalog = new ADOX.Catalog();
                catalog.Create(accessConnectionString);

                //Create an Access connection and a command that we'll use
                OleDbConnection accessConnection = new OleDbConnection(accessConnectionString);
                OleDbCommand command = new OleDbCommand();
                command.Connection = accessConnection;
                command.CommandType = CommandType.Text;
                accessConnection.Open();

                //This loop creates the structure of the database
                foreach (DataTable table in dataSet.Tables)
                {
                    String columnsCommandText = "(";
                    foreach (DataColumn column in table.Columns)
                    {
                        String columnName = column.ColumnName;
                        String dataTypeName = column.DataType.Name;
                        //String sqlDataTypeName = getSqlDataTypeName(dataTypeName);
                        columnsCommandText += "[" + columnName + "] " + dataTypeName + ",";
                    }
                    columnsCommandText = columnsCommandText.Remove(columnsCommandText.Length - 1);
                    columnsCommandText += ")";

                    command.CommandText = "CREATE TABLE " + table.TableName + columnsCommandText;

                    command.ExecuteNonQuery();
                }

                //This loop fills the database with all information
                foreach (DataTable table in dataSet.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        String commandText = "INSERT INTO " + table.TableName + " VALUES (";
                        foreach (var item in row.ItemArray)
                        {
                            commandText += "'" + item.ToString() + "',";
                        }
                        commandText = commandText.Remove(commandText.Length - 1);
                        commandText += ")";

                        command.CommandText = commandText;
                        command.ExecuteNonQuery();
                    }
                }

                accessConnection.Close();
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
    }
}
