using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
            string pattern = @"^[a-z]\w{7,12}$";
            if (Regex.Match(Password,pattern,RegexOptions.IgnoreCase).Value != string.Empty || string.Equals(password,"None",StringComparison.Ordinal))
            {
                return string.Empty;
            }
            return $"{Password} didn`t match security requirements!";
        }

        public string Error { get; set; }
    }
}
