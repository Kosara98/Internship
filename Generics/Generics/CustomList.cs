using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class CustomList<T> : IEnumerable<T>, ICollection<T>, IList<T>
    {
        int indexBase = 0;
        T[] items = new T[16];
        T[] itemsNew;

        public T this[int index] { get => items[index]; set => items[index] = value;  }

        public int Count { get => indexBase; private set => indexBase = value; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            ChekingLengthAndDoubleIt();
            items[Count] = item;
            Count++;
        }

        public void Clear()
        {
            items = new T[16];
            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var i in items)
            {
                if (i.Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length > Count)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i + arrayIndex] = items[i];
                }
            }
            else
                throw new System.ArgumentException("Destination array was not long enough.");   
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator<T>(this);
            //for (int i = 0; i < Count; i++)
            //    yield return items[i];
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new System.ArgumentOutOfRangeException();
            else
            {
                ChekingLengthAndDoubleIt();
                for (int i = Count; i > index; i--)
                {
                    items[i] = items[i-1];
                }
                items[index] = item;
                Count++;
            }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(item))
                {
                    for (int n = i + 1; n < items.Length; n++)
                    {
                        items[n - 1] = items[n];
                    }
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count)
                throw new System.ArgumentOutOfRangeException();
            else
            {
                for (int i = index; i < Count - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                Count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ChekingLengthAndDoubleIt()
        {
            if (Count == items.Length)
            {
                itemsNew = new T[items.Length * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    itemsNew[i] = items[i];
                }
                items = itemsNew;
            }
        }
    }
}
