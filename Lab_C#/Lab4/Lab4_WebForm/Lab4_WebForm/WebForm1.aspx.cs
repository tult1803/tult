using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4_WebForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSwitch_Click(object sender, ImageClickEventArgs e)
        {
            
            if (lblT.Text.Contains("T"))
            {
                lblF.Text = "To"; lblT.Text = "From";
                txt1.Enabled = false;
                txt2.Enabled = true;
                txt1.Text = "";
            }
            else
            if (lblT.Text.Contains("F"))
            {
                txt2.Text = "";
                txt1.Enabled = true;
                txt2.Enabled = false;
                lblF.Text = "Form"; lblT.Text = "To";
            }

            lblError.Text = "Switched !!!";

        }

        protected double Currency()
        {

            if (list.Text.Equals("AUD"))
            {
                return 15394.88;
            }
            else if (list.Text.Equals("EUR"))
            {
                return 25400.81;
            }
            else if (list.Text.Equals("GBP"))
            {
                return 29295.26;
            }
            else if (list.Text.Equals("HKD"))
            {
                return 2911.78;
            }
            else if (list.Text.Equals("JPY"))
            {
                return 203.3;
            }
            else if (list.Text.Equals("SGD"))
            {
                return 16690.08;
            }
            else if (list.Text.Equals("THB"))
            {
                return 747.79;
            }
            else if (list.Text.Equals("USD"))
            {
                return 23110;
            }

            return 0;
        }

        protected void btnCon_Click(object sender, EventArgs e)
        {
            try
            {
            if (txt1.Enabled == true)
            {
                double vnd = Double.Parse(txt1.Text);
                txt2.Text = vnd / Currency() + "";
            }else if (txt1.Enabled == false)
            {
                double foreignCurrency = Double.Parse(txt2.Text);
                txt1.Text = foreignCurrency * Currency() + "";
            }
                lblError.Text = "Successed !!!";
            }
            catch
            {
                lblError.Text = "Error !!!";
            }
        }
    }
}