namespace WorkingShedule
{
    partial class EditWorker
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblWorkingHours = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.numWorkHours = new System.Windows.Forms.NumericUpDown();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewWorker = new System.Windows.Forms.Button();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkHours)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.Wheat;
            this.pnlInfo.Controls.Add(this.lblWorkingHours);
            this.pnlInfo.Controls.Add(this.lblName);
            this.pnlInfo.Controls.Add(this.numWorkHours);
            this.pnlInfo.Controls.Add(this.tbName);
            this.pnlInfo.Font = new System.Drawing.Font("HP Simplified Hans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlInfo.Location = new System.Drawing.Point(12, 21);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(251, 266);
            this.pnlInfo.TabIndex = 0;
            // 
            // lblWorkingHours
            // 
            this.lblWorkingHours.AutoSize = true;
            this.lblWorkingHours.Location = new System.Drawing.Point(10, 87);
            this.lblWorkingHours.Name = "lblWorkingHours";
            this.lblWorkingHours.Size = new System.Drawing.Size(111, 18);
            this.lblWorkingHours.TabIndex = 3;
            this.lblWorkingHours.Text = "WorkingHours:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 18);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // numWorkHours
            // 
            this.numWorkHours.Location = new System.Drawing.Point(160, 79);
            this.numWorkHours.Name = "numWorkHours";
            this.numWorkHours.Size = new System.Drawing.Size(69, 26);
            this.numWorkHours.TabIndex = 1;
            this.numWorkHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(85, 24);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(144, 26);
            this.tbName.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Olive;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Location = new System.Drawing.Point(14, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 45);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnChange.Location = new System.Drawing.Point(14, 9);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 45);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "Ändern";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Khaki;
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnNewWorker);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnChange);
            this.pnlButtons.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlButtons.Location = new System.Drawing.Point(274, 24);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(114, 262);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.Location = new System.Drawing.Point(14, 111);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 45);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Löschen Arb.";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNewWorker
            // 
            this.btnNewWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNewWorker.Location = new System.Drawing.Point(14, 60);
            this.btnNewWorker.Name = "btnNewWorker";
            this.btnNewWorker.Size = new System.Drawing.Size(75, 45);
            this.btnNewWorker.TabIndex = 6;
            this.btnNewWorker.Text = "Neue Arb.";
            this.btnNewWorker.UseVisualStyleBackColor = false;
            this.btnNewWorker.Click += new System.EventHandler(this.btnNewWorker_Click);
            // 
            // EditWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 328);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlInfo);
            this.Name = "EditWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditWorker";
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkHours)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlInfo;
        private Button btnCancel;
        private Button btnChange;
        private Label lblWorkingHours;
        private Label lblName;
        private NumericUpDown numWorkHours;
        private TextBox tbName;
        private Panel pnlButtons;
        private Button btnDelete;
        private Button btnNewWorker;
    }
}