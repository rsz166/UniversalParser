using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateParser.Elements
{
    class SimpleVariable : IVariable
    {
        object data;

        public string Get(string argument = null, string format = null)
        {
            return (format != null) ? string.Format($"{{0:{format}}}", data) : data.ToString();
        }

        public void Set(object value, string argument = null)
        {
            data = value;
        }
    }
}
