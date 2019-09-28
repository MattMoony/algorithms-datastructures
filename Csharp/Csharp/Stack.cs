using System;

namespace AlgorithmsDatastructures
{
    class Stack<T>
    {
        private SinglyLinkedList<T> values = new SinglyLinkedList<T>();
        private int end = -1;

        public int size() {
            return end + 1;
        }

        public void push(T value)
        {
            values.append(value);
            end++;
        }

        public T pop()
        {
            T value = values.last().Value;
            values.remove(end);
            end--;

            return value;
        }

        public override string ToString()
        {
            string ret = String.Format("Stack[{0}]{{ ", typeof(T).Name);

            if ((end+1) > 16)
            {
                for (int i = 0; i < 8; i++)
                {
                    ret += values.get(i).ToString() + ", ";
                }

                ret += "..., ";

                for (int i = (end + 1) - 8; i < (end + 1); i++)
                {
                    ret += values.get(i).ToString();
                    ret += i == (end + 1) - 1 ? " }" : ", ";
                }
            }
            else
            {
                for (int i = 0; i < (end + 1); i++)
                {
                    ret += values.get(i).ToString();
                    ret += i == (end + 1) - 1 ? " }" : ", ";
                }
            }

            return ret;
        }
    }
}
