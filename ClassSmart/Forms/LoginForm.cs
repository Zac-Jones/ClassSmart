using ClassSmart.Data;
using ClassSmart.Model;
using ClassSmart.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassSmart.Forms
{
    public partial class LoginForm : Form
    {
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;

        public LoginForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            txtEmail = new TextBox
            {
                Location = new Point(100, 115),
                Name = "txtEmail",
                PlaceholderText = "Email",
                Size = new Size(200, 23),
                TabIndex = 0
            };
            txtEmail.KeyDown += TxtEmail_KeyDown;

            txtPassword = new TextBox
            {
                Location = new Point(100, 165),
                Name = "txtPassword",
                PasswordChar = '*',
                PlaceholderText = "Password",
                Size = new Size(200, 23),
                TabIndex = 1
            };
            txtPassword.KeyDown += TxtPassword_KeyDown;

            btnLogin = new Button
            {
                Location = new Point(150, 215),
                Name = "btnLogin",
                Size = new Size(100, 30),
                TabIndex = 2,
                Text = "Login"
            };
            btnLogin.Click += BtnLogin_Click;

            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
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
                    OpenMainForm(teacher);
                }
                else
                {
                    var student = context.Students
                        .FirstOrDefault(s => s.Email == email && s.Password == password);

                    if (student != null)
                    {
                        OpenMainForm(student);
                    }
                    else
                    {
                        MessageBox.Show("Invalid login credentials.");
                    }
                }
            }
        }

        private void OpenMainForm(User user)
        {
            MainForm mainForm = new MainForm(user);
            Hide();
            mainForm.ShowDialog();
            Close();
        }
    }
}
