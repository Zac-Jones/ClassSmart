using ClassSmart.Model;

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
            label6 = new Label();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            label7 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            cancelBtn = new Button();
            nextQuestionBtn = new Button();
            errorLabel = new Label();
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 177);
            label6.Name = "label6";
            label6.Size = new Size(69, 21);
            label6.TabIndex = 17;
            label6.Text = "Answers";
            // 
            // textBox6
            // 
            textBox6.Enabled = false;
            textBox6.Location = new Point(12, 201);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(240, 23);
            textBox6.TabIndex = 18;
            textBox6.Text = "True";
            textBox6.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            textBox7.Enabled = false;
            textBox7.Location = new Point(12, 230);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(240, 23);
            textBox7.TabIndex = 19;
            textBox7.Text = "False";
            textBox7.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(211, 177);
            label7.Name = "label7";
            label7.Size = new Size(117, 21);
            label7.TabIndex = 28;
            label7.Text = "Correct Answer";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(258, 205);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(14, 13);
            radioButton1.TabIndex = 29;
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(258, 234);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(14, 13);
            radioButton2.TabIndex = 30;
            radioButton2.TabStop = true;
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(122, 385);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(97, 23);
            cancelBtn.TabIndex = 18;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // nextQuestionBtn
            // 
            nextQuestionBtn.Location = new Point(122, 356);
            nextQuestionBtn.Name = "nextQuestionBtn";
            nextQuestionBtn.Size = new Size(97, 23);
            nextQuestionBtn.TabIndex = 19;
            nextQuestionBtn.Text = "Next Question";
            nextQuestionBtn.UseVisualStyleBackColor = true;
            nextQuestionBtn.Click += nextQuestionBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(12, 411);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(316, 23);
            errorLabel.TabIndex = 20;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // QuizCreateQuestionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 450);
            Controls.Add(errorLabel);
            Controls.Add(nextQuestionBtn);
            Controls.Add(cancelBtn);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(356, 489);
            MinimumSize = new Size(356, 489);
            Name = "QuizCreateQuestionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassSmart";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Models.Quiz quiz;
        private TeacherDashboardForm teacherDashboardForm;
        private Teacher teacher;
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
        private Label label6;
        private TextBox textBox6;
        private TextBox textBox7;
        private Label label7;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button cancelBtn;
        private Button nextQuestionBtn;
        private Label errorLabel;
        private int numOfQuestions;
    }
}