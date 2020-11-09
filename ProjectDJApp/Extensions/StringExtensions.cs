using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectDJApp.Extensions
{
    public static class StringExtensions
    {
        public static string FixTrackName(this string name)
        {
            string pattern = @"\s[—–−-]\s";
            string target = " ";
            Regex regex = new Regex(pattern);
            return regex.Replace(name, target); 
        }
    }
}
