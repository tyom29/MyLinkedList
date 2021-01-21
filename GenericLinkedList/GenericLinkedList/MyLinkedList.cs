using System;
using System.Collections.Generic;
using System.Text;

namespace GenericLinkedList
{
    public class MyLinkedList<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        private Node Head { get; set; }
        private int size = 0;
        public int Count
        {
            get
            {
                return size;
            }
        }

        // Add to the end
        public void Add(T item)
        {
            Node newNode = new Node();
            newNode.Data = item;

            if (this.Head == null)
            {
                this.Head = newNode;
            }
            else
            {
                Node curr = GetLastNode();
                curr.Next = newNode;
            }
            this.size++;
        }

        // Insert to Any Position (position starts from 1)
        public void Insert(T item, int position)
        {
            Node newNode = new Node();
            newNode.Data = item;

            if ((this.Head == null && position > 1) || position < 0 || position > this.size + 1)
            {
                throw new ArgumentOutOfRangeException("The supplied position is invalid.");
            }

            if (position == 1)
            {
                AddToTop(item);
                return;
            }
            if (position == this.size + 1)
            {
                Add(item);
                return;
            }

            Node prev = null;
            Node curr = this.Head;
            int count = 1;
            while (count < position)
            {
                prev = curr;
                curr = curr.Next;
                count++;
            }
            prev.Next = newNode;
            newNode.Next = curr;
            this.size++;
        }

        public void AddToTop(T item)
        {
            Node newNode = new Node();
            newNode.Data = item;

            if (this.Head == null)
            {
                this.Head = newNode;
            }
            else
            {
                newNode.Next = this.Head;
                this.Head = newNode;
            }
            this.size++;
        }

        // Delete at any position (position starts from 1)
        public bool Delete(int position)
        {
            if (this.Head == null)
            {
                return false;
            }
            if (position < 1)
            {
                return false;
            }
            if (position > this.size)
            {
                return false;
            }

            int count = 1;
            Node prev = null;
            Node curr = this.Head;
            Node next = this.Head.Next == null ? null : this.Head.Next;

            if (position == 1)
            {
                this.Head = next;
                this.size--;
                return true;
            }

            while (count <= position)
            {

                if (count == position)
                {
                    prev.Next = next;
                    this.size--;
                    return true;
                }

                prev = curr;
                curr = curr.Next;
                next = curr.Next == null ? null : curr.Next;

                count++;
            }

            return false;
        }

        // Print by position (position starts from 1)
        public void Print(int position)
        {
            if (this.Head == null)
            {
                throw new NullReferenceException("There are no items in the list.");
            }
            if (position < 1)
            {
                throw new IndexOutOfRangeException("The position has to be greater than 1.");
            }
            if (position > this.size)
            {
                throw new IndexOutOfRangeException("The supplied position is greater than the elements in the list.");
            }

            int count = 1;
            Node curr = this.Head;
            while (count <= position)
            {
                if (count == position)
                {
                    break;
                }
                count++;
                curr = curr.Next;
            }
            Console.WriteLine(curr.Data);
        }

        // Print all elements
        public void Print()
        {
            if (this.Head == null)
            {
                Console.WriteLine("");
                return;
            }

            string data = string.Empty;
            Node curr = this.Head;
            data = curr.Data.ToString();
            while (curr.Next != null)
            {
                curr = curr.Next;
                data += ", " + curr.Data.ToString();
            }
            Console.WriteLine(data);

        }

        private Node GetLastNode()
        {
            if (this.Head == null)
            {
                return null;
            }
            Node curr = this.Head;
            while (curr.Next != null)
            {
                curr = curr.Next;
            }
            return curr;
        }

    }


}
