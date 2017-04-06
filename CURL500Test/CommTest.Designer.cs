namespace CURL500Test
{
    partial class CommTest
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
            this.tb = new System.Windows.Forms.TextBox();
            this.command = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.measureBtn = new System.Windows.Forms.Button();
            this.readResultBtn = new System.Windows.Forms.Button();
            this.statusBtn = new System.Windows.Forms.Button();
            this.openPortBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(13, 13);
            this.tb.Multiline = true;
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(360, 257);
            this.tb.TabIndex = 0;
            // 
            // command
            // 
            this.command.Location = new System.Drawing.Point(13, 292);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(100, 20);
            this.command.TabIndex = 1;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(119, 292);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 2;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // measureBtn
            // 
            this.measureBtn.Location = new System.Drawing.Point(118, 335);
            this.measureBtn.Name = "measureBtn";
            this.measureBtn.Size = new System.Drawing.Size(75, 23);
            this.measureBtn.TabIndex = 4;
            this.measureBtn.Text = "Measure";
            this.measureBtn.UseVisualStyleBackColor = true;
            this.measureBtn.Click += new System.EventHandler(this.measureBtn_Click);
            // 
            // readResultBtn
            // 
            this.readResultBtn.Location = new System.Drawing.Point(220, 335);
            this.readResultBtn.Name = "readResultBtn";
            this.readResultBtn.Size = new System.Drawing.Size(75, 23);
            this.readResultBtn.TabIndex = 5;
            this.readResultBtn.Text = "Read Result";
            this.readResultBtn.UseVisualStyleBackColor = true;
            this.readResultBtn.Click += new System.EventHandler(this.readResultBtn_Click);
            // 
            // statusBtn
            // 
            this.statusBtn.Location = new System.Drawing.Point(12, 335);
            this.statusBtn.Name = "statusBtn";
            this.statusBtn.Size = new System.Drawing.Size(75, 23);
            this.statusBtn.TabIndex = 6;
            this.statusBtn.Text = "Status";
            this.statusBtn.UseVisualStyleBackColor = true;
            this.statusBtn.Click += new System.EventHandler(this.statusBtn_Click);
            // 
            // openPortBtn
            // 
            this.openPortBtn.Location = new System.Drawing.Point(298, 292);
            this.openPortBtn.Name = "openPortBtn";
            this.openPortBtn.Size = new System.Drawing.Size(75, 23);
            this.openPortBtn.TabIndex = 7;
            this.openPortBtn.Text = "Open Port";
            this.openPortBtn.UseVisualStyleBackColor = true;
            this.openPortBtn.Click += new System.EventHandler(this.openPortBtn_Click);
            // 
            // CommTest
            // 
            this.AcceptButton = this.sendBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 435);
            this.Controls.Add(this.openPortBtn);
            this.Controls.Add(this.statusBtn);
            this.Controls.Add(this.readResultBtn);
            this.Controls.Add(this.measureBtn);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.command);
            this.Controls.Add(this.tb);
            this.Name = "CommTest";
            this.Text = "CommTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.TextBox command;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Button measureBtn;
        private System.Windows.Forms.Button readResultBtn;
        private System.Windows.Forms.Button statusBtn;
        private System.Windows.Forms.Button openPortBtn;
    }
}