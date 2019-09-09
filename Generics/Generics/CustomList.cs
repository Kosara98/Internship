using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class CustomList<T> : IEnumerable<T>, ICollection<T>, IList<T>
    {
        int indexBase = 0;
        T[] items = new T[16];
        T defaultValue = default(T);
        T[] itemsNew;

        public T this[int index] { get => items[index]; set => items[index] = value;  }

        public int Count => indexBase;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (indexBase == items.Length)
            {
                DoubleLength();
            }
            items[indexBase] = item;
            indexBase++;
        }

        public void Clear()
        {
            items = new T[16];
            indexBase = 0;
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
                    if (i >= items.Length)
                        break;
                    else
                        array[i + arrayIndex] = items[i];
                }
            }
            else
                throw new System.ArgumentException("Destination array was not long enough.");   
        }

        public IEnumerator<T> GetEnumerator()
        {
            CustomEnumerator<T> customEnumerator = new CustomEnumerator<T>(items);
            return customEnumerator;
            //for (int i = 0; i < Count; i++)
            //    yield return items[i];
        }

        public int IndexOf(T item)
        {
            int index = 0;
            while (!items[index].Equals(item))
            {
                index++;
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            if (index < 0)
                throw new System.ArgumentOutOfRangeException();
            else if (indexBase >= items.Length - 1)
            {
                DoubleLength();
                items[index] = item;
            }
            else
            {
                for (int i = indexBase; i >= index; i--)
                {
                    if (i.Equals(index))
                    {
                        items[index] = item;
                        break;
                    }
                    items[i] = items[i-1];
                }
                indexBase++;
            }
        }

        public bool Remove(T item)
        {
            int index = 0;
            while (!items[index].Equals(item))
            {
                if (index == items.Length)
                    return false;
                index++;
            };

            items[index] = defaultValue;
            for (int n = index + 1; n < items.Length; n++)
            {
                items[n - 1] = items[n];
            }
            indexBase--;
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
                throw new System.ArgumentOutOfRangeException();
            else
            {
                items[index] = defaultValue;
                for (int i = index; i < indexBase; i++)
                {
                    items[i] = items[index + 1];
                }
                indexBase--;
                items[indexBase] = defaultValue;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void DoubleLength()
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
