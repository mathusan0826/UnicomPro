namespace UnicomPro.View
{
    partial class MarkForm
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
            this.dataGridViewMarks = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.comboBoxStudent = new System.Windows.Forms.ComboBox();
            this.comboBoxExam = new System.Windows.Forms.ComboBox();
            this.btnAddMark = new System.Windows.Forms.Button();
            this.btnUpdateMark = new System.Windows.Forms.Button();
            this.btnDeleteMark = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMarks
            // 
            this.dataGridViewMarks.AutoSize = true;
            this.dataGridViewMarks.Location = new System.Drawing.Point(261, 228);
            this.dataGridViewMarks.Name = "dataGridViewMarks";
            this.dataGridViewMarks.Size = new System.Drawing.Size(43, 16);
            this.dataGridViewMarks.TabIndex = 0;
            this.dataGridViewMarks.Text = "Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Student";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Exam";
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(343, 228);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(117, 22);
            this.txtScore.TabIndex = 3;
            // 
            // comboBoxStudent
            // 
            this.comboBoxStudent.FormattingEnabled = true;
            this.comboBoxStudent.Location = new System.Drawing.Point(343, 266);
            this.comboBoxStudent.Name = "comboBoxStudent";
            this.comboBoxStudent.Size = new System.Drawing.Size(114, 24);
            this.comboBoxStudent.TabIndex = 4;
            // 
            // comboBoxExam
            // 
            this.comboBoxExam.FormattingEnabled = true;
            this.comboBoxExam.Location = new System.Drawing.Point(343, 305);
            this.comboBoxExam.Name = "comboBoxExam";
            this.comboBoxExam.Size = new System.Drawing.Size(114, 24);
            this.comboBoxExam.TabIndex = 5;
            // 
            // btnAddMark
            // 
            this.btnAddMark.Location = new System.Drawing.Point(146, 354);
            this.btnAddMark.Name = "btnAddMark";
            this.btnAddMark.Size = new System.Drawing.Size(126, 26);
            this.btnAddMark.TabIndex = 6;
            this.btnAddMark.Text = "ExamMark Add";
            this.btnAddMark.UseVisualStyleBackColor = true;
            this.btnAddMark.Click += new System.EventHandler(this.btnAddMark_Click);
            // 
            // btnUpdateMark
            // 
            this.btnUpdateMark.Location = new System.Drawing.Point(343, 354);
            this.btnUpdateMark.Name = "btnUpdateMark";
            this.btnUpdateMark.Size = new System.Drawing.Size(151, 26);
            this.btnUpdateMark.TabIndex = 7;
            this.btnUpdateMark.Text = "ExamMark Update";
            this.btnUpdateMark.UseVisualStyleBackColor = true;
            this.btnUpdateMark.Click += new System.EventHandler(this.btnUpdateMark_Click);
            // 
            // btnDeleteMark
            // 
            this.btnDeleteMark.Location = new System.Drawing.Point(545, 354);
            this.btnDeleteMark.Name = "btnDeleteMark";
            this.btnDeleteMark.Size = new System.Drawing.Size(133, 28);
            this.btnDeleteMark.TabIndex = 8;
            this.btnDeleteMark.Text = "ExamMark Delete";
            this.btnDeleteMark.UseVisualStyleBackColor = true;
            this.btnDeleteMark.Click += new System.EventHandler(this.btnDeleteMark_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(63, 388);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(735, 228);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // MarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(858, 628);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDeleteMark);
            this.Controls.Add(this.btnUpdateMark);
            this.Controls.Add(this.btnAddMark);
            this.Controls.Add(this.comboBoxExam);
            this.Controls.Add(this.comboBoxStudent);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewMarks);
            this.Name = "MarkForm";
            this.Text = "MarkForm";
            this.Load += new System.EventHandler(this.MarkForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dataGridViewMarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.ComboBox comboBoxStudent;
        private System.Windows.Forms.ComboBox comboBoxExam;
        private System.Windows.Forms.Button btnAddMark;
        private System.Windows.Forms.Button btnUpdateMark;
        private System.Windows.Forms.Button btnDeleteMark;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}