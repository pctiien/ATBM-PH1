using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATBM_HTTT_PH1.Repository;
using ATBM_HTTT_PH1.Service;
using ATBM_HTTT_PH1.Util;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;

namespace ATBM_HTTT_PH1.Forms
{
    public partial class LoginForm : Form
    {
        private readonly ServiceCollection services;
        public LoginForm(ServiceCollection services)
        {
            InitializeComponent();
            this.services = services;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string connectionString;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string serviceNameOrSID = txtServiceName.Text;
         
            try
            {
                var oracleConfig = OracleConfig.GetOracleConfig();
                connectionString = $"User Id={username};Password={password};Data Source={oracleConfig.HostName}:{oracleConfig.OraclePort}/{serviceNameOrSID};";
                
                if (username.Equals("SYS"))
                    connectionString += "DBA Privilege = SYSDBA;";

                var factory = new OracleConnectionFactory(connectionString);
                factory.createConnection();

                services.AddSingleton(new OracleConnectionFactory(connectionString));
                services.AddScoped(provider =>
                {
                    var factory = provider.GetRequiredService<OracleConnectionFactory>();
                    return factory.createConnection();
                });
                services.AddScoped<IOracleRepository, OracleRepository>();

                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var serviceProvider = services.BuildServiceProvider();
                var userForm = serviceProvider.GetRequiredService<UserForm>();

                Hide();

                userForm.FormClosed += (s, args) => Close();
                userForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
