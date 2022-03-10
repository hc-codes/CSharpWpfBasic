using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WpfDataGrid
{
    public class Validators
    {
        public static bool  PhoneValidator(string n)
        {
            string pattern = "^(([0-9]|\\+)(\\d{9})|(\\d{11}))$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(n);
        }
    }

}
