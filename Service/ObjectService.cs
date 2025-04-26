using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATBM_HTTT_PH1.Repository;

namespace ATBM_HTTT_PH1.Service
{
    public class ObjectService : IObjectService
    {
        private IOracleRepository oracleRepository;
        public ObjectService(IOracleRepository oracleRepository)
        {
            this.oracleRepository = oracleRepository;
        }
        public async Task<List<string[]>> getObjectByType(string objectType)
        {
            return await oracleRepository.getObjectByType(objectType);
        }

        public async Task<List<string[]>> getPermissionByObject(string objectName)
        {
            return await oracleRepository.getPermissionByObject(objectName);
        }
    }
}
