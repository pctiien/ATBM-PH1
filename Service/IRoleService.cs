using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATBM_HTTT_PH1.Service
{
    public interface IRoleService
    {
        Task<List<string[]>> getPermissionsByRole(string roleName);
        Task<List<string>> getRoles();
    }
}
