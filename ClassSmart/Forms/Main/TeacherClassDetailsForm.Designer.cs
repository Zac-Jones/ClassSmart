namespace ClassSmart.Forms.Main
{
    partial class TeacherClassDetailsForm
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
            cancelBtn = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(417, 68);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(379, 139);
            label2.Name = "label2";
            label2.Size = new Size(170, 20);
            label2.TabIndex = 1;
            label2.Text = "(Class Information Here)";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(15, 567);
            cancelBtn.Margin = new Padding(3, 4, 3, 4);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(86, 31);
            cancelBtn.TabIndex = 2;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(914, 67);
            label3.TabIndex = 12;
            label3.Text = "Teacher Class Details";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(379, 291);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 13;
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TeacherClassDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cancelBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TeacherClassDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TeacherClassDetailsForm";
            Load += TeacherClassDetailsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button cancelBtn;
        private Label label3;
        private Label label4;
    }
}