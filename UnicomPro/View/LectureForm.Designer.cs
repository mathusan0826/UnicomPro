namespace UnicomPro.View
{
    partial class LectureForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtLectureName = new System.Windows.Forms.TextBox();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.dataGridViewLectures = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLectures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lecture Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select course";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(153, 259);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Lecture";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(351, 259);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update Lecture";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(519, 259);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Lecture";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtLectureName
            // 
            this.txtLectureName.Location = new System.Drawing.Point(519, 170);
            this.txtLectureName.Name = "txtLectureName";
            this.txtLectureName.Size = new System.Drawing.Size(121, 22);
            this.txtLectureName.TabIndex = 5;
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(519, 201);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCourse.TabIndex = 6;
            // 
            // dataGridViewLectures
            // 
            this.dataGridViewLectures.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewLectures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLectures.Location = new System.Drawing.Point(153, 312);
            this.dataGridViewLectures.Name = "dataGridViewLectures";
            this.dataGridViewLectures.RowHeadersWidth = 51;
            this.dataGridViewLectures.RowTemplate.Height = 24;
            this.dataGridViewLectures.Size = new System.Drawing.Size(488, 243);
            this.dataGridViewLectures.TabIndex = 7;
            this.dataGridViewLectures.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLectures_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UnicomPro.Properties.Resources.lecture;
            this.pictureBox1.Location = new System.Drawing.Point(128, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 227);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // LectureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewLectures);
            this.Controls.Add(this.comboBoxCourse);
            this.Controls.Add(this.txtLectureName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LectureForm";
            this.Text = "LectureForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLectures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtLectureName;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.DataGridView dataGridViewLectures;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}