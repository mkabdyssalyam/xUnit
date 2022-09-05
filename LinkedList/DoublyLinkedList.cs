using System.Collections;

namespace LinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T> where T : IComparable
    {
        DoublyNode<T> head;
        DoublyNode<T> tail;
        int count;

        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }

            tail = node;
            count++;
        }

        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;

            node.Next = temp;
            head = node;

            if (count == 0)
            {
                tail = head;
            }
            else
            {
                temp.Previous = node;
            }

            count++;
        }

        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }

                current = current.Next;
            }

            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }

                count--;
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        private DoublyNode<T> Partition(DoublyNode<T> last, DoublyNode<T> head)
        {
            var pivot = head.Data;

            DoublyNode<T> i = last.Previous;
            T temp;

            for (DoublyNode<T> j = last; j != head; j = j.Next)
            {
                if (j.Data.CompareTo(pivot) <= 0)
                {
                    i = (i == null) ? last : i.Next;
                    temp = i.Data;
                    i.Data = j.Data;
                    j.Data = temp;
                }
            }
            i = (i == null) ? last : i.Next;
            temp = i.Data;
            i.Data = head.Data;
            head.Data = temp;
            return i;
        }

        private void QuickSort(DoublyNode<T> last, DoublyNode<T> head)
        {
            if (head != null && last != head && last != head.Next)
            {
                DoublyNode<T> temp = Partition(last, head);
                QuickSort(last, temp.Previous);
                QuickSort(temp.Next, head);
            }
        }

        public void QuickSort()
        {
            QuickSort(head, tail);
        }
    }
}
