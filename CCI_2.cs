// Annie, Karlee, Long

using System;

namespace CCI_1
{
    class CCI_1
    {
        static void Main(string[] args)
        {
            //Node<string> n1 = new Node<string>("WA");
            //Node<string> n2 = new Node<string>("Evergreen");
            //Node<string> n3 = new Node<string>("College");

            //n1.Next = n2;
            //n1.Next.Next = n3;    //n2.Next = n3;

            //Console.WriteLine(n1.Value);

            ////Console.WriteLine(n2.Value);
            //Console.WriteLine(n1.Next.Value);

            //Console.WriteLine(n3.Value);
            //Console.WriteLine(n1.Next.Next.Value);



            //Node<int> n2 = new Node<int>(202);

            SinglyLinkedList<int> myList = new SinglyLinkedList<int>();

            myList.AddFirst(10);
            myList.AddFirst(20);
            myList.AddFirst(30);
            myList.PrintToConsole();

            Console.WriteLine();

            //myList.Clear();
            //myList.PrintToConsole();


            myList.AddLast(1);
            myList.AddLast(2);
            myList.AddLast(3);
            myList.PrintToConsole();

            bool pal = myList.IsPalindrome();
            Console.WriteLine(pal);

            //myList.DeleteFirst();
            //myList.PrintToConsole();
            //myList.DeleteFirst();
            //myList.PrintToConsole();
            //myList.DeleteFirst();
            //myList.PrintToConsole();
            //myList.DeleteFirst();
            //myList.PrintToConsole();
            //myList.DeleteFirst();
            //myList.PrintToConsole();
            //myList.DeleteFirst();
            //myList.PrintToConsole();
            //myList.DeleteFirst();
            //myList.PrintToConsole();

            myList.PrintToConsole();


            myList.DeleteValue(2);
            myList.PrintToConsole();


            SinglyLinkedList<Student> test = new SinglyLinkedList<Student>();

        }
    }
    class Student : IComparable
    {
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    class SinglyLinkedList<T> where T : IComparable
    {
        //data?  characteristics
        public Node<T> Head { get; private set; }

        //method? behavior/actions/operations

        public void DeleteFirst() //running time O(1)
        {
            if (Head != null)
                Head = Head.Next;
            else
                throw new Exception("you cannot delete the 'first' of an empty list");

        }
        public bool IsPalindrome()
        {
            bool isPalindrome = true;
            int count = 0;
            int length = 0;
            // traverse the list
            Node<T> finger = Head;
            while (finger != null)
            {
                length++;
                finger = finger.Next;
            }
            Console.WriteLine($"length: {length}");
            // traverse the list
            Node<T> front = Head;
            while(front.Next != null && count <= length/2)
            {
                Console.WriteLine($"Count: {count}");
                // get the end pointer
                Node<T> end = Head;
                for (int i = 0; i < length-count; i++)
                {
                    end = end.Next;
                }

                // compare the front and end
                if (front.Value.CompareTo(end.Value) != 0) // they are not the same
                {
                    isPalindrome = false;
                    break;
                }

                front = front.Next;

            }

            return isPalindrome;
        }
        public void DeleteLast() //running time: O(n)
        {
            if (Head == null) //IsEmpty()
            {
                throw new Exception("you cannot delete the 'last' of an empty list");
            }
            else if (Head.Next == null) //the list has one node
            {
                Head = null;
            }
            else //the general case, we have at least two nodes
            {
                //1. traverse the list, to next to the last node
                Node<T> finger = Head;
                while (finger.Next.Next != null)
                {
                    finger = finger.Next; //move finger to the right
                }

                //2. link the last node out
                finger.Next = null;
            }
        }

        public void DeleteValue(T value) //delete the first occurrence of value from the list
        {
            if (Head == null)
                throw new Exception("you cannot delete the head of an empty list");
            else if (Head.Value.CompareTo(value) == 0) //delete head value
                DeleteFirst();
            else
            {
                Node<T> finger = Head;
                while (finger.Next != null && finger.Next.Value.CompareTo(value) != 0)
                    finger = finger.Next;//move finger to the right

                if (finger.Next == null)
                    ;//value not found
                else //value was found
                    finger.Next = finger.Next.Next;
            }
        }

        public void DeleteValues(T value) //delete the all occurrences of value from the list
        {
            throw new NotImplementedException();
        }

        public void DeleteIndex(int index)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty() //traversal, running time O(1)
        {
            //if (Head == null)
            //    return true;
            //else
            //    return false;
            return Head == null;
        }


        public void PrintToConsole() //traversal, running time: O(n)
        {
            if (IsEmpty())
                Console.WriteLine("The list is empty");
            else
            {
                Node<T> finger = Head;
                while (finger != null)
                {
                    Console.Write($"{finger.Value}, ");//display the value
                    finger = finger.Next; //moves the finger to the right
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public void AddFirst(T ValueToAdd)//running time O(1)
        {
            //1. create a new node
            Node<T> newNode = new Node<T>(ValueToAdd);

            //2. link in the new node
            newNode.Next = Head;

            //3. move the head
            Head = newNode;
        }

        public void AddLast(T ValueToAdd)
        {
            if (IsEmpty()) //Head == null
            {
                AddFirst(ValueToAdd);
            }
            else
            {
                //1 create a new node
                Node<T> newNode = new Node<T>(ValueToAdd);

                //2 move to/find the last node
                Node<T> finger = Head;
                while (finger.Next != null) //if there is a next node
                {
                    finger = finger.Next;//move finger to the right
                }

                //3 link in the new node
                finger.Next = newNode;
            }
        }

        public void Append(T ValueToAdd)
        {
            AddLast(ValueToAdd);
        }

        public void Add(T ValueToAdd)//if the list is sorted, this will maintain the sorting
        {
            throw new NotImplementedException();
        }


        public void Clear() //deletes all values from the list  O(1)
        {
            Head = null;
        }


        //ctors
        public SinglyLinkedList()
        {
            Head = null;
        }
    }

    class Node<T>
    {
        //data
        public T Value { get; set; } //stores the value
        public Node<T> Next { get; set; }

        //methods

        //ctors
        public Node(T val)
        {
            Value = val;
        }
    }
}

