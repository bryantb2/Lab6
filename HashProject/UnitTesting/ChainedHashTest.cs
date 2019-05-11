using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTableLibrary;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    class ChainedHashTest
    {
        ChainedHash definedChainedTable;
        ChainedHash defaultChainTable;

        [SetUp]
        public void TestSetup()
        {
            definedChainedTable = new ChainedHash(17);
            defaultChainTable = new ChainedHash();
        }

        [Test]
        public void SizePropertyTest()
        {
            Assert.AreEqual(17, definedChainedTable.Size);
            Assert.AreEqual(11, defaultChainTable.Size);
        }

        [Test]
        public void AddItemTest()
        {
            try
            {
                defaultChainTable.AddItem("");
                Assert.Fail("AddItem did not throw an exception");
            }
            catch (ArgumentException)
            {
                Assert.Pass("The AddItem method threw an exception!");
            }
        }

        [Test]
        public void AddandFindTest()
        {
            defaultChainTable.AddItem("obi-wan");
            defaultChainTable.AddItem("anakin");
            defaultChainTable.AddItem("grevious");
            defaultChainTable.AddItem("vader");
            try
            {
                defaultChainTable.FindItem("");
                Assert.Fail("FindItem did not throw an exception");
            }
            catch (ArgumentException)
            {
                Assert.Pass("The AddItem method threw an exception!");
            }
            Assert.AreEqual(true, defaultChainTable.FindItem("vader"));
            Assert.AreEqual(true, defaultChainTable.FindItem("grevious"));
            Assert.AreEqual(true, defaultChainTable.FindItem("obi-wan"));
            Assert.AreEqual(true, defaultChainTable.FindItem("anakin"));
            Assert.AreEqual(false, defaultChainTable.FindItem("rader"));
        }

        [Test]
        public void FindAndRemoveTest()
        {
            int originalSize = defaultChainTable.Size;
            defaultChainTable.AddItem("obi-wan");
            defaultChainTable.AddItem("anakin");
            defaultChainTable.AddItem("grevious");
            defaultChainTable.AddItem("vader");
            defaultChainTable.AddItem("abc");
            defaultChainTable.AddItem("123");
            defaultChainTable.AddItem("890");
            defaultChainTable.RemoveItem("890");
            defaultChainTable.RemoveItem("anakin");
            Assert.AreEqual(false, defaultChainTable.FindItem("890"));
            Assert.AreEqual(false, defaultChainTable.FindItem("anakin"));
        }
    }
}
