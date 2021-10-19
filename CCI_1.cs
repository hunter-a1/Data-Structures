// Annie, Karlee, Long
// 10/19/21

using System;

namespace Week03___SLL
{
    class Labds4_1
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddFirst(10);
            list.AddFirst(20);
            list.AddFirst(30);
            list.AddFirst(40);
            list.AddFirst(50);
            list.AddFirst(60);
            list.AddFirst(70);
            list.AddFirst(80);
            list.AddFirst(60);
            list.AddFirst(90);
            list.AddFirst(80);
            list.AddFirst(60);
            list.AddFirst(100);

            Console.WriteLine(list);
            list.RemoveDuplicate();
            Console.WriteLine(list);

            //Console.WriteLine(list);

            //list.DeleteFirst();
            //list.DeleteLast();
            //list.DeleteValue(50);

            //Console.WriteLine(list);

            //list.Reverse();

            //Console.WriteLine(list);

            //list.Reverse();

            //Console.WriteLine(list);

            //list.DeleteFirst();

            //Console.WriteLine(list);

            //list.DeleteLast();

            //Console.WriteLine(list);

            //list.Reverse();

            //Console.WriteLine(list);

            //list.Reverse();

            //Console.WriteLine(list);
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

    class DoublyLinkedList<T> where T : IComparable
    {
        //data?  characteristics
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        //method? behavior/actions/operations

        public bool Check4Loops()
        {
            if (IsEmpty())
                return false;

            Node<T> slow = Head;
            Node<T> fast = Head.Next;

            while (fast != slow && slow != null && fast != null && fast.Next != null)
            {
                slow = slow.Next; //move slow one step
                fast = fast.Next.Next; //moves fast two steps
            }

            return slow != null && fast == slow;
        }

        public void DeleteFirst() //running time O(1)
        {
            if (IsEmpty())
            {
                throw new Exception("List is empty. Cannot delete from empty list.");
            }
            else if (Head.Next == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
        }

        public void DeleteLast() //running time: O(1)
        {
            if (IsEmpty())
            {
                throw new Exception("List is empty. Cannot delete from empty list.");
            }
            else if (Tail.Prev == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
            }
        }

        public void DeleteValue(T value) //delete the first occurrence of value from the list | O(n)
        {
            if (IsEmpty())
                throw new Exception("Cannot delete from an empty list.");
            else if (Head.Value.CompareTo(value) == 0) //delete head value
                DeleteFirst();
            else if (Tail.Value.CompareTo(value) == 0)
            {
                DeleteLast();
            }
            else
            {
                Node<T> finger = Head.Next; // already checked head, so start at 2nd node
                while (finger != null && finger.Value.CompareTo(value) != 0)
                    finger = finger.Next;//move finger to the right

                if (finger.Next == null)
                    ;//value not found
                else//value was found, link it out
                {
                    finger.Prev.Next = finger.Next;
                    finger.Next.Prev = finger.Prev;
                }
            }
        }

        public void DeleteNode(Node<T> node) // O(n)
        {
            if (IsEmpty())
                throw new Exception("Cannot delete from an empty list.");
            else if (node == null)
            {
                throw new Exception("Cannot delete null node.");
            }
            else if (Head == node) //delete head
                DeleteFirst();
            else if (Tail == node) // delete tail
            {
                DeleteLast();
            }
            else
            {
                Node<T> finger = Head.Next; // already checked head, so start at 2nd node
                while (finger != null && finger != node)
                    finger = finger.Next;//move finger to the right

                if (finger.Next == null)
                    ;//value not found
                else
                { //value was found, link it out
                    finger.Prev.Next = finger.Next;
                    finger.Next.Prev = finger.Prev;
                }

            }
        }
        public void RemoveDuplicate()
        {
            Node<T> finger = Head;
            while(finger != null) // loop the list once
            {
                Node<T> runner = finger.Next;
                while(runner != null) // loop the list one for each element in the list
                {
                    if (finger.Value.CompareTo(runner.Value) == 0)
                    {
                        DeleteValue(runner.Value);
                    }
                    runner = runner.Next;
                }

                finger = finger.Next;
            }
        }
        public void DeleteValuesArr(T[] values)  //O(n), if array is O(C)
        {
            foreach (T v in values)
            {
                if (IsEmpty())
                    DeleteValue(v);
            }
        }

        public void PartitionSimplest(T x)
        {
            Node<T> finger = Head;
            Head = null; //you just "deleted" the list
            while (finger != null)
            {
                if (finger.Value.CompareTo(x) < 0) //finger.Value<x
                    AddFirst(finger.Value);
                else
                    AddLast(finger.Value);

                finger = finger.Next;
            }
        }

        public void PartitionEfficient(T x)
        {
            Node<T> begin = null, end = null;

            Node<T> finger = Head, nextFinger;

            while (finger != null)
            {
                nextFinger = finger.Next;

                if (finger.Value.CompareTo(x) < 0)
                {
                    if (begin == null)
                    {
                        begin = finger;
                        end = finger;
                        finger.Next = null;
                    }
                    else//add first
                    {
                        finger.Next = begin;//link in
                        begin = finger;//move the begin 
                    }
                }
                else
                {
                    if (begin == null)
                    {
                        begin = finger;
                        end = finger;
                        finger.Next = null;
                    }
                    else // add last
                    {
                        end.Next = finger;
                        end = finger;//move end
                        end.Next = null;
                    }
                }
                finger = nextFinger;
            }
            Head = begin;

        }

        public int Contains(T[] values, T valueToSearchFor)
        {
            for (int pos = 0; pos < values.Length; pos++)
            {
                if (values[pos].CompareTo(valueToSearchFor) == 0)//found it!
                    return pos;
            }

            return -1;//not found
        }
        public void DeleteValuesArr2(T[] values) //O(n), if array is O(C)
        {
            if (IsEmpty())
                ; //done, nothing to do
            else
            {
                while (Contains(values, Head.Value) != -1)
                    DeleteFirst();//head = head.next

                Node<T> finger = Head;
                while (finger.Next != null)
                {
                    if (Contains(values, finger.Next.Value) != -1)
                        finger.Next = finger.Next.Next;//link it out ... check again
                    else
                        finger = finger.Next;//move finger to the right
                }
            }
        }

        public void DeleteValues(T value) //delete the all occurrences of value from the list
        {
            throw new NotImplementedException();
        }

        public void DeleteIndex(int index)
        {
            if (IsEmpty())
                throw new Exception("Cannot delete from an empty list");
            else if (index < 0)
                throw new IndexOutOfRangeException("Index must be nonnegative");
            else if (index == 0)
                DeleteFirst();
            else
            {
                Node<T> finger = Head;
                int count = 1;
                //as long as there is a next element and it not index
                while (finger.Next != null && count < index)
                {
                    finger = finger.Next;  //move right
                    count++;
                }

                if (count == index)
                {
                    finger.Next = finger.Next.Next;
                }
                else //i.e. finger.Next is null, finger points to the last node in the list
                {
                    throw new IndexOutOfRangeException("index too large");
                }

            }
        }

        public bool IsEmpty() //traversal, running time O(1)
        {
            return Head == null; // if Head is null, tail is also null
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
            string ret = "";

            if (IsEmpty())
                ret = "The list is empty";
            else
            {
                Node<T> finger = Head;
                while (finger != null)
                {
                    ret += String.Format($"{finger.Value}, ");//display the value
                    finger = finger.Next; //moves the finger to the right
                }
            }

            return ret;
        }

        //public void RemoveNode(Node<T> deleteMeNode)
        //{
        //    if (deleteMeNode != null)
        //        throw new NullReferenceException("node should not be null");
        //    else if (deleteMeNode.Next == null)
        //        throw new Exception("this method cannot delete the last node");

        //    deleteMeNode.Value = deleteMeNode.Next.Value;
        //    deleteMeNode.Next = deleteMeNode.Next.Next;

        //}

        public void AddFirst(T ValueToAdd)//running time O(1)
        {
            //1. create a new node
            Node<T> newNode = new Node<T>(ValueToAdd);

            if (IsEmpty())//creating the first node
            {
                Head = newNode;
                Tail = newNode;
            }
            else //adding another new node
            {
                //2 
                newNode.Next = Head;
                //3
                Head.Prev = newNode;

                //4
                Head = newNode;
            }
        }

        public void Reverse() // O(n)
        {
            if (IsEmpty())
            {
                throw new Exception("Cannot reverse empty list.");
            }
            else
            {
                // create pointer to last inner node
                Node<T> finger = Tail.Prev;
                // point head to tail
                Head = Tail;
                Head.Next = Head.Prev;
                Head.Prev = null;
                while (finger != null)
                {
                    // reverse Prev and Next
                    Node<T> tmp = finger.Next;
                    finger.Next = finger.Prev;
                    finger.Prev = tmp;
                    if (finger.Next == null)
                    {
                        // create pointer to tail
                        Tail = finger;
                    }
                    // move finger
                    finger = finger.Next;
                }
            }
        }

        public void AddLast(T ValueToAdd) // O(1)
        {
            //1. create a new node
            Node<T> newNode = new Node<T>(ValueToAdd);

            if (IsEmpty())//creating the first node
            {
                Head = newNode;
                Tail = newNode;
            }
            else //adding another new node at the end
            {
                //2 
                newNode.Prev = Tail;
                //3
                Tail.Next = newNode;

                //4
                Tail = newNode;
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
            Tail = null;
        }


        //ctors
        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }
    }

    class Node<T>
    {
        //data
        public T Value { get; set; } //stores the value
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        //methods

        //ctors
        public Node(T val)
        {
            Value = val;
        }
    }
}
