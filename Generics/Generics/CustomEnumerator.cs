using System.Collections;
using System.Collections.Generic;

namespace Generics
{
    public class CustomEnumerator<T> : IEnumerator<T>
    {
        
        public T Current => throw new System.NotImplementedException();

        object IEnumerator.Current => throw new System.NotImplementedException();

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
