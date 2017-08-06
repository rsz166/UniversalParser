using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateParser.Elements;

namespace TemplateParser.IoHandling
{
    class TextOutput : IOutputWriter
    {
        StreamWriter writer;

        public TextOutput(string path)
        {
            writer = new StreamWriter(path);
        }

        public void Dispose()
        {
            writer.Dispose();
        }

        public void WriteEntry(ITemplateEntry entry)
        {
            if (entry != null) writer.WriteLine(entry.Get());
        }
    }
}
