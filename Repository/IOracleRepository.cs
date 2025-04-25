using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATBM_HTTT_PH1.Repository
{
    public interface IOracleRepository
    {

        Task<List<string>> getPermissionByUser(string userName);
        Task<List<string>> getPermissionByRole(string roleName);

        Task<List<string>> getUsers();
    }
}
