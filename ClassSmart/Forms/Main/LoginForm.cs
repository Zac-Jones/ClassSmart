﻿using ClassSmart.Data;
using ClassSmart.Model;
using ClassSmart.Utilities;
using Microsoft.IdentityModel.Tokens;
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
        public LoginForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(LoginForm_FormClosing);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty())
            {
                errorLabel.Text = "Please fill in all fields";
                return;
            }

            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (!StringExtensions.IsValidEmail(email))
            {
                errorLabel.Text = "Please enter a valid email address.";
                return;
            }

            using (var context = new ApplicationDBContext())
            {
                var teacher = context.Teachers
                    .FirstOrDefault(t => t.Email == email && t.Password == password);

                if (teacher != null)
                {
                    TeacherDashboardForm teacherDashboardForm = new TeacherDashboardForm(teacher, this);
                    teacherDashboardForm.Show();
                    Hide();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    errorLabel.Text = "";
                }
                else
                {
                    var student = context.Students
                        .FirstOrDefault(s => s.Email == email && s.Password == password);

                    if (student != null)
                    {
                        StudentDashboardForm studentDashboardForm = new StudentDashboardForm(student, this);
                        studentDashboardForm.Show();
                        Hide();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        errorLabel.Text = "";
                    }
                    else
                    {
                        errorLabel.Text = "Invalid login credentials.";
                    }
                }
            }
        }
    }
}