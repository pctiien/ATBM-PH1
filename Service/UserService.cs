using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATBM_HTTT_PH1.Repository;

namespace ATBM_HTTT_PH1.Service
{
    public class UserService : IUserService
    {
        private readonly IOracleRepository oracleRepository ;
        public UserService(IOracleRepository _oracleRepository)
        {
            oracleRepository = _oracleRepository;
        }
        public async Task<List<string>> getPermissionsByUser(string userName)
        {
            return await oracleRepository.getPermissionByUser(userName);
        }

        public async Task<List<string>> getUsers()
        {
            return await oracleRepository.getUsers();
        }
    }
}
