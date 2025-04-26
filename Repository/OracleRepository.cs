using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATBM_HTTT_PH1.Model;
using ATBM_HTTT_PH1.Util;
using Microsoft.VisualBasic.ApplicationServices;
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


        private async Task<bool> ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(new OracleParameter(param.Key, param.Value));
                        }
                    }

                    await command.ExecuteNonQueryAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing SQL: {ex.Message}");
                return false;
            }
        }
        public async Task<List<string[]>> getPermissionByRole(string roleName)
        {
            var permissions = new List<string[]>();
            try
            {
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT DISTINCT TABLE_NAME,COLUMN_NAME, PRIVILEGE FROM ROLE_TAB_PRIVS WHERE ROLE = :roleName";
                    command.Parameters.Add(new OracleParameter("roleName", roleName));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string tableName = reader.IsDBNull(0) ? "N/A" : reader.GetString(0);
                            string columnName = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                            string priviledge = reader.IsDBNull(2) ? "N/A" : reader.GetString(2);

                            permissions.Add([tableName, columnName, priviledge]);
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

        public async Task<List<UserPermission>> getPermissionByUser(string userName)
        {
            var permissions = new List<UserPermission>();
            try
            {
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT DISTINCT TABLE_NAME, PRIVILEGE FROM DBA_TAB_PRIVS WHERE GRANTEE = :userName";
                    command.Parameters.Add(new OracleParameter("userName", userName));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            permissions.Add(new UserPermission(userName, reader.GetString(0), reader.GetString(1)));
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

        public async Task<List<string>> getRoles()
        {
            var roles = new List<string>();
            try
            {
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT ROLE FROM DBA_ROLES";
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            roles.Add(String.Format("{0}", reader.GetString(0)));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching roles", ex);
            }
            return roles;
        }

        public async Task<List<string[]>> getUsers()
        {
            var users = new List<string[]>();
            try
            {
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = @"
                        SELECT USERNAME, ACCOUNT_STATUS, CREATED
                        FROM DBA_USERS ";
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string username = reader.GetString(0);
                            string status = reader.GetString(1);
                            string created = reader.GetDateTime(2).ToString("yyyy-MM-dd");
                            users.Add([username, status, created]);
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

        public async Task<List<string>> GetUsersAndRoles()
        {
            var usersAndRoles = new List<string>();

            try
            {
                if (oracleConnection.State != System.Data.ConnectionState.Open)
                {
                    await oracleConnection.OpenAsync();
                }

                var command = oracleConnection.CreateCommand();
                command.CommandText = @"
                    SELECT USERNAME FROM ALL_USERS
                    UNION
                    SELECT ROLE FROM DBA_ROLES ";
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        usersAndRoles.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý lỗi tại đây
                Console.WriteLine($"Error: {ex.Message}");
            }

            return usersAndRoles;
        }

        public async Task revokePermissionForUser(UserPermission userPermission)
        {
            var users = new List<string[]>();
            try
            {
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = $"REVOKE {userPermission.Privilege} ON qltv.{userPermission.TableName} FROM {userPermission.UserName}";
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error revoking privilege for users", ex);
            }
        }
        public async Task<List<string[]>> ExecuteQuery(string sql, Dictionary<string, object> parameters = null)
        {
            var result = new List<string[]>();
            try
            {
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(new OracleParameter(param.Key, param.Value));
                        }
                    }

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string[] row = new string[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[i] = reader.IsDBNull(i) ? "N/A" : reader.GetValue(i).ToString();
                            }
                            result.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing query: {sql}", ex);
            }
            return result;
        }

        // User Management Methods
        public async Task<bool> CreateUser(string username, string password, bool isDBA = false)
        {
            string sql = $"CREATE USER {username} IDENTIFIED BY \"{password}\" " +
                         "DEFAULT TABLESPACE USERS TEMPORARY TABLESPACE TEMP";

            bool result = await ExecuteNonQuery(sql);

            // Grant basic privileges
            if (result)
            {
                await ExecuteNonQuery($"GRANT CREATE SESSION TO {username}");
                await ExecuteNonQuery($"GRANT UNLIMITED TABLESPACE TO {username}");

                if (isDBA)
                {
                    await ExecuteNonQuery($"GRANT DBA TO {username}");
                }
            }

            return result;
        }

        public async Task<bool> DropUser(string username, bool cascade = false)
        {
            string sql = $"DROP USER {username}" + (cascade ? " CASCADE" : "");
            return await ExecuteNonQuery(sql);
        }

        public async Task<bool> AlterUser(string username, string newPassword = null, bool? locked = null)
        {
            if (string.IsNullOrEmpty(newPassword) && !locked.HasValue)
            {
                return false;
            }

            string sql = $"ALTER USER {username}";

            if (!string.IsNullOrEmpty(newPassword))
            {
                sql += $" IDENTIFIED BY \"{newPassword}\"";
            }

            if (locked.HasValue)
            {
                sql += locked.Value ? " ACCOUNT LOCK" : " ACCOUNT UNLOCK";
            }

            return await ExecuteNonQuery(sql);
        }

        // Role Management Methods
        public async Task<bool> CreateRole(string roleName, string password = null)
        {
            string sql = $"CREATE ROLE {roleName}";

            if (!string.IsNullOrEmpty(password))
            {
                sql += $" IDENTIFIED BY \"{password}\"";
            }

            return await ExecuteNonQuery(sql);
        }

        public async Task<bool> DropRole(string roleName)
        {
            string sql = $"DROP ROLE {roleName}";
            return await ExecuteNonQuery(sql);
        }

        public async Task<bool> AlterRole(string roleName, string newPassword = null)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                return false;
            }

            string sql = $"ALTER ROLE {roleName} IDENTIFIED BY \"{newPassword}\"";
            return await ExecuteNonQuery(sql);
        }

        // Permission Management Methods
        public async Task<bool> GrantPrivilegeToUser(string privilege, string objectName, string username, bool withGrantOption = false)
        {
            string sql = $"GRANT {privilege} ON {objectName} TO {username}";

            if (withGrantOption)
            {
                sql += " WITH GRANT OPTION";
            }

            return await ExecuteNonQuery(sql);
        }

        public async Task<bool> GrantPrivilegeToRole(string privilege, string objectName, string roleName)
        {
            string sql = $"GRANT {privilege} ON {objectName} TO {roleName}";
            return await ExecuteNonQuery(sql);
        }

        public async Task<bool> GrantRoleToUser(string roleName, string username)
        {
            string sql = $"GRANT {roleName} TO {username}";
            return await ExecuteNonQuery(sql);
        }

        public async Task<bool> RevokePrivilegeFromUser(string privilege, string objectName, string username)
        {
            string sql = $"REVOKE {privilege} ON {objectName} FROM {username}";
            return await ExecuteNonQuery(sql);
        }

        public async Task<bool> RevokePrivilegeFromRole(string privilege, string objectName, string roleName)
        {
            string sql = $"REVOKE {privilege} ON {objectName} FROM {roleName}";
            return await ExecuteNonQuery(sql);
        }

        public async Task<bool> RevokeRoleFromUser(string roleName, string username)
        {
            string sql = $"REVOKE {roleName} FROM {username}";
            return await ExecuteNonQuery(sql);
        }

        public async Task<List<string>> GetObjectNamesByType(string objectType)
        {
            var objectNames = new List<string>();
            // Truy vấn lấy tên đối tượng dựa trên loại (TABLE, VIEW, PROCEDURE, FUNCTION)
            var command = oracleConnection.CreateCommand();
            if (objectType == "TABLE")
                command.CommandText = "SELECT TABLE_NAME FROM DBA_TABLES";
            else if (objectType == "VIEW")
                command.CommandText = "SELECT VIEW_NAME FROM DBA_VIEWS";
            else if (objectType == "PROCEDURE")
                command.CommandText = "SELECT OBJECT_NAME FROM DBA_PROCEDURES WHERE OBJECT_TYPE = 'PROCEDURE'";
            else if (objectType == "FUNCTION")
                command.CommandText = "SELECT OBJECT_NAME FROM DBA_PROCEDURES WHERE OBJECT_TYPE = 'FUNCTION'";

            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                objectNames.Add(reader.GetString(0));
            }
            return objectNames;
        }

        public async Task GrantPrivilege(string grantee, string privilege, string objectName, string objectType)
        {
            // Kiểm tra điều kiện nếu người dùng không chọn thông tin cần thiết
            if (string.IsNullOrEmpty(grantee))
            {
                MessageBox.Show("Vui lòng chọn người nhận quyền (user/role).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(privilege))
            {
                MessageBox.Show("Vui lòng chọn quyền cần cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(objectName))
            {
                MessageBox.Show("Vui lòng chọn đối tượng để cấp quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cấp quyền cho user/role
            var command = oracleConnection.CreateCommand();
            string grantQuery = $"GRANT {privilege} ON {objectName} TO {grantee}";


            command.CommandText = grantQuery;

            try
            {
                // Thực thi câu lệnh cấp quyền
                await command.ExecuteNonQueryAsync();
                MessageBox.Show("Cấp quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Nếu có lỗi trong quá trình cấp quyền, hiển thị thông báo lỗi
                MessageBox.Show($"Lỗi khi cấp quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
