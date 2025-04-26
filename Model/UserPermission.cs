using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATBM_HTTT_PH1.Model
{
    public class UserPermission(string tableName, string userName, string privilege)
    {
        public string TableName { get; set; } = tableName;
        public string UserName { get; set; } = userName;
        public string Privilege { get; set; } = privilege;
    }
}
