using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        class ListNode
        {
            // The class ListNode is called a recursive data structure because it references itself recursively.
            public int Value { get; set; }
            public ListNode NextNode { get; set; }

            public ListNode PreviousNode { get; set; }
            public ListNode(int value) // It is defined that the structure can take only integers. 
            {
                Value = value;
            }

        }
        private ListNode head;
        private ListNode tail;
        public int Count { get; private set; } // this is the count of elements in the list


        public void AddFirst (int element)
        {
            if(Count == 0) // if we have 0 elements in the list head and tail is the same so we create the first element and increase the counter to 1. 
            {
                head = tail = new ListNode (element);
            }
            else
            {
                ListNode newHead = new ListNode (element); // we put a value to the new head (which is still not a head)
                newHead.NextNode = head; // The next node of the new head is the current head. 
                head.PreviousNode = newHead;// the head previous node becomes the new head. 
                head = newHead; // the head points towards the new head. 
                //add the new element as a new head and redirect the old head as the second element, just after the new head
            }
            Count++;
        } 
        public void AddLast( int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);

            }
            else 
            {
                ListNode newTail = new ListNode (element);
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }
            Count++;
        }
        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list in empty");
            }
            int fistElement = head.Value;
            head = head.NextNode;
            if (head != null)
            {
                head.PreviousNode = null;
            }
            else
            {
                tail = null;
            }
            Count --;
            return fistElement;
        }
        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list in empty");
            }
            int lastElement = tail.Value;
            tail = tail.PreviousNode;
            if (tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }
            Count--;
            return lastElement;
        }
        public void ForEach (Action<int> action)
        {
            ListNode currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.PreviousNode;
            }

        }
        public int[] ToArray()
        {
            int [] array = new int[Count];
            int counter = 0;
            ListNode currentNode = head;
            while (currentNode!= null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }
            return array;
        }
    }
}
