namespace CURL500Test
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fiberIdTextBox = new System.Windows.Forms.TextBox();
            this.serialIdTextBox = new System.Windows.Forms.TextBox();
            this.testListDataGrid = new System.Windows.Forms.DataGridView();
            this.fiberIdLabel = new System.Windows.Forms.Label();
            this.serialIdLabel = new System.Windows.Forms.Label();
            this.testListLabel = new System.Windows.Forms.Label();
            this.mainLogTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.logoffButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.msgTab = new System.Windows.Forms.TabPage();
            this.operatorMessageBox = new System.Windows.Forms.TextBox();
            this.logTab = new System.Windows.Forms.TabPage();
            this.resultsBox = new System.Windows.Forms.TabPage();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadingCircle = new MRG.Controls.UI.LoadingCircleToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.testListDataGrid)).BeginInit();
            this.tabControl.SuspendLayout();
            this.msgTab.SuspendLayout();
            this.logTab.SuspendLayout();
            this.resultsBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fiberIdTextBox
            // 
            this.fiberIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiberIdTextBox.Location = new System.Drawing.Point(147, 74);
            this.fiberIdTextBox.Name = "fiberIdTextBox";
            this.fiberIdTextBox.Size = new System.Drawing.Size(202, 31);
            this.fiberIdTextBox.TabIndex = 0;
            this.fiberIdTextBox.Leave += new System.EventHandler(this.fiberIdTextBox_Leave);
            this.fiberIdTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.fiberIdTextBox_Validating);
            this.fiberIdTextBox.Validated += new System.EventHandler(this.fiberIdTextBox_Validated);
            // 
            // serialIdTextBox
            // 
            this.serialIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialIdTextBox.Location = new System.Drawing.Point(147, 121);
            this.serialIdTextBox.Name = "serialIdTextBox";
            this.serialIdTextBox.Size = new System.Drawing.Size(165, 31);
            this.serialIdTextBox.TabIndex = 1;
            // 
            // testListDataGrid
            // 
            this.testListDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testListDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.testListDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.testListDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testListDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.testListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.testListDataGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.testListDataGrid.Location = new System.Drawing.Point(401, 42);
            this.testListDataGrid.Name = "testListDataGrid";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testListDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.testListDataGrid.Size = new System.Drawing.Size(263, 570);
            this.testListDataGrid.TabIndex = 2;
            // 
            // fiberIdLabel
            // 
            this.fiberIdLabel.AutoSize = true;
            this.fiberIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiberIdLabel.Location = new System.Drawing.Point(15, 77);
            this.fiberIdLabel.Name = "fiberIdLabel";
            this.fiberIdLabel.Size = new System.Drawing.Size(87, 25);
            this.fiberIdLabel.TabIndex = 3;
            this.fiberIdLabel.Text = "Fiber ID";
            // 
            // serialIdLabel
            // 
            this.serialIdLabel.AutoSize = true;
            this.serialIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialIdLabel.Location = new System.Drawing.Point(15, 124);
            this.serialIdLabel.Name = "serialIdLabel";
            this.serialIdLabel.Size = new System.Drawing.Size(93, 25);
            this.serialIdLabel.TabIndex = 4;
            this.serialIdLabel.Text = "Serial ID";
            // 
            // testListLabel
            // 
            this.testListLabel.AutoSize = true;
            this.testListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testListLabel.Location = new System.Drawing.Point(396, 5);
            this.testListLabel.Name = "testListLabel";
            this.testListLabel.Size = new System.Drawing.Size(78, 24);
            this.testListLabel.TabIndex = 5;
            this.testListLabel.Text = "Test List";
            // 
            // mainLogTextBox
            // 
            this.mainLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLogTextBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mainLogTextBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.mainLogTextBox.Location = new System.Drawing.Point(0, 6);
            this.mainLogTextBox.Multiline = true;
            this.mainLogTextBox.Name = "mainLogTextBox";
            this.mainLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainLogTextBox.Size = new System.Drawing.Size(375, 276);
            this.mainLogTextBox.TabIndex = 6;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(147, 168);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 7;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // logoffButton
            // 
            this.logoffButton.CausesValidation = false;
            this.logoffButton.Location = new System.Drawing.Point(12, 9);
            this.logoffButton.Name = "logoffButton";
            this.logoffButton.Size = new System.Drawing.Size(75, 23);
            this.logoffButton.TabIndex = 8;
            this.logoffButton.Text = "Log Off";
            this.logoffButton.UseVisualStyleBackColor = true;
            this.logoffButton.Click += new System.EventHandler(this.logoffButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.CausesValidation = false;
            this.tabControl.Controls.Add(this.msgTab);
            this.tabControl.Controls.Add(this.logTab);
            this.tabControl.Controls.Add(this.resultsBox);
            this.tabControl.Location = new System.Drawing.Point(12, 295);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(383, 304);
            this.tabControl.TabIndex = 9;
            // 
            // msgTab
            // 
            this.msgTab.Controls.Add(this.operatorMessageBox);
            this.msgTab.Location = new System.Drawing.Point(4, 22);
            this.msgTab.Name = "msgTab";
            this.msgTab.Padding = new System.Windows.Forms.Padding(3);
            this.msgTab.Size = new System.Drawing.Size(375, 278);
            this.msgTab.TabIndex = 0;
            this.msgTab.Text = "Message";
            this.msgTab.UseVisualStyleBackColor = true;
            // 
            // operatorMessageBox
            // 
            this.operatorMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operatorMessageBox.BackColor = System.Drawing.Color.LightSkyBlue;
            this.operatorMessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operatorMessageBox.Location = new System.Drawing.Point(0, 0);
            this.operatorMessageBox.Multiline = true;
            this.operatorMessageBox.Name = "operatorMessageBox";
            this.operatorMessageBox.Size = new System.Drawing.Size(375, 278);
            this.operatorMessageBox.TabIndex = 0;
            // 
            // logTab
            // 
            this.logTab.Controls.Add(this.mainLogTextBox);
            this.logTab.Location = new System.Drawing.Point(4, 22);
            this.logTab.Name = "logTab";
            this.logTab.Padding = new System.Windows.Forms.Padding(3);
            this.logTab.Size = new System.Drawing.Size(375, 278);
            this.logTab.TabIndex = 1;
            this.logTab.Text = "Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // resultsBox
            // 
            this.resultsBox.AutoScroll = true;
            this.resultsBox.Controls.Add(this.resultsTextBox);
            this.resultsBox.Location = new System.Drawing.Point(4, 22);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Padding = new System.Windows.Forms.Padding(3);
            this.resultsBox.Size = new System.Drawing.Size(375, 278);
            this.resultsBox.TabIndex = 2;
            this.resultsBox.Text = "Results";
            this.resultsBox.UseVisualStyleBackColor = true;
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Location = new System.Drawing.Point(0, 0);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextBox.Size = new System.Drawing.Size(375, 269);
            this.resultsTextBox.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingCircle,
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 602);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(676, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loadingCircle
            // 
            // 
            // loadingCircle
            // 
            this.loadingCircle.LoadingCircleControl.AccessibleName = "loadingCircle";
            this.loadingCircle.LoadingCircleControl.Active = false;
            this.loadingCircle.LoadingCircleControl.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle.LoadingCircleControl.InnerCircleRadius = 5;
            this.loadingCircle.LoadingCircleControl.Location = new System.Drawing.Point(1, 2);
            this.loadingCircle.LoadingCircleControl.Name = "loadingCircle";
            this.loadingCircle.LoadingCircleControl.NumberSpoke = 12;
            this.loadingCircle.LoadingCircleControl.OuterCircleRadius = 11;
            this.loadingCircle.LoadingCircleControl.RotationSpeed = 100;
            this.loadingCircle.LoadingCircleControl.Size = new System.Drawing.Size(26, 20);
            this.loadingCircle.LoadingCircleControl.SpokeThickness = 2;
            this.loadingCircle.LoadingCircleControl.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle.LoadingCircleControl.TabIndex = 1;
            this.loadingCircle.LoadingCircleControl.Text = "loadingCircleToolStripMenuItem1";
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.Size = new System.Drawing.Size(26, 20);
            this.loadingCircle.Text = "loadingCircleToolStripMenuItem1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // Main
            // 
            this.AcceptButton = this.submitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 624);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.logoffButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.testListLabel);
            this.Controls.Add(this.serialIdLabel);
            this.Controls.Add(this.fiberIdLabel);
            this.Controls.Add(this.testListDataGrid);
            this.Controls.Add(this.serialIdTextBox);
            this.Controls.Add(this.fiberIdTextBox);
            this.Name = "Main";
            this.Text = "CURL400 Test";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.testListDataGrid)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.msgTab.ResumeLayout(false);
            this.msgTab.PerformLayout();
            this.logTab.ResumeLayout(false);
            this.logTab.PerformLayout();
            this.resultsBox.ResumeLayout(false);
            this.resultsBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fiberIdTextBox;
        private System.Windows.Forms.TextBox serialIdTextBox;
        private System.Windows.Forms.DataGridView testListDataGrid;
        private System.Windows.Forms.Label fiberIdLabel;
        private System.Windows.Forms.Label serialIdLabel;
        private System.Windows.Forms.Label testListLabel;
        private System.Windows.Forms.TextBox mainLogTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button logoffButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage msgTab;
        private System.Windows.Forms.TabPage logTab;
        private System.Windows.Forms.TextBox operatorMessageBox;
        private System.Windows.Forms.TabPage resultsBox;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private MRG.Controls.UI.LoadingCircleToolStripMenuItem loadingCircle;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

