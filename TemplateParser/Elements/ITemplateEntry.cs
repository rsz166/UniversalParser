using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateParser.Elements
{
    interface ITemplateEntry
    {
        string Get(string argument = null);
        void Set(object value, string argument = null);
    }
}
