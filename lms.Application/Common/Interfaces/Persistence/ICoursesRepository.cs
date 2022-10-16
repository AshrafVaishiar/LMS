using lms.Domain.Entities;

namespace lms.Infrastructure.Persistence
{
    public interface ICoursesRepository
    {
        Task Create(Course course);
        Task Delete(string orderId);
        Task<List<Course>> Get(string technology, int durationFromRange, int durationToRange);
        Task<List<Course>> GetAll();
        Task<List<Course>> GetCourseByTechnology(string technology);
    }
}