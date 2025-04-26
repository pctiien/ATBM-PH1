namespace ATBM_HTTT_PH1
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listViewUsers = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.listViewPermissions = new ListView();
            this.columnPermissionTable = new ColumnHeader();
            this.columnPermissionPrivilege = new ColumnHeader();
            this.label1 = new Label();
            this.lblSelectedUser = new Label();
            this.btnRefresh = new Button();
            this.btnRevoke = new Button();
            this.groupBox1 = new GroupBox();

            // listViewUsers
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 160;
            this.columnHeader2.Text = "Account Status";
            this.columnHeader2.Width = 150;
            this.columnHeader3.Text = "Created Date";
            this.columnHeader3.Width = 170;

            this.listViewUsers.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.GridLines = true;
            this.listViewUsers.Location = new Point(20, 60);
            this.listViewUsers.Size = new Size(500, 250);
            this.listViewUsers.View = View.Details;
            this.listViewUsers.SelectedIndexChanged += listViewUsers_SelectedIndexChanged;

            // listViewPermissions
            this.columnPermissionTable.Text = "Tên bảng";
            this.columnPermissionTable.Width = 240;
            this.columnPermissionPrivilege.Text = "Quyền";
            this.columnPermissionPrivilege.Width = 240;

            this.listViewPermissions.Columns.AddRange(new ColumnHeader[] { columnPermissionTable, columnPermissionPrivilege });
            this.listViewPermissions.FullRowSelect = true;
            this.listViewPermissions.GridLines = true;
            this.listViewPermissions.Location = new Point(20, 330);
            this.listViewPermissions.Size = new Size(500, 160);
            this.listViewPermissions.View = View.Details;

            // label1
            this.label1.Text = "Danh sách người dùng:";
            this.label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.label1.Location = new Point(20, 25);
            this.label1.Size = new Size(250, 30);

            // lblSelectedUser
            this.lblSelectedUser.Text = "";
            this.lblSelectedUser.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblSelectedUser.Location = new Point(20, 500);
            this.lblSelectedUser.Size = new Size(300, 25);

            // btnRefresh
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Location = new Point(400, 25);
            this.btnRefresh.Size = new Size(120, 30);
            this.btnRefresh.Click += BtnRefresh_Click;

            // btnRevoke
            this.btnRevoke.Text = "Thu hồi quyền";
            this.btnRevoke.Location = new Point(400, 500);
            this.btnRevoke.Size = new Size(120, 30);
            this.btnRevoke.Click += BtnRevokePermission_Click;

            // groupBox1
            this.groupBox1.Text = "Quản lý người dùng";
            this.groupBox1.Location = new Point(30, 30);
            this.groupBox1.Size = new Size(550, 540);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(listViewUsers);
            this.groupBox1.Controls.Add(listViewPermissions);
            this.groupBox1.Controls.Add(lblSelectedUser);
            this.groupBox1.Controls.Add(btnRefresh);
            this.groupBox1.Controls.Add(btnRevoke);

            // UserForm
            this.ClientSize = new Size(610, 600);
            this.Controls.Add(groupBox1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý Người dùng Oracle";
            this.Load += UserForm_Load;
        }

        #endregion

        private ListView listViewUsers;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;

        private ListView listViewPermissions;
        private ColumnHeader columnPermissionTable;
        private ColumnHeader columnPermissionPrivilege;

        private Label label1;
        private Label lblSelectedUser;
        private Button btnRefresh;
        private Button btnRevoke;
        private GroupBox groupBox1;
    }
}
