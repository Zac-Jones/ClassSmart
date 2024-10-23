using ClassSmart.Models;

namespace ClassSmart.Forms
{
    partial class QuizAttemptForm
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
            mainLabel = new Label();
            questionNumberLabel = new Label();
            questionBackground = new Label();
            questionLabel = new Label();
            progressBar1 = new ProgressBar();
            answerLabel1 = new Label();
            answerLabel2 = new Label();
            answerLabel3 = new Label();
            answerLabel4 = new Label();
            submitQuizBtn = new Button();
            backQuestionBtn = new Button();
            nextQuestionBtn = new Button();
            homeBtn = new Button();
            checkBox1 = new CheckBox();
            label1 = new Label();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.Dock = DockStyle.Top;
            mainLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            mainLabel.Location = new Point(0, 0);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(584, 46);
            mainLabel.TabIndex = 12;
            mainLabel.Text = "Quiz Name";
            mainLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // questionNumberLabel
            // 
            questionNumberLabel.AutoSize = true;
            questionNumberLabel.BackColor = SystemColors.Control;
            questionNumberLabel.Font = new Font("Segoe UI", 12F);
            questionNumberLabel.Location = new Point(63, 75);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(86, 21);
            questionNumberLabel.TabIndex = 30;
            questionNumberLabel.Text = "Question #";
            // 
            // questionBackground
            // 
            questionBackground.BackColor = SystemColors.ControlLight;
            questionBackground.BorderStyle = BorderStyle.FixedSingle;
            questionBackground.Font = new Font("Segoe UI", 12F);
            questionBackground.Location = new Point(63, 96);
            questionBackground.Name = "questionBackground";
            questionBackground.Size = new Size(459, 214);
            questionBackground.TabIndex = 31;
            // 
            // questionLabel
            // 
            questionLabel.AutoSize = true;
            questionLabel.BackColor = SystemColors.ControlLight;
            questionLabel.Font = new Font("Segoe UI", 12F);
            questionLabel.Location = new Point(79, 112);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(73, 21);
            questionLabel.TabIndex = 49;
            questionLabel.Text = "Question";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(63, 51);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(459, 15);
            progressBar1.TabIndex = 52;
            // 
            // answerLabel1
            // 
            answerLabel1.AutoSize = true;
            answerLabel1.BackColor = SystemColors.ControlLight;
            answerLabel1.Font = new Font("Segoe UI", 12F);
            answerLabel1.Location = new Point(79, 154);
            answerLabel1.Name = "answerLabel1";
            answerLabel1.Size = new Size(62, 21);
            answerLabel1.TabIndex = 54;
            answerLabel1.Text = "Answer";
            // 
            // answerLabel2
            // 
            answerLabel2.AutoSize = true;
            answerLabel2.BackColor = SystemColors.ControlLight;
            answerLabel2.Font = new Font("Segoe UI", 12F);
            answerLabel2.Location = new Point(79, 196);
            answerLabel2.Name = "answerLabel2";
            answerLabel2.Size = new Size(62, 21);
            answerLabel2.TabIndex = 56;
            answerLabel2.Text = "Answer";
            // 
            // answerLabel3
            // 
            answerLabel3.AutoSize = true;
            answerLabel3.BackColor = SystemColors.ControlLight;
            answerLabel3.Font = new Font("Segoe UI", 12F);
            answerLabel3.Location = new Point(79, 238);
            answerLabel3.Name = "answerLabel3";
            answerLabel3.Size = new Size(62, 21);
            answerLabel3.TabIndex = 58;
            answerLabel3.Text = "Answer";
            // 
            // answerLabel4
            // 
            answerLabel4.AutoSize = true;
            answerLabel4.BackColor = SystemColors.ControlLight;
            answerLabel4.Font = new Font("Segoe UI", 12F);
            answerLabel4.Location = new Point(79, 280);
            answerLabel4.Name = "answerLabel4";
            answerLabel4.Size = new Size(62, 21);
            answerLabel4.TabIndex = 60;
            answerLabel4.Text = "Answer";
            // 
            // submitQuizBtn
            // 
            submitQuizBtn.Location = new Point(421, 331);
            submitQuizBtn.Name = "submitQuizBtn";
            submitQuizBtn.Size = new Size(95, 23);
            submitQuizBtn.TabIndex = 64;
            submitQuizBtn.Text = "Submit";
            submitQuizBtn.UseVisualStyleBackColor = true;
            submitQuizBtn.Click += submitQuizBtn_Click;
            // 
            // backQuestionBtn
            // 
            backQuestionBtn.Enabled = false;
            backQuestionBtn.Location = new Point(304, 331);
            backQuestionBtn.Name = "backQuestionBtn";
            backQuestionBtn.Size = new Size(95, 23);
            backQuestionBtn.TabIndex = 63;
            backQuestionBtn.Text = "Previous";
            backQuestionBtn.UseVisualStyleBackColor = true;
            backQuestionBtn.Click += backQuestionBtn_Click;
            // 
            // nextQuestionBtn
            // 
            nextQuestionBtn.Location = new Point(186, 331);
            nextQuestionBtn.Name = "nextQuestionBtn";
            nextQuestionBtn.Size = new Size(95, 23);
            nextQuestionBtn.TabIndex = 62;
            nextQuestionBtn.Text = "Next";
            nextQuestionBtn.UseVisualStyleBackColor = true;
            nextQuestionBtn.Click += nextQuestionBtn_Click;
            // 
            // homeBtn
            // 
            homeBtn.Location = new Point(68, 331);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(95, 23);
            homeBtn.TabIndex = 61;
            homeBtn.Text = "Home";
            homeBtn.UseVisualStyleBackColor = true;
            homeBtn.Click += homeBtn_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = SystemColors.ControlLight;
            checkBox1.Location = new Point(464, 160);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 65;
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLight;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(432, 112);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 66;
            label1.Text = "Answer(s)";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = SystemColors.ControlLight;
            checkBox2.Location = new Point(464, 202);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 67;
            checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.BackColor = SystemColors.ControlLight;
            checkBox3.Location = new Point(464, 245);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(15, 14);
            checkBox3.TabIndex = 68;
            checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.BackColor = SystemColors.ControlLight;
            checkBox4.Location = new Point(464, 286);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(15, 14);
            checkBox4.TabIndex = 69;
            checkBox4.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = SystemColors.ControlLight;
            radioButton1.Location = new Point(464, 160);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(14, 13);
            radioButton1.TabIndex = 70;
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = SystemColors.ControlLight;
            radioButton2.Location = new Point(464, 202);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(14, 13);
            radioButton2.TabIndex = 71;
            radioButton2.TabStop = true;
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // QuizAttemptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 374);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(submitQuizBtn);
            Controls.Add(backQuestionBtn);
            Controls.Add(nextQuestionBtn);
            Controls.Add(homeBtn);
            Controls.Add(answerLabel4);
            Controls.Add(answerLabel3);
            Controls.Add(answerLabel2);
            Controls.Add(answerLabel1);
            Controls.Add(progressBar1);
            Controls.Add(questionLabel);
            Controls.Add(questionNumberLabel);
            Controls.Add(questionBackground);
            Controls.Add(mainLabel);
            Name = "QuizAttemptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassSmart";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StudentDashboardForm studentDashboardForm;
        private QuizAttempt quizAttempt;
        private List<QuestionAttempt> questionAttemptList;
        private Models.Quiz quiz;
        private List<Models.Question> questions;
        private Label mainLabel;
        private Label questionNumberLabel;
        private Label questionBackground;
        private Label questionLabel;
        private ProgressBar progressBar1;
        private int currentQuestionIndex = 0;
        private Label answerLabel1;
        private Label answerLabel2;
        private Label answerLabel3;
        private Label answerLabel4;
        private Button submitQuizBtn;
        private Button backQuestionBtn;
        private Button nextQuestionBtn;
        private Button homeBtn;
        private CheckBox checkBox1;
        private Label label1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
    }
}