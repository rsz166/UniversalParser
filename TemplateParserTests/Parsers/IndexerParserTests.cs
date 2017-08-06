using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemplateParser.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateParser.Parsers.Tests
{
    [TestClass()]
    public class IndexerParserTests
    {
        [TestMethod()]
        public void ParseSingleTest()
        {
            try
            {
                IndexerParser.ParseSingle("qwe");
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseSingle("");
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseSingle(null);
                Assert.Fail();
            }
            catch { }

            Assert.AreEqual(5, IndexerParser.ParseSingle("5"));
            Assert.AreEqual(5, IndexerParser.ParseSingle("0x5"));
            Assert.AreEqual(5, IndexerParser.ParseSingle("x5"));
            Assert.AreEqual(5, IndexerParser.ParseSingle("05"));
            Assert.AreEqual(10, IndexerParser.ParseSingle("10"));
            Assert.AreEqual(10, IndexerParser.ParseSingle("010"));
            Assert.AreEqual(10, IndexerParser.ParseSingle("0x0a"));
            Assert.AreEqual(10, IndexerParser.ParseSingle("0x0A"));
            Assert.AreEqual(16, IndexerParser.ParseSingle("x10"));
            Assert.AreEqual(16, IndexerParser.ParseSingle("0x10"));
            Assert.AreEqual(100, IndexerParser.ParseSingle("100"));
            Assert.AreEqual(255, IndexerParser.ParseSingle("0xFF"));
            Assert.AreEqual(255, IndexerParser.ParseSingle("xFF"));
        }

        [TestMethod()]
        public void ParseArrayTest()
        {
            IEnumerable<long> ret;
            try
            {
                IndexerParser.ParseArray("qwe");
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseArray("");
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseArray(null);
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseArray("1");
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseArray("1..");
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseArray("2..1");
                Assert.Fail();
            }
            catch { }

            ret = IndexerParser.ParseArray("1..3");
            Assert.AreEqual(3, ret.Count());
            Assert.AreEqual(1, ret.ElementAt(0));
            Assert.AreEqual(2, ret.ElementAt(1));
            Assert.AreEqual(3, ret.ElementAt(2));

            ret = IndexerParser.ParseArray("0..0");
            Assert.AreEqual(1, ret.Count());
            Assert.AreEqual(0, ret.ElementAt(0));

            ret = IndexerParser.ParseArray("-5..-5");
            Assert.AreEqual(1, ret.Count());
            Assert.AreEqual(-5, ret.ElementAt(0));

            ret = IndexerParser.ParseArray("-5..0");
            Assert.AreEqual(6, ret.Count());
            Assert.AreEqual(-5, ret.ElementAt(0));
            Assert.AreEqual(-4, ret.ElementAt(1));
            Assert.AreEqual(-3, ret.ElementAt(2));
            Assert.AreEqual(-2, ret.ElementAt(3));
            Assert.AreEqual(-1, ret.ElementAt(4));
            Assert.AreEqual(0, ret.ElementAt(5));

            ret = IndexerParser.ParseArray("0x0f..x11");
            Assert.AreEqual(3, ret.Count());
            Assert.AreEqual(15, ret.ElementAt(0));
            Assert.AreEqual(16, ret.ElementAt(1));
            Assert.AreEqual(17, ret.ElementAt(2));
        }

        [TestMethod()]
        public void ParseComplexTest()
        {
            IEnumerable<long> ret;
            try
            {
                IndexerParser.ParseComplex("qwe");
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseComplex("");
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseComplex(null);
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseComplex("1..");
                Assert.Fail();
            }
            catch { }
            try
            {
                IndexerParser.ParseComplex("2..1");
                Assert.Fail();
            }
            catch { }

            ret = IndexerParser.ParseComplex("5");
            Assert.AreEqual(1, ret.Count());
            Assert.AreEqual(5, ret.ElementAt(0));

            ret = IndexerParser.ParseComplex("0x5");
            Assert.AreEqual(1, ret.Count());
            Assert.AreEqual(5, ret.ElementAt(0));

            ret = IndexerParser.ParseComplex("0x10");
            Assert.AreEqual(1, ret.Count());
            Assert.AreEqual(16, ret.ElementAt(0));

            ret = IndexerParser.ParseComplex("1..3");
            Assert.AreEqual(3, ret.Count());
            Assert.AreEqual(1, ret.ElementAt(0));
            Assert.AreEqual(2, ret.ElementAt(1));
            Assert.AreEqual(3, ret.ElementAt(2));

            ret = IndexerParser.ParseComplex("1..3, 0, 5");
            Assert.AreEqual(5, ret.Count());
            Assert.AreEqual(1, ret.ElementAt(0));
            Assert.AreEqual(2, ret.ElementAt(1));
            Assert.AreEqual(3, ret.ElementAt(2));
            Assert.AreEqual(0, ret.ElementAt(3));
            Assert.AreEqual(5, ret.ElementAt(4));
        }
    }
}