using ATBM_HTTT_PH1.Service;

namespace ATBM_HTTT_PH1
{
    public partial class UserForm : Form
    {
        private readonly IUserService userService;

        public UserForm(IUserService _userService)
        {
            this.userService = _userService;
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadUserListAsync();
        }

        private async Task LoadUserListAsync()
        {
            try
            {
                // Lấy danh sách người dùng (có 3 cột: Username, Account Status, Created Date)
                List<string[]> users = await userService.getUsers();

                listView1.Items.Clear();

                foreach (var user in users)
                {
                    // Kiểm tra chắc chắn có đủ 3 trường
                    if (user.Length >= 3)
                    {
                        // Tạo một item cho mỗi người dùng
                        var item = new ListViewItem(user[0]); // Username
                        item.SubItems.Add(user[1]); // Account Status
                        item.SubItems.Add(user[2]); // Created Date
                        listView1.Items.Add(item);
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

        private async void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            // Lấy tên người dùng được chọn từ ListView
            var selectedUser = listView1.SelectedItems[0].Text;

            // Truy vấn các quyền của người dùng
            try
            {
                var permissions = await userService.getPermissionsByUser(selectedUser);

                // Hiển thị quyền vào ListView hoặc Label (tùy theo yêu cầu)
                listViewPermissions.Items.Clear(); // Xóa danh sách cũ

                foreach (var permission in permissions)
                {
                    var item = new ListViewItem(permission);
                    listViewPermissions.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải quyền người dùng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadUserListAsync();
        }
    }
}
