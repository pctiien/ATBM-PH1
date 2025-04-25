using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATBM_HTTT_PH1.Util;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ATBM_HTTT_PH1.Repository
{
    public class OracleRepository : IOracleRepository
    {
        private readonly OracleConnection oracleConnection;
        public OracleRepository(OracleConnection _oracleConnection)
        {
            this.oracleConnection = _oracleConnection;
        }
        


        public async Task<List<string>> getPermissionByRole(string roleName)
        {
            var permissions = new List<string>();
            try
            {
                    using (var command = oracleConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "SELECT TABLE_NAME, PRIVILEGE FROM DBA_TAB_PRIVS WHERE GRANTOR = :roleName";
                        command.Parameters.Add(new OracleParameter("roleName", roleName));

                        using(var reader = await command.ExecuteReaderAsync())
                        {
                            while(await reader.ReadAsync())
                            {
                                permissions.Add(String.Format("{0} ON {1}",reader.GetString(1),reader.GetString(0)));
                            }
                        }

                    }
            }
            catch (Exception ex) { 
                throw new InvalidOperationException("Error fetching permissions for user",ex);
            }
            return permissions;

        }

        public async Task<List<string>> getPermissionByUser(string userName)
        {
            var permissions = new List<string>();
            try
            {
                    using (var command = oracleConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "SELECT TABLE_NAME, PRIVILEGE FROM DBA_TAB_PRIVS WHERE GRANTOR = :userName";
                        command.Parameters.Add(new OracleParameter("userName", userName));

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                permissions.Add(String.Format("{0} ON {1}", reader.GetString(1), reader.GetString(0)));
                            }
                        }

                    }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching permissions for user", ex);
            }
            return permissions;
        }

        public async Task<List<string>> getUsers()
        {
            var users = new List<string>();
            try
            {
                    using (var command = oracleConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = @"
                        SELECT USERNAME 
                        FROM DBA_USERS ";
                    using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                users.Add(String.Format("{0}",reader.GetString(0)));
                            }
                        }

                    }
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error fetching users", ex);
            }
            return users;
        }
    }
}
