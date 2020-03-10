using System;
using System.Windows.Forms;

namespace EmployeeForm
{
    public partial class FrmSearchResult : Form
    {
        public FrmSearchResult()
        {
            InitializeComponent();
        }

        public void AddEmployeeInfo(params String[] values)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(gvEmployees);
            for (int i = 0; i < r.Cells.Count; i++)
            {
                //DataGridViewRow r = new DataGridViewRow();
                //r.CreateCells(gvEmployees);
                r.Cells[i].Value = values[i];
            }
            gvEmployees.Rows.Add(r);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
