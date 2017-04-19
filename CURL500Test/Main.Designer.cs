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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadingCircle = new MRG.Controls.UI.LoadingCircleToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu = new System.Windows.Forms.ToolStripMenuItem();
            this.COMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCOM = new System.Windows.Forms.ToolStripMenuItem();
            this.testSetSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.testListDataGrid)).BeginInit();
            this.tabControl.SuspendLayout();
            this.msgTab.SuspendLayout();
            this.logTab.SuspendLayout();
            this.resultsBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.testListDataGrid.AllowUserToAddRows = false;
            this.testListDataGrid.AllowUserToDeleteRows = false;
            this.testListDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testListDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.testListDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.testListDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testListDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.testListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.testListDataGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.testListDataGrid.Location = new System.Drawing.Point(499, 61);
            this.testListDataGrid.Name = "testListDataGrid";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testListDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.testListDataGrid.Size = new System.Drawing.Size(264, 562);
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
            this.testListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testListLabel.AutoSize = true;
            this.testListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testListLabel.Location = new System.Drawing.Point(495, 34);
            this.testListLabel.Name = "testListLabel";
            this.testListLabel.Size = new System.Drawing.Size(78, 24);
            this.testListLabel.TabIndex = 5;
            this.testListLabel.Text = "Test List";
            // 
            // mainLogTextBox
            // 
            this.mainLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLogTextBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mainLogTextBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.mainLogTextBox.Location = new System.Drawing.Point(0, 0);
            this.mainLogTextBox.Multiline = true;
            this.mainLogTextBox.Name = "mainLogTextBox";
            this.mainLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainLogTextBox.Size = new System.Drawing.Size(464, 289);
            this.mainLogTextBox.TabIndex = 6;
            // 
            // submitButton
            // 
            this.submitButton.CausesValidation = false;
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
            this.logoffButton.Location = new System.Drawing.Point(12, 27);
            this.logoffButton.Name = "logoffButton";
            this.logoffButton.Size = new System.Drawing.Size(75, 23);
            this.logoffButton.TabIndex = 8;
            this.logoffButton.Text = "Log Off";
            this.logoffButton.UseVisualStyleBackColor = true;
            this.logoffButton.Click += new System.EventHandler(this.logoffButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.CausesValidation = false;
            this.tabControl.Controls.Add(this.msgTab);
            this.tabControl.Controls.Add(this.logTab);
            this.tabControl.Controls.Add(this.resultsBox);
            this.tabControl.Location = new System.Drawing.Point(12, 295);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(472, 315);
            this.tabControl.TabIndex = 9;
            // 
            // msgTab
            // 
            this.msgTab.Controls.Add(this.operatorMessageBox);
            this.msgTab.Location = new System.Drawing.Point(4, 22);
            this.msgTab.Name = "msgTab";
            this.msgTab.Padding = new System.Windows.Forms.Padding(3);
            this.msgTab.Size = new System.Drawing.Size(464, 289);
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
            this.operatorMessageBox.Size = new System.Drawing.Size(464, 289);
            this.operatorMessageBox.TabIndex = 0;
            // 
            // logTab
            // 
            this.logTab.Controls.Add(this.mainLogTextBox);
            this.logTab.Location = new System.Drawing.Point(4, 22);
            this.logTab.Name = "logTab";
            this.logTab.Padding = new System.Windows.Forms.Padding(3);
            this.logTab.Size = new System.Drawing.Size(464, 289);
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
            this.resultsBox.Size = new System.Drawing.Size(464, 289);
            this.resultsBox.TabIndex = 2;
            this.resultsBox.Text = "Results";
            this.resultsBox.UseVisualStyleBackColor = true;
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsTextBox.Location = new System.Drawing.Point(0, 0);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextBox.Size = new System.Drawing.Size(464, 293);
            this.resultsTextBox.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingCircle,
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 613);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(775, 22);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(775, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu
            // 
            this.menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COMToolStripMenuItem,
            this.testCOM,
            this.testSetSettingsToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(50, 20);
            this.menu.Text = "Menu";
            // 
            // COMToolStripMenuItem
            // 
            this.COMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COM1ToolStripMenuItem,
            this.COM2ToolStripMenuItem,
            this.COM3ToolStripMenuItem,
            this.COM4ToolStripMenuItem,
            this.COM5ToolStripMenuItem,
            this.COM6ToolStripMenuItem,
            this.COM7ToolStripMenuItem,
            this.COM8ToolStripMenuItem,
            this.COM9ToolStripMenuItem});
            this.COMToolStripMenuItem.Name = "COMToolStripMenuItem";
            this.COMToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.COMToolStripMenuItem.Text = "COM";
            this.COMToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.COMToolStripMenuItem_DropDownItemClicked);
            // 
            // COM1ToolStripMenuItem
            // 
            this.COM1ToolStripMenuItem.Name = "COM1ToolStripMenuItem";
            this.COM1ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.COM1ToolStripMenuItem.Text = "COM1";
            // 
            // COM2ToolStripMenuItem
            // 
            this.COM2ToolStripMenuItem.Name = "COM2ToolStripMenuItem";
            this.COM2ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.COM2ToolStripMenuItem.Text = "COM2";
            // 
            // COM3ToolStripMenuItem
            // 
            this.COM3ToolStripMenuItem.Name = "COM3ToolStripMenuItem";
            this.COM3ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.COM3ToolStripMenuItem.Text = "COM3";
            // 
            // COM4ToolStripMenuItem
            // 
            this.COM4ToolStripMenuItem.Name = "COM4ToolStripMenuItem";
            this.COM4ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.COM4ToolStripMenuItem.Text = "COM4";
            // 
            // COM5ToolStripMenuItem
            // 
            this.COM5ToolStripMenuItem.Name = "COM5ToolStripMenuItem";
            this.COM5ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.COM5ToolStripMenuItem.Text = "COM5";
            // 
            // COM6ToolStripMenuItem
            // 
            this.COM6ToolStripMenuItem.Name = "COM6ToolStripMenuItem";
            this.COM6ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.COM6ToolStripMenuItem.Text = "COM6";
            // 
            // COM7ToolStripMenuItem
            // 
            this.COM7ToolStripMenuItem.Name = "COM7ToolStripMenuItem";
            this.COM7ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.COM7ToolStripMenuItem.Text = "COM7";
            // 
            // COM8ToolStripMenuItem
            // 
            this.COM8ToolStripMenuItem.Name = "COM8ToolStripMenuItem";
            this.COM8ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.COM8ToolStripMenuItem.Text = "COM8";
            // 
            // COM9ToolStripMenuItem
            // 
            this.COM9ToolStripMenuItem.Name = "COM9ToolStripMenuItem";
            this.COM9ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.COM9ToolStripMenuItem.Text = "COM9";
            // 
            // testCOM
            // 
            this.testCOM.Name = "testCOM";
            this.testCOM.Size = new System.Drawing.Size(160, 22);
            this.testCOM.Text = "Test COM Port";
            this.testCOM.Click += new System.EventHandler(this.testCOM_Click);
            // 
            // testSetSettingsToolStripMenuItem
            // 
            this.testSetSettingsToolStripMenuItem.Name = "testSetSettingsToolStripMenuItem";
            this.testSetSettingsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.testSetSettingsToolStripMenuItem.Text = "Test Set Settings";
            this.testSetSettingsToolStripMenuItem.Click += new System.EventHandler(this.testSetSettingsToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AcceptButton = this.submitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(775, 635);
            this.Controls.Add(this.testListDataGrid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.logoffButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.testListLabel);
            this.Controls.Add(this.serialIdLabel);
            this.Controls.Add(this.fiberIdLabel);
            this.Controls.Add(this.serialIdTextBox);
            this.Controls.Add(this.fiberIdTextBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "CURL500 Test";
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private MRG.Controls.UI.LoadingCircleToolStripMenuItem loadingCircle;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu;
        private System.Windows.Forms.ToolStripMenuItem COMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCOM;
        private System.Windows.Forms.ToolStripMenuItem testSetSettingsToolStripMenuItem;
    }
}

