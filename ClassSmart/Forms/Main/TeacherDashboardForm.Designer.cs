using ClassSmart.Model;

namespace ClassSmart.Forms
{
    partial class TeacherDashboardForm
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
            viewClassBtn = new Button();
            viewQuizzesBtn = new Button();
            createQuizBtn = new Button();
            viewAnalyticsBtn = new Button();
            logoutBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(804, 109);
            label1.TabIndex = 1;
            label1.Text = "SampleHeader";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // viewClassBtn
            // 
            viewClassBtn.Cursor = Cursors.Hand;
            viewClassBtn.Location = new Point(142, 112);
            viewClassBtn.Name = "viewClassBtn";
            viewClassBtn.Size = new Size(240, 60);
            viewClassBtn.TabIndex = 2;
            viewClassBtn.Text = "View Class";
            viewClassBtn.UseVisualStyleBackColor = true;
            viewClassBtn.Click += viewClassBtn_Click;
            // 
            // viewQuizzesBtn
            // 
            viewQuizzesBtn.Cursor = Cursors.Hand;
            viewQuizzesBtn.Location = new Point(142, 212);
            viewQuizzesBtn.Name = "viewQuizzesBtn";
            viewQuizzesBtn.Size = new Size(240, 60);
            viewQuizzesBtn.TabIndex = 3;
            viewQuizzesBtn.Text = "View Quizzes";
            viewQuizzesBtn.UseVisualStyleBackColor = true;
            viewQuizzesBtn.Click += viewQuizzesBtn_Click;
            // 
            // createQuizBtn
            // 
            createQuizBtn.Cursor = Cursors.Hand;
            createQuizBtn.Location = new Point(422, 212);
            createQuizBtn.Name = "createQuizBtn";
            createQuizBtn.Size = new Size(240, 60);
            createQuizBtn.TabIndex = 4;
            createQuizBtn.Text = "Create Quiz";
            createQuizBtn.UseVisualStyleBackColor = true;
            createQuizBtn.Click += createQuizBtn_Click;
            // 
            // viewAnalyticsBtn
            // 
            viewAnalyticsBtn.Cursor = Cursors.Hand;
            viewAnalyticsBtn.Location = new Point(422, 112);
            viewAnalyticsBtn.Name = "viewAnalyticsBtn";
            viewAnalyticsBtn.Size = new Size(240, 60);
            viewAnalyticsBtn.TabIndex = 5;
            viewAnalyticsBtn.Text = "View Analytics";
            viewAnalyticsBtn.UseVisualStyleBackColor = true;
            viewAnalyticsBtn.Click += viewAnalyticsBtn_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.Cursor = Cursors.Hand;
            logoutBtn.Location = new Point(282, 312);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(240, 60);
            logoutBtn.TabIndex = 6;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // TeacherDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 451);
            Controls.Add(logoutBtn);
            Controls.Add(viewAnalyticsBtn);
            Controls.Add(createQuizBtn);
            Controls.Add(viewQuizzesBtn);
            Controls.Add(viewClassBtn);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(820, 490);
            MinimumSize = new Size(820, 490);
            Name = "TeacherDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassSmart";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Teacher teacher;
        private LoginForm loginForm;
        private Button viewClassBtn;
        private Button viewQuizzesBtn;
        private Button createQuizBtn;
        private Button viewAnalyticsBtn;
        private Button logoutBtn;
    }
}