namespace ATBM_HTTT_PH1.Forms
{
    partial class GrantPermissionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListView clbGrantee;
        private System.Windows.Forms.CheckedListBox clbPrivilege;
        private System.Windows.Forms.ComboBox cbObjectName;
        private System.Windows.Forms.ComboBox cbObjectType;
        private System.Windows.Forms.Button btnGrant;

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
            clbGrantee = new ListView();
            clbPrivilege = new CheckedListBox();
            cbObjectName = new ComboBox();
            cbObjectType = new ComboBox();
            btnGrant = new Button();
            panel1 = new Panel();
            cmbColumns = new ComboBox();
            label4 = new Label();
            cmbGrantee = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // clbGrantee
            // 
            clbGrantee.Location = new Point(3, 44);
            clbGrantee.Name = "clbGrantee";
            clbGrantee.Size = new Size(200, 336);
            clbGrantee.TabIndex = 0;
            clbGrantee.UseCompatibleStateImageBehavior = false;
            clbGrantee.View = View.List;
            // 
            // clbPrivilege
            // 
            clbPrivilege.FormattingEnabled = true;
            clbPrivilege.Items.AddRange(new object[] { "SELECT", "INSERT", "UPDATE", "DELETE", "EXECUTE" });
            clbPrivilege.Location = new Point(395, 115);
            clbPrivilege.Name = "clbPrivilege";
            clbPrivilege.Size = new Size(204, 92);
            clbPrivilege.TabIndex = 1;
            // 
            // cbObjectName
            // 
            cbObjectName.FormattingEnabled = true;
            cbObjectName.Location = new Point(395, 62);
            cbObjectName.Name = "cbObjectName";
            cbObjectName.Size = new Size(204, 28);
            cbObjectName.TabIndex = 2;
            // 
            // cbObjectType
            // 
            cbObjectType.FormattingEnabled = true;
            cbObjectType.Items.AddRange(new object[] { "TABLE", "VIEW", "PROCEDURE", "FUNCTION" });
            cbObjectType.Location = new Point(396, 3);
            cbObjectType.Name = "cbObjectType";
            cbObjectType.Size = new Size(204, 28);
            cbObjectType.TabIndex = 3;
            cbObjectType.SelectedIndexChanged += cbObjectType_SelectedIndexChanged;
            // 
            // btnGrant
            // 
            btnGrant.Location = new Point(635, 345);
            btnGrant.Name = "btnGrant";
            btnGrant.Size = new Size(132, 35);
            btnGrant.TabIndex = 4;
            btnGrant.Text = "Cấp quyền";
            btnGrant.UseVisualStyleBackColor = true;
            btnGrant.Click += btnGrant_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbColumns);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cmbGrantee);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(clbPrivilege);
            panel1.Controls.Add(cbObjectName);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbObjectType);
            panel1.Controls.Add(btnGrant);
            panel1.Controls.Add(clbGrantee);
            panel1.Location = new Point(12, 85);
            panel1.Name = "panel1";
            panel1.Size = new Size(770, 383);
            panel1.TabIndex = 5;
            panel1.Click += btnGrant_Click;
            // 
            // cmbColumns
            // 
            cmbColumns.FormattingEnabled = true;
            cmbColumns.Location = new Point(395, 233);
            cmbColumns.Name = "cmbColumns";
            cmbColumns.Size = new Size(204, 28);
            cmbColumns.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label4.Location = new Point(219, 232);
            label4.Name = "label4";
            label4.Size = new Size(88, 25);
            label4.TabIndex = 10;
            label4.Text = "Chọn cột:";
            // 
            // cmbGrantee
            // 
            cmbGrantee.FormattingEnabled = true;
            cmbGrantee.Location = new Point(3, 10);
            cmbGrantee.Name = "cmbGrantee";
            cmbGrantee.Size = new Size(200, 28);
            cmbGrantee.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(219, 115);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 7;
            label3.Text = "Chọn quyền:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(219, 61);
            label2.Name = "label2";
            label2.Size = new Size(173, 25);
            label2.TabIndex = 6;
            label2.Text = "Chọn tên đối tượng:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(219, 3);
            label1.Name = "label1";
            label1.Size = new Size(143, 25);
            label1.TabIndex = 5;
            label1.Text = "Chọn đối tượng:";
            // 
            // GrantPermissionForm
            // 
            ClientSize = new Size(794, 480);
            Controls.Add(panel1);
            Name = "GrantPermissionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cấp quyền cho user/role";
            Load += GrantPermissionForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private ComboBox cmbGrantee;
        private Label label4;
        private ComboBox cmbColumns;
    }
}
