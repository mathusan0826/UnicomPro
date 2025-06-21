namespace UnicomPro.View
{
    partial class AttendanceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadStudents = new System.Windows.Forms.Button();
            this.btnSaveAttendance = new System.Windows.Forms.Button();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject selection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pick attendance date";
            // 
            // btnLoadStudents
            // 
            this.btnLoadStudents.Location = new System.Drawing.Point(187, 114);
            this.btnLoadStudents.Name = "btnLoadStudents";
            this.btnLoadStudents.Size = new System.Drawing.Size(180, 27);
            this.btnLoadStudents.TabIndex = 2;
            this.btnLoadStudents.Text = "Load students into grid";
            this.btnLoadStudents.UseVisualStyleBackColor = true;
            this.btnLoadStudents.Click += new System.EventHandler(this.btnLoadStudents_Click);
            // 
            // btnSaveAttendance
            // 
            this.btnSaveAttendance.Location = new System.Drawing.Point(412, 114);
            this.btnSaveAttendance.Name = "btnSaveAttendance";
            this.btnSaveAttendance.Size = new System.Drawing.Size(197, 27);
            this.btnSaveAttendance.TabIndex = 3;
            this.btnSaveAttendance.Text = "Save attendance records";
            this.btnSaveAttendance.UseVisualStyleBackColor = true;
            this.btnSaveAttendance.Click += new System.EventHandler(this.btnSaveAttendance_Click);
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Location = new System.Drawing.Point(16, 171);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.RowHeadersWidth = 51;
            this.dgvAttendance.RowTemplate.Height = 24;
            this.dgvAttendance.Size = new System.Drawing.Size(764, 269);
            this.dgvAttendance.TabIndex = 4;
            this.dgvAttendance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttendance_CellContentClick);
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(375, 12);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(234, 24);
            this.cmbSubject.TabIndex = 5;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(375, 55);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(234, 22);
            this.datePicker.TabIndex = 6;
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.btnSaveAttendance);
            this.Controls.Add(this.btnLoadStudents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AttendanceForm";
            this.Text = "AttendanceForm";
            this.Load += new System.EventHandler(this.AttendanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadStudents;
        private System.Windows.Forms.Button btnSaveAttendance;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.DateTimePicker datePicker;
    }
}