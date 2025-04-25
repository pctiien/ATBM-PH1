namespace ATBM_HTTT_PH1
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listView1 = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.label1 = new Label();
            this.btnRefresh = new Button();
            this.groupBox1 = new GroupBox();
            this.listViewPermissions = new ListView();

            // 
            // listView1 (Danh sách người dùng)
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 160;
            this.columnHeader2.Text = "Account Status";
            this.columnHeader2.Width = 150;
            this.columnHeader3.Text = "Created Date";
            this.columnHeader3.Width = 170;

            this.listView1.Columns.AddRange(new ColumnHeader[] { this.columnHeader1, this.columnHeader2, this.columnHeader3 });
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new Point(20, 60);
            this.listView1.Name = "listView1";
            this.listView1.Size = new Size(500, 250);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = View.Details;
            this.listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;

            // 
            // listViewPermissions (Danh sách quyền)
            // 
            this.listViewPermissions.Columns.Add("Quyền", 480);
            this.listViewPermissions.FullRowSelect = true;
            this.listViewPermissions.GridLines = true;
            this.listViewPermissions.Location = new Point(20, 330);
            this.listViewPermissions.Name = "listViewPermissions";
            this.listViewPermissions.Size = new Size(500, 160);
            this.listViewPermissions.TabIndex = 1;
            this.listViewPermissions.UseCompatibleStateImageBehavior = false;
            this.listViewPermissions.View = View.Details;

            // 
            // label1
            // 
            this.label1.Text = "Danh sách người dùng:";
            this.label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.label1.Location = new Point(20, 25);
            this.label1.Size = new Size(300, 30);

            // 
            // btnRefresh
            // 
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnRefresh.Location = new Point(400, 25);
            this.btnRefresh.Size = new Size(120, 30);
            this.btnRefresh.Click += BtnRefresh_Click;

            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.listViewPermissions);
            this.groupBox1.Location = new Point(30, 30);
            this.groupBox1.Size = new Size(550, 520);
            this.groupBox1.Text = "Quản lý người dùng";

            // 
            // UserForm
            // 
            this.ClientSize = new Size(610, 580);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý Người dùng Oracle";
            this.Load += MainForm_Load;
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label label1;
        private Button btnRefresh;
        private GroupBox groupBox1;
        private ListView listViewPermissions;
    }
}
