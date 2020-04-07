using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical
{
    public partial class Form1 : Form
    {
        static int num = -1;
        public Form1()
        {
            InitializeComponent();
        }
        int check = -1;
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        private void Connect()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(MyConnection.getConnection))
                {
                    string sql = "Select depNum, depName, mgrSSN, mgrAssDate from tblDepartment";
                    conn.Open();
                    da = new SqlDataAdapter(sql, conn);
                    da.Fill(ds, "tblDepartment");
                    dataGridView.DataSource = ds;
                    dataGridView.DataMember = "tblDepartment";
                    MessageBox.Show("Successed !!!");
                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Failed!!!");
            }
        }

        private void Insert()
        {
            try
            {   
                DataRow row = ds.Tables["tblDepartment"].NewRow();
                row["depNum"] = txtNum.Text;
                row["depName"] = txtName.Text;
                row["mgrSSN"] = txtMgrSSN.Text;
                row["mgrAssDate"] = txtMgrAssDate.Text;
                ds.Tables["tblDepartment"].Rows.Add(row);
                MessageBox.Show("Successed!!!");
                check = 0;
            }
            catch
            {
                MessageBox.Show("Failed!!!");
            }
        }

        private void Delete()
        {
            try
            {
                int rowindex = dataGridView.CurrentCell.RowIndex;
                dataGridView.Rows.RemoveAt(rowindex);
                MessageBox.Show("Successed!!!");
                check = 0;
            }
            catch
            {
                MessageBox.Show("Failed!!!");
            }
        }

        private void Update()
        {
            try
            {
            int rowindex = dataGridView.CurrentCell.RowIndex;
            DataGridViewRow dr = dataGridView.Rows[rowindex];
            dataGridView.BeginEdit(true);
            dr.Cells["depNum"].Value = txtNum.Text;
            dr.Cells["depName"].Value = txtName.Text;
            dr.Cells["mgrSSN"].Value = txtMgrSSN.Text;
            dr.Cells["mgrAssDate"].Value = txtMgrAssDate.Text;
            dataGridView.EndEdit();
            MessageBox.Show("Successed!!!");
            check = 1;
            }
            catch

            {
                MessageBox.Show("Failed!!!");
            }

        }

        private void Save_InsDele()
        {
            String depNum = txtNum.Text;
            String depName = txtName.Text;
            String mgrSSN = txtMgrSSN.Text;
            String mgrAssDate = txtMgrAssDate.Text;
            SqlConnection conn = new SqlConnection(MyConnection.getConnection);
            conn.Open();
            SqlCommand incom = new SqlCommand("insert into tbldepartment values (@depnum,@depname,@mgrssn,@mgrassdate)", conn);
            incom.Parameters.Add("@depnum", SqlDbType.Int);
            incom.Parameters.Add("@depname", SqlDbType.NVarChar);
            incom.Parameters.Add("@mgrssn", SqlDbType.Decimal);
            incom.Parameters.Add("@mgrassdate", SqlDbType.DateTime);
            incom.Parameters["@depnum"].Value = depNum;
            incom.Parameters["@depname"].Value = depName;
            incom.Parameters["@mgrssn"].Value = mgrSSN;
            incom.Parameters["@mgrassdate"].Value = mgrAssDate;
            da.InsertCommand = incom;

            SqlCommand delcom = new SqlCommand("delete from tbldepartment where depnum=@depnum and depname=@depname", conn);
            delcom.Parameters.Add("@depnum", SqlDbType.Int);
            delcom.Parameters.Add("@depname", SqlDbType.NVarChar);
            delcom.Parameters.Add("@mgrssn", SqlDbType.Decimal);
            delcom.Parameters.Add("@mgrassdate", SqlDbType.DateTime);
            delcom.Parameters["@depnum"].Value = depNum;
            delcom.Parameters["@depname"].Value = depName;
            delcom.Parameters["@mgrssn"].Value = mgrSSN;
            delcom.Parameters["@mgrassdate"].Value = mgrAssDate;
            da.DeleteCommand = delcom;
            try
            {
                da.Update(ds, "tblDepartment");
            }
            catch
            {
                MessageBox.Show("Failed!");
            }
            conn.Close();
            ds.Clear();
            Connect();
        }

        private void Save_Update()
        {
            string sql;
            int count = dataGridView.Rows.Count;       
                using (SqlConnection conn = new SqlConnection(MyConnection.getConnection))
                {
                    int depNum = int.Parse(txtNum.Text.Trim());
                    string depName = txtName.Text.Trim();
                    String mgrSSN = txtMgrSSN.Text.Trim();
                    String mgrAssDate = txtMgrAssDate.Text;
                    conn.Open();
                    sql = "Update tblDepartment Set depName=@depName, mgrssn=@mgrssn, mgrAssDate=@mgrAssDate Where depNum =@depNum";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@depNum", SqlDbType.Int);
                    cmd.Parameters.Add("@depName", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@mgrssn", SqlDbType.Decimal);
                    cmd.Parameters.Add("@mgrAssDate", SqlDbType.DateTime);
                    cmd.Parameters["@depNum"].Value = depNum;
                    cmd.Parameters["@depName"].Value = depName;
                    cmd.Parameters["@mgrssn"].Value = mgrSSN;
                    cmd.Parameters["@mgrAssDate"].Value = mgrAssDate;
                    cmd.ExecuteNonQuery();
                    conn.Close();        
                }
            ds.Clear();
            Connect();
        }

        private void Save()
        {
            if (check == 0)
            {
                Save_InsDele();
                txtNum.Text = "";
                txtName.Text = "";
                txtMgrSSN.Text = "";
                txtMgrAssDate.Text = "";
            }
            else if (check == 1)
            {
                Save_Update();
                txtNum.Text = "";
                txtName.Text = "";
                txtMgrSSN.Text = "";
                txtMgrAssDate.Text = "";
            }
            else
            {
                MessageBox.Show("Failed!");
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
            btnConnect.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            check = -1;
            txtNum.Text = "";
            txtName.Text = "";
            txtMgrSSN.Text = "";
            txtMgrAssDate.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Insert();            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();        
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            num = e.RowIndex;
            txtNum.Text = dataGridView.Rows[num].Cells[0].Value.ToString();
            txtName.Text = dataGridView.Rows[num].Cells[1].Value.ToString();
            txtMgrSSN.Text = dataGridView.Rows[num].Cells[2].Value.ToString();
            txtMgrAssDate.Text = dataGridView.Rows[num].Cells[3].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

      
    }
}
