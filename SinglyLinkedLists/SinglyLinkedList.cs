using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
      private SinglyLinkedListNode firstNode;
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
          foreach (object val in values) {
            AddLast(val.ToString());
          }          
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
          get { return ElementAt(i); }
            set {
              SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
              SinglyLinkedListNode node = firstNode;
              SinglyLinkedListNode lastNode = new SinglyLinkedListNode("old");
              for (; i > 0; i--) {
                lastNode = node;
                node = node.Next;
              }
              newNode.Next = node.Next;
              lastNode.Next = newNode;
            }
        }

        public void AddAfter(string existingValue, string value)
        {
          if (IndexOf(existingValue) == -1) { throw new ArgumentException(); }
          SinglyLinkedListNode node = firstNode;
          SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
          while (true) {
            if (node.ToString() == existingValue) {
              newNode.Next = node.Next;
              node.Next = newNode;
              break;
            }
            node = node.Next;
          }
        }

        public void AddFirst(string value)
        {
          SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
          newNode = firstNode;
          firstNode = new SinglyLinkedListNode(value);
          firstNode.Next = newNode;
        }

        public void AddLast(string value)
        {
          if (firstNode == null) {
            firstNode = new SinglyLinkedListNode(value);
          } else {
            SinglyLinkedListNode node = firstNode;
            while (true) {
              if (node.Next != null) {
                node = node.Next;
              } else {
                node.Next = new SinglyLinkedListNode(value);                
                break;
              }
              
            }
          }
          
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
          int num = 0;
          SinglyLinkedListNode node = firstNode;
          while (true) {
            if (node == null) { break; }
            num++;
            node = node.Next;
          }
          return num;

        }

        public string ElementAt(int index)
        {
          SinglyLinkedListNode result = firstNode;
          if (firstNode == null) { throw new ArgumentOutOfRangeException(); }
          
          for (int i = index; index > 0; index--) {
            if (result == null) { throw new ArgumentOutOfRangeException(); }
            result = result.Next;
          }
           return result.ToString() ;
        }

        public string First()
        {
          if (firstNode == null) {
            return null;
          } else {
            return firstNode.ToString();
          }
          
        }

        public int IndexOf(string value)
        {
          int count = 0;
          SinglyLinkedListNode node = firstNode;
          while (true) {
            if (node == null) { return -1; }
            if (value == node.ToString()) { return count; }
            count++;
            node = node.Next; 
          }
        }

        public bool IsSorted()
        {
          if (firstNode == null || firstNode.Next == null) { return true; }
          SinglyLinkedListNode node = firstNode;
          bool sorted = true;
          while (true) {
           if (node.Next == null) { break; }
           sorted = !(node > node.Next);
           node = node.Next;
           if (sorted == false) { return sorted; }
          }
          return sorted;
        }
            

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
          if (firstNode == null) { return null; }
          SinglyLinkedListNode node = firstNode;
          while (true) {
            if (node.Next == null) {
              return node.ToString();
            } else {
              node = node.Next;
            }
          }
        }

        public void Remove(string value)
        {
          if (IndexOf(value) == -1) { return; }
          SinglyLinkedListNode node = firstNode;
          SinglyLinkedListNode lastNode = new SinglyLinkedListNode("old");
          while (true) {
            if (node.ToString() == value) {
              if (node == firstNode) {
                firstNode = node.Next;
                break;
              }
              lastNode.Next = node.Next;
              break;
            }
            lastNode = node;
            node = node.Next;
          } 
        }

        public void Sort()
        {
          if(firstNode == null || firstNode.Next == null){ return;}
          SinglyLinkedListNode node = firstNode.Next;
          SinglyLinkedListNode prev = firstNode;
          SinglyLinkedListNode prevprev = null;
          while (true) {
            
            SinglyLinkedListNode temp = null;
            SinglyLinkedListNode temp2 = null;

            while (!IsSorted()) {
              if (firstNode > firstNode.Next) {
                temp = firstNode.Next.Next;
                temp2 = firstNode;
                firstNode = firstNode.Next;
                firstNode.Next = temp2;
                firstNode.Next.Next = temp;

                node = firstNode.Next;
                prev = firstNode;
                prevprev = null;
                break;
              }
              if (prev > node) {
                temp = node.Next;
                temp2 = prev;
                prev.Next = temp;
                node.Next = prev;
                prevprev.Next = node;

                node = firstNode.Next;
                prev = firstNode;
                prevprev = null;
                break;
              }
              prevprev = prev;
              prev = node;
              node = node.Next;
              break;
            }
            if (IsSorted()) { break; }
          }
        }

        public override string ToString() {
          SinglyLinkedListNode node = firstNode;
          StringBuilder myString = new StringBuilder("{");
          while (true) {
            if (node == null) { break; }
            myString.Append(" \"" + node.ToString() + "\"");
            if (node.Next == null) { break; }
            myString.Append(",");
            node = node.Next;
          }

          myString.Append(" }");
          return myString.ToString();
        }

        public string[] ToArray() {
          List<string> myString = new List<string> { };
          SinglyLinkedListNode node = firstNode;
          while (true) {
            if (node == null) { break; }
            myString.Add(node.ToString());
            node = node.Next;
          }
          return myString.ToArray();
        }
    }
}
