using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATBM_HTTT_PH1.Service
{
    public interface IUserService
    {
        Task<List<string>> getUsers();
        Task<List<string>> getPermissionsByUser(string userName);
    }
}
