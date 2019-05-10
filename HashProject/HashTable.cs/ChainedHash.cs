using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.cs
{
    class ChainedHash
    {
        //Class Fields
        int size;
        string[] hashArray;
        const string empty = null;

        //Default Constructor
        public ChainedHash()
        {
            hashArray = new string[17];
            this.size = 11;
            NullifyNewHashTable();
        }

        //Defined Constructor
        public ChainedHash(int size)
        {
            hashArray = new string[size];
            this.size = size;
            NullifyNewHashTable();
        }

        //Properties
        public int Size
        {
            get
            {
                return this.size;
            }
        }

        //Methods



        //Private Method
        private int Hash(string item)
        {
            //create a running total
            //use for loop to access the substring of the string
            //convert the substring to an int (results in ASCII value)
            //raise the substring to the power of its position
            //return modulus of the running total
            int runningTotal = 0;
            for (int i = 0; i < item.Length; i++)
            {
                //int ASCIIValue = (int)item[i];
                //runningTotal += (int)(Math.Pow(ASCIIValue, (i + 1)));
                runningTotal *= i;
                runningTotal += item[i];
            }
            return (Math.Abs(runningTotal % this.size));
        }

        private void NullifyNewHashTable()
        {
            for (int i = 0; i < this.size; i++)
            {
                hashArray[i] = empty;
            }
        }
    }
}
