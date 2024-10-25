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
            analyticsBtn = new Button();
            SuspendLayout();
            // 
            // logoutBtn
            // 
            logoutBtn.Cursor = Cursors.Hand;
            logoutBtn.Location = new Point(142, 245);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(240, 60);
            logoutBtn.TabIndex = 9;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // viewUpcomingQuizzesBtn
            // 
            viewUpcomingQuizzesBtn.Cursor = Cursors.Hand;
            viewUpcomingQuizzesBtn.Location = new Point(422, 145);
            viewUpcomingQuizzesBtn.Name = "viewUpcomingQuizzesBtn";
            viewUpcomingQuizzesBtn.Size = new Size(240, 60);
            viewUpcomingQuizzesBtn.TabIndex = 8;
            viewUpcomingQuizzesBtn.Text = "Upcoming Quizzes";
            viewUpcomingQuizzesBtn.UseVisualStyleBackColor = true;
            viewUpcomingQuizzesBtn.Click += viewUpcomingQuizzesBtn_Click;
            // 
            // viewClassesBtn
            // 
            viewClassesBtn.Cursor = Cursors.Hand;
            viewClassesBtn.Location = new Point(142, 145);
            viewClassesBtn.Name = "viewClassesBtn";
            viewClassesBtn.Size = new Size(240, 60);
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
            label1.Size = new Size(804, 109);
            label1.TabIndex = 10;
            label1.Text = "SampleHeader";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // analyticsBtn
            // 
            analyticsBtn.Cursor = Cursors.Hand;
            analyticsBtn.Location = new Point(422, 245);
            analyticsBtn.Name = "analyticsBtn";
            analyticsBtn.Size = new Size(240, 60);
            analyticsBtn.TabIndex = 11;
            analyticsBtn.Text = "Analytics";
            analyticsBtn.UseVisualStyleBackColor = true;
            analyticsBtn.Click += analyticsBtn_Click;
            // 
            // StudentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 451);
            Controls.Add(analyticsBtn);
            Controls.Add(label1);
            Controls.Add(logoutBtn);
            Controls.Add(viewUpcomingQuizzesBtn);
            Controls.Add(viewClassesBtn);
            MaximizeBox = false;
            MaximumSize = new Size(820, 490);
            MinimumSize = new Size(820, 490);
            Name = "StudentDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassSmart";
            ResumeLayout(false);
        }

        #endregion
        public Student student;
        private LoginForm loginForm;
        private Button logoutBtn;
        private Button viewUpcomingQuizzesBtn;
        private Button viewClassesBtn;
        private Label label1;
        private Button analyticsBtn;
    }
}