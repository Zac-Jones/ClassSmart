namespace ClassSmart.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername;
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Text = "Login";

            this.txtUsername = new TextBox();
            this.txtUsername.Location = new Point(100, 100);
            this.txtUsername.Size = new Size(200, 30);
            this.txtUsername.PlaceholderText = "Username";

            this.txtPassword = new TextBox();
            this.txtPassword.Location = new Point(100, 150);
            this.txtPassword.Size = new Size(200, 30);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "Password";

            this.btnLogin = new Button();
            this.btnLogin.Location = new Point(150, 200);
            this.btnLogin.Size = new Size(100, 30);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new EventHandler(this.BtnLogin_Click);

            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Do login logic here
        }
    }
}
