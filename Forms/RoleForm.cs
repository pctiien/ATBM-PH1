using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATBM_HTTT_PH1.Service;

namespace ATBM_HTTT_PH1.Forms
{
    public partial class RoleForm : Form
    {
        private readonly IRoleService roleService;

        public RoleForm(IRoleService roleService)
        {
            this.roleService = roleService;
            InitializeComponent();
            this.Load += RoleForm_Load;
        }

        private async void RoleForm_Load(object sender, EventArgs e)
        {
            await LoadRoleListAsync();
        }

        private async void BtnLoadRoles_Click(object sender, EventArgs e)
        {
            var roles = await roleService.getRoles();
            listViewRoles.Items.Clear();

            foreach (var role in roles)
            {
                listViewRoles.Items.Add(new ListViewItem(role));
            }

            comboBoxRoles.Items.Clear();
            comboBoxRoles.Items.AddRange(roles.ToArray());
        }

        private async void BtnLoadPermissions_Click(object sender, EventArgs e)
        {
            string? selectedRole = listViewRoles.SelectedItems[0]?.Text;
            if (selectedRole != null)
            {
                var permissions = await roleService.getPermissionsByRole(selectedRole);

                listViewPermissions.Items.Clear();


                foreach (var permission in permissions)
                {
                    if (permission.Length >= 3)
                    {
                        string tableName = permission[0];
                        string columnName = permission[1];
                        string privilege = permission[2];

                        ListViewItem item = new ListViewItem(tableName); 
                        item.SubItems.Add(columnName);  
                        item.SubItems.Add(privilege); 

                        listViewPermissions.Items.Add(item);
                    }
                }
            }
        }

        private async Task LoadRoleListAsync()
        {
            try
            {
                // Lấy danh sách các role từ service
                List<string> roles = await roleService.getRoles();

                listViewRoles.Items.Clear();

                foreach (var role in roles)
                {
                    listViewRoles.Items.Add(new ListViewItem(role));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách người dùng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
