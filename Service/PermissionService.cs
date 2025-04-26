using System.Collections.Generic;
using System.Threading.Tasks;
using ATBM_HTTT_PH1.Repository;

namespace ATBM_HTTT_PH1.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IOracleRepository _oracleRepository;

        public PermissionService(IOracleRepository oracleRepository)
        {
            _oracleRepository = oracleRepository;
        }

        public async Task<List<string>> GetGrantees()
        {
            return await _oracleRepository.GetUsersAndRoles();
        }

        public async Task<List<string>> GetObjectNamesByType(string objectType)
        {
            return await _oracleRepository.GetObjectNamesByType(objectType);
        }

        public async Task GrantPrivilege(string grantee, string privilege, string objectName, string objectType)
        {
            await _oracleRepository.GrantPrivilege(grantee, privilege, objectName, objectType);
        }



    }
}
