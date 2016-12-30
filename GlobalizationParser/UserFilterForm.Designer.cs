namespace GlobalizationPointsOfInterest
{
    partial class UserFilterForm
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
            this.cboUserCategory = new System.Windows.Forms.ComboBox();
            this.cboUserIncludeExclude = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxUserFilter = new System.Windows.Forms.TextBox();
            this.btnUserAdd = new System.Windows.Forms.Button();
            this.btnUserCancel = new System.Windows.Forms.Button();
            this.cboIsPattern = new System.Windows.Forms.ComboBox();
            this.chkboxCS = new System.Windows.Forms.CheckBox();
            this.chkboxCSHTML = new System.Windows.Forms.CheckBox();
            this.chkboxJS = new System.Windows.Forms.CheckBox();
            this.panelFileTypes = new System.Windows.Forms.Panel();
            this.lblFileTypes = new System.Windows.Forms.Label();
            this.txtboxUserFilterName = new System.Windows.Forms.TextBox();
            this.panelFileTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboUserCategory
            // 
            this.cboUserCategory.FormattingEnabled = true;
            this.cboUserCategory.Items.AddRange(new object[] {
            "String Concatenations",
            "String Comparisons",
            "Functions Returning Strings",
            "Hard Coded Strings",
            "Date Formats",
            "Decimal Formats"});
            this.cboUserCategory.Location = new System.Drawing.Point(8, 68);
            this.cboUserCategory.Name = "cboUserCategory";
            this.cboUserCategory.Size = new System.Drawing.Size(312, 21);
            this.cboUserCategory.TabIndex = 1;
            this.cboUserCategory.Text = "Select a Parsing Category";
            // 
            // cboUserIncludeExclude
            // 
            this.cboUserIncludeExclude.FormattingEnabled = true;
            this.cboUserIncludeExclude.Items.AddRange(new object[] {
            "Include",
            "Exclude"});
            this.cboUserIncludeExclude.Location = new System.Drawing.Point(8, 122);
            this.cboUserIncludeExclude.Name = "cboUserIncludeExclude";
            this.cboUserIncludeExclude.Size = new System.Drawing.Size(121, 21);
            this.cboUserIncludeExclude.TabIndex = 2;
            this.cboUserIncludeExclude.Text = "Include/Exclude";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "the following from Category Results:";
            // 
            // txtboxUserFilter
            // 
            this.txtboxUserFilter.Location = new System.Drawing.Point(8, 149);
            this.txtboxUserFilter.Name = "txtboxUserFilter";
            this.txtboxUserFilter.Size = new System.Drawing.Size(312, 20);
            this.txtboxUserFilter.TabIndex = 4;
            this.txtboxUserFilter.Text = "Enter the filter string";
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.Location = new System.Drawing.Point(164, 201);
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(75, 42);
            this.btnUserAdd.TabIndex = 5;
            this.btnUserAdd.Text = "Add";
            this.btnUserAdd.UseVisualStyleBackColor = true;
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // btnUserCancel
            // 
            this.btnUserCancel.Location = new System.Drawing.Point(245, 201);
            this.btnUserCancel.Name = "btnUserCancel";
            this.btnUserCancel.Size = new System.Drawing.Size(75, 42);
            this.btnUserCancel.TabIndex = 6;
            this.btnUserCancel.Text = "Cancel";
            this.btnUserCancel.UseVisualStyleBackColor = true;
            this.btnUserCancel.Click += new System.EventHandler(this.btnUserCancel_Click);
            // 
            // cboIsPattern
            // 
            this.cboIsPattern.FormattingEnabled = true;
            this.cboIsPattern.Items.AddRange(new object[] {
            "Regex Pattern (For matching general patterns)",
            "Substring Match(calls String.Contains for specific substrings)"});
            this.cboIsPattern.Location = new System.Drawing.Point(8, 95);
            this.cboIsPattern.Name = "cboIsPattern";
            this.cboIsPattern.Size = new System.Drawing.Size(312, 21);
            this.cboIsPattern.TabIndex = 8;
            this.cboIsPattern.Text = "Select Filter Type";
            // 
            // chkboxCS
            // 
            this.chkboxCS.AutoSize = true;
            this.chkboxCS.Location = new System.Drawing.Point(3, 8);
            this.chkboxCS.Name = "chkboxCS";
            this.chkboxCS.Size = new System.Drawing.Size(40, 17);
            this.chkboxCS.TabIndex = 9;
            this.chkboxCS.Text = "C#";
            this.chkboxCS.UseVisualStyleBackColor = true;
            // 
            // chkboxCSHTML
            // 
            this.chkboxCSHTML.AutoSize = true;
            this.chkboxCSHTML.Location = new System.Drawing.Point(49, 8);
            this.chkboxCSHTML.Name = "chkboxCSHTML";
            this.chkboxCSHTML.Size = new System.Drawing.Size(70, 17);
            this.chkboxCSHTML.TabIndex = 10;
            this.chkboxCSHTML.Text = "CSHTML";
            this.chkboxCSHTML.UseVisualStyleBackColor = true;
            // 
            // chkboxJS
            // 
            this.chkboxJS.AutoSize = true;
            this.chkboxJS.Location = new System.Drawing.Point(125, 8);
            this.chkboxJS.Name = "chkboxJS";
            this.chkboxJS.Size = new System.Drawing.Size(74, 17);
            this.chkboxJS.TabIndex = 11;
            this.chkboxJS.Text = "Javascript";
            this.chkboxJS.UseVisualStyleBackColor = true;
            // 
            // panelFileTypes
            // 
            this.panelFileTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFileTypes.Controls.Add(this.chkboxCS);
            this.panelFileTypes.Controls.Add(this.chkboxJS);
            this.panelFileTypes.Controls.Add(this.chkboxCSHTML);
            this.panelFileTypes.Location = new System.Drawing.Point(8, 25);
            this.panelFileTypes.Name = "panelFileTypes";
            this.panelFileTypes.Size = new System.Drawing.Size(200, 37);
            this.panelFileTypes.TabIndex = 12;
            // 
            // lblFileTypes
            // 
            this.lblFileTypes.AutoSize = true;
            this.lblFileTypes.Location = new System.Drawing.Point(5, 9);
            this.lblFileTypes.Name = "lblFileTypes";
            this.lblFileTypes.Size = new System.Drawing.Size(194, 13);
            this.lblFileTypes.TabIndex = 12;
            this.lblFileTypes.Text = "Compatible Filetypes (Choose at least 1)";
            // 
            // txtboxUserFilterName
            // 
            this.txtboxUserFilterName.Location = new System.Drawing.Point(8, 175);
            this.txtboxUserFilterName.Name = "txtboxUserFilterName";
            this.txtboxUserFilterName.Size = new System.Drawing.Size(312, 20);
            this.txtboxUserFilterName.TabIndex = 7;
            this.txtboxUserFilterName.Text = "Enter the Name of the Filter (optional)";
            // 
            // UserFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 255);
            this.ControlBox = false;
            this.Controls.Add(this.lblFileTypes);
            this.Controls.Add(this.panelFileTypes);
            this.Controls.Add(this.cboIsPattern);
            this.Controls.Add(this.txtboxUserFilterName);
            this.Controls.Add(this.btnUserCancel);
            this.Controls.Add(this.btnUserAdd);
            this.Controls.Add(this.txtboxUserFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboUserIncludeExclude);
            this.Controls.Add(this.cboUserCategory);
            this.Name = "UserFilterForm";
            this.Text = "Add a Category Filter";
            this.panelFileTypes.ResumeLayout(false);
            this.panelFileTypes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cboUserCategory;
        public System.Windows.Forms.ComboBox cboUserIncludeExclude;
        public System.Windows.Forms.TextBox txtboxUserFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUserAdd;
        private System.Windows.Forms.Button btnUserCancel;
        public System.Windows.Forms.ComboBox cboIsPattern;
        public System.Windows.Forms.CheckBox chkboxCS;
        public System.Windows.Forms.CheckBox chkboxCSHTML;
        public System.Windows.Forms.CheckBox chkboxJS;
        private System.Windows.Forms.Panel panelFileTypes;
        private System.Windows.Forms.Label lblFileTypes;
        public System.Windows.Forms.TextBox txtboxUserFilterName;
    }
}