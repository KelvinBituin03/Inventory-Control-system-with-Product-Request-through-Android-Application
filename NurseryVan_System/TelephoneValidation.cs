﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NurseryVan_System
{
    class TelephoneValidation
    {
        public static bool TelephoneNumber(string email)
        {
            bool isValid = false;

            // Regex r = new Regex((@"^(0011)(([ ][0-9]{3}){3})$"));
            //  Regex r = new Regex((@"^\d{4}\d{3}\d{4}"));
            Regex r = new Regex((@"^(\(?\d{2}\)?-? *\d{3}-? *-?\d{4})"));
            if (r.IsMatch(email))

                isValid = true;
            return isValid;
        }
    }
}
