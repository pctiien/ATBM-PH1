

using System;
using System.Drawing;
using System.Windows.Forms;

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
        private TextBox txtRole;
        private TextBox txtTable;
        private TextBox txtColumn;
        private ComboBox cmbPrivilege;
        private CheckBox chkWithGrantOption;
        private Button btnGrantPermission;

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
            this.txtRole = new TextBox();
            this.txtTable = new TextBox();
            this.txtColumn = new TextBox();
            this.cmbPrivilege = new ComboBox();
            this.chkWithGrantOption = new CheckBox();
            this.btnGrantPermission = new Button();

            // listViewRoles
            this.listViewRoles.Location = new Point(20, 60);
            this.listViewRoles.Size = new Size(300, 200);
            this.listViewRoles.View = View.Details;
            this.listViewRoles.Columns.Add("Roles", 250);

            // listViewPermissions
            this.listViewPermissions.Location = new Point(350, 60);
            this.listViewPermissions.Size = new Size(750, 200);
            this.listViewPermissions.View = View.Details;
            this.listViewPermissions.Columns.Add("Table Name", 250);
            this.listViewPermissions.Columns.Add("Column Name", 250);
            this.listViewPermissions.Columns.Add("Privilege", 250);

            // btnLoadRoles
            this.btnLoadRoles.Text = "Load Roles";
            this.btnLoadRoles.Location = new Point(20, 280);
            this.btnLoadRoles.Size = new Size(100, 30);
            this.btnLoadRoles.Click += new EventHandler(this.BtnLoadRoles_Click);

            // btnLoadPermissions
            this.btnLoadPermissions.Text = "Load Permissions";
            this.btnLoadPermissions.Location = new Point(350, 280);
            this.btnLoadPermissions.Size = new Size(150, 30);
            this.btnLoadPermissions.Click += new EventHandler(this.BtnLoadPermissions_Click);

            // Labels
            this.lblRoles.Text = "Roles:";
            this.lblRoles.Location = new Point(20, 30);
            this.lblRoles.Size = new Size(100, 20);

            this.lblPermissions.Text = "Permissions:";
            this.lblPermissions.Location = new Point(350, 30);
            this.lblPermissions.Size = new Size(100, 20);

            // txtRole
            this.txtRole.Location = new Point(20, 330);
            this.txtRole.Size = new Size(200, 23);
            this.txtRole.PlaceholderText = "Role Name";

            // txtTable
            this.txtTable.Location = new Point(230, 330);
            this.txtTable.Size = new Size(200, 23);
            this.txtTable.PlaceholderText = "Table Name";

            // txtColumn
            this.txtColumn.Location = new Point(440, 330);
            this.txtColumn.Size = new Size(150, 23);
            this.txtColumn.PlaceholderText = "Column Name (optional)";

            // cmbPrivilege
            this.cmbPrivilege.Location = new Point(600, 330);
            this.cmbPrivilege.Size = new Size(120, 23);
            this.cmbPrivilege.Items.AddRange(new string[] { "SELECT", "UPDATE", "INSERT", "DELETE" });

            // chkWithGrantOption
            this.chkWithGrantOption.Location = new Point(730, 330);
            this.chkWithGrantOption.Text = "WITH GRANT OPTION";
            this.chkWithGrantOption.AutoSize = true;

            // btnGrantPermission
            this.btnGrantPermission.Location = new Point(900, 330);
            this.btnGrantPermission.Size = new Size(150, 30);
            this.btnGrantPermission.Text = "Grant Permission";
            this.btnGrantPermission.Click += new EventHandler(this.BtnGrantPermission_Click);

            // RoleForm
            this.ClientSize = new Size(1300, 400);
            this.Controls.Add(this.listViewRoles);
            this.Controls.Add(this.listViewPermissions);
            this.Controls.Add(this.btnLoadRoles);
            this.Controls.Add(this.btnLoadPermissions);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.lblPermissions);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.txtColumn);
            this.Controls.Add(this.cmbPrivilege);
            this.Controls.Add(this.chkWithGrantOption);
            this.Controls.Add(this.btnGrantPermission);
            this.Text = "Role Management";
        }
    }
}
