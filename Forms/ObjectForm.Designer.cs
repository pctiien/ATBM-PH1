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
            comboBoxObjectType = new ComboBox();
            labelObjectType = new Label();
            dataGridViewObjects = new DataGridView();
            dataGridViewPermissions = new DataGridView();
            splitContainer = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)dataGridViewObjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPermissions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxObjectType
            // 
            comboBoxObjectType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxObjectType.FormattingEnabled = true;
            comboBoxObjectType.Items.AddRange(new object[] { "TABLE", "VIEW", "FUNCTION", "PROCEDURE" });
            comboBoxObjectType.Location = new Point(88, 0);
            comboBoxObjectType.Name = "comboBoxObjectType";
            comboBoxObjectType.Size = new Size(219, 23);
            comboBoxObjectType.TabIndex = 0;
            comboBoxObjectType.SelectedIndexChanged += comboBoxObjectType_SelectedIndexChanged;
            // 
            // labelObjectType
            // 
            labelObjectType.AutoSize = true;
            labelObjectType.Location = new Point(0, 0);
            labelObjectType.Name = "labelObjectType";
            labelObjectType.Size = new Size(72, 15);
            labelObjectType.TabIndex = 1;
            labelObjectType.Text = "Object Type:";
            // 
            // dataGridViewObjects
            // 
            dataGridViewObjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewObjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewObjects.Dock = DockStyle.Fill;
            dataGridViewObjects.Location = new Point(0, 0);
            dataGridViewObjects.Name = "dataGridViewObjects";
            dataGridViewObjects.RowTemplate.Height = 24;
            dataGridViewObjects.Size = new Size(967, 366);
            dataGridViewObjects.TabIndex = 0;
            dataGridViewObjects.CellClick += dataGridViewObjects_CellClick;
            // 
            // dataGridViewPermissions
            // 
            dataGridViewPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPermissions.Dock = DockStyle.Fill;
            dataGridViewPermissions.Location = new Point(0, 0);
            dataGridViewPermissions.Name = "dataGridViewPermissions";
            dataGridViewPermissions.RowTemplate.Height = 24;
            dataGridViewPermissions.Size = new Size(228, 366);
            dataGridViewPermissions.TabIndex = 0;
            dataGridViewPermissions.CellContentClick += dataGridViewPermissions_CellContentClick;
            // 
            // splitContainer
            // 
            splitContainer.Location = new Point(0, 23);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dataGridViewObjects);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(dataGridViewPermissions);
            splitContainer.Size = new Size(1199, 366);
            splitContainer.SplitterDistance = 967;
            splitContainer.TabIndex = 2;
            // 
            // ObjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1267, 583);
            Controls.Add(comboBoxObjectType);
            Controls.Add(labelObjectType);
            Controls.Add(splitContainer);
            Name = "ObjectForm";
            Text = "Database Objects";
            ((System.ComponentModel.ISupportInitialize)dataGridViewObjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPermissions).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
