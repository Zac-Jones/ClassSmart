﻿using ClassSmart.Model;

namespace ClassSmart.Forms
{
    partial class QuizCreateMainForm
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
            textBox1 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label6 = new Label();
            numericUpDown2 = new NumericUpDown();
            label7 = new Label();
            numericUpDown3 = new NumericUpDown();
            addQuestionsBtn = new Button();
            cancelBtn = new Button();
            errorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(322, 67);
            label1.TabIndex = 11;
            label1.Text = "Quiz Creator";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ImageAlign = ContentAlignment.BottomLeft;
            label2.Location = new Point(12, 50);
            label2.Name = "label2";
            label2.Size = new Size(109, 28);
            label2.TabIndex = 12;
            label2.Text = "Quiz Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 99);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Name";
            textBox1.Size = new Size(297, 27);
            textBox1.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(14, 153);
            label4.Name = "label4";
            label4.Size = new Size(106, 28);
            label4.TabIndex = 16;
            label4.Text = "Open Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(14, 240);
            label5.Name = "label5";
            label5.Size = new Size(105, 28);
            label5.TabIndex = 18;
            label5.Text = "Close Date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(14, 185);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(297, 27);
            dateTimePicker1.TabIndex = 21;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(14, 272);
            dateTimePicker2.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(297, 27);
            dateTimePicker2.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(14, 327);
            label6.Name = "label6";
            label6.Size = new Size(158, 28);
            label6.TabIndex = 26;
            label6.Text = "No. of Questions";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(14, 359);
            numericUpDown2.Margin = new Padding(3, 4, 3, 4);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(297, 27);
            numericUpDown2.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(14, 413);
            label7.Name = "label7";
            label7.Size = new Size(122, 28);
            label7.TabIndex = 30;
            label7.Text = "Total Weight";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(14, 445);
            numericUpDown3.Margin = new Padding(3, 4, 3, 4);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(297, 27);
            numericUpDown3.TabIndex = 29;
            // 
            // addQuestionsBtn
            // 
            addQuestionsBtn.Location = new Point(107, 501);
            addQuestionsBtn.Margin = new Padding(3, 4, 3, 4);
            addQuestionsBtn.Name = "addQuestionsBtn";
            addQuestionsBtn.Size = new Size(111, 31);
            addQuestionsBtn.TabIndex = 32;
            addQuestionsBtn.Text = "Add Questions";
            addQuestionsBtn.UseVisualStyleBackColor = true;
            addQuestionsBtn.Click += addQuestionsBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(107, 543);
            cancelBtn.Margin = new Padding(3, 4, 3, 4);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(111, 31);
            cancelBtn.TabIndex = 33;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(14, 592);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(297, 31);
            errorLabel.TabIndex = 34;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // QuizCreateMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 644);
            Controls.Add(errorLabel);
            Controls.Add(cancelBtn);
            Controls.Add(addQuestionsBtn);
            Controls.Add(label7);
            Controls.Add(numericUpDown3);
            Controls.Add(label6);
            Controls.Add(numericUpDown2);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(340, 691);
            MinimumSize = new Size(340, 691);
            Name = "QuizCreateMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassSmart";
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label4;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label6;
        private NumericUpDown numericUpDown2;
        private Label label7;
        private NumericUpDown numericUpDown3;
        private Button addQuestionsBtn;
        private Button cancelBtn;
        private TeacherDashboardForm teacherDashboardForm;
        private Teacher teacher;
        private Label errorLabel;
    }
}