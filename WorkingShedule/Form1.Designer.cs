using WorkingShedule.Data;

namespace WorkingShedule
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbName = new System.Windows.Forms.ComboBox();
            this.cbPosition = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnShowTabelle = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chckBxViewTab = new System.Windows.Forms.CheckBox();
            this.tbRestHours = new System.Windows.Forms.TextBox();
            this.tbDayHours = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cbDays = new System.Windows.Forms.ComboBox();
            this.cbWorkHours = new System.Windows.Forms.ComboBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.TCEmployee = new System.Windows.Forms.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbFour = new System.Windows.Forms.RadioButton();
            this.rbTree = new System.Windows.Forms.RadioButton();
            this.rbTwo = new System.Windows.Forms.RadioButton();
            this.rbOne = new System.Windows.Forms.RadioButton();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.lwTabelle = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.btnCloseTabelle = new System.Windows.Forms.Button();
            this.btnOpenEXCEL = new System.Windows.Forms.Button();
            this.lblDatum = new System.Windows.Forms.Label();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewWorker = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.lblWorkingHours = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numWorkHours = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkHours)).BeginInit();
            this.SuspendLayout();
            // 
            // cbName
            // 
            this.cbName.DisplayMember = "Name";
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(6, 29);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(206, 26);
            this.cbName.TabIndex = 0;
            this.cbName.ValueMember = "Name";
            this.cbName.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            // 
            // cbPosition
            // 
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.Items.AddRange(new object[] {
            "Bäcker 02:00 - 8:00",
            "Imbis 03:00 - 10:30",
            "Schicht 1 05:00 - 13:00",
            "Schicht 2 11:00 - 16:30",
            "Schicht 3 14:00 - 20:30",
            "Schicht 31 15:00 - 20:30",
            "x",
            "Urlaub"});
            this.cbPosition.Location = new System.Drawing.Point(6, 140);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(206, 26);
            this.cbPosition.TabIndex = 1;
            this.cbPosition.SelectedIndexChanged += new System.EventHandler(this.cbPosition_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Wheat;
            this.panel1.Controls.Add(this.btnOptions);
            this.panel1.Controls.Add(this.btnShowTabelle);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.chckBxViewTab);
            this.panel1.Controls.Add(this.tbRestHours);
            this.panel1.Controls.Add(this.tbDayHours);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lblDays);
            this.panel1.Controls.Add(this.lblPosition);
            this.panel1.Controls.Add(this.lblHours);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.cbDays);
            this.panel1.Controls.Add(this.cbWorkHours);
            this.panel1.Controls.Add(this.cbName);
            this.panel1.Controls.Add(this.cbPosition);
            this.panel1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 300);
            this.panel1.TabIndex = 3;
            // 
            // btnOptions
            // 
            this.btnOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOptions.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOptions.Location = new System.Drawing.Point(96, 215);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(68, 33);
            this.btnOptions.TabIndex = 20;
            this.btnOptions.Text = "&Options";
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnShowTabelle
            // 
            this.btnShowTabelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnShowTabelle.Enabled = false;
            this.btnShowTabelle.Font = new System.Drawing.Font("HP Simplified Hans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowTabelle.Location = new System.Drawing.Point(184, 212);
            this.btnShowTabelle.Name = "btnShowTabelle";
            this.btnShowTabelle.Size = new System.Drawing.Size(93, 36);
            this.btnShowTabelle.TabIndex = 19;
            this.btnShowTabelle.Text = "&Tabele =>>";
            this.btnShowTabelle.UseVisualStyleBackColor = false;
            this.btnShowTabelle.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEdit.Font = new System.Drawing.Font("HP Simplified", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEdit.Location = new System.Drawing.Point(75, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(50, 20);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(80, 257);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 36);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "&Schließung";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chckBxViewTab
            // 
            this.chckBxViewTab.AutoSize = true;
            this.chckBxViewTab.Location = new System.Drawing.Point(6, 175);
            this.chckBxViewTab.Name = "chckBxViewTab";
            this.chckBxViewTab.Size = new System.Drawing.Size(118, 22);
            this.chckBxViewTab.TabIndex = 16;
            this.chckBxViewTab.Text = "View Tabelle";
            this.chckBxViewTab.UseVisualStyleBackColor = true;
            this.chckBxViewTab.Visible = false;
            // 
            // tbRestHours
            // 
            this.tbRestHours.Enabled = false;
            this.tbRestHours.Location = new System.Drawing.Point(220, 140);
            this.tbRestHours.Name = "tbRestHours";
            this.tbRestHours.Size = new System.Drawing.Size(57, 26);
            this.tbRestHours.TabIndex = 15;
            // 
            // tbDayHours
            // 
            this.tbDayHours.Enabled = false;
            this.tbDayHours.Location = new System.Drawing.Point(220, 82);
            this.tbDayHours.Name = "tbDayHours";
            this.tbDayHours.Size = new System.Drawing.Size(57, 26);
            this.tbDayHours.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Arb. Std:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Rest Stnd:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.Font = new System.Drawing.Font("HP Simplified Hans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.Location = new System.Drawing.Point(5, 212);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 36);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(10, 60);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(40, 18);
            this.lblDays.TabIndex = 9;
            this.lblDays.Text = "Tag:";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(6, 117);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(69, 18);
            this.lblPosition.TabIndex = 8;
            this.lblPosition.Text = "Position:";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(195, 8);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(79, 18);
            this.lblHours.TabIndex = 7;
            this.lblHours.Text = "Std/Wche";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 18);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Arbeiter";
            // 
            // cbDays
            // 
            this.cbDays.FormattingEnabled = true;
            this.cbDays.Items.AddRange(new object[] {
            "Montag",
            "Dinstag",
            "Mitwoch",
            "Donerstag",
            "Freitag",
            "Samstag",
            "Sontag"});
            this.cbDays.Location = new System.Drawing.Point(6, 83);
            this.cbDays.Name = "cbDays";
            this.cbDays.Size = new System.Drawing.Size(206, 26);
            this.cbDays.TabIndex = 5;
            // 
            // cbWorkHours
            // 
            this.cbWorkHours.FormattingEnabled = true;
            this.cbWorkHours.Items.AddRange(new object[] {
            "15",
            "20",
            "25",
            "30",
            "39",
            "40"});
            this.cbWorkHours.Location = new System.Drawing.Point(218, 29);
            this.cbWorkHours.Name = "cbWorkHours";
            this.cbWorkHours.Size = new System.Drawing.Size(59, 26);
            this.cbWorkHours.TabIndex = 4;
            this.cbWorkHours.SelectedIndexChanged += new System.EventHandler(this.cbWorkHours_SelectedIndexChanged);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.OldLace;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRight.Controls.Add(this.TCEmployee);
            this.panelRight.Controls.Add(this.panel2);
            this.panelRight.Controls.Add(this.monthCalendar);
            this.panelRight.Controls.Add(this.lwTabelle);
            this.panelRight.Controls.Add(this.listView2);
            this.panelRight.Controls.Add(this.btnCloseTabelle);
            this.panelRight.Controls.Add(this.btnOpenEXCEL);
            this.panelRight.Controls.Add(this.lblDatum);
            this.panelRight.Font = new System.Drawing.Font("HP Simplified Jpan", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelRight.Location = new System.Drawing.Point(326, 38);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1200, 512);
            this.panelRight.TabIndex = 5;
            // 
            // TCEmployee
            // 
            this.TCEmployee.CausesValidation = false;
            this.TCEmployee.Location = new System.Drawing.Point(874, 339);
            this.TCEmployee.Name = "TCEmployee";
            this.TCEmployee.SelectedIndex = 0;
            this.TCEmployee.Size = new System.Drawing.Size(303, 158);
            this.TCEmployee.TabIndex = 6;
            this.TCEmployee.Visible = false;
            this.TCEmployee.SelectedIndexChanged += new System.EventHandler(this.TCEmployee_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.rbFour);
            this.panel2.Controls.Add(this.rbTree);
            this.panel2.Controls.Add(this.rbTwo);
            this.panel2.Controls.Add(this.rbOne);
            this.panel2.Location = new System.Drawing.Point(127, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 30);
            this.panel2.TabIndex = 25;
            // 
            // rbFour
            // 
            this.rbFour.AutoSize = true;
            this.rbFour.Location = new System.Drawing.Point(194, 4);
            this.rbFour.Name = "rbFour";
            this.rbFour.Size = new System.Drawing.Size(49, 23);
            this.rbFour.TabIndex = 3;
            this.rbFour.TabStop = true;
            this.rbFour.Text = "4/4";
            this.rbFour.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbFour.UseVisualStyleBackColor = true;
            this.rbFour.CheckedChanged += new System.EventHandler(this.rbFour_CheckedChanged_1);
            // 
            // rbTree
            // 
            this.rbTree.AutoSize = true;
            this.rbTree.Location = new System.Drawing.Point(129, 4);
            this.rbTree.Name = "rbTree";
            this.rbTree.Size = new System.Drawing.Size(49, 23);
            this.rbTree.TabIndex = 2;
            this.rbTree.TabStop = true;
            this.rbTree.Text = "3/4";
            this.rbTree.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbTree.UseVisualStyleBackColor = true;
            this.rbTree.CheckedChanged += new System.EventHandler(this.rbTree_CheckedChanged_1);
            // 
            // rbTwo
            // 
            this.rbTwo.AutoSize = true;
            this.rbTwo.Location = new System.Drawing.Point(76, 4);
            this.rbTwo.Name = "rbTwo";
            this.rbTwo.Size = new System.Drawing.Size(49, 23);
            this.rbTwo.TabIndex = 1;
            this.rbTwo.TabStop = true;
            this.rbTwo.Text = "2/4";
            this.rbTwo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbTwo.UseVisualStyleBackColor = true;
            this.rbTwo.CheckedChanged += new System.EventHandler(this.rbTwo_CheckedChanged);
            // 
            // rbOne
            // 
            this.rbOne.AutoSize = true;
            this.rbOne.Checked = true;
            this.rbOne.Location = new System.Drawing.Point(5, 3);
            this.rbOne.Name = "rbOne";
            this.rbOne.Size = new System.Drawing.Size(49, 23);
            this.rbOne.TabIndex = 0;
            this.rbOne.TabStop = true;
            this.rbOne.Text = "1/4";
            this.rbOne.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbOne.UseVisualStyleBackColor = true;
            this.rbOne.CheckedChanged += new System.EventHandler(this.rbOne_CheckedChanged);
            // 
            // monthCalendar
            // 
            this.monthCalendar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.monthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.monthCalendar.ForeColor = System.Drawing.Color.YellowGreen;
            this.monthCalendar.Location = new System.Drawing.Point(35, 339);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 6;
            // 
            // lwTabelle
            // 
            this.lwTabelle.GridLines = true;
            this.lwTabelle.Location = new System.Drawing.Point(29, 58);
            this.lwTabelle.Name = "lwTabelle";
            this.lwTabelle.Size = new System.Drawing.Size(1148, 268);
            this.lwTabelle.TabIndex = 4;
            this.lwTabelle.UseCompatibleStateImageBehavior = false;
            this.lwTabelle.View = System.Windows.Forms.View.Details;
            // 
            // listView2
            // 
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(13, 766);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1148, 223);
            this.listView2.TabIndex = 23;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // btnCloseTabelle
            // 
            this.btnCloseTabelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCloseTabelle.Font = new System.Drawing.Font("HP Simplified Hans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCloseTabelle.Location = new System.Drawing.Point(13, 7);
            this.btnCloseTabelle.Name = "btnCloseTabelle";
            this.btnCloseTabelle.Size = new System.Drawing.Size(93, 36);
            this.btnCloseTabelle.TabIndex = 20;
            this.btnCloseTabelle.Text = "<<=Tabele";
            this.btnCloseTabelle.UseVisualStyleBackColor = false;
            this.btnCloseTabelle.Click += new System.EventHandler(this.btnCloseTabelle_Click);
            // 
            // btnOpenEXCEL
            // 
            this.btnOpenEXCEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnOpenEXCEL.Location = new System.Drawing.Point(398, 13);
            this.btnOpenEXCEL.Name = "btnOpenEXCEL";
            this.btnOpenEXCEL.Size = new System.Drawing.Size(94, 32);
            this.btnOpenEXCEL.TabIndex = 6;
            this.btnOpenEXCEL.Text = "Open EXCEL";
            this.btnOpenEXCEL.UseVisualStyleBackColor = false;
            this.btnOpenEXCEL.Click += new System.EventHandler(this.btnOpenEXCEL_Click);
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(20, 4);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(50, 19);
            this.lblDatum.TabIndex = 5;
            this.lblDatum.Text = "Datum";
            this.lblDatum.Visible = false;
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.Wheat;
            this.pnlOptions.Controls.Add(this.pnlButtons);
            this.pnlOptions.Controls.Add(this.lblWorkingHours);
            this.pnlOptions.Controls.Add(this.tbName);
            this.pnlOptions.Controls.Add(this.label3);
            this.pnlOptions.Controls.Add(this.numWorkHours);
            this.pnlOptions.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlOptions.Location = new System.Drawing.Point(13, 344);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(302, 206);
            this.pnlOptions.TabIndex = 6;
            this.pnlOptions.Visible = false;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Khaki;
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnNewWorker);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnChange);
            this.pnlButtons.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlButtons.Location = new System.Drawing.Point(17, 121);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(259, 69);
            this.pnlButtons.TabIndex = 11;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.Location = new System.Drawing.Point(176, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 45);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "&Löschen Arb.";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNewWorker
            // 
            this.btnNewWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNewWorker.Location = new System.Drawing.Point(95, 10);
            this.btnNewWorker.Name = "btnNewWorker";
            this.btnNewWorker.Size = new System.Drawing.Size(75, 45);
            this.btnNewWorker.TabIndex = 6;
            this.btnNewWorker.Text = "&Neue Arb.";
            this.btnNewWorker.UseVisualStyleBackColor = false;
            this.btnNewWorker.Click += new System.EventHandler(this.btnNewWorker_Click);
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
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnChange.Location = new System.Drawing.Point(14, 9);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 45);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "Ä&ndern";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lblWorkingHours
            // 
            this.lblWorkingHours.AutoSize = true;
            this.lblWorkingHours.Location = new System.Drawing.Point(31, 79);
            this.lblWorkingHours.Name = "lblWorkingHours";
            this.lblWorkingHours.Size = new System.Drawing.Size(116, 18);
            this.lblWorkingHours.TabIndex = 10;
            this.lblWorkingHours.Text = "WorkingHours:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(105, 36);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(144, 26);
            this.tbName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name:";
            // 
            // numWorkHours
            // 
            this.numWorkHours.Location = new System.Drawing.Point(181, 71);
            this.numWorkHours.Name = "numWorkHours";
            this.numWorkHours.Size = new System.Drawing.Size(69, 26);
            this.numWorkHours.TabIndex = 8;
            this.numWorkHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1553, 572);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schicht Liste Ordner";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWorkHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cbName;
        private ComboBox cbPosition;
        private Panel panel1;
        private Label lblDays;
        private Label lblPosition;
        private Label lblHours;
        private Label lblName;
        private ComboBox cbDays;
        private ComboBox cbWorkHours;
        private Button btnAdd;
        private Label label1;
        private Label label2;
        private TextBox tbRestHours;
        private TextBox tbDayHours;
        private CheckBox chckBxViewTab;
        private Panel panelRight;
        private Label lblDatum;
        private Button btnClose;
        private Button btnEdit;
        private Button btnShowTabelle;
        private Button btnOpenEXCEL;
        private Button btnCloseTabelle;
        private ListView listView2;
        private Panel panel2;
        private RadioButton rbFour;
        private RadioButton rbTree;
        private RadioButton rbTwo;
        private RadioButton rbOne;
        private Panel pnlOptions;
        private Label lblWorkingHours;
        private TextBox tbName;
        private Label label3;
        private NumericUpDown numWorkHours;
        private Button btnOptions;
        private Panel pnlButtons;
        private Button btnDelete;
        private Button btnNewWorker;
        private Button btnCancel;
        private Button btnChange;
        private TabControl TCEmployee;
        private MonthCalendar monthCalendar;
        private ListView lwTabelle;
    }
}