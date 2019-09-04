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

        public T this[int index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Count => indexBase;

        public bool IsReadOnly => throw new System.NotImplementedException();

        public void Add(T item)
        {
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
            throw new System.NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
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
            if (index < 0 || index > items.Length)
                throw new System.ArgumentOutOfRangeException();
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
                        item = items[index - 1];
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
            throw new System.NotImplementedException();
        }
    }
}
