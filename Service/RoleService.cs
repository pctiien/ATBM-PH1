using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATBM_HTTT_PH1.Repository;
using Oracle.ManagedDataAccess.Client;

namespace ATBM_HTTT_PH1.Service
{
    public class RoleService : IRoleService
    {
        private IOracleRepository oracleRepository;
        public RoleService(IOracleRepository oracleRepository)
        {
            this.oracleRepository = oracleRepository;
        }

        public async Task<List<string[]>> getPermissionsByRole(string roleName)
        {
            return await oracleRepository.getPermissionByRole(roleName);
        }

        public async Task<List<string>> getRoles()
        {
            return await oracleRepository.getRoles();
        }
    }
}
