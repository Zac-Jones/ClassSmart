using ClassSmart.Model;

namespace ClassSmart.Forms
{
    partial class StudentDashboardForm
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
            logoutBtn = new Button();
            viewUpcomingQuizzesBtn = new Button();
            viewClassesBtn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // logoutBtn
            // 
            logoutBtn.Cursor = Cursors.Hand;
            logoutBtn.Location = new Point(322, 327);
            logoutBtn.Margin = new Padding(3, 4, 3, 4);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(274, 80);
            logoutBtn.TabIndex = 9;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // viewUpcomingQuizzesBtn
            // 
            viewUpcomingQuizzesBtn.Cursor = Cursors.Hand;
            viewUpcomingQuizzesBtn.Location = new Point(482, 193);
            viewUpcomingQuizzesBtn.Margin = new Padding(3, 4, 3, 4);
            viewUpcomingQuizzesBtn.Name = "viewUpcomingQuizzesBtn";
            viewUpcomingQuizzesBtn.Size = new Size(274, 80);
            viewUpcomingQuizzesBtn.TabIndex = 8;
            viewUpcomingQuizzesBtn.Text = "Upcoming Quizzes";
            viewUpcomingQuizzesBtn.UseVisualStyleBackColor = true;
            viewUpcomingQuizzesBtn.Click += viewUpcomingQuizzesBtn_Click;
            // 
            // viewClassesBtn
            // 
            viewClassesBtn.Cursor = Cursors.Hand;
            viewClassesBtn.Location = new Point(162, 193);
            viewClassesBtn.Margin = new Padding(3, 4, 3, 4);
            viewClassesBtn.Name = "viewClassesBtn";
            viewClassesBtn.Size = new Size(274, 80);
            viewClassesBtn.TabIndex = 7;
            viewClassesBtn.Text = "View Classes";
            viewClassesBtn.UseVisualStyleBackColor = true;
            viewClassesBtn.Click += viewClassesBtn_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(917, 145);
            label1.TabIndex = 10;
            label1.Text = "SampleHeader";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // StudentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 591);
            Controls.Add(label1);
            Controls.Add(logoutBtn);
            Controls.Add(viewUpcomingQuizzesBtn);
            Controls.Add(viewClassesBtn);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(935, 638);
            MinimumSize = new Size(935, 638);
            Name = "StudentDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassSmart";
            ResumeLayout(false);
        }

        #endregion
        private Student student;
        private LoginForm loginForm;
        private Button logoutBtn;
        private Button viewUpcomingQuizzesBtn;
        private Button viewClassesBtn;
        private Label label1;
    }
}