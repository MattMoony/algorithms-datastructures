using System;

namespace AlgorithmsDatastructures
{
    class SinglyLinkedListNode<T>
    {
        private T value;
        private SinglyLinkedListNode<T> next = null;

        public SinglyLinkedListNode(T value)
        {
            this.value = value;
        }

        public SinglyLinkedListNode(T value, SinglyLinkedListNode<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public T Value
        {
            set { this.value = value; }
            get { return this.value; }
        }

        public SinglyLinkedListNode<T> Next
        {
            set { next = value; }
            get { return next; }
        }
    }

    class LinkedListNode<T>
    {
        private T value;
        private LinkedListNode<T> prev = null;
        private LinkedListNode<T> next = null;

        public LinkedListNode(T value)
        {
            this.value = value;
        }

        public LinkedListNode(T value, LinkedListNode<T> prev)
        {
            this.value = value;
            this.prev = prev;
        }

        public LinkedListNode(T value, LinkedListNode<T> prev, LinkedListNode<T> next)
        {
            this.value = value;
            this.prev = prev;
            this.next = next;
        }

        public T Value
        {
            set { this.value = value; }
            get { return value; }
        }

        public LinkedListNode<T> Prev
        {
            set { prev = value; }
            get { return prev; }
        }

        public LinkedListNode<T> Next
        {
            set { next = value; }
            get { return next; }
        }
    }

    class LinkedList<T>
    {
        private int length = 0;
        private LinkedListNode<T> start = null;
        private LinkedListNode<T> end = null;

        public int size()
        {
            return this.length;
        }

        public void append(T value)
        {
            LinkedListNode<T> n;

            if (start == null)
            {
                n = new LinkedListNode<T>(value);
                start = n;
            } else
            {
                n = new LinkedListNode<T>(value, end);
                end.Next = n;
            }

            end = n;
            length++;
        }

        public void insert(T value, int index)
        {
            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == length)
            {
                append(value);
            }
            else
            {
                LinkedListNode<T> n;

                if (index == 0)
                {
                    n = new LinkedListNode<T>(value, null, start);
                    start.Prev = n;
                    start = n;
                }
                else
                {
                    LinkedListNode<T> trgt = getNode(index);
                    n = new LinkedListNode<T>(value, trgt.Prev, trgt);
                    trgt.Prev.Next = n;
                    trgt.Prev = n;
                }

                length++;
            }
        }

        public LinkedListNode<T> getNode(int index)
        {
            if (index >= length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                LinkedListNode<T> cu = start;
                for (int i = 0; i < index; i++)
                {
                    cu = cu.Next;
                }

                return cu;
            }
        }

        public LinkedListNode<T> first()
        {
            return start;
        }

        public LinkedListNode<T> last()
        {
            return end;
        }

        public T get(int index)
        {
            try
            {
                return getNode(index).Value;
            } catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void remove(int index)
        {
            LinkedListNode<T> el = getNode(index);
            
            if (el != start)
            {
                el.Prev.Next = el.Next;
                el.Next.Prev = el.Prev;

                if (el == end)
                {
                    end = el.Prev;
                }
            } else
            {
                start = el.Next;
                el.Next.Prev = null;
            }

            length--;
        }

        public override string ToString()
        {
            string ret = String.Format("LinkedList[{0}]{{ ", typeof(T).Name);
            
            if (length > 16)
            {
                for (int i = 0; i < 8; i++)
                {
                    ret += get(i).ToString() + ", ";
                }

                ret += "..., ";

                for (int i = length-8; i < length; i++)
                {
                    ret += get(i).ToString();
                    ret += i == length - 1 ? " }" : ", ";
                }
            } else
            {
                for (int i = 0; i < length; i++)
                {
                    ret += get(i).ToString();
                    ret += i == length - 1 ? " }" : ", ";
                }
            }

            return ret;
        }
    }

    class SinglyLinkedList<T>
    {
        private int length = 0;
        private SinglyLinkedListNode<T> start = null;
        private SinglyLinkedListNode<T> end = null;

        public int size()
        {
            return this.length;
        }

        public void append(T value)
        {
            SinglyLinkedListNode<T> n = new SinglyLinkedListNode<T>(value);

            if (start == null)
            {
                start = n;
            }
            else
            {
                end.Next = n;
            }

            end = n;
            length++;
        }

        public void insert(T value, int index)
        {
            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == length)
            {
                append(value);
            }
            else
            {
                SinglyLinkedListNode<T> n;

                if (index == 0)
                {
                    n = new SinglyLinkedListNode<T>(value, start);
                    start = n;
                }
                else
                {
                    SinglyLinkedListNode<T> trgt = getNode(index-1);
                    n = new SinglyLinkedListNode<T>(value, trgt.Next);
                    trgt.Next = n;
                }

                length++;
            }
        }

        public SinglyLinkedListNode<T> getNode(int index)
        {
            if (index >= length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                SinglyLinkedListNode<T> cu = start;
                for (int i = 0; i < index; i++)
                {
                    cu = cu.Next;
                }

                return cu;
            }
        }

        public SinglyLinkedListNode<T> first()
        {
            return start;
        }

        public SinglyLinkedListNode<T> last()
        {
            return end;
        }

        public T get(int index)
        {
            try
            {
                return getNode(index).Value;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void remove(int index)
        {
            if (index == 0)
            {
                start = start.Next;
            } else
            {
                SinglyLinkedListNode<T> bel = getNode(index - 1);
                bel.Next = bel.Next.Next;

                if (index == length-1)
                {
                    end = bel;
                }
            }

            length--;
        }

        public override string ToString()
        {
            string ret = String.Format("LinkedList[{0}]{{ ", typeof(T).Name);

            if (length > 16)
            {
                for (int i = 0; i < 8; i++)
                {
                    ret += get(i).ToString() + ", ";
                }

                ret += "..., ";

                for (int i = length - 8; i < length; i++)
                {
                    ret += get(i).ToString();
                    ret += i == length - 1 ? " }" : ", ";
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    ret += get(i).ToString();
                    ret += i == length - 1 ? " }" : ", ";
                }
            }

            return ret;
        }
    }
}
