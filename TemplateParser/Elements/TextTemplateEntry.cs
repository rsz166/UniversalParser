using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateParser.Elements
{
    class TextTemplateEntry : ITemplateEntry
    {
        string data;

        public TextTemplateEntry(string value)
        {
            data = value;
        }

        public string Get(string argument = null)
        {
            return data;
        }

        public void Set(object value, string argument = null)
        {
            data = value.ToString();
        }
    }
}
