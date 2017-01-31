namespace CURL500Test
{
    partial class CURL
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
            this.curlLog = new System.Windows.Forms.TextBox();
            this.yesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radiusResultLabel = new System.Windows.Forms.Label();
            this.staticStatusLabel = new System.Windows.Forms.Label();
            this.statusResultLabel = new System.Windows.Forms.Label();
            this.noButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadingCircleToolStripMenuItem1 = new MRG.Controls.UI.LoadingCircleToolStripMenuItem();
            this.curlStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.radiusEntryTextbox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // curlLog
            // 
            this.curlLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.curlLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curlLog.Location = new System.Drawing.Point(13, 13);
            this.curlLog.Multiline = true;
            this.curlLog.Name = "curlLog";
            this.curlLog.ReadOnly = true;
            this.curlLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.curlLog.Size = new System.Drawing.Size(433, 214);
            this.curlLog.TabIndex = 0;
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(71, 394);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Radius :";
            // 
            // radiusResultLabel
            // 
            this.radiusResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radiusResultLabel.AutoSize = true;
            this.radiusResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiusResultLabel.Location = new System.Drawing.Point(110, 272);
            this.radiusResultLabel.Name = "radiusResultLabel";
            this.radiusResultLabel.Size = new System.Drawing.Size(102, 25);
            this.radiusResultLabel.TabIndex = 3;
            this.radiusResultLabel.Text = "Waiting...";
            // 
            // staticStatusLabel
            // 
            this.staticStatusLabel.AutoSize = true;
            this.staticStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staticStatusLabel.Location = new System.Drawing.Point(13, 346);
            this.staticStatusLabel.Name = "staticStatusLabel";
            this.staticStatusLabel.Size = new System.Drawing.Size(133, 25);
            this.staticStatusLabel.TabIndex = 6;
            this.staticStatusLabel.Text = "Test Status :";
            // 
            // statusResultLabel
            // 
            this.statusResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusResultLabel.Location = new System.Drawing.Point(152, 346);
            this.statusResultLabel.Name = "statusResultLabel";
            this.statusResultLabel.Size = new System.Drawing.Size(183, 25);
            this.statusResultLabel.TabIndex = 7;
            this.statusResultLabel.Text = "Waiting...";
            this.statusResultLabel.TextChanged += new System.EventHandler(this.statusResultLabel_TextChanged);
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(260, 394);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 8;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Visible = false;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingCircleToolStripMenuItem1,
            this.curlStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(458, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loadingCircleToolStripMenuItem1
            // 
            // 
            // loadingCircleToolStripMenuItem1
            // 
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.AccessibleName = "loadingCircleToolStripMenuItem1";
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Active = false;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Color = System.Drawing.Color.DarkGray;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.InnerCircleRadius = 5;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Location = new System.Drawing.Point(1, 2);
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Name = "loadingCircleToolStripMenuItem1";
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.NumberSpoke = 12;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.OuterCircleRadius = 11;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.RotationSpeed = 100;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Size = new System.Drawing.Size(26, 20);
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.SpokeThickness = 2;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.TabIndex = 1;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Text = "loadingCircleToolStripMenuItem1";
            this.loadingCircleToolStripMenuItem1.Name = "loadingCircleToolStripMenuItem1";
            this.loadingCircleToolStripMenuItem1.Size = new System.Drawing.Size(26, 20);
            this.loadingCircleToolStripMenuItem1.Text = "loadingCircleToolStripMenuItem1";
            // 
            // curlStatusLabel
            // 
            this.curlStatusLabel.Name = "curlStatusLabel";
            this.curlStatusLabel.Size = new System.Drawing.Size(126, 17);
            this.curlStatusLabel.Text = "Waiting for curl results";
            // 
            // radiusEntryTextbox
            // 
            this.radiusEntryTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiusEntryTextbox.Location = new System.Drawing.Point(110, 269);
            this.radiusEntryTextbox.Name = "radiusEntryTextbox";
            this.radiusEntryTextbox.Size = new System.Drawing.Size(100, 31);
            this.radiusEntryTextbox.TabIndex = 10;
            this.radiusEntryTextbox.Visible = false;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(167, 394);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Visible = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // CURL
            // 
            this.AcceptButton = this.yesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 443);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.statusResultLabel);
            this.Controls.Add(this.staticStatusLabel);
            this.Controls.Add(this.radiusResultLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.curlLog);
            this.Controls.Add(this.radiusEntryTextbox);
            this.Name = "CURL";
            this.Text = "CURL";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox curlLog;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label radiusResultLabel;
        private System.Windows.Forms.Label staticStatusLabel;
        private System.Windows.Forms.Label statusResultLabel;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel curlStatusLabel;
        private MRG.Controls.UI.LoadingCircleToolStripMenuItem loadingCircleToolStripMenuItem1;
        private System.Windows.Forms.TextBox radiusEntryTextbox;
        private System.Windows.Forms.Button okButton;
    }
}