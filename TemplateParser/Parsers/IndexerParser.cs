using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TemplateParser.Parsers
{
    public class IndexerParser
    {
        public static long ParseSingle(string argument)
        {
            long ret = 0;
            if (string.IsNullOrWhiteSpace(argument)) throw new ArgumentException("Argument is empty");
            if(argument.StartsWith("0x") || argument.StartsWith("x"))
            {
                // hex
                argument = argument.TrimStart('0', 'x');
                ret = long.Parse(argument, System.Globalization.NumberStyles.HexNumber);
            }
            else ret = long.Parse(argument);
            return ret;
        }

        public static IEnumerable<long> ParseArray(string argument)
        {
            var parts = argument.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) throw new ArgumentException("Argument is not an array");
            long start = ParseSingle(parts[0]);
            long end = ParseSingle(parts[1]);
            long[] ret = new long[end - start + 1];
            for (int i = 0; i <= end - start; i++)
            {
                ret[i] = start + i;
            }
            return ret;
        }

        public static IEnumerable<long> ParseComplex(string argument)
        {
            var parts = argument.Split(',');
            var ret = new List<long>();
            foreach (var part in parts)
            {
                if (part.Contains("..")) ret.AddRange(ParseArray(part));
                else ret.Add(ParseSingle(part));
            }
            return ret;
        }
        
        public static IEnumerable<long> ParseComplexOperation(string argument, out string cmdStr)
        {
            Regex regex = new Regex(@"^((?<cmd>sum|avg|min|max|xor)\()?(?<arg>(\d|\s|\.|,)+)(\))?$",
                            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            var match = regex.Match(argument);
            if (!match.Success) throw new ArgumentException("Unable to parse argument");
            var arg = match.Groups["arg"];
            if (!arg.Success) throw new ArgumentException("Unable to parse argument");
            var cmd = match.Groups["cmd"];
            cmdStr = cmd.Success ? cmd.Value : null;
            return ParseComplex(arg.Value);
        }
    }
}
