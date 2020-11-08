using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NurseryVan_System
{
    class EmailforafterValidate
    {
        public static bool aftervalidate(string email2)
        {


            bool isValid = true;

            Regex r = new Regex(@"^([\.\w\-]+)(((\w){2,35})()@+)$");


            if (r.IsMatch(email2))

                isValid = false;
            return isValid;
        }
    }
}
