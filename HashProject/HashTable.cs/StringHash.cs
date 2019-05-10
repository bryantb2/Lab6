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
        bool defaultSize = false;
        bool definedSize = false;
        int size;
        string[] hashArray;
        int[] primeSizeArray = new int[] { 11, 23, 47, 97, 217, 437 };


        //Default Constructor
        public StringHash()
        {
            hashArray = new string[11];
            this.size = 11;
            defaultSize = true;
            NullifyNewHashTable();
        }

        //Defined Constructor
        public StringHash(int size)
        {
            hashArray = new string[size];
            this.size = size;
            definedSize = true;
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
                    if ((runningIndex - 1) == index && isWrapped == true && hashArray[runningIndex] != item) //meaning that it has wrapped
                    {
                        return false;
                    }
                    else if (runningIndex == this.size - 1)
                    {
                        runningIndex = 0;
                        isWrapped = true;
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
            //hash item and use returned index to determine if the value exists in its expected spot
              //if its there: set the value to const deleted
                 //return true
              //else
                //iterate through the array to find value
                    //return false if not found
                //if found, set to deleted and return true
            int index = Hash(item);
            if (hashArray[index] == item)
            {
                hashArray[index] = deleted;
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
                    else if ((runningIndex - 1) == index && isWrapped == true && hashArray[runningIndex] != item) //meaning that it has wrapped and did not break out of loop
                    {
                        return false;
                    }
                    else
                    {
                        runningIndex++;
                    }
                }
                hashArray[runningIndex] = deleted;
                return true;
                //if false was not returned within the while loop,
                //then it means that the current runningIndex contains the desired value
            }
        }

        //PRIVATE METHODS
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
        return (Math.Abs(runningTotal%this.size));
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
                bool isWrapped = false;
                while (hashArray[runningIndex] != deleted || hashArray[runningIndex] != empty || runningIndex != index)
                {
                    if(runningIndex == this.size - 1)
                    {
                        runningIndex = 0;
                    }
                    else if((runningIndex - 1)==index && isWrapped==true && hashArray[runningIndex] != deleted || hashArray[runningIndex] != empty) //meaning that it has wrapped
                    {
                        return -1; //means there is no available space
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
            //find what value in the sizes array that the current hash size is closest to
                //use for loop to iterate through array, subtract its value from the current size
                //if the subtracted size is smaller than the current smallest size, add index to variable
            //make a new hashtable array, with the size found in the array
            //track old hashtable size
            //iterate through old hashtable and perform a modulus operator on all non-empty elements
            int primeNumberIndex = 0;
            if (definedSize == true)
            {
                for (int i = 0; i < primeSizeArray.Length; i++)
                {
                    if (this.size * 2 < primeSizeArray[i])
                    {
                        //finds first array size value that is at least two times the current size
                        primeNumberIndex = i;
                        break;
                    }
                }
            }
            else if(defaultSize == true)
            {
                for (int i = 0; i < primeSizeArray.Length; i++)
                {
                    if(this.size == primeSizeArray[i])
                    {
                        //finds the size that the array is currently at and goes to the next double size
                        primeNumberIndex = i+1;
                        break;
                    }
                }
            }
            string[] oldHash = hashArray;
            int oldHashSize = this.size;
            string[] doubledHashTable = new string[primeSizeArray[primeNumberIndex]];
            this.hashArray = doubledHashTable;
            this.size = primeSizeArray[primeNumberIndex];

            for (int i = 0; i < oldHashSize; i++)
            {
                if(oldHash[i] != null)
                {
                    int index = Hash(oldHash[i]); //hashes into the new array with the new size
                    index = FindNextFreeSpace(index); //deals with a potential collisio
                    hashArray[index] = oldHash[i];
                }
               
            }

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
