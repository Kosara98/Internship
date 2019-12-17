using System.Collections.Generic;

namespace DBFirstApproach
{
    public abstract class UniRepository<T> where T : BaseModel
    {
        public abstract void Add(T model);
        public abstract void Update(T model);
        public abstract void Delete(T model);
        public abstract IEnumerable<T> GetAll();
    }
}
