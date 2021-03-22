using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAccess.Model
{
    public partial class Account : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Password))
                    return CheckPasswordReq();
                return string.Empty;
            }
        }

        private string CheckPasswordReq()
        {
            if (string.Equals(Password, "password", StringComparison.OrdinalIgnoreCase))
            {
                return "Gotcha!";
            }
            return string.Empty;
        }

        public string Error { get; set; }
    }
}
