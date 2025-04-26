using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATBM_HTTT_PH1.Service
{
    public interface IObjectService
    {
        Task<List<string[]>> getObjectByType(string objectType);
        Task<List<string[]>> getPermissionByObject(string objectName);
    }
}
