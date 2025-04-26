using Microsoft.Extensions.DependencyInjection;
using ATBM_HTTT_PH1.Util;
using ATBM_HTTT_PH1.Repository;
using ATBM_HTTT_PH1.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DotNetEnv;
using Oracle.ManagedDataAccess.Client;
using ATBM_HTTT_PH1.Forms;
namespace ATBM_HTTT_PH1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var services = new ServiceCollection();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOracleRepository, OracleRepository>();
            services.AddScoped<IPermissionService, PermissionService>();

            services.AddTransient<UserForm>();
            services.AddTransient<RoleForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<GrantPermissionForm>();


            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            var loginForm = new LoginForm(services);
            Application.Run(loginForm);  // Kh�ng g�n gi� tr? tr? v? v�o bi?n

            // Sau khi ��ng nh?p th�nh c�ng, m? GrantPermissionForm
            if (loginForm.DialogResult == DialogResult.OK) // Ki?m tra khi ng�?i d�ng ��ng nh?p th�nh c�ng
            {
                var grantPermissionForm = serviceProvider.GetService<GrantPermissionForm>();
                Application.Run(grantPermissionForm);
            }
        }

    }
}