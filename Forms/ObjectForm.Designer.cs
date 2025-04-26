namespace ATBM_HTTT_PH1.Forms
{
    partial class ObjectForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxObjectType;
        private System.Windows.Forms.Label labelObjectType;
        private System.Windows.Forms.DataGridView dataGridViewObjects;
        private System.Windows.Forms.DataGridView dataGridViewPermissions;
        private System.Windows.Forms.SplitContainer splitContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxObjectType = new System.Windows.Forms.ComboBox();
            this.labelObjectType = new System.Windows.Forms.Label();
            this.dataGridViewObjects = new System.Windows.Forms.DataGridView();
            this.dataGridViewPermissions = new System.Windows.Forms.DataGridView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();

            // labelObjectType
            this.labelObjectType.AutoSize = true;
            this.labelObjectType.Location = new System.Drawing.Point(0, 0);
            this.labelObjectType.Name = "labelObjectType";
            this.labelObjectType.Size = new System.Drawing.Size(100, 20);
            this.labelObjectType.Text = "Object Type:";

            // comboBoxObjectType
            this.comboBoxObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxObjectType.FormattingEnabled = true;
            this.comboBoxObjectType.Items.AddRange(new object[] { "TABLE", "VIEW", "FUNCTION", "PROCEDURE" });
            this.comboBoxObjectType.Location = new System.Drawing.Point(100,0);
            this.comboBoxObjectType.Name = "comboBoxObjectType";
            this.comboBoxObjectType.Size = new System.Drawing.Size(250, 25); // Điều chỉnh chiều rộng cho phù hợp
            this.comboBoxObjectType.SelectedIndexChanged += new System.EventHandler(this.comboBoxObjectType_SelectedIndexChanged);

            // splitContainer
            //this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);  // Điều chỉnh vị trí
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitContainer.SplitterDistance = 685;  // Chia đều giữa hai bảng
            this.splitContainer.Size = new System.Drawing.Size(1370, 390);

            this.splitContainer.Panel1.Controls.Add(this.dataGridViewObjects);
            this.splitContainer.Panel2.Controls.Add(this.dataGridViewPermissions);

            // dataGridViewObjects
            this.dataGridViewObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewObjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewObjects.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewObjects.Name = "dataGridViewObjects";
            this.dataGridViewObjects.RowTemplate.Height = 24;
            this.dataGridViewObjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewObjects_CellClick);

            // dataGridViewPermissions
            this.dataGridViewPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPermissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPermissions.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPermissions.Name = "dataGridViewPermissions";
            this.dataGridViewPermissions.RowTemplate.Height = 24;

            // ObjectForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 450);
            this.Controls.Add(this.comboBoxObjectType);
            this.Controls.Add(this.labelObjectType);
            this.Controls.Add(this.splitContainer);
            this.Name = "ObjectForm";
            this.Text = "Database Objects";

            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
