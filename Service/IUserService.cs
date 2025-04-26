using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATBM_HTTT_PH1.Model;

namespace ATBM_HTTT_PH1.Service
{
    public interface IUserService
    {
        Task<List<string[]>> getUsers();
        Task<List<UserPermission>> getPermissionsByUser(string userName);
        Task<List<string>> getRolesByUser(string userName);

        Task revokePermissionForUser(UserPermission userPermission);
    }
}
