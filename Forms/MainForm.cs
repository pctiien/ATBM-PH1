using System;
using System.Windows.Forms;
using ATBM_HTTT_PH1.Service;

namespace ATBM_HTTT_PH1.Forms
{
    public partial class MainForm : Form
    {
        private readonly RoleForm roleForm;
        private readonly UserForm userForm;
        private readonly ObjectForm objectForm;

        public MainForm(RoleForm roleForm, UserForm userForm, ObjectForm objectForm)
        {
            this.roleForm = roleForm;
            this.userForm = userForm;
            this.objectForm = objectForm;
            InitializeComponent();

            LoadFormToTab(roleForm, tabRoles);
            LoadFormToTab(userForm, tabUsers);
            LoadFormToTab(objectForm, tabObjects);
        }

        private void LoadFormToTab(Form form, TabPage tabPage)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tabPage.Controls.Add(form);
            form.Show();
        }
    }
}
