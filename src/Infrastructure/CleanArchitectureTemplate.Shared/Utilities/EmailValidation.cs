using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Shared.Utilities
{
    public static class EmailValidation
    {
        public static bool IsValid(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string persianChar = @"[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]";
            //check first string
            if (!Regex.IsMatch(email, persianChar))
            {
                if (Regex.IsMatch(email, pattern))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
