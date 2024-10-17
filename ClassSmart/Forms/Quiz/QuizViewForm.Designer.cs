using ClassSmart.Model;
using ClassSmart.Models;
using ClassSmart.Services;

namespace ClassSmart.Forms.TeacherSpecific
{
    partial class QuizViewForm
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
            comboBox1 = new ComboBox();
            label2 = new Label();
            deleteCancelBtn = new Button();
            editSaveBtn = new Button();
            label3 = new Label();
            questionNumberLabel = new Label();
            questionBackground = new Label();
            label6 = new Label();
            questionLabel = new Label();
            multipleChoiceAnswer2 = new Label();
            multipleChoiceAnswer3 = new Label();
            multipleChoiceAnswer4 = new Label();
            correctAnswerLabel = new Label();
            nextQuestionBtn = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            backQuestionBtn = new Button();
            trueLabel = new Label();
            multipleChoiceAnswer1 = new Label();
            falseLabel = new Label();
            trueRadioBtn = new RadioButton();
            falseRadioBtn = new RadioButton();
            homeBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(592, 75);
            label1.TabIndex = 11;
            label1.Text = "View Quizzes";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 99);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(568, 23);
            comboBox1.TabIndex = 17;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 75);
            label2.Name = "label2";
            label2.Size = new Size(42, 21);
            label2.TabIndex = 18;
            label2.Text = "Quiz";
            // 
            // deleteCancelBtn
            // 
            deleteCancelBtn.Location = new Point(130, 311);
            deleteCancelBtn.Name = "deleteCancelBtn";
            deleteCancelBtn.Size = new Size(95, 23);
            deleteCancelBtn.TabIndex = 19;
            deleteCancelBtn.Text = "Sample";
            deleteCancelBtn.UseVisualStyleBackColor = true;
            // 
            // editSaveBtn
            // 
            editSaveBtn.Location = new Point(11, 311);
            editSaveBtn.Name = "editSaveBtn";
            editSaveBtn.Size = new Size(95, 23);
            editSaveBtn.TabIndex = 20;
            editSaveBtn.Text = "Sample";
            editSaveBtn.UseVisualStyleBackColor = true;
            editSaveBtn.Click += editSaveBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 125);
            label3.Name = "label3";
            label3.Size = new Size(0, 21);
            label3.TabIndex = 21;
            // 
            // questionNumberLabel
            // 
            questionNumberLabel.AutoSize = true;
            questionNumberLabel.BackColor = SystemColors.Control;
            questionNumberLabel.Font = new Font("Segoe UI", 12F);
            questionNumberLabel.Location = new Point(12, 147);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(86, 21);
            questionNumberLabel.TabIndex = 22;
            questionNumberLabel.Text = "Question #";
            // 
            // questionBackground
            // 
            questionBackground.BackColor = SystemColors.ControlLight;
            questionBackground.BorderStyle = BorderStyle.FixedSingle;
            questionBackground.Font = new Font("Segoe UI", 12F);
            questionBackground.Location = new Point(12, 168);
            questionBackground.Name = "questionBackground";
            questionBackground.Size = new Size(568, 120);
            questionBackground.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLight;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(13, 168);
            label6.Name = "label6";
            label6.Size = new Size(0, 21);
            label6.TabIndex = 24;
            // 
            // questionLabel
            // 
            questionLabel.AutoSize = true;
            questionLabel.BackColor = SystemColors.ControlLight;
            questionLabel.Font = new Font("Segoe UI", 12F);
            questionLabel.Location = new Point(19, 175);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(273, 21);
            questionLabel.TabIndex = 25;
            questionLabel.Text = "Sample question goes here blah blah?";
            // 
            // multipleChoiceAnswer2
            // 
            multipleChoiceAnswer2.AutoSize = true;
            multipleChoiceAnswer2.BackColor = SystemColors.ControlLight;
            multipleChoiceAnswer2.Font = new Font("Segoe UI", 10F);
            multipleChoiceAnswer2.Location = new Point(19, 259);
            multipleChoiceAnswer2.Name = "multipleChoiceAnswer2";
            multipleChoiceAnswer2.Size = new Size(282, 19);
            multipleChoiceAnswer2.TabIndex = 29;
            multipleChoiceAnswer2.Text = "2. Sample answer goes here. I am an answer.";
            // 
            // multipleChoiceAnswer3
            // 
            multipleChoiceAnswer3.AutoSize = true;
            multipleChoiceAnswer3.BackColor = SystemColors.ControlLight;
            multipleChoiceAnswer3.Font = new Font("Segoe UI", 10F);
            multipleChoiceAnswer3.Location = new Point(19, 301);
            multipleChoiceAnswer3.Name = "multipleChoiceAnswer3";
            multipleChoiceAnswer3.Size = new Size(282, 19);
            multipleChoiceAnswer3.TabIndex = 31;
            multipleChoiceAnswer3.Text = "3. Sample answer goes here. I am an answer.";
            // 
            // multipleChoiceAnswer4
            // 
            multipleChoiceAnswer4.AutoSize = true;
            multipleChoiceAnswer4.BackColor = SystemColors.ControlLight;
            multipleChoiceAnswer4.Font = new Font("Segoe UI", 10F);
            multipleChoiceAnswer4.Location = new Point(19, 343);
            multipleChoiceAnswer4.Name = "multipleChoiceAnswer4";
            multipleChoiceAnswer4.Size = new Size(282, 19);
            multipleChoiceAnswer4.TabIndex = 33;
            multipleChoiceAnswer4.Text = "4. Sample answer goes here. I am an answer.";
            // 
            // correctAnswerLabel
            // 
            correctAnswerLabel.AutoSize = true;
            correctAnswerLabel.BackColor = SystemColors.ControlLight;
            correctAnswerLabel.Font = new Font("Segoe UI", 12F);
            correctAnswerLabel.Location = new Point(366, 175);
            correctAnswerLabel.Name = "correctAnswerLabel";
            correctAnswerLabel.Size = new Size(134, 21);
            correctAnswerLabel.TabIndex = 34;
            correctAnswerLabel.Text = "Correct Answer(s)";
            // 
            // nextQuestionBtn
            // 
            nextQuestionBtn.Location = new Point(248, 311);
            nextQuestionBtn.Name = "nextQuestionBtn";
            nextQuestionBtn.Size = new Size(95, 23);
            nextQuestionBtn.TabIndex = 35;
            nextQuestionBtn.Text = "Next";
            nextQuestionBtn.UseVisualStyleBackColor = true;
            nextQuestionBtn.Click += nextQuestionBtn_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = SystemColors.ControlLight;
            checkBox1.Location = new Point(421, 217);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 36;
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = SystemColors.ControlLight;
            checkBox2.Location = new Point(421, 259);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 37;
            checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.BackColor = SystemColors.ControlLight;
            checkBox3.Location = new Point(421, 301);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(15, 14);
            checkBox3.TabIndex = 38;
            checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.BackColor = SystemColors.ControlLight;
            checkBox4.Location = new Point(421, 343);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(15, 14);
            checkBox4.TabIndex = 39;
            checkBox4.UseVisualStyleBackColor = false;
            // 
            // backQuestionBtn
            // 
            backQuestionBtn.Enabled = false;
            backQuestionBtn.Location = new Point(366, 311);
            backQuestionBtn.Name = "backQuestionBtn";
            backQuestionBtn.Size = new Size(95, 23);
            backQuestionBtn.TabIndex = 40;
            backQuestionBtn.Text = "Previous";
            backQuestionBtn.UseVisualStyleBackColor = true;
            backQuestionBtn.Click += backQuestionBtn_Click;
            // 
            // trueLabel
            // 
            trueLabel.AutoSize = true;
            trueLabel.BackColor = SystemColors.ControlLight;
            trueLabel.Font = new Font("Segoe UI", 10F);
            trueLabel.Location = new Point(19, 217);
            trueLabel.Name = "trueLabel";
            trueLabel.Size = new Size(35, 19);
            trueLabel.TabIndex = 41;
            trueLabel.Text = "True";
            // 
            // multipleChoiceAnswer1
            // 
            multipleChoiceAnswer1.AutoSize = true;
            multipleChoiceAnswer1.BackColor = SystemColors.ControlLight;
            multipleChoiceAnswer1.Font = new Font("Segoe UI", 10F);
            multipleChoiceAnswer1.Location = new Point(19, 217);
            multipleChoiceAnswer1.Name = "multipleChoiceAnswer1";
            multipleChoiceAnswer1.Size = new Size(282, 19);
            multipleChoiceAnswer1.TabIndex = 27;
            multipleChoiceAnswer1.Text = "1. Sample answer goes here. I am an answer.";
            // 
            // falseLabel
            // 
            falseLabel.AutoSize = true;
            falseLabel.BackColor = SystemColors.ControlLight;
            falseLabel.Font = new Font("Segoe UI", 10F);
            falseLabel.Location = new Point(19, 259);
            falseLabel.Name = "falseLabel";
            falseLabel.Size = new Size(39, 19);
            falseLabel.TabIndex = 42;
            falseLabel.Text = "False";
            // 
            // trueRadioBtn
            // 
            trueRadioBtn.AutoSize = true;
            trueRadioBtn.BackColor = SystemColors.ControlLight;
            trueRadioBtn.Location = new Point(420, 217);
            trueRadioBtn.Name = "trueRadioBtn";
            trueRadioBtn.Size = new Size(14, 13);
            trueRadioBtn.TabIndex = 43;
            trueRadioBtn.TabStop = true;
            trueRadioBtn.UseVisualStyleBackColor = false;
            // 
            // falseRadioBtn
            // 
            falseRadioBtn.AutoSize = true;
            falseRadioBtn.BackColor = SystemColors.ControlLight;
            falseRadioBtn.Location = new Point(420, 259);
            falseRadioBtn.Name = "falseRadioBtn";
            falseRadioBtn.Size = new Size(14, 13);
            falseRadioBtn.TabIndex = 44;
            falseRadioBtn.TabStop = true;
            falseRadioBtn.UseVisualStyleBackColor = false;
            // 
            // homeBtn
            // 
            homeBtn.Location = new Point(485, 311);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(95, 23);
            homeBtn.TabIndex = 41;
            homeBtn.Text = "Home";
            homeBtn.UseVisualStyleBackColor = true;
            // 
            // QuizViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 451);
            Controls.Add(homeBtn);
            Controls.Add(backQuestionBtn);
            Controls.Add(nextQuestionBtn);
            Controls.Add(correctAnswerLabel);
            Controls.Add(questionLabel);
            Controls.Add(label6);
            Controls.Add(questionNumberLabel);
            Controls.Add(label3);
            Controls.Add(editSaveBtn);
            Controls.Add(deleteCancelBtn);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(questionBackground);
            MaximizeBox = false;
            MaximumSize = new Size(608, 490);
            MinimumSize = new Size(608, 490);
            Name = "QuizViewForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassSmart";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private Button deleteCancelBtn;
        private Button editSaveBtn;
        private Label label3;
        private Label questionNumberLabel;
        private Label questionBackground;
        private Label label6;
        private Label questionLabel;
        private Label multipleChoiceAnswer2;
        private Label multipleChoiceAnswer3;
        private Label multipleChoiceAnswer4;
        private Label correctAnswerLabel;
        private Button nextQuestionBtn;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Button backQuestionBtn;
        private Label trueLabel;
        private Label multipleChoiceAnswer1;
        private Label falseLabel;
        private RadioButton trueRadioBtn;
        private RadioButton falseRadioBtn;
        private bool editing = false;
        private Button homeBtn;
        private Teacher _teacher;
        private List<Models.Quiz> quizzes = new List<Models.Quiz>();
        private Models.Quiz activeQuiz;
        private QuizService _quizService;
        private List<Question> _questions;
        private List<Answer> _answers;
    }
}