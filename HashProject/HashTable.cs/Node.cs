using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLibrary
{
    public class Node<T>
    {
        //Class Fields
        private T value;

        //Defined and Default Constructor
        public Node(T v, Node<T> next, Node<T> previous)
        {
            this.value = v;
            this.Next = next; //sets the value of the next to the following link
            this.Previous = previous; //sets the value of the next to the previous link
        }

        //Properties
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public Node<T> Next { get; set; } = null;

        public Node<T> Previous { get; set; } = null;

        public override string ToString()
        {
            return this.value.ToString();
        }
        }
}
