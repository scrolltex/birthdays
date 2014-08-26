namespace BirthDayS
{
    partial class MsgForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgForm));
            this.SuperPanel = new System.Windows.Forms.Panel();
            this.copyright = new System.Windows.Forms.LinkLabel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PozgravLabel = new System.Windows.Forms.Label();
            this.SuperPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SuperPanel
            // 
            this.SuperPanel.AutoSize = true;
            this.SuperPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.SuperPanel.Controls.Add(this.copyright);
            this.SuperPanel.Controls.Add(this.NameLabel);
            this.SuperPanel.Controls.Add(this.PozgravLabel);
            this.SuperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuperPanel.Location = new System.Drawing.Point(3, 3);
            this.SuperPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SuperPanel.Name = "SuperPanel";
            this.SuperPanel.Size = new System.Drawing.Size(378, 86);
            this.SuperPanel.TabIndex = 0;
            // 
            // copyright
            // 
            this.copyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyright.AutoSize = true;
            this.copyright.Location = new System.Drawing.Point(318, 73);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(57, 13);
            this.copyright.TabIndex = 2;
            this.copyright.TabStop = true;
            this.copyright.Text = "© scrolltex";
            this.copyright.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.copyright_LinkClicked);
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NameLabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold);
            this.NameLabel.ForeColor = System.Drawing.Color.Blue;
            this.NameLabel.Location = new System.Drawing.Point(0, 33);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.NameLabel.Size = new System.Drawing.Size(378, 53);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Калашников Данил";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PozgravLabel
            // 
            this.PozgravLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PozgravLabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PozgravLabel.ForeColor = System.Drawing.Color.Red;
            this.PozgravLabel.Location = new System.Drawing.Point(0, 0);
            this.PozgravLabel.Margin = new System.Windows.Forms.Padding(5);
            this.PozgravLabel.Name = "PozgravLabel";
            this.PozgravLabel.Padding = new System.Windows.Forms.Padding(5);
            this.PozgravLabel.Size = new System.Drawing.Size(378, 37);
            this.PozgravLabel.TabIndex = 0;
            this.PozgravLabel.Text = "Поздравляем с днем рождения!";
            this.PozgravLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MsgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 92);
            this.Controls.Add(this.SuperPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MsgForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Happy birthday!";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MsgForm_Load);
            this.SuperPanel.ResumeLayout(false);
            this.SuperPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SuperPanel;
        private System.Windows.Forms.Label PozgravLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.LinkLabel copyright;


    }
}