using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATBM_HTTT_PH1.Service;
using Oracle.ManagedDataAccess.Client;
using System.Data;


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
        private void BtnGrantPermission_Click(object sender, EventArgs e)
        {
            string role = txtRole.Text.Trim().ToUpper();
            string table = txtTable.Text.Trim().ToUpper();
            string column = string.IsNullOrWhiteSpace(txtColumn.Text) ? null : txtColumn.Text.Trim().ToUpper();
            string privilege = cmbPrivilege.SelectedItem?.ToString();
            string withGrantOption = chkWithGrantOption.Checked ? "Y" : "N";

            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(table) || string.IsNullOrEmpty(privilege))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Role, Table và chọn Privilege.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=ADMIN;Password=123456;Data Source=localhost:1521/XEPDB1"))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand("SP_GRANT_OBJECT_PRIVS", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_privilege", OracleDbType.Varchar2).Value = privilege;
                    cmd.Parameters.Add("p_object", OracleDbType.Varchar2).Value = table;
                    cmd.Parameters.Add("p_column", OracleDbType.Varchar2).Value = column;
                    cmd.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = role;
                    cmd.Parameters.Add("p_grant_opt", OracleDbType.Varchar2).Value = withGrantOption;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cấp quyền thành công cho role " + role);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cấp quyền: " + ex.Message);
            }
        }


    }
}
