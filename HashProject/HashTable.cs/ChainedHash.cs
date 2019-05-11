using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLibrary
{
    public class ChainedHash
    {
        //Class Fields
        const string deletedKey = "--xyzcvb--";
        int size;
        Node<string>[] hashArray;

        //Default Constructor
        public ChainedHash()
        {
            hashArray = new Node<string>[17];
            this.size = 11;
            NullifyNewHashTable();
        }

        //Defined Constructor
        public ChainedHash(int size)
        {
            hashArray = new Node<string>[size];
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

        //Public Methods
        public void AddItem(string item)
        {
            //if item is not empty
            //call hash method, use return value as index for adding to hashArray
            //if the element is empty, set element node with item value
            //else (meaning that nodes already exists)
                //add new node to list by setting it as the new head and then assigning to array element
            if (item != "")
            {
                int index = Hash(item);
                if (hashArray[index] == null)
                {
                    Node<string> firstNode = new Node<string>(item, null,null);
                    hashArray[index] = firstNode;
                }
                else
                {
                    //create new node, making itself the head and the other links the nodes already in the list
                    Node<string> headNode = new Node<string>(item, hashArray[index],null);
                    //sets new head to the index element in the array
                    hashArray[index] = headNode;
                    //sets the previous value of the second value in the node to recognize the first
                    hashArray[index].Next.Previous = hashArray[index];
                }
            }
            else
            {
                throw new ArgumentException("string parameter must not be empty");
            }
        }

        public bool RemoveItem(string item)
        {
            //hash the item and return the index
            //if the head node of the indexed element equals item and there is not another node, 
                //set value to null, return true
            //else iterate through the element until the value is found
                //return true if found
                //otherwise false
            int index = Hash(item);
            if (hashArray[index].Value == item && hashArray[index].Next == null)
            {
                //asumes current node is only link
                hashArray[index] = null;
                return true;
            }
            else if (hashArray[index].Value == item && hashArray[index].Next != null)
            {
                //assumes current node is not only link
                //set next value to current head
                Node<string> next = hashArray[index].Next;
                hashArray[index] = next;
                //set previous property of now head node in element to null
                hashArray[index].Previous = null;
                return true;
            }
            else
            {
                Node<string> currentNode = hashArray[index].Next; //set to next since first value
                while (currentNode != null)
                {
                    if (currentNode.Value == item)
                    {
                        //set the previous node's next value to the next node
                        //set the next node's previous value to the previous node
                        //Node<string> prevNode = currentNode.Previous;
                        //Node<string> nextNode = currentNode.Next;
                        currentNode.Previous.Next = currentNode.Next;
                        currentNode.Next.Previous = currentNode.Previous;
                        while(currentNode.Previous != null)
                        {
                            currentNode = currentNode.Previous;
                        }
                        hashArray[index] = currentNode;
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
                return false;
                //if true was not returned within the while loop,
                //then it means that the list does not contain the desired value
            }
        }

        public bool FindItem(string item)
        {
            if (item == "")
            {
                throw new ArgumentException("Enter a non-empty string");
            }
            else
            {
                //hash the item and return the index
                //if the head node of the indexed element equals item, return true
                //else iterate through the element until the value is found
                //return true if found
                //otherwise false
                int index = Hash(item);
                if (hashArray[index] != null && hashArray[index].Value == item)
                {
                    return true;
                }
                else
                {
                    Node<string> currentNode = hashArray[index];
                    while (currentNode != null)
                    {
                        if (currentNode.Value == item)
                        {
                            return true;
                        }
                        currentNode = currentNode.Next;
                    }
                    return false;
                    //if true was not returned within the while loop,
                    //then it means that the list does not contain the desired value
                }
            }
        }

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
                hashArray[i] = null;
            }
        }
    }
}
