namespace RentMetrics
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.btnHomes = this.Factory.CreateRibbonButton();
            this.btnApartments = this.Factory.CreateRibbonButton();
            this.btnHelp = this.Factory.CreateRibbonButton();
            this.btnAPI = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group3.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group3);
            this.tab1.Label = "RentMetrics";
            this.tab1.Name = "tab1";
            // 
            // group3
            // 
            this.group3.Items.Add(this.btnHomes);
            this.group3.Items.Add(this.btnApartments);
            this.group3.Items.Add(this.btnHelp);
            this.group3.Items.Add(this.btnAPI);
            this.group3.Label = "Rent Comparables";
            this.group3.Name = "group3";
            // 
            // btnHomes
            // 
            this.btnHomes.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnHomes.Image = global::RentMetrics.Properties.Resources.free_vector_purzen_house_icon_clip_art_104702_Purzen_House_Icon_clip_art_hight;
            this.btnHomes.Label = "Singlefamily";
            this.btnHomes.Name = "btnHomes";
            this.btnHomes.ShowImage = true;
            this.btnHomes.SuperTip = "Single-family residences";
            this.btnHomes.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnHomes_Click);
            // 
            // btnApartments
            // 
            this.btnApartments.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnApartments.Image = global::RentMetrics.Properties.Resources.Accommodation_Apartment_icon;
            this.btnApartments.Label = "Multifamily";
            this.btnApartments.Name = "btnApartments";
            this.btnApartments.ShowImage = true;
            this.btnApartments.SuperTip = "Apartments, Condos, Lofts & Townhomes";
            this.btnApartments.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnApartments_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnHelp.Image = global::RentMetrics.Properties.Resources.Actions_help_contents_icon;
            this.btnHelp.Label = "Help";
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.ShowImage = true;
            this.btnHelp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnHelp_Click);
            // 
            // btnAPI
            // 
            this.btnAPI.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAPI.Image = global::RentMetrics.Properties.Resources.roundel2;
            this.btnAPI.Label = "Enter/Change Access Key";
            this.btnAPI.Name = "btnAPI";
            this.btnAPI.ShowImage = true;
            this.btnAPI.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAPI_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAPI;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnHomes;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnApartments;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnHelp;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
