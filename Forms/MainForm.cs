using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATBM_HTTT_PH1.Service;

namespace ATBM_HTTT_PH1.Forms
{
    public partial class MainForm : Form
    {
        private readonly RoleForm roleForm;
        private readonly UserForm userForm;
        private readonly GrantPermissionForm grantForm;
        public MainForm(RoleForm roleForm, UserForm userForm, GrantPermissionForm grantForm)
        {
            this.roleForm = roleForm;
            this.userForm = userForm;
            this.grantForm = grantForm;
            InitializeComponent();

            // Initialize RoleForm and embed it in the Roles tab
            roleForm.TopLevel = false;
            roleForm.FormBorderStyle = FormBorderStyle.None;
            roleForm.Dock = DockStyle.Fill; 

            tabRoles.Controls.Add(roleForm);
            roleForm.Show();

            // Initialize UserForm and embed it in the Users tab
            userForm.TopLevel = false;
            userForm.FormBorderStyle = FormBorderStyle.None;
            userForm.Dock = DockStyle.Fill;

            tabUsers.Controls.Add(userForm);
            userForm.Show();

            // Initialize UserForm and embed it in the Grants tab
            grantForm.TopLevel = false;
            grantForm.FormBorderStyle = FormBorderStyle.None;
            grantForm.Dock = DockStyle.Fill;

            tabGrants.Controls.Add(grantForm);
            grantForm.Show();
        }
    }
}
