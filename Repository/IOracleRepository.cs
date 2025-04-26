using System;
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
    }
}
