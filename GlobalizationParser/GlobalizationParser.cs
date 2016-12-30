using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using GlobalizationPointsOfInterest.Properties;
using System.Runtime.InteropServices;
using System.Configuration;


namespace GlobalizationPointsOfInterest
{
    public partial class GlobalizationParser : Form
    {

        #region Fields

        private const int CS = 0;
        private const int CSHTML = 1;
        private const int JS = 2;
        private int _fileTypeSelected;
        private string _FilterPath;

        private Boolean _cancel = false;
        private int _fileCount = 0;
        private string _inputPath = "";

        private UserFilterForm UserFilterForm;

        private ProjectListForm ProjectListForm;
        private ArrayList ProjectList;
        private bool[] SelectedProjects;
        private ArrayList AllFileNames;
        private string SolutionName;
        private string SolutionPath;

        public List<Category> CategoryList;
        private Dictionary<string, ArrayList> _ProjectsAndFiles = new Dictionary<string, ArrayList>();
        private Dictionary<string, List<Filter>> _CategoryFilter = new Dictionary<string, List<Filter>>();

        private Bitmap _bufKey_Blue;
        private Bitmap _bufKey_Orange;

        //Declarations to describe and alter thee attributes of the treeview item
        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;
        private const int TVM_GETITEM = TV_FIRST + 62;
        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam,
                                                 ref TVITEM lParam);
        #endregion

        #region Delegates
        private delegate void ShowProgressNewDelegate(int fileCount, string currentDir);

        private delegate void ShowResultsTVDelegate(TreeView tv, TreeNode parent, List<TreeNode> children);

        private delegate void ShowResultsLabelDelegate(Label label, string results);
        #endregion

        #region Initializers

        /// <summary>
        /// Set initial state of the application
        /// </summary>
        public GlobalizationParser()
        {
            InitializeComponent();
            var systemPath = System.Environment.
                             GetFolderPath(
                                 Environment.SpecialFolder.CommonApplicationData
                             );
            var complete = Path.Combine(systemPath, "files");
            Directory.CreateDirectory(complete);
            _FilterPath = Path.Combine(complete, @"GlobalizationFilterValues.xml");
            InitCategories();
            InitFilters();

            treeViewConfig.ExpandAll();

            lbl_OverView_Results.Visible = false;

            //Animation Smoothing
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            //initialize bitmaps for OverView Key
            _bufKey_Blue = new Bitmap(panelKey_Blue.Width, panelKey_Blue.Height);
            _bufKey_Orange = new Bitmap(panelKey_Orange.Width, panelKey_Orange.Height);

            //Key Timer Settings
            this.timer_Key.Enabled = true;
            timer_Key.Interval = 1000 / 30;

            //initiate timer for bar graph drawing
            timer_Key.Start();
            timer_Key.Tick += new System.EventHandler(this.timerKey_Tick);
            
            //Graphics Timer Settings
            this.timer.Enabled = true;
            timer.Interval = 1000/30;
        }

        /// <summary>
        /// Parsing categories are treated as classes. Initializes all parsing categories available to user.
        /// </summary>
        public void InitCategories()
        {
            CategoryList = new List<Category>();

            //String Concatenation
            Category concatenations = new Category();
            concatenations.Name = Resources.Label_Concat;
            SetRegex(concatenations);
            concatenations.TV = treeViewConcat;
            concatenations.Lbl_Title = lblConcat;
            concatenations.Lbl_Title_Result = Resources.Label_Concat_Results;
            concatenations.ChkBox = treeViewConfig.Nodes["NodeSelectAll"].Nodes["NodeStrConcat"];
            concatenations.ExportBtn = btnExportStrConcat;
            concatenations.ExpandBtn = btnExpandConcat;
            concatenations.CboSort = cboSortConcat;
            concatenations.PanelFiles = panelConcatBarFiles;
            concatenations.PanelMatches = panelConcatBar;
            concatenations.BufMatches = new Bitmap(concatenations.PanelMatches.Width, concatenations.PanelMatches.Height);
            concatenations.BufFiles = new Bitmap(concatenations.PanelFiles.Width, concatenations.PanelFiles.Height);
            CategoryList.Add(concatenations);

            //String Comparison
            Category comparisons = new Category();
            comparisons.Name = Resources.Label_Compare;
            SetRegex(comparisons);
            comparisons.TV = treeViewCompare;
            comparisons.Lbl_Title = lblCompare;
            comparisons.Lbl_Title_Result = Resources.Label_Compare_Results;
            comparisons.ChkBox = treeViewConfig.Nodes["NodeSelectAll"].Nodes["NodeStrCompare"];
            comparisons.ExportBtn = btnExportStrCompare;
            comparisons.ExpandBtn = btnExpandCompare;
            comparisons.CboSort = cboSortCompare;
            comparisons.PanelFiles = panelCompareBarFiles;
            comparisons.PanelMatches = panelCompareBar;
            comparisons.BufMatches = new Bitmap(comparisons.PanelMatches.Width, comparisons.PanelMatches.Height);
            comparisons.BufFiles = new Bitmap(comparisons.PanelFiles.Width, comparisons.PanelFiles.Height);
            CategoryList.Add(comparisons);

            //Functions that return type String
            Category strFuncReturn = new Category();
            strFuncReturn.Name = Resources.Label_Func;
            SetRegex(strFuncReturn);
            strFuncReturn.TV = treeViewFunc;
            strFuncReturn.Lbl_Title = lblFunc;
            strFuncReturn.Lbl_Title_Result = Resources.Label_Func_Results;
            strFuncReturn.ChkBox = treeViewConfig.Nodes["NodeSelectAll"].Nodes["NodeStrFunc"];
            strFuncReturn.ExportBtn = btnExportFunc;
            strFuncReturn.ExpandBtn = btnExpandFunc;
            strFuncReturn.CboSort = cboSortFunc;
            strFuncReturn.PanelFiles = panelFuncBarFiles;
            strFuncReturn.PanelMatches = panelFuncBar;
            strFuncReturn.BufMatches = new Bitmap(strFuncReturn.PanelMatches.Width, strFuncReturn.PanelMatches.Height);
            strFuncReturn.BufFiles = new Bitmap(strFuncReturn.PanelFiles.Width, strFuncReturn.PanelFiles.Height);
            CategoryList.Add(strFuncReturn);

            //Hard Coded Strings
            Category hardCodedStr = new Category();
            hardCodedStr.Name = Resources.Label_HardCoded;
            SetRegex(hardCodedStr);
            hardCodedStr.TV = treeViewHardCoded;
            hardCodedStr.Lbl_Title = lblHardCoded;
            hardCodedStr.Lbl_Title_Result = Resources.Label_HardCoded_Results;
            hardCodedStr.ChkBox = treeViewConfig.Nodes["NodeSelectAll"].Nodes["NodeHardCoded"];
            hardCodedStr.ExportBtn = btnExportHardCoded;
            hardCodedStr.ExpandBtn = btnExpandHardCoded;
            hardCodedStr.CboSort = cboSortHardCoded;
            hardCodedStr.PanelFiles = panelHardCodedBarFiles;
            hardCodedStr.PanelMatches = panelHardCodedBar;
            hardCodedStr.BufMatches = new Bitmap(hardCodedStr.PanelMatches.Width, hardCodedStr.PanelMatches.Height);
            hardCodedStr.BufFiles = new Bitmap(hardCodedStr.PanelFiles.Width, hardCodedStr.PanelFiles.Height);
            CategoryList.Add(hardCodedStr);

            //Date Formats
            Category dateFormats = new Category();
            dateFormats.Name = Resources.Label_DateFormat;
            SetRegex(dateFormats);
            dateFormats.TV = treeViewDate;
            dateFormats.Lbl_Title = lblDateFormat;
            dateFormats.Lbl_Title_Result = Resources.Label_DateFormat_Results;
            dateFormats.ChkBox = treeViewConfig.Nodes["NodeSelectAll"].Nodes["NodeDate"];
            dateFormats.ExportBtn = btnExportDateFormat;
            dateFormats.ExpandBtn = btnExpandDate;
            dateFormats.CboSort = cboSortDate;
            dateFormats.PanelFiles = panelDateBarFiles;
            dateFormats.PanelMatches = panelDateBar;
            dateFormats.BufMatches = new Bitmap(dateFormats.PanelMatches.Width, dateFormats.PanelMatches.Height);
            dateFormats.BufFiles = new Bitmap(dateFormats.PanelFiles.Width, dateFormats.PanelFiles.Height);
            CategoryList.Add(dateFormats);

            //Decimal Formats
            Category decimalFormats = new Category();
            decimalFormats.Name = Resources.Label_Decimal;
            SetRegex(decimalFormats);
            decimalFormats.TV = treeViewDecimal;
            decimalFormats.Lbl_Title = lblDecimal;
            decimalFormats.Lbl_Title_Result = Resources.Label_Decimal_Results;
            decimalFormats.ChkBox = treeViewConfig.Nodes["NodeSelectAll"].Nodes["NodeDecimal"];
            decimalFormats.ExportBtn = btnExportDecimal;
            decimalFormats.ExpandBtn = btnExpandDecimal;
            decimalFormats.CboSort = cboSortDecimal;
            decimalFormats.PanelFiles = panelDecimalBarFiles;
            decimalFormats.PanelMatches = panelDecimalBar;
            decimalFormats.BufMatches = new Bitmap(decimalFormats.PanelMatches.Width, decimalFormats.PanelMatches.Height);
            decimalFormats.BufFiles = new Bitmap(decimalFormats.PanelFiles.Width, decimalFormats.PanelFiles.Height);
            CategoryList.Add(decimalFormats);

            foreach (Category c in CategoryList)
            {
                Font boldFont = new Font(c.TV.Font, FontStyle.Bold);
                c.TV.Font = boldFont;
            }
        }

        /// <summary>
        /// Initializes and sets the Filters to be used
        /// </summary>
        private void InitFilters()
        {
            //clear all previous filters first
            foreach (TreeNode node in treeViewConfig.Nodes["NodeSelectAll"].Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    node.Nodes.Clear();
                }
            }
            _CategoryFilter.Clear();

            List<Filter> filterList = new List<Filter>();

            //if doesnt exist, create xml file
            //if xml exists, read it in and assign to filter list
            if (!File.Exists(_FilterPath))
                SerializeDefaultSet(_FilterPath);

            filterList = DeserializeFilterXML(_FilterPath);

            //populate dictionary where KEY = Parsing Category and VALUE = Filter
            foreach (Filter filter in filterList)
            {
                List<Filter> tempFilterList = new List<Filter>();

                //assign the regex
                if (!filter.IsPattern)
                    filter.Filter_Regex = new Regex(Regex.Escape(filter.Filter_String));
                else
                    filter.Filter_Regex = new Regex(filter.Filter_String, RegexOptions.IgnoreCase);

                if (_CategoryFilter.ContainsKey(filter.ParentCategory))
                {
                    _CategoryFilter[filter.ParentCategory].Add(filter);
                }
                else
                {
                    tempFilterList.Add(filter);
                    _CategoryFilter.Add(filter.ParentCategory, tempFilterList);
                }

                AssignFilter(filter);
            }
        }

        #endregion

        #region Graphics
        Timer timer = new Timer();
        Timer timer_Key = new Timer();

        /// <summary>
        /// Determines the actions of the timer for the Key at each tick.  Initiates the drawing of the key for bar graphs
        /// </summary>
        void timerKey_Tick(object sender, EventArgs e)
        {
            
            PaintKey(Brushes.RoyalBlue, _bufKey_Blue, panelKey_Blue);
            PaintKey(Brushes.Tomato, _bufKey_Orange, panelKey_Orange);
        }

        /// <summary>
        /// Creates the graphics for the Key that explains the overview bar graphs
        /// </summary>
        /// <param name="brush"> The color of the graph </param>
        /// <param name="buf"> The BitMap to draw in the graphics </param>
        /// <param name="p"> The panel to place the graphics on </param>
        void PaintKey(Brush brush, Bitmap buf, Panel p)
        {
            using (Graphics g = Graphics.FromImage(buf))
            {
                g.FillRectangle(Brushes.Transparent, new Rectangle(0, 0, p.Width, p.Height));
                Rectangle rect = new Rectangle(0, 0, p.Width, p.Height);
                g.FillRectangle(brush, rect);
                p.CreateGraphics().DrawImageUnscaled(buf, 0, 0);
            }
        }

        /// <summary>
        /// Determines the actions of the timer at each tick.  Initiates the drawing of the overview bar graphs
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Category c in CategoryList)
            {
                PaintGraph(Brushes.Tomato, c.BufFiles, c.PanelFiles, c.FileCount);
                PaintGraph(Brushes.RoyalBlue, c.BufMatches, c.PanelMatches, c.TotalCount);
                i++;
            }
            
        }

        /// <summary>
        /// Creates the graphics for the bar graphs that will appear on the overview panels
        /// </summary>
        /// <param name="brush"> The color of the graph </param>
        /// <param name="buf"> The BitMap to draw in the graphics </param>
        /// <param name="p"> The panel to place the graphics on </param>
        /// <param name="statToGraph"> The statistic to graph: File Count or Matches Count </param>
        void PaintGraph(Brush brush, Bitmap buf, Panel p, int statToGraph)
        {
            using (Graphics g = Graphics.FromImage(buf))
            {
                g.FillRectangle(Brushes.Transparent, new Rectangle(0, 0, p.Width, p.Height));
                DrawItemsCategory_Bar(g, brush, p, statToGraph);
                p.CreateGraphics().DrawImageUnscaled(buf, 0, 0);
            }
        }

        /// <summary>
        /// Draws the bar graph in relation to the passed in statistics
        /// </summary>
        /// <param name="g"> Graphics class used to draw the shape </param>
        /// <param name="brush"> The color of the rectangle </param>
        /// <param name="p"> The panel to place the rectangle </param>
        /// <param name="stat"> The stat to track and base the rectangle length off of </param>
        private void DrawItemsCategory_Bar(Graphics g, Brush brush, Panel p, int stat)
        {
            Rectangle rect = new Rectangle(0, 0, stat/2, p.Height);
            g.FillRectangle(brush, rect);
        }
        #endregion

        #region Form Components

            #region CheckBox Components

        /// <summary>
        /// Unchecks all checkboxes on the parsing category TreeView
        /// </summary>
        private void CategoryUncheck()
        {
            foreach (Category c in CategoryList)
            {
                c.ChkBox.Checked = false;
            }
        }

        /// <summary>
        /// Checks to see if a checkbox on the form has been selected
        /// </summary>
        /// <returns> TRUE if at least one checkbox selected, FALSE if none are selected </returns>
        private Boolean IsCategoryChecked()
        {
            foreach (Category c in CategoryList)
            {
                if (c.ChkBox.Checked)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if a user selected one of the available file types to parse for
        /// </summary>
        private bool IsFileTypeChecked()
        {
            return cboFileType.SelectedIndex > -1;
        }

            #endregion

            #region Buttons
        /// <summary>
        /// Event Handler for when "Start Button" is pressed.  Begins the asynchronous parsing sequence.
        /// </summary>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            //input file authenication
            if (rbSolution.Checked && File.Exists(txtboxInputPath.Text))
            {
                _inputPath = txtboxInputPath.Text;
            }
            else if (rbDirectory.Checked && Directory.Exists(txtboxInputPath.Text))
            {
                _inputPath = txtboxInputPath.Text;
            }
            else
            {
                MessageBox.Show(Resources.Msg_Input_Missing);
                return;
            }

            if (!IsCategoryChecked())
            {
                MessageBox.Show(Resources.Msg_Checkbox);
                return;
            }

            if (!IsFileTypeChecked())
            {
                MessageBox.Show(Resources.Msg_FileType);
                return;
            }

            //disable interactive elements of the UI during the parse
            var filePaths = _inputPath;
            btnBrowse.Enabled = false;
            btnProjects.Enabled = false;
            btnClear.Enabled = false;
            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            cboFileType.Enabled = false;
            RestoreLabelNames();
            ClearForm();
            DisableExportExpand();
            foreach (Category c in CategoryList)
            {
                c.ResetCount();
            }

            string fileType = "CS";
            if (_fileTypeSelected == CSHTML) fileType = "CSHTML";
            if (_fileTypeSelected == JS) fileType = "JS";
            lbl_OverView_Results.Text = String.Format(Resources.Lbl_OverView_Results, fileType, _inputPath);
            lbl_OverView_Results.Visible = true;

            //initiate timer for bar graph drawing
            timer.Start();
            timer.Tick += new System.EventHandler(this.timer_Tick);

            //begin asynchronous work via Background worker
            #region BackgroundWorker Traverse
            BackgroundWorker bwTraverse = new BackgroundWorker();
            bwTraverse.WorkerReportsProgress = true;
            bwTraverse.WorkerSupportsCancellation = true;
            bwTraverse.DoWork += (bwSender, bwE) =>
            {
                // do work. You can use locals from here
                if (rbDirectory.Checked)
                    TraverseDir(filePaths);
                else
                    TraverseSln();

                if(_cancel) bwTraverse.CancelAsync();
                _cancel = false;

                if ((bwTraverse.CancellationPending))
                {
                    bwE.Cancel = true;
                }

            };//end DoWork
            bwTraverse.ProgressChanged += delegate
            {
                //report progress
            };//end ProgressChanged
            bwTraverse.RunWorkerCompleted += (bwSender, bwE) =>
            {
                // do something with the results.
                if ((bwE.Cancelled))
                {
                    MessageBox.Show(Resources.Msg_Cancelled);
                    lblPercentage.Text = String.Format(Resources.Label_Percentage_Cancelled) + lblPercentage.Text;
                }
                else if (bwE.Error != null)
                {
                    MessageBox.Show(String.Format(Resources.Msg_Error, bwE.Error.Message));
                }
                else
                {
                    MessageBox.Show(Resources.Msg_Complete);
                    lblPercentage.Text = String.Format(Resources.Msg_Complete);
                }
                EnableExportExpand();
                btnBrowse.Enabled = true;
                btnProjects.Enabled = rbSolution.Checked;
                btnClear.Enabled = true;
                btnStart.Enabled = true;
                btnCancel.Enabled = false;
                cboFileType.Enabled = true;
            };//end RunWorkerCompleted
            bwTraverse.RunWorkerAsync();
            #endregion
        }

        /// <summary>
        /// Event Handler for "Cancel" button.  Sets instance field "_cancel" to true, which cancels current working threads.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancel = true;
        }

        /// <summary>
        /// Returns Form to Initial State
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            DisableExportExpand();
            CategoryUncheck();
            RestoreLabelNames();
            lstboxAnalyze.Items.Clear();
        }

        /// <summary>
        /// Event Handler that gathers the files to parse based on user selection.
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (!IsFileTypeChecked())
            {
                MessageBox.Show(Resources.Msg_FileType);
                return;
            }

            // Directory search
            if (rbDirectory.Checked)
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        txtboxInputPath.Text = dialog.SelectedPath;
                        _inputPath = this.txtboxInputPath.Text;
                        AnalyzeSelectedFileGroup();
                        btnStart.Enabled = true;
                    }
                }
            }
            // Solution Search
            else
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.Filter = "Solution Files|*.sln;...";
                    dialog.DefaultExt = ".sln"; // Default file extension 

                    // Process open file dialog box results 
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        txtboxInputPath.Text = dialog.FileName;
                        _inputPath = this.txtboxInputPath.Text;

                        //extract all .csproj from .sln and send to ProjectList
                        var parts = dialog.FileName.Split('\\');
                        SolutionName = parts[parts.Length - 1];
                        SolutionPath = dialog.FileName.Substring(0, dialog.FileName.Length - SolutionName.Length);
                        SetProjectsList(dialog.FileName);

                        //Show the available projects on the ProjectListForm for additional filtering by user
                        SelectedProjects = Enumerable.Repeat(true, ProjectList.Count + 1).ToArray();
                        ProjectListForm = new ProjectListForm(dialog.FileName, ProjectList, SelectedProjects);
                        ProjectListForm.Show();
                        ProjectListForm.Closed += ProjectListForm_Closed;

                        btnProjects.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Allows User to Filter Which Projects of a Solution to parse.
        /// </summary>
        private void btnProjects_Click(object sender, EventArgs e)
        {
            if (!IsFileTypeChecked())
            {
                MessageBox.Show(Resources.Msg_FileType);
                return;
            }

            if (ProjectList != null)
            {
                btnProjects.Enabled = false;
                ProjectListForm = new ProjectListForm(txtboxInputPath.Text, ProjectList, SelectedProjects);
                ProjectListForm.Show();
                ProjectListForm.Closed += ProjectListForm_Closed;
            }
        }

        /// <summary>
        /// Exports results to an external text file.
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            foreach (Category c in CategoryList)
            {
                if (String.Equals(((Button)sender).Name, c.ExportBtn.Name))
                {
                    if (c.TV.Nodes.Count > 0)
                    {
                        //create output text from the TreeView results
                        string results = "";
                        foreach (TreeNode node in c.TV.Nodes)
                        {
                            results += "\r\n" + node.Text + "\r\n";
                            if (node.Nodes.Count > 0)
                            {
                                foreach (TreeNode child in node.Nodes)
                                {
                                    results += "\n   " + child.Text;
                                }
                            }
                        }
                        string fileType = "CS";
                        if (_fileTypeSelected == CSHTML) fileType = "CSHTML";
                        if (_fileTypeSelected == JS) fileType = "JS";
                        string header = String.Format(Resources.Lbl_OverView_Results, fileType, _inputPath);
                        header += "\r\n" + c.Lbl_Title.Text;

                        string output = String.Format(Resources.Export_Format, header, results);
                        ExportFileToText(c.Name, output, saveFileDialog_Export);
                    }
                    else
                    {
                        MessageBox.Show(Resources.Msg_ExportWarning);
                    }
                }
            }
        }

        /// <summary>
        /// Exports summary of overview results to an external text file.
        /// </summary>
        private void btnExportOverview_Click(object sender, EventArgs e)
        {
            string filename = "ParsingOverview";
            string fileType = "CS";
            if (_fileTypeSelected == CSHTML) fileType = "CSHTML";
            if (_fileTypeSelected == JS) fileType = "JS";
            string header = String.Format(Resources.Lbl_OverView_Results, fileType, _inputPath);
            string output = header + "\r\n\r\n" +
                            lblConcat.Text + "\r\n\r\n" +
                            lblCompare.Text + "\r\n\r\n" +
                            lblFunc.Text + "\r\n\r\n" +
                            lblHardCoded.Text + "\r\n\r\n" +
                            lblDateFormat.Text + "\r\n\r\n" +
                            lblDecimal.Text;
            ExportFileToText(filename, output, saveFileDialog_Export);
        }

        /// <summary>
        /// Expands or Collapses the results in the Treeview
        /// </summary>
        private void btnExpandCollapse_Click(object sender, EventArgs e)
        {
            foreach (Category c in CategoryList)
            {
                if (String.Equals(((Button)sender).Name, c.ExpandBtn.Name))
                {
                    if (c.IsExpanded)
                    {
                        c.TV.CollapseAll();
                        c.IsExpanded = false;
                    }
                    else
                    {
                        c.TV.ExpandAll();
                        c.IsExpanded = true;
                    }
                }
            }
        }

        /// <summary>
        /// Adds the User Defined Filter to program
        /// </summary>
        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            UserFilterForm = new UserFilterForm();
            UserFilterForm.Show();
            UserFilterForm.Closed += UserFilterForm_Closed;
        }

        /// <summary>
        /// Removes the Specified Filter from the program
        /// </summary>
        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            string currentCategory = treeViewConfig.SelectedNode.Parent.Text;
            if (treeViewConfig.SelectedNode.Parent.Name != "NodeSelectAll")
            {
                foreach (Filter filter in _CategoryFilter[currentCategory])
                {
                    if (treeViewConfig.SelectedNode.Text == filter.Name)
                    {
                        _CategoryFilter[currentCategory].Remove(filter);
                        break;
                    }
                }
                treeViewConfig.Nodes.Remove(treeViewConfig.SelectedNode);

                foreach (Category c in CategoryList)
                {
                    if (c.Name == currentCategory)
                    {
                        SetRegex(c);
                        break;
                    }
                }

                //Save the changes to Filter settings
                File.Delete(_FilterPath);
                SerializeFilterXML(_FilterPath);
            }
            else
            {
                MessageBox.Show("Cannot Delete Filter Category");
            }
        }

        /// <summary>
        /// Restores Default Filter Settings
        /// </summary>
        private void btnDefaultFilter_Click(object sender, EventArgs e)
        {
            File.Delete(_FilterPath);

            InitFilters();
        }

        #region Help Messages

        /// <summary>
        /// Provides context for the configuration section
        /// </summary>
        private void btnHelpConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Msg_Help_Config, "Help: Configuration");
        }

        /// <summary>
        /// Provides context for the analysis section
        /// </summary>
        private void btnHelp_Analysis_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Msg_Help_Info, "Help: Analysis Window");
        }

        /// <summary>
        /// Provides context for the results section
        /// </summary>
        private void btnHelp_Results_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Msg_Help_Results, "Help: Results Screen");
        }

        private void btnHelp_Concat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Msg_Help_Concat, "Help: String Concatentation");
        }

        private void btnHelp_Compare_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                Resources.Msg_Help_Compare, "Help: String Comparison");
        }

        private void btnHelp_Func_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Msg_Help_Func, "Help: Functions Returning Strings");
        }

        private void btnHelp_HardCoded_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Msg_Help_HardCoded, "Help: Hard Coded Strings");
        }

        private void btnHelp_Date_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Msg_Help_Date, "Help: Date Formatting");
        }

        private void btnHelp_Decimal_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Msg_Help_Decimal, "Help: Decimal Format");
        }
        #endregion

            #endregion

            #region Radio Buttons
        /// <summary>
        /// Changes the label text of the Info Pane to be Directory based
        /// </summary>
        private void rbDirectory_CheckedChanged(object sender, EventArgs e)
        {
            btnProjects.Enabled = false;
            lblAnalyze.Text = Resources.Label_Analyze_Dir;
            lstboxAnalyze.Items.Clear();
        }

        /// <summary>
        /// Changes the label text of the Info Pane to be Solution based
        /// </summary>
        private void rbSolution_CheckedChanged(object sender, EventArgs e)
        {
            lblAnalyze.Text = Resources.Label_Analyze_Sln;
            lstboxAnalyze.Items.Clear();
        }
            #endregion

            #region OverView Graph Panels

        /// <summary>
        /// Allows user to switch to specific category tab upon selecting its associated panel in the overview tab
        /// </summary>
        private void OverviewConcat_Click(object sender, EventArgs e)
        {
            tabResults.SelectTab("tabConcatTV");
        }

        /// <summary>
        /// Allows user to switch to specific category tab upon selecting its associated panel in the overview tab
        /// </summary>
        private void OverviewCompare_Click(object sender, EventArgs e)
        {
            tabResults.SelectTab("tabCompareTV");
        }

        /// <summary>
        /// Allows user to switch to specific category tab upon selecting its associated panel in the overview tab
        /// </summary>
        private void OverviewFunc_Click(object sender, EventArgs e)
        {
            tabResults.SelectTab("tabFuncTV");
        }

        /// <summary>
        /// Allows user to switch to specific category tab upon selecting its associated panel in the overview tab
        /// </summary>
        private void OverviewHardCoded_Click(object sender, EventArgs e)
        {
            tabResults.SelectTab("tabHardCodedTV");
        }

        /// <summary>
        /// Allows user to switch to specific category tab upon selecting its associated panel in the overview tab
        /// </summary>
        private void OverviewDate_Click(object sender, EventArgs e)
        {
            tabResults.SelectTab("tabDateTV");
        }

        /// <summary>
        /// Allows user to switch to specific category tab upon selecting its associated panel in the overview tab
        /// </summary>
        private void OverviewDecimal_Click(object sender, EventArgs e)
        {
            tabResults.SelectTab("tabDecimalTV");
        }

            #endregion

        #endregion

        #region Traverse Sln
        /// <summary>
        /// Event Handler that updates the contents of the Project List once the Project Form is closed to reflect user changes
        /// </summary>
        private void ProjectListForm_Closed(object sender, EventArgs e)
        {
            btnProjects.Enabled = true;
            _ProjectsAndFiles.Clear();
            lstboxAnalyze.Items.Clear();
            SetProjectFileList();
        }

        /// <summary>
        /// Takes a .sln file path and extracts all .csproj files and adds to Project List
        /// </summary>
        /// <param name="file">
        /// The .sln file path to extract all .csproj files from
        /// </param>
        private void SetProjectsList(string file)
        {
            string line;
            // Read the file and display it line by line.
            var sln = new System.IO.StreamReader(file);

            if (ProjectList == null)
            {
                ProjectList = new ArrayList();
            }
            else
            {
                ProjectList.Clear();
            }

            SolutionPath = file.Substring(0, file.Length - SolutionName.Length);
            while ((line = sln.ReadLine()) != null)
            {
                if (line.IndexOf("Project(") >= 0 && line.IndexOf(".csproj") > 0)
                {
                    var sp = line.Split('"');
                    ProjectList.Add(SolutionPath + sp[5]);
                }
            }

            sln.Close();
        }

        /// <summary>
        /// For each .csproj in Project File List, extract all relevant files associated with that project and add to ArrayList AllFileNames.
        /// Projects and their files are stored associatively in Dictionary _ProjectsandFiles
        /// </summary>
        private void SetProjectFileList()
        {
            _fileCount = 0;
            if (ProjectList == null)
            {
                ProjectList = new ArrayList();
            }
            if (ProjectList.Count > 0)
            {
                int index = 0;
                string line;
                foreach (string p in ProjectList)
                {
                    AllFileNames = new ArrayList();
                    ++index;
                    if (SelectedProjects[index])
                    {
                        var dir = p.Split('\\');
                        if (File.Exists(p))
                        {
                            StreamReader project = new StreamReader(p);
                            string newPath = p.Substring(0, p.Length - dir[dir.Length - 1].Length);
                            //read the .csproj file line by line - parse for the selected file type
                            while ((line = project.ReadLine()) != null)
                            {
                                var sp = line.Split('"');
                                if (line.IndexOf("<Compile Include=") > 0)
                                {
                                    if (_fileTypeSelected == CS && (line.IndexOf(".cs\"") > 0 && !line.Contains("esigner")))
                                    {
                                        var parts = sp[1].Split('.');
                                        FileInfo f = new FileInfo(newPath + sp[1]);
                                        AllFileNames.Add(f.ToString());
                                    }
                                }
                                if (line.IndexOf("<Content Include=") > 0)
                                {
                                    if (_fileTypeSelected == CSHTML && line.IndexOf(".cshtml\"") > 0)
                                    {
                                        var parts = sp[1].Split('.');
                                        FileInfo f = new FileInfo(newPath + sp[1]);
                                        AllFileNames.Add(f.ToString());
                                    }
                                    if (_fileTypeSelected == JS && line.IndexOf(".js\"") > 0)
                                    {
                                        var parts = sp[1].Split('.');
                                        FileInfo f = new FileInfo(newPath + sp[1]);
                                        AllFileNames.Add(f.ToString());
                                    }
                                }
                            }
                            project.Close();
                        }
                    }
                    _ProjectsAndFiles.Add(p, AllFileNames);
                    _fileCount += AllFileNames.Count;
                }
                AnalyzeSelectedFileGroup();
                btnStart.Enabled = true;
            }
        }

        /// <summary>
        /// For each .cs file, perform a parse
        /// </summary>
        private void TraverseSln()
        {
            int filesParsed = 0;
            foreach (KeyValuePair<string, ArrayList> p in _ProjectsAndFiles)
            {
                string currentProject = p.Key;

                foreach (string file in p.Value)
                {
                    if (_cancel)
                    {
                        return;
                    }
                    filesParsed++;
                    ShowProgress(filesParsed, currentProject);
                    FileInfo fi = new FileInfo(file);
                    ParseFile(fi);
                }
            }
        }

        #endregion

        #region Traverse Directory

        /// <summary>
        /// For all .cs files in a specified root directory, parse the file
        /// </summary>
        /// <param name="root"> The root Directory to conduct the file parse </param>
        private void TraverseDir(string root)
        {
            //Retreive Enumeration of all files in Directory root and its subdirectories
            string includeFiles = "";
            if(_fileTypeSelected == CS)
                includeFiles += @"\.cs";
            if (_fileTypeSelected == CSHTML)
                includeFiles += includeFiles == String.Empty ? @"\.cshtml" : @"|\.cshtml";
            if (_fileTypeSelected == JS)
                includeFiles += includeFiles == String.Empty ? @"\.js" : @"|\.js";

            var fileList = GetFileList(root, includeFiles, @"\.csproj|\.Designer\.cs|\.css");
            _fileCount = fileList.Count();

            int filesParsed = 0;

            foreach (string file in fileList)
            {
                if (_cancel)
                {
                    return;
                }
                filesParsed++;
                ShowProgress(filesParsed, file);
                FileInfo fi = new FileInfo(file);
                ParseFile(fi);
            }
        }

        #endregion

        #region UI updates

        /// <summary>
        /// Displays the Progress bar, which is based on the total number of files to parse and the number of files already parsed
        /// </summary>
        /// <param name="numFilesParsed"> The number of Files parsed </param>
        /// <param name="currentDir"> The current directory of the parse </param>
        private void ShowProgress(int numFilesParsed, string currentDir)
        {
            if (progbar.InvokeRequired == false)
            {
                int percentage = (numFilesParsed*100)/_fileCount;
                lblPercentage.Visible = true;
                lblPercentage.Text = percentage+"%";
                progbar.Maximum = _fileCount;
                progbar.Visible = true;
                lblProcessing.Visible = true;

                lblProcessing.Text = String.Format(Resources.Label_Processing, numFilesParsed, _fileCount, currentDir);
                progbar.Increment(1);

                if (progbar.Value == progbar.Maximum)
                {
                    lblPercentage.Visible = false;
                    lblProcessing.Visible = false;
                    progbar.Visible = false;
                }

                Update();
            }
            else
            {
                ShowProgressNewDelegate showProgressNewDelegate = new ShowProgressNewDelegate(ShowProgress);
                this.Invoke(showProgressNewDelegate, numFilesParsed, currentDir);
            }
        }
        
        /// <summary>
        /// Displays the accumulated output from an active parse to the UI TreeView 
        /// </summary>
        /// <param name="tv"> The TreeView Control </param>
        /// <param name="parent"> The Parent Node </param>
        /// <param name="children"> The child Node </param>
        private void ShowResults_TV(TreeView tv, TreeNode parent, List<TreeNode> children)
        {
            if (tv.InvokeRequired == false)
            {
                tv.Nodes.Add(parent);
                parent.Text = parent.Text;

                foreach (TreeNode node in children)
                {
                    Font font = new Font(tv.Font, FontStyle.Regular);
                    node.NodeFont = font;
                    parent.Nodes.Add(node);
                }
            }
            else
            {
                ShowResultsTVDelegate showTVDelegate = new ShowResultsTVDelegate(ShowResults_TV);
                this.Invoke(showTVDelegate, new object[] { tv, parent, children });
            }

        }

        /// <summary>
        /// The Label of each output textbox, which also serves as a header
        /// </summary>
        /// <param name="label"> The corresponding text label to update </param>
        /// <param name="results"> The results to show </param>
        private void ShowResults_Label(Label label, string results)
        {
            if (label.InvokeRequired == false)
            {
                label.Text = results;
            }
            else
            {
                ShowResultsLabelDelegate showLabelDelegate = new ShowResultsLabelDelegate(ShowResults_Label);
                this.Invoke(showLabelDelegate, new object[] { label, results });
            }
        }

        /// <summary>
        /// Adds the analyzed output to the Info Pane
        /// </summary>
        /// <param name="myList"> The List to add to the Info Pane </param>
        /// <param name="fileCount"> Total number of files of the chosen filetype in the selected project </param>
        private void AddToListBox(List<KeyValuePair<string, int>> myList, int fileCount)
        {
            lstboxAnalyze.Items.Clear();
            if (rbDirectory.Checked)
                lstboxAnalyze.Items.Add(Resources.ListBox_Dir_Results);
            else
            {
                if(_fileTypeSelected == CS)
                {
                    lstboxAnalyze.Items.Add(Resources.ListBox_Sln_Results + " (C# Files):");
                }
                else if (_fileTypeSelected == CSHTML)
                {
                    lstboxAnalyze.Items.Add(Resources.ListBox_Sln_Results + " (CSHTML Files):");
                }
                else
                {
                    lstboxAnalyze.Items.Add(Resources.ListBox_Sln_Results + " (Javascript Files):");
                }
            }
            lstboxAnalyze.Items.Add(String.Format(Resources.ListBox_Total, fileCount));
            foreach (KeyValuePair<string, int> entry in myList)
            {
                string filetype = String.Format(Resources.ListBox_Items, entry.Key, entry.Value);
                if(entry.Value > 0)
                    lstboxAnalyze.Items.Add(filetype);
            }
        }

        /// <summary>
        /// Takes the user selected Directory/Solution and outputs information regarding the number of 
        /// file types or projects that are associated with the user's selection
        /// </summary>
        //TODO: Figure out why File type selection fires the event handler twice(printing the info pane)
        private void AnalyzeSelectedFileGroup()
        {
            Dictionary<string, int> fileTypes = new Dictionary<string, int>();
            List<KeyValuePair<string, int>> myList = new List<KeyValuePair<string, int>>();

            int fileCount = 0;
            fileTypes.Clear();
            lstboxAnalyze.Items.Add(Resources.ListBox_Working);

            //begin asynchronous work
            #region Background Worker FileGroup Analysis
            BackgroundWorker bwAnalyze = new BackgroundWorker();
            bwAnalyze.WorkerReportsProgress = true;
            bwAnalyze.WorkerSupportsCancellation = true;
            bwAnalyze.DoWork += delegate
            {
                // do work. You can use locals from here
                if (rbDirectory.Checked)
                {//directory path
                    _inputPath = txtboxInputPath.Text;
                    var fileList = GetFileList(txtboxInputPath.Text);
                    fileCount = fileList.Count();

                    foreach (string file in fileList)
                    {
                        string ext = Path.GetExtension(file);
                        if (!fileTypes.ContainsKey(ext))
                        {
                            fileTypes.Add(ext, 1);
                        }
                        else
                        {
                            fileTypes[ext]++;
                        }
                    }
                }
                else
                {//sln path
                    foreach (KeyValuePair<string, ArrayList> p in _ProjectsAndFiles)
                    {
                        if (!fileTypes.ContainsKey(p.Key))
                        {
                            fileTypes.Add(Path.GetFileName(p.Key), p.Value.Count);
                            fileCount += p.Value.Count;
                        }
                    }
                }

                //Sort the filetypes by frequency
                myList = fileTypes.ToList();
                myList.Sort((firstPair, nextPair) =>
                {
                    return nextPair.Value.CompareTo(firstPair.Value);
                }
                );
            };//end DoWork
            bwAnalyze.ProgressChanged += delegate
            {
                //report progress
            };//end ProgressChanged
            bwAnalyze.RunWorkerCompleted += delegate
            {
                // do something with the results.
                AddToListBox(myList, fileCount);
            };//end RunWorkerCompleted
            bwAnalyze.RunWorkerAsync();
            #endregion 
        }

        /// <summary>
        /// Determine the Sort order for a specific category's results based on the combobox selection
        /// </summary>
        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Category c in CategoryList)
            {
                if (String.Equals(((ComboBox)sender).Name, c.CboSort.Name))
                {
                    switch (c.CboSort.SelectedIndex)
                    {
                        case 0:
                            c.TV.TreeViewNodeSorter = new NodeSorterOccurence();
                            break;
                        case 1:
                            c.TV.TreeViewNodeSorter = new NodeSorterDescending();
                            break;
                        case 2:
                            c.TV.TreeViewNodeSorter = new NodeSorterAscending();
                            break;
                    }
                }
            }
        }
        #endregion

        #region ExportText Output to File
        /// <summary>
        /// Enables the export buttons if the text boxes have data
        /// </summary>
        private void EnableExportExpand()
        {
            foreach (Category c in CategoryList)
            {
                if(c.TV != null)
                    c.ExportBtn.Enabled = c.ExpandBtn.Enabled = c.TV.Nodes.Count > 0;
            }
        }

        /// <summary>
        /// Disables the export buttons (Initial Start and during File Traversal)
        /// </summary>
        private void DisableExportExpand()
        {
            foreach (Category c in CategoryList)
            {
                if (c.TV != null)
                    c.ExportBtn.Enabled = c.ExpandBtn.Enabled = c.TV.Nodes.Count > 0;
            }
        }

        /// <summary>
        /// Saves the Output to Text File
        /// </summary>
        /// <param name="filename"> The name of the output file </param>
        /// <param name="output"> The contents of the output file </param>
        /// <param name="saveFile"> The SaveFileDialog </param>
        private void ExportFileToText(string filename, string output, SaveFileDialog saveFile)
        {
            DateTime date = DateTime.Now;
            saveFile.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv";
            saveFile.FilterIndex = 1;
            saveFile.RestoreDirectory = true;
            saveFile.FileName = String.Format(Resources.Filename_Construction, Path.GetFileName(_inputPath), filename, date.ToString("yyyyMMdd_HHmmss"));

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (saveFile.FileName != "")
                {
                    // Code to write the stream goes here.
                    File.WriteAllText(saveFile.FileName, output);
                }
            }
        }

        
        #endregion

        #region Clear Data
        /// <summary>
        /// Clears all counts/fields of all parsing categories and blanks textboxes on the UI
        /// </summary>
        private void ClearForm()
        {
            
            foreach (Category c in CategoryList)
            {
                c.ResetCount();
                timer.Stop();
                c.PanelMatches.Invalidate();
                c.PanelFiles.Invalidate();
                c.BufMatches.Dispose();
                c.BufFiles.Dispose();
                c.BufMatches = new Bitmap(c.PanelMatches.Width, c.PanelMatches.Height);
                c.BufFiles = new Bitmap(c.PanelFiles.Width, c.PanelFiles.Height);
                if(c.TV != null)
                    c.TV.Nodes.Clear();
            }
            lbl_OverView_Results.Visible = false;
            progbar.Value = 0;
            progbar.Visible = false;
            lblProcessing.Visible = false;
            lblPercentage.Visible = false;
        }

        /// <summary>
        /// Returns Label Names to Initial State 
        /// </summary>
        private void RestoreLabelNames()
        {
            lblCompare.Text = Resources.Filename_Compare;
            lblConcat.Text = Resources.Filename_Concats;
            lblHardCoded.Text = Resources.Filename_HardCode;
            lblFunc.Text = Resources.Filename_Func;
            lblDateFormat.Text = Resources.Filename_Date;
            lblDecimal.Text = Resources.Filename_Decimal;
        }

        #endregion

        #region Asynch Parsing
        /// <summary>
        /// Determines if a line in a file being parsed contains a match for any of the selected categories through Regex
        /// </summary>
        /// <param name="c"> The parsing category </param>
        /// <param name="line"> The line being parsed </param>
        /// <returns> TRUE if line produces a match, FALSE if not </returns>
        public bool IsConditionMet(Category c, string line)
        {
            foreach (Filter filter in c.RegExInclude_list)
            {
                if (filter.IsPattern)
                {
                    if (filter.Filter_Regex.IsMatch(line))
                        return true;
                }
                else
                {
                    if (line.IndexOf(filter.Filter_String, StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if the matched line should be omitted due to conflict with an exclusion filter
        /// </summary>
        /// <param name="c">The parsing category</param>
        /// <param name="line">The line being parsed</param>
        /// <returns></returns>
        public bool ExclusionsDetected(Category c, string line)
        {
            foreach (Filter exclusions in c.RegExExclude_list)
            {
                if (exclusions.IsPattern)
                {
                    if (exclusions.Filter_Regex.IsMatch(line))
                        return true;
                }
                else
                {
                    if (line.IndexOf(exclusions.Filter_String, StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Goes through each cs file line by line and determines if there is a match for the selected parsing category
        /// </summary>
        /// <param name="fi"> The file currently being parsed </param>
        public void ParseFile(FileInfo fi)
        {
            StreamReader file = fi.OpenText();
            string line;
            string filename = fi.FullName;

            //shorten the filename path in ui for easier reading
            string[] pathName = _inputPath.Split('\\');
            string[] currentName = filename.Split('\\');
            for(int i = 0; i < pathName.Count(); i++)
            {
                if (pathName[i].Equals(currentName[i]))
                {
                    currentName[i] = "";
                }
                else
                {
                    break;
                }
            }
            filename = "~" + Path.Combine(currentName);

            //Read resulting file line by line
            int lineCount = 1;
            while ((line = file.ReadLine()) != null)
            {
                foreach (Category category in CategoryList)
                {
                    //create new child node for each match found
                    if (category.Enabled && category.ChkBox.Checked && IsConditionMet(category, line))
                    {
                        bool exclusionsDetected = ExclusionsDetected(category, line);

                        if (!exclusionsDetected)
                        {
                            category.Count++;
                            TreeNode child = new TreeNode();
                            child.Text = String.Format(Resources.TextBox_Results_Line, lineCount, line.Trim());
                            category.ChildrenNodes.Add(child);
                        }
                    }
                }
                lineCount++;
            }
            file.Close();

            //populate the UI with the match results
            foreach (Category category in CategoryList)
            {
                if (category.Count > 0)
                {
                    category.TotalCount += category.Count;
                    category.FileCount++;

                    //populate each category's treeview
                    TreeNode parent = new TreeNode();
                    parent.Text = String.Format(Resources.Treeview_Results, category.Count, filename);
                    parent.Tag = category.FileCount; //tagging for sort order
                    ShowResults_TV(category.TV, parent, category.ChildrenNodes);

                    //call the following methods on UI thread, not current working thread(this)
                    ShowResults_Label(category.Lbl_Title,
                        String.Format(category.Lbl_Title_Result, category.TotalCount, category.FileCount));
                    
                    category.Count = 0;
                    category.ChildrenNodes.Clear();
                }
            }
        }

        #endregion

        #region EnumerateFiles
        /// <summary>
        /// Searches through a specified directory and subdirectories for files that match the 
        /// searchPatternExpression and don't match the excludePatternExpression.
        /// Uses Directory.EnumerateFiles for fast Traversal .NET 4.0 and above
        /// </summary>
        /// <param name="path"> The file path to Enumerate </param>
        /// <param name="searchPatternExpression"> The file Pattern to Search for </param>
        /// <param name="excludePatternExpression"> The file Pattern to exclude </param>
        /// <returns> A List containing all files in the specified directory and its cubdirectories that match the searchPattern </returns>
        public static IEnumerable<string> GetFileList(string path, string searchPatternExpression = "", string excludePatternExpression = @".somefilename")
        {
            Regex reSearchPattern = new Regex(searchPatternExpression, RegexOptions.IgnoreCase);
            Regex reExcludePattern = new Regex(excludePatternExpression, RegexOptions.IgnoreCase);
            return Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)
                            .Where(file =>
                                     reSearchPattern.IsMatch(Path.GetFileName(file)) && !reExcludePattern.IsMatch(Path.GetFileName(file)));
        }

        /// <summary>
        /// For if Directory.EnumarateFiles is not available (.NET 3.5 and below)
        /// Searches a given path for files matching the filesearchPattern
        /// </summary>
        /// <param name="fileSearchPattern"> The pattern to match files to </param>
        /// <param name="rootFolderPath"> The path to search </param>
        /// <returns> A list containing all files that match the pattern </returns>
        public static IEnumerable<string> GetFileListA(string fileSearchPattern, string rootFolderPath)
        {
            Queue<string> pending = new Queue<string>();
            //Regex reSearchPattern = new Regex(fileSearchPattern, RegexOptions.IgnoreCase);
            pending.Enqueue(rootFolderPath);
            string[] tmp;
            while (pending.Count > 0)
            {
                rootFolderPath = pending.Dequeue();
                tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);
                for (int i = 0; i < tmp.Length; i++)
                {
                    yield return tmp[i];
                }
                tmp = Directory.GetDirectories(rootFolderPath);
                for (int i = 0; i < tmp.Length; i++)
                {
                    pending.Enqueue(tmp[i]);
                }
            }
        }

        #endregion

        #region TreeView Category Selection
        /// <summary>
        /// Dictates the behavior of the Category Selection TreeView
        /// </summary>
        private void TreeViewConfig_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (Category c in CategoryList)
            {
                if (c.Enabled)
                    SetRegex(c);
            }

            SetChildrenChecked(e.Node, e.Node.Checked);

            if (e.Node.Parent != null)
            {
                bool setParentChecked = true;
                foreach (TreeNode node in e.Node.Parent.Nodes)
                {
                    if (node.Checked != e.Node.Checked)
                    {
                        setParentChecked = false;
                        break;
                    }
                }
                if (setParentChecked)
                {
                    if (e.Node.ForeColor != Color.Gray)
                    {
                        e.Node.Parent.Checked = e.Node.Checked;
                    }
                }
            }
        }

        /// <summary>
        /// Sets child nodes to be checked if the parent node is checked
        /// </summary>
        /// <param name="treeNode">The Parent node</param>
        /// <param name="checkedState">The state of the parent node checkbox</param>
        private void SetChildrenChecked(TreeNode treeNode, bool checkedState)
        {
            foreach (TreeNode item in treeNode.Nodes)
            {
                if (item.Checked != checkedState && item.ForeColor != Color.Gray)
                {
                    item.Checked = checkedState;
                }
            }
        }

        /// <summary>
        /// Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
        private void HideCheckBox(TreeView tvw, TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }

        /// <summary>
        /// Displays the checkbox for the specified node on a TreeView control.
        /// </summary>
        private void ShowCheckBox(TreeView tvw, TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 4096; //0x1000
            SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }

        // Updates all isChild tree nodes to check all checkboxes recursively.
        private void EnableAllChildNodes(TreeNode treeNode)
        {
            ShowCheckBox(treeViewConfig, treeNode);
            treeNode.ForeColor = Color.Black;
            if (treeNode.Nodes.Count > 0)
            {
                foreach (TreeNode node in treeNode.Nodes)
                {
                    // If the current node has isChild nodes, call the method recursively.
                    this.EnableAllChildNodes(node);
                }
            }
        }

        /// <summary>
        /// Disables a configuration option in the parsing category TreeView
        /// </summary>
        /// <param name="treeView"> The TreeView that oholds the configuration options </param>
        /// <param name="treeNode"> The TreeNode Option to Disable </param>
        private void DisableConfigOption(TreeView treeView, TreeNode treeNode)
        {
            HideCheckBox(treeView, treeNode);
            treeNode.ForeColor = Color.Gray;
        }

        /// <summary>
        /// Enables a configuration option in the parsing category TreeView
        /// </summary>
        /// <param name="treeView"> The TreeView that oholds the configuration options </param>
        /// <param name="treeNode"> The TreeNode Option to Enable </param>
        private void EnableConfigOption(TreeView treeView, TreeNode treeNode)
        {
            ShowCheckBox(treeView, treeNode);
            treeNode.ForeColor = Color.Black;
        }

        private int DisableConfigNodes(TreeNode root, List<string> nodeList, int disableCount)
        {
            int cnt = 0;
            foreach (TreeNode node in root.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    cnt = DisableConfigNodes(node, nodeList, disableCount);
                    if (cnt == node.Nodes.Count)
                        DisableConfigOption(treeViewConfig, node);
                }
                

                if (nodeList.Contains(node.Text))
                {
                    DisableConfigOption(treeViewConfig, node);
                    disableCount++;
                }
            }
            return disableCount;
        }

        /// <summary>
        /// Enable or Disable certain parsing categories depending on which file type is selected
        /// </summary>
        private void FileType_CheckChanged(object sender, EventArgs e)
        {
            List<string> NodesToDisable = new List<string>();

            foreach (TreeNode node in treeViewConfig.Nodes)
            {
                EnableAllChildNodes(node);
            }

            if (cboFileType.SelectedIndex == CS)
            {
                _fileTypeSelected = CS;

                //identify the parsing categories not supported by CS file search
                foreach (KeyValuePair<string, List<Filter>> entry in _CategoryFilter)
                {
                    foreach (Filter filter in entry.Value)
                    {
                        if(filter.fileCS == 0)
                            NodesToDisable.Add(filter.Name);
                    }
                }

                //disable non-compatible categories 
                int disableCount = 0;
                foreach (TreeNode node in treeViewConfig.Nodes)
                {
                    DisableConfigNodes(node, NodesToDisable, disableCount);
                    if (disableCount == node.Nodes.Count)
                        DisableConfigOption(treeViewConfig, node);
                }

                foreach (Category c in CategoryList)
                {
                    c.Enabled = true;
                }
            }
            if (cboFileType.SelectedIndex == CSHTML)
            {
                _fileTypeSelected = CSHTML;

                //identify the parsing categories not supported by CSHTML file search
                foreach (KeyValuePair<string, List<Filter>> entry in _CategoryFilter)
                {
                    foreach (Filter filter in entry.Value)
                    {
                        if (filter.fileCSHTML == 0)
                            NodesToDisable.Add(filter.Name);
                    }
                }

                //disable non-compatible categories
                int disableCount = 0;
                foreach (TreeNode node in treeViewConfig.Nodes)
                {
                    DisableConfigNodes(node, NodesToDisable, disableCount);
                    if (disableCount == node.Nodes.Count)
                        DisableConfigOption(treeViewConfig, node);
                }

                foreach (Category c in CategoryList)
                {
                    if (c.Name == Resources.Label_Compare || c.Name == Resources.Label_Func)
                        c.Enabled = false;
                    c.Enabled = true;
                }
            }
            if (cboFileType.SelectedIndex == JS)
            {
                _fileTypeSelected = JS;

                //identify the parsing categories not supported by JS file search
                foreach (KeyValuePair<string, List<Filter>> entry in _CategoryFilter)
                {
                    foreach (Filter filter in entry.Value)
                    {
                        if (filter.fileJS == 0)
                            NodesToDisable.Add(filter.Name);
                    }
                }

                //disable non-compatible categories
                int disableCount = 0;
                foreach (TreeNode node in treeViewConfig.Nodes)
                {
                    DisableConfigNodes(node, NodesToDisable, disableCount);
                    if (disableCount == node.Nodes.Count)
                        DisableConfigOption(treeViewConfig, node);
                }
                foreach (Category c in CategoryList)
                {
                    if (c.Name == Resources.Label_Func)
                        c.Enabled = false;
                    c.Enabled = true;
                }
            }

            foreach (Category c in CategoryList)
            {
                if (c.Enabled)
                    SetRegex(c);
            }

            if (rbSolution.Checked)
            {
                _ProjectsAndFiles.Clear();
                lstboxAnalyze.Items.Clear();
                //TODO: find out why this line below causes the event handler to fire twice
                SetProjectFileList();
            }
            
        }

        /// <summary>
        /// Receive a List of all checked checkboxes in the Parsing Categories Treeview
        /// </summary>
        /// <param name="theNodes"> The TreeView Nodes </param>
        /// <returns> List of all checked checkboxes </returns>
        List<String> CheckedCategories(TreeNodeCollection theNodes)
        {
            List<String> selectedCategories = new List<String>();

            if (theNodes != null)
            {
                foreach (TreeNode aNode in theNodes)
                {
                    if (aNode.Checked)
                    {
                        selectedCategories.Add(aNode.Text);
                    }

                    selectedCategories.AddRange(CheckedCategories(aNode.Nodes));
                }
            }

            return selectedCategories;
        }

        #endregion

        #region Regex Construction
        /// <summary>
        /// Set the Regex patterns for each category
        /// </summary>
        /// <param name="category">The category to set the Regex Pattern of</param>
        private void SetRegex(Category category)
        {
            #region Regex Modular Construction
            List<String> checkedCategories = CheckedCategories(treeViewConfig.Nodes);
            category.RegExInclude_list.Clear();
            category.RegExExclude_list.Clear();

            //for each parsing category that is checked in the configuration treeview
            foreach (string categoryName in checkedCategories)
            {
                //for each category 
                foreach (Filter filter in _CategoryFilter[category.Name])
                {
                    //assign all filters in category to its list
                    if (categoryName == filter.Name && !category.RegExInclude_list.Contains(filter))
                    {
                        if (filter.Include)
                            category.RegExInclude_list.Add(filter);
                        else
                            category.RegExExclude_list.Add(filter);
                    }
                }
            }
            #endregion
        }
        #endregion

        #region Filter Addition/Deletion/Saving

        /// <summary>
        /// Takes a user defined filter and adds it to the UI
        /// </summary>
        /// <param name="userFilter">The user defined filter</param>
        private void AssignFilter(Filter userFilter)
        {
            TreeNode filterNode = new TreeNode();
            filterNode.Text = userFilter.Name;
            foreach (TreeNode node in treeViewConfig.Nodes["NodeSelectAll"].Nodes)
            {
                if (node.Text == userFilter.ParentCategory)
                {
                    if (!node.Nodes.Contains(filterNode))
                    {
                        node.Nodes.Add(filterNode);
                        if (_fileTypeSelected == CS)
                        {
                            if(userFilter.fileCS == 0)
                                DisableConfigOption(treeViewConfig, filterNode);
                        }
                        if (_fileTypeSelected == CSHTML)
                        {
                            if (userFilter.fileCSHTML == 0)
                                DisableConfigOption(treeViewConfig, filterNode);
                        }
                        if (_fileTypeSelected == JS)
                        {
                            if (userFilter.fileJS == 0)
                                DisableConfigOption(treeViewConfig, filterNode);
                        }
                    }
                    
                }
            }
        }
        
        /// <summary>
        /// Initializes the Default Filter Set.
        /// To add a new Filter: 
        /// Name of Filter, Parent Category, Inclusive (true) or Exclusive (false), Regex String, pattern (true), cs compat, cshtml compat, js compat
        /// </summary>
        /// <param name="filename">The XML file to read in the Default and User-Defined filters</param>
        private void SerializeDefaultSet(string filename)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Filter>));

            List<Filter> filterList = new List<Filter>();

            //concatenations
            
            //filterList.Add(new Filter("\"str\" + \"str\"", "String Concatenations", true, "([+].*)?\".*\".*[+].*\"", pattern: true, cs: 1, cshtml: 1, js: 0));
            filterList.Add(new Filter("\"str\" + \"str\"", "String Concatenations", true, "([+].*)?&quot;.*&quot;.*[+].*&quot;", pattern: true, cs: 1, cshtml: 1, js: 0));
            filterList.Add(new Filter("String.Format", "String Concatenations", true, @"tring.Format", cs: 1, cshtml: 1, js: 0));
            filterList.Add(new Filter("String.Concat()", "String Concatenations", true, @".concat", cs: 1, cshtml: 1, js: 1));


            //comparisons
            filterList.Add(new Filter("String.Compare()", "String Comparisons", true, @"tring.Compare", cs: 1, cshtml: 0, js: 0));
            filterList.Add(new Filter("String.CompareTo()", "String Comparisons", true, @"tring.CompareTo", cs: 1, cshtml: 0, js: 0));
            filterList.Add(new Filter("String.Equals()", "String Comparisons", true, @"tring.Equals", cs: 1, cshtml: 0, js: 0));
            filterList.Add(new Filter("StringComparison Enumerator", "String Comparisons", true, @"StringComparison", cs: 1, cshtml: 0, js: 0));
            filterList.Add(new Filter("locale.Compare()", "String Comparisons", true, @"locale.Compare", cs: 0, cshtml: 0, js: 1));

            //func returning strings
            filterList.Add(new Filter("Method Signature", "Functions Returning Strings", true, "([sS]tring( |\\[\\]).*\\()|([cC]har( |\\[\\]).*\\()", pattern: true, cs: 1, cshtml: 0, js: 0));
            filterList.Add(new Filter("Method Signature Exclusions", "Functions Returning Strings", false, @"\.|=|:|return|//|/\*|\*/", pattern: true, cs: 1, cshtml: 0, js: 0));

            //hardcoded 
            filterList.Add(new Filter("Strings in Double Quotes: All", "Hard Coded Strings", true, @"""[a-zA-Z\s]*""", pattern: true));
            filterList.Add(new Filter("Strings in Double Quotes: Multiple Words Only", "Hard Coded Strings", true, @"""(\w+\s.)+[^\""]*""", pattern: true));
            filterList.Add(new Filter("Exclude Log", "Hard Coded Strings", false, @"Log|log"));
            filterList.Add(new Filter("Exclude Assembly", "Hard Coded Strings", false, @"Assembly"));
            filterList.Add(new Filter("Exclude System.Diagnostics", "Hard Coded Strings", false, @"System\.Diagnostics"));
            filterList.Add(new Filter("Exclude Message", "Hard Coded Strings", false, @"Message"));
            filterList.Add(new Filter("Exclude GUID", "Hard Coded Strings", false, @"guid"));
            filterList.Add(new Filter("Exclude Guard.Argument", "Hard Coded Strings", false, @"Guard\.ArgumentNotNull"));
            filterList.Add(new Filter("Exclude InternalCode", "Hard Coded Strings", false, @"InternalCode"));
            filterList.Add(new Filter("Exclude Attribute()", "Hard Coded Strings", false, @"Attribute"));
            filterList.Add(new Filter("Exclude ResourceManager.GetString()", "Hard Coded Strings", false, @"ResourceManager\.GetString"));
            filterList.Add(new Filter("Exclude LocalizableDisplayName", "Hard Coded Strings", false, @"LocalizableDisplayName"));

            //date formats
            filterList.Add(new Filter("\"yyyy\" or \"yy\"", "Date Formats", true, "(yyyy|/|-)(yy|yyyy)|(yy|yyyy)(/|-)", pattern: true, cs: 1, cshtml: 0, js: 1));
            filterList.Add(new Filter("MyDateTime()", "Date Formats", true, @"MyDateTime", cs: 0, cshtml: 1, js: 0));

            //decimal formats
            filterList.Add(new Filter("#.# Pattern", "Decimal Formats", true, @"#+[\.,][0-9#]+|[0-9#]+[\.,]#+", pattern: true, cs: 1, cshtml: 1, js: 0));
            filterList.Add(new Filter("Include ToFixed()", "Decimal Formats", true, @"ToFixed", cs: 0, cshtml: 0, js: 1));
            filterList.Add(new Filter("Include ToPrecision()", "Decimal Formats", true, @"ToPrecision", cs: 0, cshtml: 0, js: 1));

            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, filterList);
            writer.Close();
        }

        /// <summary>
        /// Reads in the XML file containing all persistent filter data
        /// </summary>
        /// <param name="filename">The XML file to read in</param>
        /// <returns>A list of filters contained in the XML file</returns>
        private List<Filter> DeserializeFilterXML(string filename)
        {
            List<Filter> filterList;
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Filter>));
            // To read the file, create a FileStream.
            FileStream myFileStream = new FileStream(filename, FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            filterList = (List<Filter>) mySerializer.Deserialize(myFileStream);
            myFileStream.Close();
            return filterList;
        }

        /// <summary>
        /// Serializes the Filters into an external XML file for persistnce between sessions
        /// </summary>
        /// <param name="filename">The file the XML is saved to</param>
        private void SerializeFilterXML(string filename)
        {
            //XmlSerializer ser = new XmlSerializer(typeof(Filter));
            List<Filter> filterList = new List<Filter>();
            XmlSerializer ser = new XmlSerializer(typeof(List<Filter>));

            TextWriter writer = new StreamWriter(filename);

            foreach(KeyValuePair<string, List<Filter>> entry in _CategoryFilter)
            {
                foreach (Filter f in entry.Value)
                {
                    filterList.Add(f);
                }
            }
            ser.Serialize(writer, filterList);

            writer.Close();
        }

        /// <summary>
        /// Saves the new filter or does nothing depending on how the UserFilterForm is closed.
        /// </summary>
        private void UserFilterForm_Closed(object sender, EventArgs e)
        {
            if (UserFilterForm.txtboxUserFilter.Text != string.Empty)
            {
                //Create the filter based on the User selected parameters
                string filterCategory = UserFilterForm.cboUserCategory.SelectedItem.ToString();
                string filterString = UserFilterForm.txtboxUserFilter.Text;
                Regex filterRegex = new Regex(Regex.Escape(filterString), RegexOptions.IgnoreCase);
                bool inclusion = UserFilterForm.cboUserIncludeExclude.SelectedItem.ToString() == "Include" ? true : false;
                bool isPattern = UserFilterForm.cboIsPattern.SelectedIndex == 0;
                string filterName = (inclusion ? "Include" : "Exclude") + " filter: " + filterString;
                int fileCS = UserFilterForm.chkboxCS.Checked ? 1 : 0;
                int fileCSHTML = UserFilterForm.chkboxCSHTML.Checked ? 1 : 0;
                int fileJS = UserFilterForm.chkboxJS.Checked ? 1 : 0;

                if (UserFilterForm.txtboxUserFilterName.Text != "Enter the Name of the Filter (optional)" &&
                    !String.IsNullOrEmpty(UserFilterForm.txtboxUserFilterName.Text))
                {
                    filterName = UserFilterForm.txtboxUserFilterName.Text;
                }

                MessageBox.Show("Filter added to category "+ filterCategory + ": " + filterName);

                Filter newFilter = new Filter(filterName, filterCategory, inclusion, filterString, isPattern, fileCS, fileCSHTML, fileJS);
                newFilter.Filter_Regex = filterRegex;

                //add new filter to Global Filter Dictionary
                if (_CategoryFilter.ContainsKey(newFilter.ParentCategory))
                {
                    _CategoryFilter[newFilter.ParentCategory].Add(newFilter);
                }
                else
                {
                    List<Filter> tempFilterList = new List<Filter>();
                    tempFilterList.Add(newFilter);
                    _CategoryFilter.Add(newFilter.ParentCategory, tempFilterList);
                }

                AssignFilter(newFilter);

                //Save the changes to Filter settings
                File.Delete(_FilterPath);
                SerializeFilterXML(_FilterPath);
            }
            else
            {
                MessageBox.Show("Cancelled: No Filter Added");
            }

        }

        #endregion
    }

    #region Category Class
    /// <summary>
    /// The parsing categories and associated fields
    /// </summary>
    //TODO: Decouple from the WinForm
    public class Category
    {
        public Category()
        {
            Count = 0;
            TotalCount = 0;
            FileCount = 0;
            Enabled = true;
            IsExpanded = false;
            ChildrenNodes = new List<TreeNode>();

            RegExInclude_list = new List<Filter>();
            RegExExclude_list = new List<Filter>();
        }

        public void ResetCount()
        {
            Count = 0;
            TotalCount = 0;
            FileCount = 0;
            ChildrenNodes.Clear();
        }

        public string Name;
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int FileCount { get; set; }
        public bool Enabled { get; set; }
        public bool IsExpanded { get; set; }
        public Bitmap BufMatches { get; set; }
        public Bitmap BufFiles { get; set; }
        //decouple -- linked to winform
        public Panel PanelMatches { get; set; }
        public Panel PanelFiles { get; set; }
        public Label Lbl_Title { get; set; }
        public TreeView TV { get; set; }
        public TreeNode ChkBox { get; set; }
        public Button ExportBtn { get; set; }
        public Button ExpandBtn { get; set; }
        public ComboBox CboSort { get; set; }
        //
        public List<TreeNode> ChildrenNodes { get; set; }
        public Regex RegExPattern { get; set; }
        public Regex RegExContains { get; set; }
        public String Lbl_Title_Result { get; set; }
        public List<Filter> RegExInclude_list { get; set; }
        public List<Filter> RegExExclude_list { get; set; }
    }
    #endregion

    #region Filter Class
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class Filter
    {
        public Filter()
        {
            Name = "";
            Include = true;
        }

        public Filter(string name)
        {
            Name = name;
        }

        public Filter(string name, string category, bool include, string userfilter, bool pattern = false, int cs = 1, int cshtml = 1, int js = 1)
        {
            Name = name;
            ParentCategory = category;
            Include = include;
            Filter_String = userfilter;
            IsPattern = pattern;
            fileCS = cs;
            fileCSHTML = cshtml;
            fileJS = js;
        }

        public string Name { get; set; }
        public string ParentCategory { get; set; }
        public string Filter_String { get; set; }
        public Regex Filter_Regex { get; set; }
        public bool Include { get; set; }
        public bool IsPattern { get; set; }
        public int fileCS { get; set; }
        public int fileCSHTML { get; set; }
        public int fileJS { get; set; }
    }
    #endregion

    #region NodeSorting Classes
    /// <summary>
    /// Node sorter that implements the IComparer interface.  Sorts based on order of occurence
    /// </summary>
    public class NodeSorterOccurence : IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            int tx_int = 0;
            int ty_int = 0;
            int result = 1;

            if (tx.Parent == null && ty.Parent == null)
            {
                tx_int = (int)tx.Tag;
                ty_int = (int)ty.Tag;
                result = tx_int - ty_int;
            }

            return result;
        }
    }

    /// <summary>
    /// Node sorter that implements the IComparer interface.  Sorts based on number of matches (Descending)
    /// </summary>
    public class NodeSorterDescending : IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            int tx_int = 0;
            int ty_int = 0;
            int result = 0;
            string[] tx_text = tx.Text.Split(' ');
            string[] ty_text = ty.Text.Split(' ');

            if (tx.Parent == null && ty.Parent == null)
            {
                tx_int = Int32.Parse(tx_text[0]);
                ty_int = Int32.Parse(ty_text[0]);
                result = ty_int - tx_int;
            }
            else
            {
                tx_int = Int32.Parse(tx_text[1]);
                ty_int = Int32.Parse(ty_text[1]);
                result = tx_int - ty_int;
            }

            return result;
        }
    }

    /// <summary>
    /// Node sorter that implements the IComparer interface.  Sorts based on number of matches (Ascending)
    /// </summary>
    public class NodeSorterAscending : IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            int tx_int = 0;
            int ty_int = 0;
            int result = 0;
            string[] tx_text = tx.Text.Split(' ');
            string[] ty_text = ty.Text.Split(' ');

            if (tx.Parent == null && ty.Parent == null)
            {
                tx_int = Int32.Parse(tx_text[0]);
                ty_int = Int32.Parse(ty_text[0]);
                result = tx_int - ty_int;
            }
            else
            {
                tx_int = Int32.Parse(tx_text[1]);
                ty_int = Int32.Parse(ty_text[1]);
                result = tx_int - ty_int;
            }

            return result;
        }
    }
    #endregion
}
