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
            dataGridView1.Location = new Point(101, 49);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.Size = new Size(678, 181);
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
            button1.Location = new Point(371, 546);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(136, 56);
            button1.TabIndex = 7;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // StudentAnalyticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 622);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "StudentAnalyticsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassSmart";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
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
    }
}