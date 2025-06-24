namespace UnicomPro.View
{
    partial class ExamForm
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
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.btnUpdateExam = new System.Windows.Forms.Button();
            this.btnDeleteExam = new System.Windows.Forms.Button();
            this.dataGridViewExams = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exam";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(531, 182);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(244, 22);
            this.txtExamName.TabIndex = 1;
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(462, 236);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(80, 26);
            this.btnAddExam.TabIndex = 2;
            this.btnAddExam.Text = "Add";
            this.btnAddExam.UseVisualStyleBackColor = true;
            this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);
            // 
            // btnUpdateExam
            // 
            this.btnUpdateExam.Location = new System.Drawing.Point(577, 236);
            this.btnUpdateExam.Name = "btnUpdateExam";
            this.btnUpdateExam.Size = new System.Drawing.Size(77, 26);
            this.btnUpdateExam.TabIndex = 3;
            this.btnUpdateExam.Text = "Update";
            this.btnUpdateExam.UseVisualStyleBackColor = true;
            this.btnUpdateExam.Click += new System.EventHandler(this.btnUpdateExam_Click);
            // 
            // btnDeleteExam
            // 
            this.btnDeleteExam.Location = new System.Drawing.Point(688, 236);
            this.btnDeleteExam.Name = "btnDeleteExam";
            this.btnDeleteExam.Size = new System.Drawing.Size(87, 26);
            this.btnDeleteExam.TabIndex = 4;
            this.btnDeleteExam.Text = "Delete";
            this.btnDeleteExam.UseVisualStyleBackColor = true;
            this.btnDeleteExam.Click += new System.EventHandler(this.btnDeleteExam_Click);
            // 
            // dataGridViewExams
            // 
            this.dataGridViewExams.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExams.Location = new System.Drawing.Point(101, 297);
            this.dataGridViewExams.Name = "dataGridViewExams";
            this.dataGridViewExams.RowHeadersWidth = 51;
            this.dataGridViewExams.RowTemplate.Height = 24;
            this.dataGridViewExams.Size = new System.Drawing.Size(683, 225);
            this.dataGridViewExams.TabIndex = 5;
            this.dataGridViewExams.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExams_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UnicomPro.Properties.Resources.Exam;
            this.pictureBox1.Location = new System.Drawing.Point(119, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // ExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(842, 534);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewExams);
            this.Controls.Add(this.btnDeleteExam);
            this.Controls.Add(this.btnUpdateExam);
            this.Controls.Add(this.btnAddExam);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ExamForm";
            this.Text = "ExamForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.Button btnAddExam;
        private System.Windows.Forms.Button btnUpdateExam;
        private System.Windows.Forms.Button btnDeleteExam;
        private System.Windows.Forms.DataGridView dataGridViewExams;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}