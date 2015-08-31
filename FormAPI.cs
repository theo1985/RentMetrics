using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RentMetrics.Properties;

namespace RentMetrics
{
    public partial class FormAPI : Form
    {
        public FormAPI()
        {
            InitializeComponent();
            txtApiKey.Text = Reg.API;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Reg.API = txtApiKey.Text.Trim();
            this.Close();
        }

        private void txtApiKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave_Click(sender, e);
            else if (e.KeyCode == Keys.Escape)
                btnCancel_Click(sender, e);
        }
    }
}
