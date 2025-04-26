using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATBM_HTTT_PH1.Service;

namespace ATBM_HTTT_PH1.Forms
{
    public partial class GrantPermissionForm : Form
    {
        private readonly IPermissionService _permissionService;

        public GrantPermissionForm(IPermissionService permissionService)
        {
            _permissionService = permissionService;
            InitializeComponent();
        }

        private async void GrantPermissionForm_Load(object sender, EventArgs e)
        {
            // Load danh sách user/role vào ListView clbGrantee
            var grantees = await _permissionService.GetGrantees(); // Hàm lấy user/role
            foreach (var grantee in grantees)
            {
                clbGrantee.Items.Add(grantee);
                cmbGrantee.Items.Add(grantee);
            }

            // Load các quyền vào CheckedListBox clbPrivilege
            clbPrivilege.Items.AddRange(new object[] { "SELECT", "INSERT", "UPDATE", "DELETE", "EXECUTE" });

            // Mặc định chọn 'TABLE' cho ComboBox cbObjectType
            cbObjectType.SelectedIndex = 0;


        }

        private async void cbObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string objectType = cbObjectType.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(objectType))
            {
                // Lấy tên đối tượng từ CSDL theo loại đối tượng
                var objectNames = await _permissionService.GetObjectNamesByType(objectType);

                // Xóa các item cũ trong ComboBox cbObjectName
                cbObjectName.Items.Clear();

                // Thêm các item mới vào ComboBox cbObjectName
                cbObjectName.Items.AddRange(objectNames.ToArray());

                // Nếu có ít nhất một đối tượng, chọn cái đầu tiên làm mặc định
                if (objectNames.Count > 0)
                {
                    cbObjectName.SelectedIndex = 0;
                }
            }
        }


        private async void btnGrant_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ CheckedListBox clbGrantee và ComboBox cbGranteeComboBox
            var selectedGrantees = clbGrantee.CheckedItems.Cast<string>().ToList();
            var selectedGranteeFromComboBox = cmbGrantee.SelectedItem?.ToString(); // Lấy người dùng/role từ ComboBox

            // Nếu người dùng chọn từ ComboBox, thêm vào danh sách của CheckedListBox
            if (!string.IsNullOrEmpty(selectedGranteeFromComboBox) && !selectedGrantees.Contains(selectedGranteeFromComboBox))
            {
                selectedGrantees.Add(selectedGranteeFromComboBox);
            }

            var selectedPrivileges = clbPrivilege.CheckedItems.Cast<string>().ToList();
            var objectName = cbObjectName.SelectedItem?.ToString();
            var objectType = cbObjectType.SelectedItem?.ToString();

            if (selectedGrantees.Count == 0 || selectedPrivileges.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một người dùng/role và một quyền.");
                return;
            }

            if (string.IsNullOrEmpty(objectName) || string.IsNullOrEmpty(objectType))
            {
                MessageBox.Show("Vui lòng chọn loại đối tượng và tên đối tượng.");
                return;
            }

            foreach (string grantee in selectedGrantees)
            {
                foreach (string privilege in selectedPrivileges)
                {
                    try
                    {
                        await _permissionService.GrantPrivilege(grantee, privilege, objectName, objectType);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cấp quyền {privilege} cho {grantee}: {ex.Message}");
                    }
                }
            }
        }

    }
}
