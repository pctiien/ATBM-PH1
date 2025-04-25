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

            services.AddTransient<UserForm>();
            services.AddTransient<RoleForm>();
            services.AddTransient<MainForm>();

            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            Application.Run(new LoginForm(services));
        }

    }
}