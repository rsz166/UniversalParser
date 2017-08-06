using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TemplateParser.Elements;
using TemplateParser.Parsers;

namespace TemplateParser.IoHandling
{
    class BinarySource : IInputReader
    {
        BinaryReader reader;

        public BinarySource(string path)
        {
            reader = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read));
        }

        private byte GetByte(long offset)
        {
            if(reader.BaseStream.Position != offset) reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            return reader.ReadByte();
        }

        public IVariable GetVariable(string argument)
        {
            string cmd;
            var locations = IndexerParser.ParseComplexOperation(argument, out cmd);
            var values = locations.Select(GetByte);
            var ret = new SimpleVariable();
            switch (cmd)
            {
                case "sum":
                    ulong sum = 0;
                    foreach (var item in values) sum += item;
                    ret.Set(sum);
                    break;
                case "avg": ret.Set(values.Average(x => x)); break;
                case "min": ret.Set(values.Min()); break;
                case "max": ret.Set(values.Max()); break;
                case "xor":
                    byte xor = 0;
                    foreach (var item in values) xor ^= item;
                    ret.Set(xor);
                    break;
                default: break;
            }
            return ret;
        }
    }
}
