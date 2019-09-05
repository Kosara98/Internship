﻿using System.Collections;
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
                if (index == -1)
                {
                    return items[0];
                }
                return items[index];
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
            if (index > 0)
            {
                if (items[index].Equals(default(T)))
                    return false;
            }
            return (index < items.Count);
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
