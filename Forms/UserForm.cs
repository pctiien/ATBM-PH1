using ATBM_HTTT_PH1.Model;
using ATBM_HTTT_PH1.Service;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ATBM_HTTT_PH1
{
    public partial class UserForm : Form
    {
        private readonly IUserService userService;

        public UserForm(IUserService _userService)
        {
            userService = _userService;
            InitializeComponent();
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            await LoadUserListAsync();
        }

        private async Task LoadUserListAsync()
        {
            try
            {
                var users = await userService.getUsers();
                listViewUsers.Items.Clear();

                foreach (var user in users)
                {
                    if (user.Length >= 3)
                    {
                        var item = new ListViewItem(user[0]);
                        item.SubItems.Add(user[1]);
                        item.SubItems.Add(user[2]);
                        listViewUsers.Items.Add(item);
                    }
                }

                if (users.Count == 0)
                {
                    MessageBox.Show("Không có người dùng nào được tìm thấy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách người dùng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUserPermissionsAsync(string userName)
        {
            try
            {
                var permissions = await userService.getPermissionsByUser(userName);
                listViewPermissions.Items.Clear();

                foreach (var permission in permissions)
                {
                    var item = new ListViewItem(permission.TableName);
                    item.SubItems.Add(permission.Privilege);
                    item.SubItems.Add(permission.Owner);
                    item.SubItems.Add(permission.Grantor);
                    listViewPermissions.Items.Add(item);
                }

                lblSelectedUser.Text = $"Quyền của người dùng: {userName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải quyền người dùng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count == 0)
                return;

            var selectedUser = listViewUsers.SelectedItems[0].Text;
            await LoadUserPermissionsAsync(selectedUser);
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadUserListAsync();
            listViewPermissions.Items.Clear();
            lblSelectedUser.Text = "";
        }


        private async void BtnRevokePermission_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count == 0 || listViewPermissions.SelectedItems.Count == 0)
                return;

            string userName = listViewUsers.SelectedItems[0].Text;

            // Lấy các thông tin từ listViewPermissions
            var selectedItem = listViewPermissions.SelectedItems[0];
            string tableName = selectedItem.SubItems[0].Text;
            string privilege = selectedItem.SubItems[1].Text;
            string owner = selectedItem.SubItems[2].Text;

            var confirm = MessageBox.Show(
                $"Xác nhận thu hồi quyền {privilege} trên bảng {tableName} của người dùng {userName}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                var permission = new UserPermission(userName, tableName, privilege, owner, null); // Grantor không cần khi revoke
                await userService.revokePermissionForUser(permission);
                await LoadUserPermissionsAsync(userName);
            }
        }
        private void BtnGrantPermissionToUser_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim().ToUpper();
            string objectName = txtObject.Text.Trim().ToUpper();
            string column = string.IsNullOrWhiteSpace(txtColumn.Text) ? null : txtColumn.Text.Trim().ToUpper();
            string privilege = cmbPrivilege.SelectedItem?.ToString();
            string grantOption = chkWithGrant.Checked ? "Y" : "N";

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(objectName) || string.IsNullOrEmpty(privilege))
            {
                MessageBox.Show("Vui lòng nhập user, object name và chọn quyền.");
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
                    cmd.Parameters.Add("p_object", OracleDbType.Varchar2).Value = objectName;
                    cmd.Parameters.Add("p_column", OracleDbType.Varchar2).Value = column;
                    cmd.Parameters.Add("p_grantee", OracleDbType.Varchar2).Value = user;
                    cmd.Parameters.Add("p_grant_opt", OracleDbType.Varchar2).Value = grantOption;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã cấp quyền cho user " + user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cấp quyền: " + ex.Message);
            }
        }
        private void BtnGrantRoleToUser_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim().ToUpper();
            string role = txtRole.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng nhập user và role.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=ADMIN;Password=123456;Data Source=localhost:1521/XEPDB1"))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"GRANT {role} TO {user}";

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã cấp role " + role + " cho user " + user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cấp role: " + ex.Message);
            }
        }
        private void BtnCreateUser_Click(object sender, EventArgs e)
        {
            string user = txtNewUsername.Text.Trim().ToUpper();
            string password = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu cho user:", "Tạo User", "");

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên user và mật khẩu.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=ADMIN;Password=123456;Data Source=localhost:1521/XEPDB1"))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand($"CREATE USER {user} IDENTIFIED BY {password}", conn);
                    cmd.ExecuteNonQuery();

                    OracleCommand grantCmd = new OracleCommand($"GRANT CONNECT TO {user}", conn);
                    grantCmd.ExecuteNonQuery();

                    MessageBox.Show($"Đã tạo user {user} thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo user: {ex.Message}");
            }
        }

        private async void BtnDropUser_Click(object sender, EventArgs e)
        {
            string user = txtNewUsername.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Vui lòng nhập tên user cần xóa.");
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa user {user}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=ADMIN;Password=123456;Data Source=localhost:1521/XEPDB1"))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand($"DROP USER {user} CASCADE", conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Đã xóa user {user} thành công.");
                }

                await LoadUserListAsync(); // Refresh danh sách user
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa user: {ex.Message}");
            }
        }
        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string user = txtNewUsername.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Vui lòng nhập tên user cần đổi mật khẩu.");
                return;
            }

            string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu mới:", "Đổi mật khẩu", "");
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection("User Id=ADMIN;Password=123456;Data Source=localhost:1521/XEPDB1"))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand($"ALTER USER {user} IDENTIFIED BY {newPassword}", conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Đã đổi mật khẩu cho user {user} thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đổi mật khẩu: {ex.Message}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
