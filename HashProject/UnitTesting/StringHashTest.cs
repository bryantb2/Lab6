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
    public class StringHashTest
    {
        //Class Fields
        StringHash definedHashTable;
        StringHash defaultHashTable;

        [SetUp]
        public void TestSetup()
        {
            definedHashTable = new StringHash(17);
            defaultHashTable = new StringHash();
        }

        [Test]
        public void SizePropertyTest()
        {
            Assert.AreEqual(17, definedHashTable.Size);
            Assert.AreEqual(11, defaultHashTable.Size);
        }

        [Test]
        public void AddItemTest()
        {
            try
            {
                defaultHashTable.AddItem("");
                Assert.Fail("AddItem did not throw an exception");
            }
            catch(ArgumentException)
            {
                Assert.Pass("The AddItem method threw an exception!");
            }
        }

        [Test]
        public void AddandFindTest()
        {
            defaultHashTable.AddItem("obi-wan");
            defaultHashTable.AddItem("anakin");
            defaultHashTable.AddItem("grevious");
            defaultHashTable.AddItem("vader");
            Assert.AreEqual(true, defaultHashTable.FindItem("vader"));
            Assert.AreEqual(true, defaultHashTable.FindItem("grevious"));
            Assert.AreEqual(false, defaultHashTable.FindItem(""));
            Assert.AreEqual(false, defaultHashTable.FindItem("rader"));
        }

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
            Assert.AreEqual(originalSize * 2, defaultHashTable.Size);
        }





    }
}
