using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATBM_HTTT_PH1.Model
{
    public class UserPermission(string userName, string tableName, string privilege, string owner, string grantor)
    {
        public string TableName { get; set; } = tableName;
        public string UserName { get; set; } = userName;
        public string Privilege { get; set; } = privilege;
        public string Owner { get; set; } = owner;
        public string Grantor { get; set; } = grantor;
    }
}
