namespace ATBM_HTTT_PH1.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRoles;
        private System.Windows.Forms.TabPage tabUsers;

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
            tabControl = new TabControl();
            tabRoles = new TabPage();
            tabUsers = new TabPage();
            tabGrants = new TabPage();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabRoles);
            tabControl.Controls.Add(tabUsers);
            tabControl.Controls.Add(tabGrants);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 562);
            tabControl.TabIndex = 0;
            // 
            // tabRoles
            // 
            tabRoles.Location = new Point(4, 29);
            tabRoles.Margin = new Padding(3, 4, 3, 4);
            tabRoles.Name = "tabRoles";
            tabRoles.Padding = new Padding(3, 4, 3, 4);
            tabRoles.Size = new Size(792, 529);
            tabRoles.TabIndex = 0;
            tabRoles.Text = "Roles";
            tabRoles.UseVisualStyleBackColor = true;
            // 
            // tabUsers
            // 
            tabUsers.Location = new Point(4, 29);
            tabUsers.Margin = new Padding(3, 4, 3, 4);
            tabUsers.Name = "tabUsers";
            tabUsers.Padding = new Padding(3, 4, 3, 4);
            tabUsers.Size = new Size(792, 529);
            tabUsers.TabIndex = 1;
            tabUsers.Text = "Users";
            tabUsers.UseVisualStyleBackColor = true;
            // 
            // tabGrants
            // 
            tabGrants.Location = new Point(4, 29);
            tabGrants.Name = "tabGrants";
            tabGrants.Padding = new Padding(3);
            tabGrants.Size = new Size(792, 529);
            tabGrants.TabIndex = 2;
            tabGrants.Text = "Grants";
            tabGrants.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(tabControl);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Role and User Management";
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TabPage tabGrants;
    }
}