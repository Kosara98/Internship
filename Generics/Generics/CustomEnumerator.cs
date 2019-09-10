using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics
{
    public class CustomEnumerator<T> : IEnumerator<T>
    {
        int index = -1;
        IList<T> items;

        public CustomEnumerator(IList<T> array)
        {
            items = array;
        }

        public T Current
        {
            get
            {
                try
                {
                    return items[index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            index++;
            return (index < items.Count);
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
