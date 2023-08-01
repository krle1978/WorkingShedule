namespace WorkingShedule.Data
{
    partial class DialogWindow
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
            this.btnOK = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tbPathView = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnOK.Font = new System.Drawing.Font("HP Simplified Hans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOK.Location = new System.Drawing.Point(159, 149);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 43);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel.Controls.Add(this.lblInfo);
            this.panel.Controls.Add(this.tbPathView);
            this.panel.Controls.Add(this.btnOK);
            this.panel.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel.Location = new System.Drawing.Point(17, 13);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(411, 237);
            this.panel.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(39, 37);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(50, 19);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label1";
            // 
            // tbPathView
            // 
            this.tbPathView.Location = new System.Drawing.Point(39, 73);
            this.tbPathView.Name = "tbPathView";
            this.tbPathView.Size = new System.Drawing.Size(314, 26);
            this.tbPathView.TabIndex = 1;
            // 
            // DialogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 266);
            this.Controls.Add(this.panel);
            this.Name = "DialogWindow";
            this.Text = "DialogWindow";
            this.Load += new System.EventHandler(this.DialogWindow_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnOK;
        private Panel panel;
        private Label lblInfo;
        private TextBox tbPathView;
    }
}