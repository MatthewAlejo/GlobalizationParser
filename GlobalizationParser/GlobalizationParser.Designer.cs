namespace GlobalizationPointsOfInterest
{
    partial class GlobalizationParser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("String Concatenations");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("String Comparisons");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Functions Returning Strings");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Multiple Words Only");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Double Quoted Strings", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Hard Coded Strings", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Date Formats");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Decimal Formats");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("SelectAll", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode6,
            treeNode7,
            treeNode8});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalizationParser));
            this.folderBrowserDialogSource = new System.Windows.Forms.FolderBrowserDialog();
            this.txtboxInputPath = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.folderBrowserDialogTarget = new System.Windows.Forms.FolderBrowserDialog();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.progbar = new System.Windows.Forms.ProgressBar();
            this.lblConcat = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.saveFileDialog_Export = new System.Windows.Forms.SaveFileDialog();
            this.lstboxAnalyze = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.rbDirectory = new System.Windows.Forms.RadioButton();
            this.rbSolution = new System.Windows.Forms.RadioButton();
            this.btnProjects = new System.Windows.Forms.Button();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblAnalyze = new System.Windows.Forms.Label();
            this.panelConfig = new System.Windows.Forms.Panel();
            this.btnDefaultFilter = new System.Windows.Forms.Button();
            this.btnDeleteFilter = new System.Windows.Forms.Button();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.btnHelpConfig = new System.Windows.Forms.Button();
            this.treeViewConfig = new System.Windows.Forms.TreeView();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.btnHelp_Analysis = new System.Windows.Forms.Button();
            this.tabResults = new System.Windows.Forms.TabControl();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.btnExportOverview = new System.Windows.Forms.Button();
            this.lbl_OverView_Results = new System.Windows.Forms.Label();
            this.panelKey = new System.Windows.Forms.Panel();
            this.panelKey_Orange = new System.Windows.Forms.Panel();
            this.panelKey_Blue = new System.Windows.Forms.Panel();
            this.lblKey_Files = new System.Windows.Forms.Label();
            this.lblKey_Matches = new System.Windows.Forms.Label();
            this.btnHelp_Results = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panelDecimalBar = new System.Windows.Forms.Panel();
            this.lblDecimal = new System.Windows.Forms.Label();
            this.panelDecimalBarFiles = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblDateFormat = new System.Windows.Forms.Label();
            this.panelDateBar = new System.Windows.Forms.Panel();
            this.panelDateBarFiles = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblHardCoded = new System.Windows.Forms.Label();
            this.panelHardCodedBar = new System.Windows.Forms.Panel();
            this.panelHardCodedBarFiles = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblFunc = new System.Windows.Forms.Label();
            this.panelFuncBar = new System.Windows.Forms.Panel();
            this.panelFuncBarFiles = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelCompareBar = new System.Windows.Forms.Panel();
            this.lblCompare = new System.Windows.Forms.Label();
            this.panelCompareBarFiles = new System.Windows.Forms.Panel();
            this.panelOverviewConcat = new System.Windows.Forms.Panel();
            this.panelConcatBarFiles = new System.Windows.Forms.Panel();
            this.panelConcatBar = new System.Windows.Forms.Panel();
            this.tabConcatTV = new System.Windows.Forms.TabPage();
            this.cboSortConcat = new System.Windows.Forms.ComboBox();
            this.btnHelp_Concat = new System.Windows.Forms.Button();
            this.btnExpandConcat = new System.Windows.Forms.Button();
            this.btnExportStrConcat = new System.Windows.Forms.Button();
            this.treeViewConcat = new System.Windows.Forms.TreeView();
            this.tabCompareTV = new System.Windows.Forms.TabPage();
            this.btnHelp_Compare = new System.Windows.Forms.Button();
            this.btnExportStrCompare = new System.Windows.Forms.Button();
            this.cboSortCompare = new System.Windows.Forms.ComboBox();
            this.btnExpandCompare = new System.Windows.Forms.Button();
            this.treeViewCompare = new System.Windows.Forms.TreeView();
            this.tabFuncTV = new System.Windows.Forms.TabPage();
            this.cboSortFunc = new System.Windows.Forms.ComboBox();
            this.btnExpandFunc = new System.Windows.Forms.Button();
            this.btnHelp_Func = new System.Windows.Forms.Button();
            this.treeViewFunc = new System.Windows.Forms.TreeView();
            this.btnExportFunc = new System.Windows.Forms.Button();
            this.tabHardCodedTV = new System.Windows.Forms.TabPage();
            this.cboSortHardCoded = new System.Windows.Forms.ComboBox();
            this.btnExpandHardCoded = new System.Windows.Forms.Button();
            this.btnHelp_HardCoded = new System.Windows.Forms.Button();
            this.treeViewHardCoded = new System.Windows.Forms.TreeView();
            this.btnExportHardCoded = new System.Windows.Forms.Button();
            this.tabDateTV = new System.Windows.Forms.TabPage();
            this.cboSortDate = new System.Windows.Forms.ComboBox();
            this.btnExpandDate = new System.Windows.Forms.Button();
            this.btnHelp_Date = new System.Windows.Forms.Button();
            this.treeViewDate = new System.Windows.Forms.TreeView();
            this.btnExportDateFormat = new System.Windows.Forms.Button();
            this.tabDecimalTV = new System.Windows.Forms.TabPage();
            this.cboSortDecimal = new System.Windows.Forms.ComboBox();
            this.btnExpandDecimal = new System.Windows.Forms.Button();
            this.btnHelp_Decimal = new System.Windows.Forms.Button();
            this.treeViewDecimal = new System.Windows.Forms.TreeView();
            this.btnExportDecimal = new System.Windows.Forms.Button();
            this.gridCol_FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCol_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCol_LineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCol_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelConfig.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.tabResults.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.panelKey.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelOverviewConcat.SuspendLayout();
            this.tabConcatTV.SuspendLayout();
            this.tabCompareTV.SuspendLayout();
            this.tabFuncTV.SuspendLayout();
            this.tabHardCodedTV.SuspendLayout();
            this.tabDateTV.SuspendLayout();
            this.tabDecimalTV.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtboxInputPath
            // 
            this.txtboxInputPath.Location = new System.Drawing.Point(26, 67);
            this.txtboxInputPath.Name = "txtboxInputPath";
            this.txtboxInputPath.Size = new System.Drawing.Size(259, 20);
            this.txtboxInputPath.TabIndex = 0;
            this.txtboxInputPath.Text = "Select a Solution (.sln) file or Enter a Directory...";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStart.Location = new System.Drawing.Point(3, 541);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(301, 64);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Location = new System.Drawing.Point(327, 4);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(35, 13);
            this.lblProcessing.TabIndex = 7;
            this.lblProcessing.Text = "label1";
            this.lblProcessing.Visible = false;
            // 
            // progbar
            // 
            this.progbar.BackColor = System.Drawing.SystemColors.Control;
            this.progbar.Location = new System.Drawing.Point(330, 33);
            this.progbar.Name = "progbar";
            this.progbar.Size = new System.Drawing.Size(720, 23);
            this.progbar.TabIndex = 8;
            this.progbar.Visible = false;
            // 
            // lblConcat
            // 
            this.lblConcat.AutoSize = true;
            this.lblConcat.BackColor = System.Drawing.Color.Transparent;
            this.lblConcat.Location = new System.Drawing.Point(3, 5);
            this.lblConcat.Name = "lblConcat";
            this.lblConcat.Size = new System.Drawing.Size(111, 13);
            this.lblConcat.TabIndex = 12;
            this.lblConcat.Text = "String Concatenations";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(157, 499);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 41);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.BackColor = System.Drawing.SystemColors.Control;
            this.lblPercentage.Location = new System.Drawing.Point(1056, 33);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(35, 13);
            this.lblPercentage.TabIndex = 28;
            this.lblPercentage.Text = "label1";
            this.lblPercentage.Visible = false;
            // 
            // lstboxAnalyze
            // 
            this.lstboxAnalyze.FormattingEnabled = true;
            this.lstboxAnalyze.HorizontalScrollbar = true;
            this.lstboxAnalyze.Location = new System.Drawing.Point(3, 31);
            this.lstboxAnalyze.Name = "lstboxAnalyze";
            this.lstboxAnalyze.Size = new System.Drawing.Size(251, 563);
            this.lstboxAnalyze.TabIndex = 46;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 499);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(151, 41);
            this.btnClear.TabIndex = 48;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(26, 93);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(128, 33);
            this.btnBrowse.TabIndex = 49;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // rbDirectory
            // 
            this.rbDirectory.AutoSize = true;
            this.rbDirectory.Location = new System.Drawing.Point(154, 17);
            this.rbDirectory.Name = "rbDirectory";
            this.rbDirectory.Size = new System.Drawing.Size(67, 17);
            this.rbDirectory.TabIndex = 50;
            this.rbDirectory.Text = "Directory";
            this.rbDirectory.UseVisualStyleBackColor = true;
            this.rbDirectory.CheckedChanged += new System.EventHandler(this.rbDirectory_CheckedChanged);
            // 
            // rbSolution
            // 
            this.rbSolution.AutoSize = true;
            this.rbSolution.Checked = true;
            this.rbSolution.Location = new System.Drawing.Point(66, 17);
            this.rbSolution.Name = "rbSolution";
            this.rbSolution.Size = new System.Drawing.Size(82, 17);
            this.rbSolution.TabIndex = 51;
            this.rbSolution.TabStop = true;
            this.rbSolution.Text = "Solution File";
            this.rbSolution.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.rbSolution.UseVisualStyleBackColor = true;
            this.rbSolution.CheckedChanged += new System.EventHandler(this.rbSolution_CheckedChanged);
            // 
            // btnProjects
            // 
            this.btnProjects.Enabled = false;
            this.btnProjects.Location = new System.Drawing.Point(157, 93);
            this.btnProjects.Name = "btnProjects";
            this.btnProjects.Size = new System.Drawing.Size(128, 33);
            this.btnProjects.TabIndex = 52;
            this.btnProjects.Text = "Filter Projects";
            this.btnProjects.UseVisualStyleBackColor = true;
            this.btnProjects.Click += new System.EventHandler(this.btnProjects_Click);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(26, 19);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(34, 13);
            this.lblInput.TabIndex = 53;
            this.lblInput.Text = "Input:";
            // 
            // lblAnalyze
            // 
            this.lblAnalyze.AutoSize = true;
            this.lblAnalyze.Location = new System.Drawing.Point(3, 7);
            this.lblAnalyze.Name = "lblAnalyze";
            this.lblAnalyze.Size = new System.Drawing.Size(150, 13);
            this.lblAnalyze.TabIndex = 54;
            this.lblAnalyze.Text = "Solution Info (Projects : #Files)";
            // 
            // panelConfig
            // 
            this.panelConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConfig.Controls.Add(this.btnDefaultFilter);
            this.panelConfig.Controls.Add(this.btnProjects);
            this.panelConfig.Controls.Add(this.btnDeleteFilter);
            this.panelConfig.Controls.Add(this.btnBrowse);
            this.panelConfig.Controls.Add(this.btnAddFilter);
            this.panelConfig.Controls.Add(this.cboFileType);
            this.panelConfig.Controls.Add(this.btnHelpConfig);
            this.panelConfig.Controls.Add(this.treeViewConfig);
            this.panelConfig.Controls.Add(this.btnCancel);
            this.panelConfig.Controls.Add(this.txtboxInputPath);
            this.panelConfig.Controls.Add(this.btnStart);
            this.panelConfig.Controls.Add(this.rbSolution);
            this.panelConfig.Controls.Add(this.btnClear);
            this.panelConfig.Controls.Add(this.rbDirectory);
            this.panelConfig.Controls.Add(this.lblInput);
            this.panelConfig.Location = new System.Drawing.Point(12, 62);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(312, 609);
            this.panelConfig.TabIndex = 60;
            // 
            // btnDefaultFilter
            // 
            this.btnDefaultFilter.Location = new System.Drawing.Point(26, 427);
            this.btnDefaultFilter.Name = "btnDefaultFilter";
            this.btnDefaultFilter.Size = new System.Drawing.Size(259, 31);
            this.btnDefaultFilter.TabIndex = 65;
            this.btnDefaultFilter.Text = "Restore Defaults";
            this.btnDefaultFilter.UseVisualStyleBackColor = true;
            this.btnDefaultFilter.Click += new System.EventHandler(this.btnDefaultFilter_Click);
            // 
            // btnDeleteFilter
            // 
            this.btnDeleteFilter.Location = new System.Drawing.Point(157, 458);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(128, 32);
            this.btnDeleteFilter.TabIndex = 63;
            this.btnDeleteFilter.Text = "Delete Filter";
            this.btnDeleteFilter.UseVisualStyleBackColor = true;
            this.btnDeleteFilter.Click += new System.EventHandler(this.btnDeleteFilter_Click);
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Location = new System.Drawing.Point(26, 458);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(128, 32);
            this.btnAddFilter.TabIndex = 62;
            this.btnAddFilter.Text = "Add Filter";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // cboFileType
            // 
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Items.AddRange(new object[] {
            "C# files (.cs)",
            "CSHTML files (.cshtml)",
            "Javascript files  (.js)"});
            this.cboFileType.Location = new System.Drawing.Point(26, 40);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(259, 21);
            this.cboFileType.TabIndex = 63;
            this.cboFileType.Text = "Select a file type to parse for";
            this.cboFileType.SelectedIndexChanged += new System.EventHandler(this.FileType_CheckChanged);
            // 
            // btnHelpConfig
            // 
            this.btnHelpConfig.Image = global::GlobalizationPointsOfInterest.Properties.Resources.Help;
            this.btnHelpConfig.Location = new System.Drawing.Point(283, -1);
            this.btnHelpConfig.Name = "btnHelpConfig";
            this.btnHelpConfig.Size = new System.Drawing.Size(28, 28);
            this.btnHelpConfig.TabIndex = 62;
            this.btnHelpConfig.UseVisualStyleBackColor = true;
            this.btnHelpConfig.Click += new System.EventHandler(this.btnHelpConfig_Click);
            // 
            // treeViewConfig
            // 
            this.treeViewConfig.CheckBoxes = true;
            this.treeViewConfig.Location = new System.Drawing.Point(26, 132);
            this.treeViewConfig.Name = "treeViewConfig";
            treeNode1.Name = "NodeStrConcat";
            treeNode1.Text = "String Concatenations";
            treeNode2.Name = "NodeStrCompare";
            treeNode2.Text = "String Comparisons";
            treeNode3.Name = "NodeStrFunc";
            treeNode3.Text = "Functions Returning Strings";
            treeNode4.Name = "NodeHardCoded_QuotedMulti";
            treeNode4.Text = "Multiple Words Only";
            treeNode5.Name = "NodeHardCoded_Quoted";
            treeNode5.Text = "Double Quoted Strings";
            treeNode6.Name = "NodeHardCoded";
            treeNode6.Text = "Hard Coded Strings";
            treeNode7.Name = "NodeDate";
            treeNode7.Text = "Date Formats";
            treeNode8.Name = "NodeDecimal";
            treeNode8.Text = "Decimal Formats";
            treeNode9.Name = "NodeSelectAll";
            treeNode9.Text = "SelectAll";
            this.treeViewConfig.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeViewConfig.Size = new System.Drawing.Size(259, 295);
            this.treeViewConfig.TabIndex = 61;
            this.treeViewConfig.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewConfig_AfterCheck);
            // 
            // panelInfo
            // 
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.btnHelp_Analysis);
            this.panelInfo.Controls.Add(this.lstboxAnalyze);
            this.panelInfo.Controls.Add(this.lblAnalyze);
            this.panelInfo.Location = new System.Drawing.Point(1093, 62);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(259, 609);
            this.panelInfo.TabIndex = 61;
            // 
            // btnHelp_Analysis
            // 
            this.btnHelp_Analysis.Image = global::GlobalizationPointsOfInterest.Properties.Resources.Help;
            this.btnHelp_Analysis.Location = new System.Drawing.Point(230, -1);
            this.btnHelp_Analysis.Name = "btnHelp_Analysis";
            this.btnHelp_Analysis.Size = new System.Drawing.Size(28, 28);
            this.btnHelp_Analysis.TabIndex = 62;
            this.btnHelp_Analysis.UseVisualStyleBackColor = true;
            this.btnHelp_Analysis.Click += new System.EventHandler(this.btnHelp_Analysis_Click);
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.tabOverview);
            this.tabResults.Controls.Add(this.tabConcatTV);
            this.tabResults.Controls.Add(this.tabCompareTV);
            this.tabResults.Controls.Add(this.tabFuncTV);
            this.tabResults.Controls.Add(this.tabHardCodedTV);
            this.tabResults.Controls.Add(this.tabDateTV);
            this.tabResults.Controls.Add(this.tabDecimalTV);
            this.tabResults.Location = new System.Drawing.Point(330, 62);
            this.tabResults.Name = "tabResults";
            this.tabResults.SelectedIndex = 0;
            this.tabResults.Size = new System.Drawing.Size(757, 610);
            this.tabResults.TabIndex = 40;
            // 
            // tabOverview
            // 
            this.tabOverview.BackColor = System.Drawing.SystemColors.Control;
            this.tabOverview.Controls.Add(this.btnExportOverview);
            this.tabOverview.Controls.Add(this.lbl_OverView_Results);
            this.tabOverview.Controls.Add(this.panelKey);
            this.tabOverview.Controls.Add(this.btnHelp_Results);
            this.tabOverview.Controls.Add(this.panel16);
            this.tabOverview.Controls.Add(this.panel13);
            this.tabOverview.Controls.Add(this.panel10);
            this.tabOverview.Controls.Add(this.panel6);
            this.tabOverview.Controls.Add(this.panel3);
            this.tabOverview.Controls.Add(this.panelOverviewConcat);
            this.tabOverview.Location = new System.Drawing.Point(4, 22);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tabOverview.Size = new System.Drawing.Size(749, 584);
            this.tabOverview.TabIndex = 14;
            this.tabOverview.Text = "Overview";
            // 
            // btnExportOverview
            // 
            this.btnExportOverview.Location = new System.Drawing.Point(523, 0);
            this.btnExportOverview.Name = "btnExportOverview";
            this.btnExportOverview.Size = new System.Drawing.Size(193, 28);
            this.btnExportOverview.TabIndex = 64;
            this.btnExportOverview.Text = "Export Overview";
            this.btnExportOverview.UseVisualStyleBackColor = true;
            this.btnExportOverview.Click += new System.EventHandler(this.btnExportOverview_Click);
            // 
            // lbl_OverView_Results
            // 
            this.lbl_OverView_Results.AutoSize = true;
            this.lbl_OverView_Results.Location = new System.Drawing.Point(3, 31);
            this.lbl_OverView_Results.Name = "lbl_OverView_Results";
            this.lbl_OverView_Results.Size = new System.Drawing.Size(220, 13);
            this.lbl_OverView_Results.TabIndex = 63;
            this.lbl_OverView_Results.Text = "Results For Filetype: {0} in Project/Folder: {1}";
            // 
            // panelKey
            // 
            this.panelKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelKey.Controls.Add(this.panelKey_Orange);
            this.panelKey.Controls.Add(this.panelKey_Blue);
            this.panelKey.Controls.Add(this.lblKey_Files);
            this.panelKey.Controls.Add(this.lblKey_Matches);
            this.panelKey.Location = new System.Drawing.Point(213, 3);
            this.panelKey.Name = "panelKey";
            this.panelKey.Size = new System.Drawing.Size(277, 25);
            this.panelKey.TabIndex = 62;
            // 
            // panelKey_Orange
            // 
            this.panelKey_Orange.Location = new System.Drawing.Point(164, 4);
            this.panelKey_Orange.Name = "panelKey_Orange";
            this.panelKey_Orange.Size = new System.Drawing.Size(15, 15);
            this.panelKey_Orange.TabIndex = 64;
            // 
            // panelKey_Blue
            // 
            this.panelKey_Blue.Location = new System.Drawing.Point(16, 4);
            this.panelKey_Blue.Name = "panelKey_Blue";
            this.panelKey_Blue.Size = new System.Drawing.Size(15, 15);
            this.panelKey_Blue.TabIndex = 63;
            // 
            // lblKey_Files
            // 
            this.lblKey_Files.AutoSize = true;
            this.lblKey_Files.Location = new System.Drawing.Point(185, 4);
            this.lblKey_Files.Name = "lblKey_Files";
            this.lblKey_Files.Size = new System.Drawing.Size(80, 13);
            this.lblKey_Files.TabIndex = 1;
            this.lblKey_Files.Text = "= Files Affected";
            // 
            // lblKey_Matches
            // 
            this.lblKey_Matches.AutoSize = true;
            this.lblKey_Matches.Location = new System.Drawing.Point(37, 4);
            this.lblKey_Matches.Name = "lblKey_Matches";
            this.lblKey_Matches.Size = new System.Drawing.Size(90, 13);
            this.lblKey_Matches.TabIndex = 0;
            this.lblKey_Matches.Text = "= Matches Found";
            // 
            // btnHelp_Results
            // 
            this.btnHelp_Results.Image = global::GlobalizationPointsOfInterest.Properties.Resources.Help;
            this.btnHelp_Results.Location = new System.Drawing.Point(721, 0);
            this.btnHelp_Results.Name = "btnHelp_Results";
            this.btnHelp_Results.Size = new System.Drawing.Size(28, 28);
            this.btnHelp_Results.TabIndex = 61;
            this.btnHelp_Results.UseVisualStyleBackColor = true;
            this.btnHelp_Results.Click += new System.EventHandler(this.btnHelp_Results_Click);
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.panelDecimalBar);
            this.panel16.Controls.Add(this.lblDecimal);
            this.panel16.Controls.Add(this.panelDecimalBarFiles);
            this.panel16.Location = new System.Drawing.Point(0, 494);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(749, 90);
            this.panel16.TabIndex = 44;
            this.panel16.Click += new System.EventHandler(this.OverviewDecimal_Click);
            // 
            // panelDecimalBar
            // 
            this.panelDecimalBar.Location = new System.Drawing.Point(5, 31);
            this.panelDecimalBar.Name = "panelDecimalBar";
            this.panelDecimalBar.Size = new System.Drawing.Size(740, 27);
            this.panelDecimalBar.TabIndex = 61;
            this.panelDecimalBar.Click += new System.EventHandler(this.OverviewDecimal_Click);
            // 
            // lblDecimal
            // 
            this.lblDecimal.AutoSize = true;
            this.lblDecimal.BackColor = System.Drawing.Color.Transparent;
            this.lblDecimal.Location = new System.Drawing.Point(3, 3);
            this.lblDecimal.Name = "lblDecimal";
            this.lblDecimal.Size = new System.Drawing.Size(85, 13);
            this.lblDecimal.TabIndex = 62;
            this.lblDecimal.Text = "Decimal Formats";
            this.lblDecimal.Click += new System.EventHandler(this.OverviewDecimal_Click);
            // 
            // panelDecimalBarFiles
            // 
            this.panelDecimalBarFiles.Location = new System.Drawing.Point(5, 57);
            this.panelDecimalBarFiles.Name = "panelDecimalBarFiles";
            this.panelDecimalBarFiles.Size = new System.Drawing.Size(740, 27);
            this.panelDecimalBarFiles.TabIndex = 13;
            this.panelDecimalBarFiles.Click += new System.EventHandler(this.OverviewDecimal_Click);
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.lblDateFormat);
            this.panel13.Controls.Add(this.panelDateBar);
            this.panel13.Controls.Add(this.panelDateBarFiles);
            this.panel13.Location = new System.Drawing.Point(0, 405);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(749, 90);
            this.panel13.TabIndex = 43;
            this.panel13.Click += new System.EventHandler(this.OverviewDate_Click);
            // 
            // lblDateFormat
            // 
            this.lblDateFormat.AutoSize = true;
            this.lblDateFormat.BackColor = System.Drawing.Color.Transparent;
            this.lblDateFormat.Location = new System.Drawing.Point(3, 3);
            this.lblDateFormat.Name = "lblDateFormat";
            this.lblDateFormat.Size = new System.Drawing.Size(70, 13);
            this.lblDateFormat.TabIndex = 60;
            this.lblDateFormat.Text = "Date Formats";
            this.lblDateFormat.Click += new System.EventHandler(this.OverviewDate_Click);
            // 
            // panelDateBar
            // 
            this.panelDateBar.Location = new System.Drawing.Point(5, 33);
            this.panelDateBar.Name = "panelDateBar";
            this.panelDateBar.Size = new System.Drawing.Size(740, 27);
            this.panelDateBar.TabIndex = 59;
            this.panelDateBar.Click += new System.EventHandler(this.OverviewDate_Click);
            // 
            // panelDateBarFiles
            // 
            this.panelDateBarFiles.Location = new System.Drawing.Point(5, 57);
            this.panelDateBarFiles.Name = "panelDateBarFiles";
            this.panelDateBarFiles.Size = new System.Drawing.Size(740, 27);
            this.panelDateBarFiles.TabIndex = 13;
            this.panelDateBarFiles.Click += new System.EventHandler(this.OverviewDate_Click);
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.lblHardCoded);
            this.panel10.Controls.Add(this.panelHardCodedBar);
            this.panel10.Controls.Add(this.panelHardCodedBarFiles);
            this.panel10.Location = new System.Drawing.Point(0, 316);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(749, 90);
            this.panel10.TabIndex = 42;
            this.panel10.Click += new System.EventHandler(this.OverviewHardCoded_Click);
            // 
            // lblHardCoded
            // 
            this.lblHardCoded.AutoSize = true;
            this.lblHardCoded.BackColor = System.Drawing.Color.Transparent;
            this.lblHardCoded.Location = new System.Drawing.Point(3, 3);
            this.lblHardCoded.Name = "lblHardCoded";
            this.lblHardCoded.Size = new System.Drawing.Size(99, 13);
            this.lblHardCoded.TabIndex = 58;
            this.lblHardCoded.Text = "Hard Coded Strings";
            this.lblHardCoded.Click += new System.EventHandler(this.OverviewHardCoded_Click);
            // 
            // panelHardCodedBar
            // 
            this.panelHardCodedBar.Location = new System.Drawing.Point(5, 31);
            this.panelHardCodedBar.Name = "panelHardCodedBar";
            this.panelHardCodedBar.Size = new System.Drawing.Size(740, 27);
            this.panelHardCodedBar.TabIndex = 57;
            this.panelHardCodedBar.Click += new System.EventHandler(this.OverviewHardCoded_Click);
            // 
            // panelHardCodedBarFiles
            // 
            this.panelHardCodedBarFiles.Location = new System.Drawing.Point(5, 57);
            this.panelHardCodedBarFiles.Name = "panelHardCodedBarFiles";
            this.panelHardCodedBarFiles.Size = new System.Drawing.Size(740, 27);
            this.panelHardCodedBarFiles.TabIndex = 13;
            this.panelHardCodedBarFiles.Click += new System.EventHandler(this.OverviewHardCoded_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblFunc);
            this.panel6.Controls.Add(this.panelFuncBar);
            this.panel6.Controls.Add(this.panelFuncBarFiles);
            this.panel6.Location = new System.Drawing.Point(0, 227);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(749, 90);
            this.panel6.TabIndex = 41;
            this.panel6.Click += new System.EventHandler(this.OverviewFunc_Click);
            // 
            // lblFunc
            // 
            this.lblFunc.AutoSize = true;
            this.lblFunc.BackColor = System.Drawing.Color.Transparent;
            this.lblFunc.Location = new System.Drawing.Point(3, 3);
            this.lblFunc.Name = "lblFunc";
            this.lblFunc.Size = new System.Drawing.Size(137, 13);
            this.lblFunc.TabIndex = 56;
            this.lblFunc.Text = "Functions Returning Strings";
            this.lblFunc.Click += new System.EventHandler(this.OverviewFunc_Click);
            // 
            // panelFuncBar
            // 
            this.panelFuncBar.Location = new System.Drawing.Point(5, 31);
            this.panelFuncBar.Name = "panelFuncBar";
            this.panelFuncBar.Size = new System.Drawing.Size(740, 27);
            this.panelFuncBar.TabIndex = 55;
            this.panelFuncBar.Click += new System.EventHandler(this.OverviewFunc_Click);
            // 
            // panelFuncBarFiles
            // 
            this.panelFuncBarFiles.Location = new System.Drawing.Point(5, 57);
            this.panelFuncBarFiles.Name = "panelFuncBarFiles";
            this.panelFuncBarFiles.Size = new System.Drawing.Size(740, 27);
            this.panelFuncBarFiles.TabIndex = 13;
            this.panelFuncBarFiles.Click += new System.EventHandler(this.OverviewFunc_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panelCompareBar);
            this.panel3.Controls.Add(this.lblCompare);
            this.panel3.Controls.Add(this.panelCompareBarFiles);
            this.panel3.Location = new System.Drawing.Point(0, 138);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(749, 90);
            this.panel3.TabIndex = 40;
            this.panel3.Click += new System.EventHandler(this.OverviewCompare_Click);
            // 
            // panelCompareBar
            // 
            this.panelCompareBar.Location = new System.Drawing.Point(5, 31);
            this.panelCompareBar.Name = "panelCompareBar";
            this.panelCompareBar.Size = new System.Drawing.Size(740, 27);
            this.panelCompareBar.TabIndex = 53;
            this.panelCompareBar.Click += new System.EventHandler(this.OverviewCompare_Click);
            // 
            // lblCompare
            // 
            this.lblCompare.AutoSize = true;
            this.lblCompare.BackColor = System.Drawing.Color.Transparent;
            this.lblCompare.Location = new System.Drawing.Point(2, 3);
            this.lblCompare.Name = "lblCompare";
            this.lblCompare.Size = new System.Drawing.Size(97, 13);
            this.lblCompare.TabIndex = 54;
            this.lblCompare.Text = "String Comparisons";
            this.lblCompare.Click += new System.EventHandler(this.OverviewCompare_Click);
            // 
            // panelCompareBarFiles
            // 
            this.panelCompareBarFiles.Location = new System.Drawing.Point(5, 57);
            this.panelCompareBarFiles.Name = "panelCompareBarFiles";
            this.panelCompareBarFiles.Size = new System.Drawing.Size(740, 27);
            this.panelCompareBarFiles.TabIndex = 13;
            this.panelCompareBarFiles.Click += new System.EventHandler(this.OverviewCompare_Click);
            // 
            // panelOverviewConcat
            // 
            this.panelOverviewConcat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOverviewConcat.Controls.Add(this.panelConcatBarFiles);
            this.panelOverviewConcat.Controls.Add(this.lblConcat);
            this.panelOverviewConcat.Controls.Add(this.panelConcatBar);
            this.panelOverviewConcat.Location = new System.Drawing.Point(0, 49);
            this.panelOverviewConcat.Name = "panelOverviewConcat";
            this.panelOverviewConcat.Size = new System.Drawing.Size(749, 90);
            this.panelOverviewConcat.TabIndex = 39;
            this.panelOverviewConcat.Click += new System.EventHandler(this.OverviewConcat_Click);
            // 
            // panelConcatBarFiles
            // 
            this.panelConcatBarFiles.Location = new System.Drawing.Point(5, 57);
            this.panelConcatBarFiles.Name = "panelConcatBarFiles";
            this.panelConcatBarFiles.Size = new System.Drawing.Size(740, 27);
            this.panelConcatBarFiles.TabIndex = 13;
            this.panelConcatBarFiles.Click += new System.EventHandler(this.OverviewConcat_Click);
            // 
            // panelConcatBar
            // 
            this.panelConcatBar.Location = new System.Drawing.Point(5, 31);
            this.panelConcatBar.Name = "panelConcatBar";
            this.panelConcatBar.Size = new System.Drawing.Size(740, 27);
            this.panelConcatBar.TabIndex = 0;
            this.panelConcatBar.Click += new System.EventHandler(this.OverviewConcat_Click);
            // 
            // tabConcatTV
            // 
            this.tabConcatTV.BackColor = System.Drawing.SystemColors.Control;
            this.tabConcatTV.Controls.Add(this.cboSortConcat);
            this.tabConcatTV.Controls.Add(this.btnHelp_Concat);
            this.tabConcatTV.Controls.Add(this.btnExpandConcat);
            this.tabConcatTV.Controls.Add(this.btnExportStrConcat);
            this.tabConcatTV.Controls.Add(this.treeViewConcat);
            this.tabConcatTV.Location = new System.Drawing.Point(4, 22);
            this.tabConcatTV.Name = "tabConcatTV";
            this.tabConcatTV.Padding = new System.Windows.Forms.Padding(3);
            this.tabConcatTV.Size = new System.Drawing.Size(749, 584);
            this.tabConcatTV.TabIndex = 8;
            this.tabConcatTV.Text = "String Concatenations";
            // 
            // cboSortConcat
            // 
            this.cboSortConcat.FormattingEnabled = true;
            this.cboSortConcat.Items.AddRange(new object[] {
            "Sort By Ocurrence (Default)",
            "Sort By Number of Matches (Descending)",
            "Sort By Number of Matches (Ascending)"});
            this.cboSortConcat.Location = new System.Drawing.Point(54, 525);
            this.cboSortConcat.Name = "cboSortConcat";
            this.cboSortConcat.Size = new System.Drawing.Size(232, 21);
            this.cboSortConcat.TabIndex = 44;
            this.cboSortConcat.Text = "Choose a Sort Order";
            this.cboSortConcat.SelectedIndexChanged += new System.EventHandler(this.cboSort_SelectedIndexChanged);
            // 
            // btnHelp_Concat
            // 
            this.btnHelp_Concat.Image = global::GlobalizationPointsOfInterest.Properties.Resources.Help;
            this.btnHelp_Concat.Location = new System.Drawing.Point(0, 524);
            this.btnHelp_Concat.Name = "btnHelp_Concat";
            this.btnHelp_Concat.Size = new System.Drawing.Size(54, 60);
            this.btnHelp_Concat.TabIndex = 40;
            this.btnHelp_Concat.UseVisualStyleBackColor = true;
            this.btnHelp_Concat.Click += new System.EventHandler(this.btnHelp_Concat_Click);
            // 
            // btnExpandConcat
            // 
            this.btnExpandConcat.Enabled = false;
            this.btnExpandConcat.Location = new System.Drawing.Point(54, 547);
            this.btnExpandConcat.Name = "btnExpandConcat";
            this.btnExpandConcat.Size = new System.Drawing.Size(232, 37);
            this.btnExpandConcat.TabIndex = 41;
            this.btnExpandConcat.Text = "Expand/Collapse";
            this.btnExpandConcat.UseVisualStyleBackColor = true;
            this.btnExpandConcat.Click += new System.EventHandler(this.btnExpandCollapse_Click);
            // 
            // btnExportStrConcat
            // 
            this.btnExportStrConcat.Enabled = false;
            this.btnExportStrConcat.Location = new System.Drawing.Point(286, 524);
            this.btnExportStrConcat.Name = "btnExportStrConcat";
            this.btnExportStrConcat.Size = new System.Drawing.Size(463, 60);
            this.btnExportStrConcat.TabIndex = 39;
            this.btnExportStrConcat.Text = "ExportText...";
            this.btnExportStrConcat.UseVisualStyleBackColor = true;
            this.btnExportStrConcat.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // treeViewConcat
            // 
            this.treeViewConcat.Location = new System.Drawing.Point(0, 3);
            this.treeViewConcat.Name = "treeViewConcat";
            this.treeViewConcat.Size = new System.Drawing.Size(749, 516);
            this.treeViewConcat.TabIndex = 0;
            // 
            // tabCompareTV
            // 
            this.tabCompareTV.BackColor = System.Drawing.SystemColors.Control;
            this.tabCompareTV.Controls.Add(this.btnHelp_Compare);
            this.tabCompareTV.Controls.Add(this.btnExportStrCompare);
            this.tabCompareTV.Controls.Add(this.cboSortCompare);
            this.tabCompareTV.Controls.Add(this.btnExpandCompare);
            this.tabCompareTV.Controls.Add(this.treeViewCompare);
            this.tabCompareTV.Location = new System.Drawing.Point(4, 22);
            this.tabCompareTV.Name = "tabCompareTV";
            this.tabCompareTV.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompareTV.Size = new System.Drawing.Size(749, 584);
            this.tabCompareTV.TabIndex = 9;
            this.tabCompareTV.Text = "String Comparisons";
            // 
            // btnHelp_Compare
            // 
            this.btnHelp_Compare.Image = global::GlobalizationPointsOfInterest.Properties.Resources.Help;
            this.btnHelp_Compare.Location = new System.Drawing.Point(0, 524);
            this.btnHelp_Compare.Name = "btnHelp_Compare";
            this.btnHelp_Compare.Size = new System.Drawing.Size(54, 60);
            this.btnHelp_Compare.TabIndex = 41;
            this.btnHelp_Compare.UseVisualStyleBackColor = true;
            this.btnHelp_Compare.Click += new System.EventHandler(this.btnHelp_Compare_Click);
            // 
            // btnExportStrCompare
            // 
            this.btnExportStrCompare.Enabled = false;
            this.btnExportStrCompare.Location = new System.Drawing.Point(286, 524);
            this.btnExportStrCompare.Name = "btnExportStrCompare";
            this.btnExportStrCompare.Size = new System.Drawing.Size(463, 60);
            this.btnExportStrCompare.TabIndex = 40;
            this.btnExportStrCompare.Text = "ExportText...";
            this.btnExportStrCompare.UseVisualStyleBackColor = true;
            this.btnExportStrCompare.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cboSortCompare
            // 
            this.cboSortCompare.FormattingEnabled = true;
            this.cboSortCompare.Items.AddRange(new object[] {
            "Sort By Ocurrence (Default)",
            "Sort By Number of Matches (Descending)",
            "Sort By Number of Matches (Ascending)"});
            this.cboSortCompare.Location = new System.Drawing.Point(54, 525);
            this.cboSortCompare.Name = "cboSortCompare";
            this.cboSortCompare.Size = new System.Drawing.Size(232, 21);
            this.cboSortCompare.TabIndex = 45;
            this.cboSortCompare.Text = "Choose a Sort Order";
            this.cboSortCompare.SelectedIndexChanged += new System.EventHandler(this.cboSort_SelectedIndexChanged);
            // 
            // btnExpandCompare
            // 
            this.btnExpandCompare.Enabled = false;
            this.btnExpandCompare.Location = new System.Drawing.Point(54, 547);
            this.btnExpandCompare.Name = "btnExpandCompare";
            this.btnExpandCompare.Size = new System.Drawing.Size(232, 37);
            this.btnExpandCompare.TabIndex = 43;
            this.btnExpandCompare.Text = "Expand/Collapse";
            this.btnExpandCompare.UseVisualStyleBackColor = true;
            this.btnExpandCompare.Click += new System.EventHandler(this.btnExpandCollapse_Click);
            // 
            // treeViewCompare
            // 
            this.treeViewCompare.Location = new System.Drawing.Point(0, 4);
            this.treeViewCompare.Name = "treeViewCompare";
            this.treeViewCompare.Size = new System.Drawing.Size(749, 515);
            this.treeViewCompare.TabIndex = 42;
            // 
            // tabFuncTV
            // 
            this.tabFuncTV.BackColor = System.Drawing.SystemColors.Control;
            this.tabFuncTV.Controls.Add(this.cboSortFunc);
            this.tabFuncTV.Controls.Add(this.btnExpandFunc);
            this.tabFuncTV.Controls.Add(this.btnHelp_Func);
            this.tabFuncTV.Controls.Add(this.treeViewFunc);
            this.tabFuncTV.Controls.Add(this.btnExportFunc);
            this.tabFuncTV.Location = new System.Drawing.Point(4, 22);
            this.tabFuncTV.Name = "tabFuncTV";
            this.tabFuncTV.Size = new System.Drawing.Size(749, 584);
            this.tabFuncTV.TabIndex = 10;
            this.tabFuncTV.Text = "Functions Returning Strings";
            // 
            // cboSortFunc
            // 
            this.cboSortFunc.FormattingEnabled = true;
            this.cboSortFunc.Items.AddRange(new object[] {
            "Sort By Ocurrence (Default)",
            "Sort By Number of Matches (Descending)",
            "Sort By Number of Matches (Ascending)"});
            this.cboSortFunc.Location = new System.Drawing.Point(54, 525);
            this.cboSortFunc.Name = "cboSortFunc";
            this.cboSortFunc.Size = new System.Drawing.Size(232, 21);
            this.cboSortFunc.TabIndex = 46;
            this.cboSortFunc.Text = "Choose a Sort Order";
            this.cboSortFunc.SelectedIndexChanged += new System.EventHandler(this.cboSort_SelectedIndexChanged);
            // 
            // btnExpandFunc
            // 
            this.btnExpandFunc.Enabled = false;
            this.btnExpandFunc.Location = new System.Drawing.Point(54, 547);
            this.btnExpandFunc.Name = "btnExpandFunc";
            this.btnExpandFunc.Size = new System.Drawing.Size(232, 37);
            this.btnExpandFunc.TabIndex = 44;
            this.btnExpandFunc.Text = "Expand/Collapse";
            this.btnExpandFunc.UseVisualStyleBackColor = true;
            this.btnExpandFunc.Click += new System.EventHandler(this.btnExpandCollapse_Click);
            // 
            // btnHelp_Func
            // 
            this.btnHelp_Func.Image = global::GlobalizationPointsOfInterest.Properties.Resources.Help;
            this.btnHelp_Func.Location = new System.Drawing.Point(0, 524);
            this.btnHelp_Func.Name = "btnHelp_Func";
            this.btnHelp_Func.Size = new System.Drawing.Size(54, 60);
            this.btnHelp_Func.TabIndex = 42;
            this.btnHelp_Func.UseVisualStyleBackColor = true;
            this.btnHelp_Func.Click += new System.EventHandler(this.btnHelp_Func_Click);
            // 
            // treeViewFunc
            // 
            this.treeViewFunc.Location = new System.Drawing.Point(0, 4);
            this.treeViewFunc.Name = "treeViewFunc";
            this.treeViewFunc.Size = new System.Drawing.Size(749, 515);
            this.treeViewFunc.TabIndex = 43;
            // 
            // btnExportFunc
            // 
            this.btnExportFunc.Enabled = false;
            this.btnExportFunc.Location = new System.Drawing.Point(286, 524);
            this.btnExportFunc.Name = "btnExportFunc";
            this.btnExportFunc.Size = new System.Drawing.Size(463, 60);
            this.btnExportFunc.TabIndex = 41;
            this.btnExportFunc.Text = "ExportText...";
            this.btnExportFunc.UseVisualStyleBackColor = true;
            this.btnExportFunc.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabHardCodedTV
            // 
            this.tabHardCodedTV.BackColor = System.Drawing.SystemColors.Control;
            this.tabHardCodedTV.Controls.Add(this.cboSortHardCoded);
            this.tabHardCodedTV.Controls.Add(this.btnExpandHardCoded);
            this.tabHardCodedTV.Controls.Add(this.btnHelp_HardCoded);
            this.tabHardCodedTV.Controls.Add(this.treeViewHardCoded);
            this.tabHardCodedTV.Controls.Add(this.btnExportHardCoded);
            this.tabHardCodedTV.Location = new System.Drawing.Point(4, 22);
            this.tabHardCodedTV.Name = "tabHardCodedTV";
            this.tabHardCodedTV.Size = new System.Drawing.Size(749, 584);
            this.tabHardCodedTV.TabIndex = 11;
            this.tabHardCodedTV.Text = "Hard Coded Strings";
            // 
            // cboSortHardCoded
            // 
            this.cboSortHardCoded.FormattingEnabled = true;
            this.cboSortHardCoded.Items.AddRange(new object[] {
            "Sort By Ocurrence (Default)",
            "Sort By Number of Matches (Descending)",
            "Sort By Number of Matches (Ascending)"});
            this.cboSortHardCoded.Location = new System.Drawing.Point(54, 525);
            this.cboSortHardCoded.Name = "cboSortHardCoded";
            this.cboSortHardCoded.Size = new System.Drawing.Size(232, 21);
            this.cboSortHardCoded.TabIndex = 46;
            this.cboSortHardCoded.Text = "Choose a Sort Order";
            this.cboSortHardCoded.SelectedIndexChanged += new System.EventHandler(this.cboSort_SelectedIndexChanged);
            // 
            // btnExpandHardCoded
            // 
            this.btnExpandHardCoded.Enabled = false;
            this.btnExpandHardCoded.Location = new System.Drawing.Point(54, 547);
            this.btnExpandHardCoded.Name = "btnExpandHardCoded";
            this.btnExpandHardCoded.Size = new System.Drawing.Size(232, 37);
            this.btnExpandHardCoded.TabIndex = 45;
            this.btnExpandHardCoded.Text = "Expand/Collapse";
            this.btnExpandHardCoded.UseVisualStyleBackColor = true;
            this.btnExpandHardCoded.Click += new System.EventHandler(this.btnExpandCollapse_Click);
            // 
            // btnHelp_HardCoded
            // 
            this.btnHelp_HardCoded.Image = global::GlobalizationPointsOfInterest.Properties.Resources.Help;
            this.btnHelp_HardCoded.Location = new System.Drawing.Point(0, 524);
            this.btnHelp_HardCoded.Name = "btnHelp_HardCoded";
            this.btnHelp_HardCoded.Size = new System.Drawing.Size(54, 60);
            this.btnHelp_HardCoded.TabIndex = 43;
            this.btnHelp_HardCoded.UseVisualStyleBackColor = true;
            this.btnHelp_HardCoded.Click += new System.EventHandler(this.btnHelp_HardCoded_Click);
            // 
            // treeViewHardCoded
            // 
            this.treeViewHardCoded.Location = new System.Drawing.Point(0, 4);
            this.treeViewHardCoded.Name = "treeViewHardCoded";
            this.treeViewHardCoded.Size = new System.Drawing.Size(749, 515);
            this.treeViewHardCoded.TabIndex = 44;
            // 
            // btnExportHardCoded
            // 
            this.btnExportHardCoded.Enabled = false;
            this.btnExportHardCoded.Location = new System.Drawing.Point(286, 524);
            this.btnExportHardCoded.Name = "btnExportHardCoded";
            this.btnExportHardCoded.Size = new System.Drawing.Size(463, 60);
            this.btnExportHardCoded.TabIndex = 42;
            this.btnExportHardCoded.Text = "ExportText...";
            this.btnExportHardCoded.UseVisualStyleBackColor = true;
            this.btnExportHardCoded.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabDateTV
            // 
            this.tabDateTV.BackColor = System.Drawing.SystemColors.Control;
            this.tabDateTV.Controls.Add(this.cboSortDate);
            this.tabDateTV.Controls.Add(this.btnExpandDate);
            this.tabDateTV.Controls.Add(this.btnHelp_Date);
            this.tabDateTV.Controls.Add(this.treeViewDate);
            this.tabDateTV.Controls.Add(this.btnExportDateFormat);
            this.tabDateTV.Location = new System.Drawing.Point(4, 22);
            this.tabDateTV.Name = "tabDateTV";
            this.tabDateTV.Size = new System.Drawing.Size(749, 584);
            this.tabDateTV.TabIndex = 12;
            this.tabDateTV.Text = "Date Format";
            // 
            // cboSortDate
            // 
            this.cboSortDate.FormattingEnabled = true;
            this.cboSortDate.Items.AddRange(new object[] {
            "Sort By Ocurrence (Default)",
            "Sort By Number of Matches (Descending)",
            "Sort By Number of Matches (Ascending)"});
            this.cboSortDate.Location = new System.Drawing.Point(54, 525);
            this.cboSortDate.Name = "cboSortDate";
            this.cboSortDate.Size = new System.Drawing.Size(232, 21);
            this.cboSortDate.TabIndex = 47;
            this.cboSortDate.Text = "Choose a Sort Order";
            this.cboSortDate.SelectedIndexChanged += new System.EventHandler(this.cboSort_SelectedIndexChanged);
            // 
            // btnExpandDate
            // 
            this.btnExpandDate.Enabled = false;
            this.btnExpandDate.Location = new System.Drawing.Point(54, 547);
            this.btnExpandDate.Name = "btnExpandDate";
            this.btnExpandDate.Size = new System.Drawing.Size(232, 37);
            this.btnExpandDate.TabIndex = 46;
            this.btnExpandDate.Text = "Expand/Collapse";
            this.btnExpandDate.UseVisualStyleBackColor = true;
            this.btnExpandDate.Click += new System.EventHandler(this.btnExpandCollapse_Click);
            // 
            // btnHelp_Date
            // 
            this.btnHelp_Date.Image = global::GlobalizationPointsOfInterest.Properties.Resources.Help;
            this.btnHelp_Date.Location = new System.Drawing.Point(0, 524);
            this.btnHelp_Date.Name = "btnHelp_Date";
            this.btnHelp_Date.Size = new System.Drawing.Size(54, 60);
            this.btnHelp_Date.TabIndex = 44;
            this.btnHelp_Date.UseVisualStyleBackColor = true;
            this.btnHelp_Date.Click += new System.EventHandler(this.btnHelp_Date_Click);
            // 
            // treeViewDate
            // 
            this.treeViewDate.Location = new System.Drawing.Point(0, 4);
            this.treeViewDate.Name = "treeViewDate";
            this.treeViewDate.Size = new System.Drawing.Size(749, 515);
            this.treeViewDate.TabIndex = 45;
            // 
            // btnExportDateFormat
            // 
            this.btnExportDateFormat.Enabled = false;
            this.btnExportDateFormat.Location = new System.Drawing.Point(286, 524);
            this.btnExportDateFormat.Name = "btnExportDateFormat";
            this.btnExportDateFormat.Size = new System.Drawing.Size(463, 60);
            this.btnExportDateFormat.TabIndex = 43;
            this.btnExportDateFormat.Text = "ExportText...";
            this.btnExportDateFormat.UseVisualStyleBackColor = true;
            this.btnExportDateFormat.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabDecimalTV
            // 
            this.tabDecimalTV.BackColor = System.Drawing.SystemColors.Control;
            this.tabDecimalTV.Controls.Add(this.cboSortDecimal);
            this.tabDecimalTV.Controls.Add(this.btnExpandDecimal);
            this.tabDecimalTV.Controls.Add(this.btnHelp_Decimal);
            this.tabDecimalTV.Controls.Add(this.treeViewDecimal);
            this.tabDecimalTV.Controls.Add(this.btnExportDecimal);
            this.tabDecimalTV.Location = new System.Drawing.Point(4, 22);
            this.tabDecimalTV.Name = "tabDecimalTV";
            this.tabDecimalTV.Size = new System.Drawing.Size(749, 584);
            this.tabDecimalTV.TabIndex = 13;
            this.tabDecimalTV.Text = "Decimal Format";
            // 
            // cboSortDecimal
            // 
            this.cboSortDecimal.FormattingEnabled = true;
            this.cboSortDecimal.Items.AddRange(new object[] {
            "Sort By Ocurrence (Default)",
            "Sort By Number of Matches (Descending)",
            "Sort By Number of Matches (Ascending)"});
            this.cboSortDecimal.Location = new System.Drawing.Point(54, 525);
            this.cboSortDecimal.Name = "cboSortDecimal";
            this.cboSortDecimal.Size = new System.Drawing.Size(232, 21);
            this.cboSortDecimal.TabIndex = 48;
            this.cboSortDecimal.Text = "Choose a Sort Order";
            this.cboSortDecimal.SelectedIndexChanged += new System.EventHandler(this.cboSort_SelectedIndexChanged);
            // 
            // btnExpandDecimal
            // 
            this.btnExpandDecimal.Enabled = false;
            this.btnExpandDecimal.Location = new System.Drawing.Point(54, 547);
            this.btnExpandDecimal.Name = "btnExpandDecimal";
            this.btnExpandDecimal.Size = new System.Drawing.Size(232, 37);
            this.btnExpandDecimal.TabIndex = 47;
            this.btnExpandDecimal.Text = "Expand/Collapse";
            this.btnExpandDecimal.UseVisualStyleBackColor = true;
            this.btnExpandDecimal.Click += new System.EventHandler(this.btnExpandCollapse_Click);
            // 
            // btnHelp_Decimal
            // 
            this.btnHelp_Decimal.Image = global::GlobalizationPointsOfInterest.Properties.Resources.Help;
            this.btnHelp_Decimal.Location = new System.Drawing.Point(0, 524);
            this.btnHelp_Decimal.Name = "btnHelp_Decimal";
            this.btnHelp_Decimal.Size = new System.Drawing.Size(54, 60);
            this.btnHelp_Decimal.TabIndex = 45;
            this.btnHelp_Decimal.UseVisualStyleBackColor = true;
            this.btnHelp_Decimal.Click += new System.EventHandler(this.btnHelp_Decimal_Click);
            // 
            // treeViewDecimal
            // 
            this.treeViewDecimal.Location = new System.Drawing.Point(0, 4);
            this.treeViewDecimal.Name = "treeViewDecimal";
            this.treeViewDecimal.Size = new System.Drawing.Size(749, 515);
            this.treeViewDecimal.TabIndex = 46;
            // 
            // btnExportDecimal
            // 
            this.btnExportDecimal.Enabled = false;
            this.btnExportDecimal.Location = new System.Drawing.Point(286, 524);
            this.btnExportDecimal.Name = "btnExportDecimal";
            this.btnExportDecimal.Size = new System.Drawing.Size(463, 60);
            this.btnExportDecimal.TabIndex = 44;
            this.btnExportDecimal.Text = "ExportText...";
            this.btnExportDecimal.UseVisualStyleBackColor = true;
            this.btnExportDecimal.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridCol_FileName
            // 
            this.gridCol_FileName.Name = "gridCol_FileName";
            // 
            // gridCol_Number
            // 
            this.gridCol_Number.Name = "gridCol_Number";
            // 
            // gridCol_LineNum
            // 
            this.gridCol_LineNum.Name = "gridCol_LineNum";
            // 
            // gridCol_Code
            // 
            this.gridCol_Code.Name = "gridCol_Code";
            // 
            // GlobalizationParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 683);
            this.Controls.Add(this.tabResults);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.progbar);
            this.Controls.Add(this.lblProcessing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GlobalizationParser";
            this.Text = "Globalization Parser For C# Solutions";
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.tabResults.ResumeLayout(false);
            this.tabOverview.ResumeLayout(false);
            this.tabOverview.PerformLayout();
            this.panelKey.ResumeLayout(false);
            this.panelKey.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelOverviewConcat.ResumeLayout(false);
            this.panelOverviewConcat.PerformLayout();
            this.tabConcatTV.ResumeLayout(false);
            this.tabCompareTV.ResumeLayout(false);
            this.tabFuncTV.ResumeLayout(false);
            this.tabHardCodedTV.ResumeLayout(false);
            this.tabDateTV.ResumeLayout(false);
            this.tabDecimalTV.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSource;
        private System.Windows.Forms.TextBox txtboxInputPath;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogTarget;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.ProgressBar progbar;
        private System.Windows.Forms.Label lblConcat;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_Export;
        private System.Windows.Forms.ListBox lstboxAnalyze;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.RadioButton rbDirectory;
        private System.Windows.Forms.RadioButton rbSolution;
        private System.Windows.Forms.Button btnProjects;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblAnalyze;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.TabControl tabResults;
        private System.Windows.Forms.Button btnExportStrConcat;
        private System.Windows.Forms.Button btnExportStrCompare;
        private System.Windows.Forms.Button btnExportFunc;
        private System.Windows.Forms.Button btnExportHardCoded;
        private System.Windows.Forms.Button btnExportDateFormat;
        private System.Windows.Forms.Button btnExportDecimal;
        private System.Windows.Forms.TreeView treeViewConfig;
        private System.Windows.Forms.Button btnHelpConfig;
        private System.Windows.Forms.Button btnHelp_Analysis;
        private System.Windows.Forms.Button btnHelp_Results;
        private System.Windows.Forms.Button btnHelp_Concat;
        private System.Windows.Forms.Button btnHelp_Compare;
        private System.Windows.Forms.Button btnHelp_Func;
        private System.Windows.Forms.Button btnHelp_HardCoded;
        private System.Windows.Forms.Button btnHelp_Date;
        private System.Windows.Forms.Button btnHelp_Decimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCol_FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCol_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCol_LineNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCol_Code;
        private System.Windows.Forms.TabPage tabConcatTV;
        private System.Windows.Forms.TreeView treeViewConcat;
        private System.Windows.Forms.TabPage tabCompareTV;
        private System.Windows.Forms.TreeView treeViewCompare;
        private System.Windows.Forms.TabPage tabFuncTV;
        private System.Windows.Forms.TreeView treeViewFunc;
        private System.Windows.Forms.TabPage tabHardCodedTV;
        private System.Windows.Forms.TreeView treeViewHardCoded;
        private System.Windows.Forms.TabPage tabDateTV;
        private System.Windows.Forms.TreeView treeViewDate;
        private System.Windows.Forms.TabPage tabDecimalTV;
        private System.Windows.Forms.TreeView treeViewDecimal;
        private System.Windows.Forms.Button btnExpandConcat;
        private System.Windows.Forms.Button btnExpandCompare;
        private System.Windows.Forms.Button btnExpandFunc;
        private System.Windows.Forms.Button btnExpandHardCoded;
        private System.Windows.Forms.Button btnExpandDate;
        private System.Windows.Forms.Button btnExpandDecimal;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.Panel panelConcatBar;
        private System.Windows.Forms.Panel panelOverviewConcat;
        private System.Windows.Forms.Panel panelConcatBarFiles;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panelDecimalBar;
        private System.Windows.Forms.Label lblDecimal;
        private System.Windows.Forms.Panel panelDecimalBarFiles;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lblDateFormat;
        private System.Windows.Forms.Panel panelDateBar;
        private System.Windows.Forms.Panel panelDateBarFiles;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblHardCoded;
        private System.Windows.Forms.Panel panelHardCodedBar;
        private System.Windows.Forms.Panel panelHardCodedBarFiles;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblFunc;
        private System.Windows.Forms.Panel panelFuncBar;
        private System.Windows.Forms.Panel panelFuncBarFiles;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelCompareBar;
        private System.Windows.Forms.Label lblCompare;
        private System.Windows.Forms.Panel panelCompareBarFiles;
        private System.Windows.Forms.ComboBox cboSortConcat;
        private System.Windows.Forms.ComboBox cboSortCompare;
        private System.Windows.Forms.ComboBox cboSortFunc;
        private System.Windows.Forms.ComboBox cboSortHardCoded;
        private System.Windows.Forms.ComboBox cboSortDate;
        private System.Windows.Forms.ComboBox cboSortDecimal;
        private System.Windows.Forms.ComboBox cboFileType;
        private System.Windows.Forms.Panel panelKey;
        private System.Windows.Forms.Panel panelKey_Orange;
        private System.Windows.Forms.Panel panelKey_Blue;
        private System.Windows.Forms.Label lblKey_Files;
        private System.Windows.Forms.Label lblKey_Matches;
        private System.Windows.Forms.Label lbl_OverView_Results;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.Button btnDeleteFilter;
        private System.Windows.Forms.Button btnDefaultFilter;
        private System.Windows.Forms.Button btnExportOverview;
    }
}

