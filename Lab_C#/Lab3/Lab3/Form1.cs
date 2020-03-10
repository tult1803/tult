using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
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
            btnAdd.Enabled = true;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
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
    }
}
