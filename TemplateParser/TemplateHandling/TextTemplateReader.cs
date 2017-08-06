using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateParser.Elements;

namespace TemplateParser.TemplateHandling
{
    class TextTemplateReader : ITemplateReader
    {
        StreamReader source;

        #region IDisposable

        public void Dispose()
        {
            source.Dispose();
        }

        #endregion

        #region Ctor

        public TextTemplateReader(string path)
        {
            source = new StreamReader(path);
        }

        #endregion

        #region ITemplateReader

        public bool IsComplete()
        {
            return source.EndOfStream;
        }

        public ITemplateEntry ReadEntry()
        {
            return new TextTemplateEntry(source.ReadLine());
        }

        #endregion
    }
}
