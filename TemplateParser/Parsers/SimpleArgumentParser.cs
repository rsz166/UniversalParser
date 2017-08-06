using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TemplateParser.Elements;

namespace TemplateParser.Parsers
{
    class SimpleArgumentParser : IArgumentParser
    {
        public void ProcessEntry(ITemplateEntry entry)
        {
            string source = entry.Get();
            StringBuilder dest = new StringBuilder();
            int start = -1;
            for (int i = 0; i < source.Length; i++)
            {
                if (start < 0)
                {
                    if(source[i] == '{' && (i == 0 || source[i - 1] != '\\'))
                    {
                        start = i + 1;
                    }
                    else
                    {
                        dest.Append(source[i]);
                    }
                }
                else
                {
                    if (source[i] == '}' && source[i - 1] != '\\')
                    {
                        dest.Append(ProcessArgument(source.Substring(start, i - start - 1)));
                        start = -1;
                    }
                }
            }
        }

        private char ProcessArgument(string arg)
        {
            throw new NotImplementedException();
        }
    }
}
