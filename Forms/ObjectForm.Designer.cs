namespace ATBM_HTTT_PH1.Forms
{
    partial class ObjectForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxObjectType;
        private System.Windows.Forms.Label labelObjectType;
        private System.Windows.Forms.DataGridView dataGridViewObjects;

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

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).BeginInit();
            this.SuspendLayout();

            // labelObjectType
            this.labelObjectType.AutoSize = true;
            this.labelObjectType.Location = new System.Drawing.Point(20, 20);
            this.labelObjectType.Name = "labelObjectType";
            this.labelObjectType.Size = new System.Drawing.Size(95, 17);
            this.labelObjectType.Text = "Object Type:";

            // comboBoxObjectType
            this.comboBoxObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxObjectType.FormattingEnabled = true;
            this.comboBoxObjectType.Items.AddRange(new object[] { "TABLE", "VIEW", "FUNCTION", "PROCEDURE" });
            this.comboBoxObjectType.Location = new System.Drawing.Point(130, 17);
            this.comboBoxObjectType.Name = "comboBoxObjectType";
            this.comboBoxObjectType.Size = new System.Drawing.Size(200, 24);
            this.comboBoxObjectType.SelectedIndexChanged += new System.EventHandler(this.comboBoxObjectType_SelectedIndexChanged);

            // dataGridViewObjects
            this.dataGridViewObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewObjects.Location = new System.Drawing.Point(20, 60);
            this.dataGridViewObjects.Name = "dataGridViewObjects";
            this.dataGridViewObjects.RowTemplate.Height = 24;
            this.dataGridViewObjects.Size = new System.Drawing.Size(760, 360);

            // ObjectForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewObjects);
            this.Controls.Add(this.comboBoxObjectType);
            this.Controls.Add(this.labelObjectType);
            this.Name = "ObjectForm";
            this.Text = "Database Objects";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
