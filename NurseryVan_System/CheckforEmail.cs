using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NurseryVan_System
{
    class CheckforEmail
    {
        public static bool checkForEmail(string email)
        {


            bool isValid = false;

            Regex r = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z]*[a-z]$");

            if (r.IsMatch(email))

                isValid = true;
            return isValid;
        }
    }
}
