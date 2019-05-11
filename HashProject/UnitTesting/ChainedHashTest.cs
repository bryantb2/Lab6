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
            Assert.AreEqual(true, defaultChainTable.FindItem("vader"));
            Assert.AreEqual(true, defaultChainTable.FindItem("grevious"));
            Assert.AreEqual(false, defaultChainTable.FindItem(""));
            Assert.AreEqual(false, defaultChainTable.FindItem("rader"));
        }
        /*
        [Test]
        public void DoubleHashTableTest()
        {
            int originalSize = defaultHashTable.Size;
            defaultHashTable.AddItem("obi-wan");
            defaultHashTable.AddItem("anakin");
            defaultHashTable.AddItem("grevious");
            defaultHashTable.AddItem("vader");
            defaultHashTable.AddItem("abc");
            defaultHashTable.AddItem("123"); //should double here
            defaultHashTable.AddItem("890");
            Assert.AreEqual(23, defaultHashTable.Size);
        }

        [Test]
        public void FindAndRemoveTest()
        {
            int originalSize = defaultHashTable.Size;
            defaultHashTable.AddItem("obi-wan");
            defaultHashTable.AddItem("anakin");
            defaultHashTable.AddItem("grevious");
            defaultHashTable.AddItem("vader");
            defaultHashTable.AddItem("abc");
            defaultHashTable.AddItem("123"); //should double here
            defaultHashTable.AddItem("890");
            defaultHashTable.RemoveItem("890");
            defaultHashTable.RemoveItem("anakin");
            Assert.AreEqual(false, defaultHashTable.FindItem("890"));
            Assert.AreEqual(false, defaultHashTable.FindItem("anakin"));
        }*/
    }
}
