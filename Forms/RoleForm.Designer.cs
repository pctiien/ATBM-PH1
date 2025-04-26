namespace ATBM_HTTT_PH1.Forms
{
    partial class RoleForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewRoles;
        private ListView listViewPermissions;
        private Button btnLoadRoles;
        private Label lblRoles;
        private Label lblPermissions;
        private Button btnLoadPermissions;
        //private ComboBox comboBoxRoles;

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
            this.listViewRoles = new ListView();
            this.listViewPermissions = new ListView();
            this.btnLoadRoles = new Button();
            this.lblRoles = new Label();
            this.lblPermissions = new Label();
            this.btnLoadPermissions = new Button();
            //this.comboBoxRoles = new ComboBox();

            // 
            // listViewRoles
            // 
            this.listViewRoles.Location = new Point(20, 60);
            this.listViewRoles.Size = new Size(300, 200);
            this.listViewRoles.View = View.Details;
            this.listViewRoles.Columns.Add("Roles", 250);

            // 
            // listViewPermissions
            // 
            this.listViewPermissions.Location = new Point(350, 60);
            this.listViewPermissions.Size = new Size(750, 200);
            this.listViewPermissions.View = View.Details;
            this.listViewPermissions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //this.listViewPermissions.FullRowSelect = true;
            //this.listViewPermissions.GridLines = true;
            this.listViewPermissions.Columns.Add("Table Name", 250);
            this.listViewPermissions.Columns.Add("Column Name", 250);
            this.listViewPermissions.Columns.Add("Privilege", 250);

            // 
            // btnLoadRoles
            // 
            this.btnLoadRoles.Text = "Load Roles";
            this.btnLoadRoles.Location = new Point(20, 280);
            this.btnLoadRoles.Size = new Size(100, 30);
            this.btnLoadRoles.Click += new EventHandler(this.BtnLoadRoles_Click);

            // 
            // btnLoadPermissions
            // 
            this.btnLoadPermissions.Text = "Load Permissions";
            this.btnLoadPermissions.Location = new Point(350, 280);
            this.btnLoadPermissions.Size = new Size(150, 30);
            this.btnLoadPermissions.Click += new EventHandler(this.BtnLoadPermissions_Click);

            // 
            // lblRoles
            // 
            this.lblRoles.Text = "Roles:";
            this.lblRoles.Location = new Point(20, 30);
            this.lblRoles.Size = new Size(100, 20);

            // 
            // lblPermissions
            // 
            this.lblPermissions.Text = "Permissions:";
            this.lblPermissions.Location = new Point(350, 30);
            this.lblPermissions.Size = new Size(100, 20);

            // 
            // RoleForm
            // 
            this.ClientSize = new Size(1300, 400);
            this.Controls.Add(this.listViewRoles);
            this.Controls.Add(this.listViewPermissions);
            this.Controls.Add(this.btnLoadRoles);
            this.Controls.Add(this.btnLoadPermissions);
            //this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.lblPermissions);
            this.Text = "Role Management";
        }
    }
}
