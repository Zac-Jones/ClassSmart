namespace ClassSmart.Forms.Main
{
    partial class ClassDetailsForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            listBox1 = new ListBox();
            textbox1 = new TextBox();
            CancelBtn = new Button();
            classBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)classBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(375, 73);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // listBox1
            // 
            listBox1.DataSource = classBindingSource;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(340, 102);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 94);
            listBox1.TabIndex = 1;
            // 
            // textbox1
            // 
            textbox1.Location = new Point(350, 47);
            textbox1.Name = "textbox1";
            textbox1.Size = new Size(100, 23);
            textbox1.TabIndex = 3;
            textbox1.Tag = "";
            textbox1.Text = "Class Details";
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(12, 415);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(75, 23);
            CancelBtn.TabIndex = 4;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click_1;
            // 
            // classBindingSource
            // 
            classBindingSource.DataSource = typeof(Models.Class);
            // 
            // ClassDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelBtn);
            Controls.Add(textbox1);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Name = "ClassDetailsForm";
            Text = "ClassDetailsForm";
            ((System.ComponentModel.ISupportInitialize)classBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private TextBox textbox1;
        private Button CancelBtn;
        private BindingSource classBindingSource;
    }
}