using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RentMetrics
{
    public partial class FormProgress : Form
    {
        public ProgressBar bar { get { return progressBar1; } }
        public FormProgress()
        {
            InitializeComponent();
        }
    }
}
