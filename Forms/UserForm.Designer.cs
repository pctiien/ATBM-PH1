using System;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM_HTTT_PH1
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewUsers;
        private ListView listViewPermissions;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnPermissionTable;
        private ColumnHeader columnPermissionPrivilege;
        private ColumnHeader columnPermissionOwner;
        private ColumnHeader columnPermissionGrantor;
        private Label label1;
        private Label lblSelectedUser;
        private Button btnRefresh;
        private Button btnRevoke;
        private GroupBox groupBox1;

        // New controls
        private TextBox txtUsername;
        private TextBox txtObject;
        private TextBox txtColumn;
        private ComboBox cmbPrivilege;
        private CheckBox chkWithGrant;
        private Button btnGrantUser;
        private TextBox txtRole;
        private CheckBox chkWithAdmin;
        private Button btnGrantRole;
        //
        private Button btnCreateUser;
        private Button btnDropUser;
        private TextBox txtNewUsername;
        private Button btnChangePassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            listViewUsers = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            listViewPermissions = new ListView();
            columnPermissionTable = new ColumnHeader();
            columnPermissionPrivilege = new ColumnHeader();
            columnPermissionOwner = new ColumnHeader();
            columnPermissionGrantor = new ColumnHeader();
            label1 = new Label();
            lblSelectedUser = new Label();
            btnRefresh = new Button();
            btnRevoke = new Button();
            groupBox1 = new GroupBox();
            txtUsername = new TextBox();
            txtObject = new TextBox();
            txtColumn = new TextBox();
            cmbPrivilege = new ComboBox();
            chkWithGrant = new CheckBox();
            btnGrantUser = new Button();
            txtRole = new TextBox();
            chkWithAdmin = new CheckBox();
            btnGrantRole = new Button();
            btnCreateUser = new Button();
            btnDropUser = new Button();
            txtNewUsername = new TextBox();
            btnChangePassword = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listViewUsers
            // 
            listViewUsers.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listViewUsers.FullRowSelect = true;
            listViewUsers.GridLines = true;
            listViewUsers.Location = new Point(20, 60);
            listViewUsers.Name = "listViewUsers";
            listViewUsers.Size = new Size(500, 250);
            listViewUsers.TabIndex = 1;
            listViewUsers.UseCompatibleStateImageBehavior = false;
            listViewUsers.View = View.Details;
            listViewUsers.SelectedIndexChanged += listViewUsers_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Username";
            columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Account Status";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Created Date";
            columnHeader3.Width = 170;
            // 
            // listViewPermissions
            // 
            listViewPermissions.Columns.AddRange(new ColumnHeader[] { columnPermissionTable, columnPermissionPrivilege, columnPermissionOwner, columnPermissionGrantor });
            listViewPermissions.FullRowSelect = true;
            listViewPermissions.GridLines = true;
            listViewPermissions.Location = new Point(20, 330);
            listViewPermissions.Name = "listViewPermissions";
            listViewPermissions.Size = new Size(500, 160);
            listViewPermissions.TabIndex = 2;
            listViewPermissions.UseCompatibleStateImageBehavior = false;
            listViewPermissions.View = View.Details;
            // 
            // columnPermissionTable
            // 
            columnPermissionTable.Text = "Table name";
            columnPermissionTable.Width = 160;
            // 
            // columnPermissionPrivilege
            // 
            columnPermissionPrivilege.Text = "Privilege";
            columnPermissionPrivilege.Width = 100;
            // 
            // columnPermissionOwner
            // 
            columnPermissionOwner.Text = "Owner";
            columnPermissionOwner.Width = 120;
            // 
            // columnPermissionGrantor
            // 
            columnPermissionGrantor.Text = "Grantor";
            columnPermissionGrantor.Width = 120;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(20, 25);
            label1.Name = "label1";
            label1.Size = new Size(250, 30);
            label1.TabIndex = 0;
            label1.Text = "Danh sách người dùng:";
            // 
            // lblSelectedUser
            // 
            lblSelectedUser.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblSelectedUser.Location = new Point(20, 500);
            lblSelectedUser.Name = "lblSelectedUser";
            lblSelectedUser.Size = new Size(300, 25);
            lblSelectedUser.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(400, 25);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 30);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Làm mới";
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // btnRevoke
            // 
            btnRevoke.Location = new Point(400, 500);
            btnRevoke.Name = "btnRevoke";
            btnRevoke.Size = new Size(120, 30);
            btnRevoke.TabIndex = 5;
            btnRevoke.Text = "Thu hồi quyền";
            btnRevoke.Click += BtnRevokePermission_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(listViewUsers);
            groupBox1.Controls.Add(listViewPermissions);
            groupBox1.Controls.Add(lblSelectedUser);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnRevoke);
            groupBox1.Location = new Point(30, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(550, 540);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Quản lý người dùng";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(600, 60);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Tên người dùng";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtObject
            // 
            txtObject.Location = new Point(600, 100);
            txtObject.Name = "txtObject";
            txtObject.PlaceholderText = "Tên bảng/View/Procedure";
            txtObject.Size = new Size(200, 23);
            txtObject.TabIndex = 2;
            // 
            // txtColumn
            // 
            txtColumn.Location = new Point(600, 140);
            txtColumn.Name = "txtColumn";
            txtColumn.PlaceholderText = "Tên cột (nếu có)";
            txtColumn.Size = new Size(200, 23);
            txtColumn.TabIndex = 3;
            // 
            // cmbPrivilege
            // 
            cmbPrivilege.Items.AddRange(new object[] { "SELECT", "UPDATE", "INSERT", "DELETE" });
            cmbPrivilege.Location = new Point(600, 180);
            cmbPrivilege.Name = "cmbPrivilege";
            cmbPrivilege.Size = new Size(200, 23);
            cmbPrivilege.TabIndex = 4;
            // 
            // chkWithGrant
            // 
            chkWithGrant.AutoSize = true;
            chkWithGrant.Location = new Point(600, 210);
            chkWithGrant.Name = "chkWithGrant";
            chkWithGrant.Size = new Size(142, 19);
            chkWithGrant.TabIndex = 5;
            chkWithGrant.Text = "WITH GRANT OPTION";
            // 
            // btnGrantUser
            // 
            btnGrantUser.Location = new Point(600, 240);
            btnGrantUser.Name = "btnGrantUser";
            btnGrantUser.Size = new Size(200, 30);
            btnGrantUser.TabIndex = 6;
            btnGrantUser.Text = "Cấp quyền cho User";
            btnGrantUser.Click += BtnGrantPermissionToUser_Click;
            // 
            // txtRole
            // 
            txtRole.Location = new Point(600, 300);
            txtRole.Name = "txtRole";
            txtRole.PlaceholderText = "Tên Role";
            txtRole.Size = new Size(200, 23);
            txtRole.TabIndex = 7;
            // 
            // chkWithAdmin
            // 
            chkWithAdmin.Location = new Point(0, 0);
            chkWithAdmin.Name = "chkWithAdmin";
            chkWithAdmin.Size = new Size(104, 24);
            chkWithAdmin.TabIndex = 8;
            // 
            // btnGrantRole
            // 
            btnGrantRole.Location = new Point(600, 360);
            btnGrantRole.Name = "btnGrantRole";
            btnGrantRole.Size = new Size(200, 30);
            btnGrantRole.TabIndex = 9;
            btnGrantRole.Text = "Cấp Role cho User";
            btnGrantRole.Click += BtnGrantRoleToUser_Click;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(846, 100);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(200, 30);
            btnCreateUser.TabIndex = 10;
            btnCreateUser.Text = "Tạo User";
            btnCreateUser.Click += BtnCreateUser_Click;
            // 
            // btnDropUser
            // 
            btnDropUser.Location = new Point(846, 180);
            btnDropUser.Name = "btnDropUser";
            btnDropUser.Size = new Size(200, 30);
            btnDropUser.TabIndex = 11;
            btnDropUser.Text = "Xóa User";
            btnDropUser.Click += BtnDropUser_Click;
            // 
            // txtNewUsername
            // 
            txtNewUsername.Location = new Point(846, 62);
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.PlaceholderText = "Nhập tên user";
            txtNewUsername.Size = new Size(200, 23);
            txtNewUsername.TabIndex = 12;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(846, 140);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(200, 30);
            btnChangePassword.TabIndex = 13;
            btnChangePassword.Text = "Đổi mật khẩu";
            btnChangePassword.Click += BtnChangePassword_Click;
            // 
            // UserForm
            // 
            ClientSize = new Size(1079, 600);
            Controls.Add(groupBox1);
            Controls.Add(txtUsername);
            Controls.Add(txtObject);
            Controls.Add(txtColumn);
            Controls.Add(cmbPrivilege);
            Controls.Add(chkWithGrant);
            Controls.Add(btnGrantUser);
            Controls.Add(txtRole);
            Controls.Add(chkWithAdmin);
            Controls.Add(btnGrantRole);
            Controls.Add(btnCreateUser);
            Controls.Add(btnDropUser);
            Controls.Add(txtNewUsername);
            Controls.Add(btnChangePassword);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Người dùng";
            Load += UserForm_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
