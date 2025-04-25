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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRoles = new System.Windows.Forms.TabPage();
            this.tabUsers = new System.Windows.Forms.TabPage();

            this.tabControl.SuspendLayout();
            this.SuspendLayout();

            // TabControl
            this.tabControl.Controls.Add(this.tabRoles);
            this.tabControl.Controls.Add(this.tabUsers);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);

            // TabRoles
            this.tabRoles.Location = new System.Drawing.Point(4, 25);
            this.tabRoles.Name = "tabRoles";
            this.tabRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoles.Size = new System.Drawing.Size(792, 421);
            this.tabRoles.Text = "Roles";
            this.tabRoles.UseVisualStyleBackColor = true;

            // TabUsers
            this.tabUsers.Location = new System.Drawing.Point(4, 25);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(792, 421);
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;

            // CombinedForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "CombinedForm";
            this.Text = "Role and User Management";

            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}