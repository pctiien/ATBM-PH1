﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATBM_HTTT_PH1.Model;

namespace ATBM_HTTT_PH1.Repository
{
    public interface IOracleRepository
    {

        Task<List<UserPermission>> getPermissionByUser(string userName);
        Task<List<string[]>> getPermissionByRole(string roleName);
        Task<List<string>> getRoles();
        Task<List<string[]>> getUsers();

        Task revokePermissionForUser(UserPermission userPermission);
        Task<List<string[]>> getPermissionByObject(string objectName);
        Task<List<string[]>> getObjectByType(string objectType);

        Task<bool> CreateUser(string username, string password, bool isDBA = false);
        Task<bool> DropUser(string username, bool cascade = false);
        Task<bool> AlterUser(string username, string newPassword = null, bool? locked = null);
    
  
        Task<bool> CreateRole(string roleName, string password = null);
        Task<bool> DropRole(string roleName);
        Task<bool> AlterRole(string roleName, string newPassword = null);
    
   
        Task<bool> GrantPrivilegeToUser(string privilege, string objectName, string username, bool withGrantOption = false);
        Task<bool> GrantPrivilegeToRole(string privilege, string objectName, string roleName);
        Task<bool> GrantRoleToUser(string roleName, string username);
        Task<bool> RevokePrivilegeFromUser(string privilege, string objectName, string username);
        Task<bool> RevokePrivilegeFromRole(string privilege, string objectName, string roleName);
        Task<bool> RevokeRoleFromUser(string roleName, string username);
    
        // New method for custom SQL execution
        Task<List<string[]>> ExecuteQuery(string sql, Dictionary<string, object> parameters = null);
    }
}
