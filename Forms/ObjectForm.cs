using System;
using System.Linq;
using System.Windows.Forms;
using ATBM_HTTT_PH1.Service;

namespace ATBM_HTTT_PH1.Forms
{
    public partial class ObjectForm : Form
    {
        private readonly IObjectService objectService;

        public ObjectForm(IObjectService objectService)
        {
            InitializeComponent();
            this.objectService = objectService;
        }

        private async void comboBoxObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedType = comboBoxObjectType.SelectedItem?.ToString();
            if (selectedType != null)
            {
                var data = await objectService.getObjectByType(selectedType);

                dataGridViewObjects.DataSource = data
                    .Select(row => new
                    {
                        ObjectName = row[0],
                        Owner = row[1],
                        CreatedDate = row[2]
                    })
                    .ToList();

                // Xoá bảng permissions cũ nếu có
                dataGridViewPermissions.DataSource = null;
            }
        }

        private async void dataGridViewObjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewObjects.Rows[e.RowIndex];
                string objectName = row.Cells["ObjectName"].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(objectName))
                {
                    var permissionData = await objectService.getPermissionByObject(objectName);

                    var result = permissionData.Select(p => new
                    {
                        Grantee = p[0],
                        Owner = p[1],
                        ObjectName = p[2],
                        Grantor = p[3],
                        Privilege = p[4],
                        PrivType = p[5]
                    }).ToList();

                    dataGridViewPermissions.DataSource = result;
                }
            }
        }

        private void dataGridViewPermissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
