using System.Collections.Generic;

namespace CodeFirstWithDB
{
    public interface ICourseRepository
    {
        public void Add(Course course);
        public void Update(Course targetCourse, Course updatedCourse);
        public void Delete(Course course);
        public IEnumerable<Course> GetAll();
    }
}
