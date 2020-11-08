using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NurseryVan_System
{
    class EmailforbeforeValidate
    {
        public static bool emailbeforevalidate1(string email1)
        {


            bool isValid = true;

            Regex r = new Regex(@"^()@([\.\w\-]+)(((\w){2,35})+)$");


            if (r.IsMatch(email1))

                isValid = false;
            return isValid;
        }
    }
}
