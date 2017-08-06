using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateParser.Elements
{
    /// <summary>
    /// Classes that handles variables of template shall implement this interface.
    /// </summary>
    interface IVariable
    {
        string Get(string argument = null, string format = null);
        void Set(object value, string argument = null);
    }
}
