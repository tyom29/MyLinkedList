using System;

namespace GenericLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();

            // Add element from end
            myLinkedList.Add(1);
            myLinkedList.Add(2);
            myLinkedList.Add(3);
            myLinkedList.Add(4);

            //Insert by position
            myLinkedList.Insert(item:5, position:3);

            // Print All elements
            myLinkedList.Print();

            // Print element by position
            myLinkedList.Print(3);
        }
    }
}
