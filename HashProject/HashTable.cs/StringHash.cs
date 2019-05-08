using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLibrary
{
    public class StringHash
    {
        //Class Fields
        const string deleted = "--deleteKeyActivated--";
        const string empty = null;

        int size;
        int largestAddIndex;
        string[] hashArray;
        int[] primeSizeArray = new int[] { 11, 23, 47, 97, 217, 437 };


        //Default Constructor
        public StringHash()
        {
            hashArray = new string[11];
            this.size = 11;
            NullifyHashTable();
        }

        //Defined Constructor
        public StringHash(int size)
        {
            hashArray = new string[size];
            this.size = size;
            NullifyHashTable();
        }

        //Properties
        public int Size
        {
            get
            {
                return this.size;
            }
        }


        //Public Methods
        public void AddItem(string item)
        {
            //if item is not empty
            //call is half full
                //if true, double the hash table
            //call hash method, use return value as index for adding to hashArray
            //record largest add at index if the returned hash value is larger than the current
        }

        public bool FindItem(string item)
        {
            return true;
        }

        public bool RemoveItem(string item)
        {
            return true;
        }

        //Private Methods
        private int Hash()
        {
            return 1;
        }

        private bool IsHalfFull()
        {
            int runningCounter = 0;
            for(int i = 0; i < this.size;i++)
            {
                if (hashArray[i] != null)
                {
                    runningCounter++;
                }
            }
            if (runningCounter >= (this.size/2))
            {
                return true;
            }
            return false;
        }

        private void DoubleHashTable()
        {

        }

        private void NullifyHashTable()
        {
            for (int i = 0; i < this.size; i++)
            {
                hashArray[i] = empty;
            }
        }

        private void NullifyHashTable(int startingPoint)
        {
            for (int i = 0; i < this.size; i++)
            {
                hashArray[i] = empty;
            }
        }

    }
}
