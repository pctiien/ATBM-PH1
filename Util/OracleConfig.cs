using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace ATBM_HTTT_PH1.Util
{
    public class OracleConfig
    {
        public string? OraclePort { get; set; }
        public string? HostName { get; set; }

        public static OracleConfig GetOracleConfig()
        {
            var config = new OracleConfig();

            string? projectDirectory = Directory.GetCurrentDirectory();
            if (projectDirectory != null)
            {
                var parentDirectory = Directory.GetParent(projectDirectory)?.Parent?.Parent?.FullName;
                if (parentDirectory != null)
                {
                    string envFilePath = Path.Combine(parentDirectory, ".env");
                    Env.Load(envFilePath);
                }
            }

            config.OraclePort = Environment.GetEnvironmentVariable("ORACLE_PORT");
            config.HostName = Environment.GetEnvironmentVariable("ORACLE_HOSTNAME");

            return config;
        }
    }
}
