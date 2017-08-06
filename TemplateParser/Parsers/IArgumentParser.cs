using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateParser.Elements;

namespace TemplateParser.Parsers
{
    interface IArgumentParser
    {
        void ProcessEntry(ITemplateEntry entry);
    }
}
