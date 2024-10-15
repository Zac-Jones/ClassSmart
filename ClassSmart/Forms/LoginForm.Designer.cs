using ClassSmart.Data;
using ClassSmart.Utilities;

namespace ClassSmart.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
 
            txtEmail.Location = new Point(100, 115);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 0;
            txtEmail.KeyDown += TxtEmail_KeyDown; 

            txtPassword.Location = new Point(100, 165);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 1;
            txtPassword.KeyDown += TxtPassword_KeyDown; 

            btnLogin.Location = new Point(150, 215);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 30);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.Click += BtnLogin_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 350);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty.");
                return;
            }

            if (!StringExtensions.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            using (var context = new ApplicationDBContext())
            {
                var teacher = context.Teachers
                    .FirstOrDefault(t => t.Email == email && t.Password == password);

                if (teacher != null)
                {
                    MessageBox.Show("Welcome, " + teacher.Name);
                    // Display the teacher's dashboard here
                }
                else
                {
                    var student = context.Students
                        .FirstOrDefault(s => s.Email == email && s.Password == password);

                    if (student != null)
                    {
                        MessageBox.Show("Welcome, " + student.Name);
                        // Display the student's dashboard here
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
        }

    }
}
