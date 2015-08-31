using System;
using System.Windows.Forms;

namespace RentMetrics
{
    public partial class FormSearch : Form
    {
        public dynamic d;
        Boolean isHomes = false;
        public FormSearch(Boolean isHome)
        {
            InitializeComponent();

            isHomes = isHome;

            txtAddress.GotFocus += txtAddress_GotFocus;
            txtAddress.LostFocus += txtAddress_LostFocus;

            txtFrom.Text = DateTime.Now.AddMonths(-3).Date.ToString("yyyy-MM-dd");
            txtTo.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

            txtAddress.Text = "e.g. 330 Townsend St., San Francisco, CA";
            
            ddlBedrooms.Items.AddRange(new String[] { "All", "Studio", "1 BR", "2 BR", "3 BR", "4 BR", "5 BR" });
            if (isHomes) ddlBedrooms.Items.RemoveAt(0);
            if (isHomes) ddlBedrooms.Items.RemoveAt(0);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                btnGo_Click(null, null);
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        void txtAddress_GotFocus(object sender, EventArgs e)
        {
            return;
            if (txtAddress.Text == "330 Townsend St., \nSan Francisco, \nCA 94107")
                txtAddress.Text = "";
        }

        void txtAddress_LostFocus(object sender, EventArgs e)
        {
            return;
            if (txtAddress.Text == "")
                txtAddress.Text = "330 Townsend St., \nSan Francisco, \nCA 94107";
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = false;

            String beds = "";

            switch (ddlBedrooms.Text)
            {
                case "All":
                    beds = "";
                    break;

                case "Studio":
                    beds = "0";
                    break;

                case "1 BR":
                    beds = "1";
                    break;

                case "2 BR":
                    beds = "2";
                    break;

                case "3 BR":
                    beds = "3";
                    break;

                case "4 BR":
                    beds = "4";
                    break;

                case "5 BR":
                    beds = "5";
                    break;

                case "6 BR":
                    beds = "6";
                    break;
            }

            if (isHomes)
                d = UDFs.RentHomes(txtAddress.Text, beds, ddlBathrooms.Text, txtFrom.Text, txtTo.Text, ddlDistance.Text, ddlLimit.Text, "", "");
            else
                d = UDFs.RentApts(txtAddress.Text, beds, ddlBathrooms.Text, txtFrom.Text, txtTo.Text, ddlDistance.Text, ddlLimit.Text, "", "");

            if (d == null)
            {
                btnGo.Enabled = true;
                return;
            }
            
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtFrom_Leave(object sender, EventArgs e)
        {
            FormatDate(txtFrom);
        }

        private void txtTo_Leave(object sender, EventArgs e)
        {
            FormatDate(txtTo);
        }

        private void FormatDate(TextBox txtBox)
        {
            DateTime dt = DateTime.Now;
            if (DateTime.TryParse(txtBox.Text, out dt))
                txtBox.Text = dt.ToString("yyyy-MM-dd");
            else if (!String.IsNullOrWhiteSpace(txtBox.Text))
            {
                MessageBox.Show("The date you have entered is invalid.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                txtBox.Text = "";
                txtBox.Focus();
            }
        }
    }
}
