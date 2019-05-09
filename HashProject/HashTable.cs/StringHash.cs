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
            if (item != "")
            {
                if(IsHalfFull() == true)
                {
                    DoubleHashTable();
                }
                else
                {
                    int index = Hash(item);
                    index = FindNextFreeSpace(index);
                    hashArray[index] = item;
                    if (index > largestAddIndex)
                        largestAddIndex = index;
                }
            }
            else
            {
                throw new ArgumentException("string parameter must not be empty");
            }
        }

        public bool FindItem(string item)
        {
            //hash the item and return the index
                //if the indexed element does not equal item
                    //iterate through the hasharray until the value is found
                        //return true if found
                    //if it loops back to the original index
                        //return false
            int index = Hash(item);
            if(hashArray[index]==item)
            {
                return true;
            }
            else
            {
                int runningIndex = index;
                bool isWrapped = false;
                while (hashArray[runningIndex] != item)
                {
                    if (runningIndex == this.size - 1)
                    {
                        runningIndex = 0;
                        isWrapped = true;
                    }
                    else if ((runningIndex - 1) == index && isWrapped==true && hashArray[runningIndex] != item) //meaning that it has wrapped
                    {
                        return false;
                    }
                    else
                    {
                        runningIndex++;
                    }
                }
                return true; 
                //if false was not returned within the while loop,
                //then it means that the current runningIndex contains the desired value
            }
        }

        public bool RemoveItem(string item)
        {
            return true;
        }

        //Private Methods
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
                int ASCIIValue = (int)item[i];
                runningTotal += (int)(Math.Pow(ASCIIValue, (i + 1)));
            }
            return (runningTotal%this.size);
        }

        private int FindNextFreeSpace(int index)
        {
            if(hashArray[index] == deleted || hashArray[index] == empty)
            {
                return index;
            }
            else
            {
                int runningIndex = index;
                while(hashArray[runningIndex] != deleted || hashArray[runningIndex] != empty || runningIndex != index)
                {
                    if(runningIndex == this.size - 1)
                    {
                        runningIndex = 0;
                    }
                    else if((runningIndex - 1)==index && hashArray[runningIndex] != deleted || hashArray[runningIndex] != empty) //meaning that it has wrapped
                    {
                        return -1;
                    }
                    else
                    {
                        runningIndex++;
                    }
                }
                return runningIndex;
            }
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
