namespace ClassSmart.Forms.Main
{
    partial class StudentAnalyticsForm
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
            Quiz = new DataGridViewTextBoxColumn();
            TotalMark = new DataGridViewTextBoxColumn();
            PercentageMark = new DataGridViewTextBoxColumn();
            ClassMarkAverage = new DataGridViewTextBoxColumn();
            ClassPercentageAverage = new DataGridViewTextBoxColumn();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Quiz
            // 
            Quiz.HeaderText = "Quiz";
            Quiz.MinimumWidth = 6;
            Quiz.Name = "Quiz";
            Quiz.Width = 125;
            // 
            // TotalMark
            // 
            TotalMark.HeaderText = "Total Mark";
            TotalMark.MinimumWidth = 6;
            TotalMark.Name = "TotalMark";
            TotalMark.Width = 125;
            // 
            // PercentageMark
            // 
            PercentageMark.HeaderText = "Percentage Mark";
            PercentageMark.MinimumWidth = 6;
            PercentageMark.Name = "PercentageMark";
            PercentageMark.Width = 125;
            // 
            // ClassMarkAverage
            // 
            ClassMarkAverage.HeaderText = "Class Mark Average";
            ClassMarkAverage.MinimumWidth = 6;
            ClassMarkAverage.Name = "ClassMarkAverage";
            ClassMarkAverage.Width = 125;
            // 
            // ClassPercentageAverage
            // 
            ClassPercentageAverage.HeaderText = "Class Percentage Average";
            ClassPercentageAverage.MinimumWidth = 6;
            ClassPercentageAverage.Name = "ClassPercentageAverage";
            ClassPercentageAverage.Width = 125;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Enabled = false;
            dataGridView1.Location = new Point(115, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.Size = new Size(775, 241);
            dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "Quiz Name";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Score";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Percentage";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Average Score";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Average Percentage";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 125;
            // 
            // button1
            // 
            button1.Location = new Point(415, 569);
            button1.Name = "button1";
            button1.Size = new Size(155, 75);
            button1.TabIndex = 3;
            button1.Text = "Return";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(239, 361);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(518, 65);
            progressBar1.TabIndex = 4;
            progressBar1.Click += progressBar1_Click;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(239, 463);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(518, 68);
            progressBar2.TabIndex = 5;
            progressBar2.Click += progressBar2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(433, 440);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 6;
            label1.Text = "Class Total Average";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(447, 338);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 7;
            label2.Text = "Total Average";
            label2.Click += label2_Click;
            // 
            // StudentAnalyticsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 768);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "StudentAnalyticsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassSmart";
            Load += StudentAnalyticsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridViewTextBoxColumn Quiz;
        private DataGridViewTextBoxColumn TotalMark;
        private DataGridViewTextBoxColumn PercentageMark;
        private DataGridViewTextBoxColumn ClassMarkAverage;
        private DataGridViewTextBoxColumn ClassPercentageAverage;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button button1;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label label1;
        private Label label2;
    }
}