namespace CURL500Test
{
    partial class Settings
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
            this.workstationSelection = new System.Windows.Forms.ComboBox();
            this.workstationLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameSelection = new System.Windows.Forms.ComboBox();
            this.numberLabe = new System.Windows.Forms.Label();
            this.numberSelection = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comSelection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.serverSelection = new System.Windows.Forms.ComboBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.msgLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // workstationSelection
            // 
            this.workstationSelection.FormattingEnabled = true;
            this.workstationSelection.Items.AddRange(new object[] {
            "1S"});
            this.workstationSelection.Location = new System.Drawing.Point(135, 37);
            this.workstationSelection.Name = "workstationSelection";
            this.workstationSelection.Size = new System.Drawing.Size(121, 21);
            this.workstationSelection.TabIndex = 0;
            // 
            // workstationLabel
            // 
            this.workstationLabel.AutoSize = true;
            this.workstationLabel.Location = new System.Drawing.Point(29, 37);
            this.workstationLabel.Name = "workstationLabel";
            this.workstationLabel.Size = new System.Drawing.Size(64, 13);
            this.workstationLabel.TabIndex = 1;
            this.workstationLabel.Text = "Workstation";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(29, 69);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name";
            // 
            // nameSelection
            // 
            this.nameSelection.FormattingEnabled = true;
            this.nameSelection.Items.AddRange(new object[] {
            "LTCURL"});
            this.nameSelection.Location = new System.Drawing.Point(135, 69);
            this.nameSelection.Name = "nameSelection";
            this.nameSelection.Size = new System.Drawing.Size(121, 21);
            this.nameSelection.TabIndex = 2;
            // 
            // numberLabe
            // 
            this.numberLabe.AutoSize = true;
            this.numberLabe.Location = new System.Drawing.Point(29, 99);
            this.numberLabe.Name = "numberLabe";
            this.numberLabe.Size = new System.Drawing.Size(44, 13);
            this.numberLabe.TabIndex = 5;
            this.numberLabe.Text = "Number";
            // 
            // numberSelection
            // 
            this.numberSelection.FormattingEnabled = true;
            this.numberSelection.Items.AddRange(new object[] {
            "01",
            "02"});
            this.numberSelection.Location = new System.Drawing.Point(135, 99);
            this.numberSelection.Name = "numberSelection";
            this.numberSelection.Size = new System.Drawing.Size(121, 21);
            this.numberSelection.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "COM Port";
            // 
            // comSelection
            // 
            this.comSelection.FormattingEnabled = true;
            this.comSelection.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.comSelection.Location = new System.Drawing.Point(135, 134);
            this.comSelection.Name = "comSelection";
            this.comSelection.Size = new System.Drawing.Size(121, 21);
            this.comSelection.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Server";
            // 
            // serverSelection
            // 
            this.serverSelection.FormattingEnabled = true;
            this.serverSelection.Items.AddRange(new object[] {
            "PROD",
            "DEV"});
            this.serverSelection.Location = new System.Drawing.Point(135, 168);
            this.serverSelection.Name = "serverSelection";
            this.serverSelection.Size = new System.Drawing.Size(121, 21);
            this.serverSelection.TabIndex = 8;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(32, 227);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(181, 227);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Location = new System.Drawing.Point(32, 3);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(0, 13);
            this.msgLabel.TabIndex = 12;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.serverSelection);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comSelection);
            this.Controls.Add(this.numberLabe);
            this.Controls.Add(this.numberSelection);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameSelection);
            this.Controls.Add(this.workstationLabel);
            this.Controls.Add(this.workstationSelection);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox workstationSelection;
        private System.Windows.Forms.Label workstationLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox nameSelection;
        private System.Windows.Forms.Label numberLabe;
        private System.Windows.Forms.ComboBox numberSelection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comSelection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox serverSelection;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label msgLabel;
    }
}