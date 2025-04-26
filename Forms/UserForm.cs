using ATBM_HTTT_PH1.Model;
using ATBM_HTTT_PH1.Service;

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
            string tableName = listViewPermissions.SelectedItems[0].Text;
            string privilege = listViewPermissions.SelectedItems[0].SubItems[1].Text;

            var confirm = MessageBox.Show($"Xác nhận thu hồi quyền {privilege} trên bảng {tableName} của người dùng {userName}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                var permission = new UserPermission(tableName, userName, privilege);
                await userService.revokePermissionForUser(permission);
                await LoadUserPermissionsAsync(userName);
            }
        }
    }
}
