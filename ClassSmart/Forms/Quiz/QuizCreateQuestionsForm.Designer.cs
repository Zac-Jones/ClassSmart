namespace ClassSmart.Forms.Quiz
{
    partial class QuizCreateQuestionsForm
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
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            label5 = new Label();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(340, 50);
            label1.TabIndex = 12;
            label1.Text = "SampleHeader";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 50);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 14;
            label2.Text = "Question Type";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 74);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(240, 23);
            comboBox1.TabIndex = 16;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 201);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 23);
            textBox1.TabIndex = 21;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 230);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(240, 23);
            textBox2.TabIndex = 22;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 259);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(240, 23);
            textBox3.TabIndex = 24;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 288);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(240, 23);
            textBox4.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 177);
            label3.Name = "label3";
            label3.Size = new Size(69, 21);
            label3.TabIndex = 27;
            label3.Text = "Answers";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(200, 177);
            label4.Name = "label4";
            label4.Size = new Size(134, 21);
            label4.TabIndex = 28;
            label4.Text = "Correct Answer(s)";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(258, 205);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 29;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(258, 234);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 30;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(258, 263);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(15, 14);
            checkBox3.TabIndex = 31;
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(258, 292);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(15, 14);
            checkBox4.TabIndex = 32;
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(12, 113);
            label5.Name = "label5";
            label5.Size = new Size(73, 21);
            label5.TabIndex = 34;
            label5.Text = "Question";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(12, 137);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(240, 23);
            textBox5.TabIndex = 33;
            // 
            // QuizCreateQuestionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 450);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(356, 489);
            MinimumSize = new Size(356, 489);
            Name = "QuizCreateQuestionsForm";
            Text = "ClassSmart";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Models.Quiz quiz;
        private TeacherDashboardForm teacherDashboardForm;
        private QuizCreateMainForm quizCreateMainForm;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label3;
        private Label label4;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Label label5;
        private TextBox textBox5;
        private int questionNumber = 1;
    }
}