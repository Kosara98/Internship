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

        public T this[int index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Count => indexBase;

        public bool IsReadOnly => throw new System.NotImplementedException();

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
                        array[arrayIndex] = defaultValue;
                    else
                        array[arrayIndex] = items[i];
                    arrayIndex++;
                }
            }
            else
                throw new System.ArgumentException("Destination array was not long enough.");   
        }

        public IEnumerator<T> GetEnumerator()
        {
            //for (int i = 0; i < Count; i++)
            //    yield return items[i];
            throw new System.NotImplementedException();
        }

        public int IndexOf(T item)
        {
            int index = 0;
            foreach (var i in items)
            {
                if (i.Equals(item))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0)
                throw new System.ArgumentOutOfRangeException();
            else if (index >= items.Length - 1)
                DoubleLength();
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (i.Equals(index))
                    {
                        indexBase++;
                        for (int n = indexBase; n > index; n--)
                        {
                            items[n] = items[n - 1];
                        }
                        items[index] = item;

                    }
                }
            }
        }

        public bool Remove(T item)
        {
            int index = 0;
            foreach(var i in items)
            {
                if (i.Equals(item))
                {
                    items[index] = defaultValue;
                    for (int n = index + 1; n < items.Length; n++)
                    {
                        items[n - 1] = items[n];
                    }
                    indexBase--;
                    return true;
                }
                index++;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
                throw new System.ArgumentOutOfRangeException();
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (i.Equals(index))
                    {
                        items[index] = defaultValue;
                        for (int n = index + 1; n < items.Length; n++)
                        {
                            items[n] = items[index - 1];
                        }
                        indexBase--;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustomEnumerator<T>();
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
