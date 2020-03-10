using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        static int numrow = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        Boolean CheckInput()
        {
            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            DateTime time_now = DateTime.Now;
            int year_now = time_now.Year;
            DateTime time = date.Value;
            int year = time.Year;
            if (name.Length == 0)
            {
                error.SetError(txtName, "Name is empty !!!");
                return false;
            }else if ((year_now - year) < 18)
            {
                error.SetError(date, "Age must be < or = 18 !!!");
                return false;
            }else if ((radMale.Checked == false) && (radFemale.Checked == false))
            {
                error.SetError(groupBox2, "Gender is empty !!!");
                return false;
            }else if(cmbNational.SelectedIndex < 0)
            {
                error.SetError(cmbNational, "National is empty !!!");
                return false;
            }else if(maskPhone.MaskCompleted == false)
            {
                error.SetError(maskPhone, "Incorrect Phone number !!!");
                return false;
            }else if (address.Length == 0)
            {
                error.SetError(txtAddress, "Incorrect Phone number !!!");
                return false;
            }else if (cmbQua.SelectedIndex < 0)
            {
                error.SetError(cmbQua, "Qualification is empty !!!");
                return false;
            }
            try 
            {
                double salary = Double.Parse(txtSalary.Text.Trim());
            }
            catch
            {
                error.SetError(txtSalary, "Salary isn't empty or isn't contain characters");
                return false;
            }
            return true;
        }

        void Add()
        {
            string gender = "";
            if (radMale.Checked == true)
            {
                gender = "Male";
            }
            else if (radFemale.Checked = true)
            {
                gender = "Female";
            }
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgEmployees);
            r.SetValues(txtName.Text, date.Value.ToShortDateString(), gender, cmbNational.Text, maskPhone.Text, txtAddress.Text, cmbQua.Text, txtSalary.Text);
            dgEmployees.Rows.Add(r);
        }

        void Clear()
        {
            txtName.Clear();
            date.Value = DateTime.Now;
            radMale.Checked = false;
            radFemale.Checked = false;
            cmbNational.Text = null;
            cmbNational.SelectedIndex = -1;
            maskPhone.Clear();
            cmbQua.Text = null;
            cmbQua.SelectedIndex = -1;
            txtAddress.Clear();
            txtSalary.Clear();
        }

        void UpdateInfo()
        {
            if (numrow != -1)
            {
                CheckInput();
                if (CheckInput() == true)
                {
                    lberror.Text = "";
                int rowindex = dgEmployees.CurrentCell.RowIndex;
                dgEmployees.Rows.RemoveAt(rowindex);
                numrow = -1;
                    Add();
                }
            }
            else
            {
                lberror.Text = "You must choose row to delete !!!";
            }
        }

        void Delete()
        {
            if (numrow != -1)
            {
                lberror.Text = "";
                int rowindex = dgEmployees.CurrentCell.RowIndex;
                dgEmployees.Rows.RemoveAt(rowindex);
                numrow = -1;
                Clear();
            }
            else
            {
                lberror.Text = "You must choose row to delete !!!";
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            btnAdd.Enabled = true;
            lberror.Text ="";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CheckInput();
            if(CheckInput() == true) 
            {
                Add();
                btnAdd.Enabled = false;
            }
        }
        
        private void dgEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {       
                numrow = e.RowIndex;
                txtName.Text = dgEmployees.Rows[numrow].Cells[0].Value.ToString();
                date.Text = dgEmployees.Rows[numrow].Cells[1].Value.ToString();
                string gender = dgEmployees.Rows[numrow].Cells[2].Value.ToString();
                if (gender.Equals("Male"))
                {
                    radMale.Checked = true;
                }
                else radFemale.Checked = true;
                cmbNational.Text = dgEmployees.Rows[numrow].Cells[3].Value.ToString();
                maskPhone.Text = dgEmployees.Rows[numrow].Cells[4].Value.ToString();
                txtAddress.Text = dgEmployees.Rows[numrow].Cells[5].Value.ToString();
                cmbQua.Text = dgEmployees.Rows[numrow].Cells[6].Value.ToString();
                txtSalary.Text = dgEmployees.Rows[numrow].Cells[7].Value.ToString();
            }
            catch
            {
                lberror.Text = "Somthing wrong !!!";
            }
            }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // saveFileDialog1.Filter = "Data files|*.dat|Text files|*.txt|Both files|*.dat;*.txt";
            DialogResult rs = saveFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(fileName);
                string Line = "";
                for (int i = 0; i < dgEmployees.Rows.Count - 0; ++i)
                {
                    if (i == dgEmployees.NewRowIndex)
                    {
                        break;
                    }
                    Line = "";
                    for (int j = 0; j < dgEmployees.Columns.Count; ++j)
                    {
                        Line += dgEmployees[j, i].Value + ";";
                    }
                    //sw.WriteLine();
                    sw.WriteLine(Line);
                }
                sw.Close();
            }
        }

        void SearchbyName()
        {
            FrmSearchResult frm = new FrmSearchResult();
            for (int i = 0; i < dgEmployees.Rows.Count; i++)
            {
                DataGridViewRow r = dgEmployees.Rows[i];
                if (r.Cells[0].Value.ToString().Equals(txtSearch.Text))
                {
                    frm.AddEmployeeInfo(r.Cells[0].Value.ToString(),
                    r.Cells[1].Value.ToString(), r.Cells[2].Value.ToString(),
                    r.Cells[3].Value.ToString(), r.Cells[4].Value.ToString(),
                    r.Cells[5].Value.ToString(), r.Cells[6].Value.ToString(),
                    r.Cells[7].Value.ToString());
                }
            }
            frm.ShowDialog();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "Data files|*.dat|Text files|*.txt||*.dBoth filesat;*.txt";
            openFileDialog1.Filter = "Data files|*.dat|Text files|*.txt|Both files|*.dat;*.txt|All files|*.*";
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult rs = openFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(fileName);
                string Line = sr.ReadLine();
                while ((Line != null) && (Line != " "))
                {
                    string[] array = Line.Split(';');
                    dgEmployees.Rows.Add(array);
                    Line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            SearchbyName();
        }

        private void BtnFilter_Click_1(object sender, EventArgs e)
        {
            FrmSearchResult frm = new FrmSearchResult();
            for (int i = 0; i < dgEmployees.Rows.Count; i++)
            {
                DataGridViewRow r = dgEmployees.Rows[i];
                if (r.Cells[3].Value.ToString().Equals(cbNationalFilter.Text))
                //if (r.Cells[3].Value.ToString().Equals(cbNationalFilter.Text))
                {
                    frm.AddEmployeeInfo(r.Cells[0].Value.ToString(),
                    r.Cells[1].Value.ToString(), r.Cells[2].Value.ToString(),
                    r.Cells[3].Value.ToString(), r.Cells[4].Value.ToString(),
                    r.Cells[5].Value.ToString(), r.Cells[6].Value.ToString(),
                    r.Cells[7].Value.ToString());
                }
            }
            frm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }
    }
}
