using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateParser.Elements;

namespace TemplateParser.TemplateHandling
{
    interface ITemplateReader : IDisposable
    {
        bool IsComplete();
        ITemplateEntry ReadEntry();
    }
}
