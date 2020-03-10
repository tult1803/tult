using System;
using System.Windows.Forms;
using System.IO;

namespace EmployeeForm
{
    public partial class frmEmployee : Form
    {
        //String EmpID;
        bool showSearch = false;
        public frmEmployee()
        {      
            InitializeComponent();
        }     
        bool ValidateInput()
        {
            string name = txtFullName.Text.Trim();
            bool bError = false;
            if (name.Length == 0)
            {
                errorProvider1.SetError(txtFullName, "Please enter your name!");
                bError = true;
            }
            DateTime currDate = DateTime.Now;
            int currYear = currDate.Year;
            DateTime DateofBirth = dTPDOB.Value;
            int birthYear = DateofBirth.Year;
            if (currYear - birthYear < 18)
            {
                errorProvider1.SetError(dTPDOB,
                    "Age must be greater than or equal to 18");
                bError = true;
            }
            if (radMale.Checked == false && radFemale.Checked == false)
            {
                errorProvider1.SetError(groupBox1, "Please select gender!");
                bError = true;
            }
            if (mtxtPhone.MaskCompleted == false)
            {
                errorProvider1.SetError(mtxtPhone,
                    "please enter required digit!");
                bError = true;
            }
            if (cbNational.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbNational,
                    "please select National!");
                bError = true;
            }
            if (bError == true)
            {
                return false;
            }
            else
                errorProvider1.Clear();
            return true;
        }
        void AddNewEmployee()
        {
            string gender = "";
            if (radMale.Checked == true)
                gender = "Male";
            else if (radFemale.Checked == true) gender = "Female";

            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgEmployees);
            r.SetValues(txtFullName.Text,
                dTPDOB.Value.ToShortDateString(),
                gender, cbNational.Text, mtxtPhone.Text, txtAddress.Text,
                cbQualification.Text, txtSalary.Text);
            dgEmployees.Rows.Add(r);
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //reset
            txtFullName.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
            mtxtPhone.Clear();
            dTPDOB.Value = DateTime.Now;
            radFemale.Checked = false;
            radMale.Checked = false;
            cbNational.SelectedIndex = -1;
            cbQualification.SelectedIndex = -1;
            //Active/Deactive
            BtnAdd.Enabled = true;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
                return;
            AddNewEmployee();
            BtnAdd.Enabled = false;
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchbyName();
        }
        void SearchbyName()
        {
            FrmSearchResult frm = new FrmSearchResult();
            for (int i = 0; i < dgEmployees.Rows.Count; i++)
            {
                DataGridViewRow r = dgEmployees.Rows[i];
                if (r.Cells[0].Value.ToString().Equals(txtName.Text))
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
        private void BtnFilter_Click(object sender, EventArgs e)
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
        private void BtnSavetoFile_Click(object sender, EventArgs e)
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
        private void BtnLoadfromFile_Click(object sender, EventArgs e)
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
        private void BtnShowHide_Click(object sender, EventArgs e)
        {
            pnSearchOptions.Visible = showSearch;
            showSearch = !showSearch;
        }
    }
}
