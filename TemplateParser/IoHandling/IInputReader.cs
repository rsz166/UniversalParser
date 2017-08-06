using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateParser.Elements;

namespace TemplateParser.IoHandling
{
    /// <summary>
    /// Classes that loads external source files shall implement this interface.
    /// </summary>
    interface IInputReader
    {
        IVariable GetVariable(string argument);
    }
}
