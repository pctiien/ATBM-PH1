using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATBM_HTTT_PH1.Service
{
    public interface IPermissionService
    {
        Task<List<string>> GetGrantees(); // Lấy danh sách user/role
        Task<List<string>> GetObjectNamesByType(string objectType); // Lấy tên đối tượng theo loại
        Task GrantPrivilege(string grantee, string privilege, string objectName, string objectType); // Cấp quyền
    }
}
