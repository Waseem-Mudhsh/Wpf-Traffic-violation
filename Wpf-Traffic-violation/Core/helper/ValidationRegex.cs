using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wpf_Traffic_violation.Services.helper
{
    public class ValidationRegex
    {
        public string nameOfSp(string sqlScript)
        {
            string pattern = @"CREATE\s+PROCEDURE\s+\[dbo\]\.\[(\w+)\]";

            // Use Regex.Match to find the first match in the script
            Match match = Regex.Match(sqlScript, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                // Extract the stored procedure name from the captured group
                return match.Groups[1].Value;
            }
            else
            {
                // Handle the case where no match is found
                return "No stored procedure found";
            }
        
        }
    }
}
