using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ATBM_HTTT_PH1.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername;
        private TextBox txtPassword;

        private Button btnLogin;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblTitle;

        private TextBox txtServiceName;
        private Label lblServiceName;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtServiceName = new TextBox();  // Thêm TextBox cho Service Name
            btnLogin = new Button();
            lblUsername = new Label();
            lblPassword = new Label();
            lblServiceName = new Label(); // Thêm Label cho Service Name
            lblTitle = new Label();

            SuspendLayout();

            // lblTitle
            lblTitle.Text = "Login to Oracle DB";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(50, 20);
            lblTitle.Size = new Size(250, 40);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblUsername
            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(30, 80);
            lblUsername.Size = new Size(80, 25);

            // txtUsername
            txtUsername.Location = new Point(120, 80);
            txtUsername.Size = new Size(180, 25);

            // lblPassword
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(30, 130);
            lblPassword.Size = new Size(80, 25);

            // txtPassword
            txtPassword.Location = new Point(120, 130);
            txtPassword.Size = new Size(180, 25);
            txtPassword.UseSystemPasswordChar = true;

            // lblServiceName
            lblServiceName.Text = "SID/Service Name:";
            lblServiceName.Location = new Point(30, 180); // Đặt vị trí cho label
            lblServiceName.Size = new Size(120, 25); // Kích thước của label

            // txtServiceName
            txtServiceName.Location = new Point(160, 180); // Vị trí cho textbox SID/Service Name
            txtServiceName.Size = new Size(140, 25); // Kích thước của textbox SID/Service Name

            // btnLogin
            btnLogin.Text = "Login";
            btnLogin.Location = new Point(120, 230);  // Cập nhật vị trí của nút Login
            btnLogin.Size = new Size(100, 35);
            btnLogin.Click += BtnLogin_Click;

            // LoginForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 300); // Cập nhật kích thước form
            Controls.Add(lblTitle);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblServiceName);  // Thêm label cho SID/Service Name
            Controls.Add(txtServiceName); // Thêm textbox cho SID/Service Name
            Controls.Add(btnLogin);
            Name = "LoginForm";
            Text = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

    }
}
