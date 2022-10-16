using lms.Contracts.Courses;
using lms.Domain.Entities;

namespace lms.Application.Services.Courses
{
    public interface ICoursesService
    {
        CourseDetailsResponse Add(AddCourseRequest course);
        CourseDetailsResponse Delete(string CourseName);

        List<CourseDetailsResponse> Get(string technology, int durationFromRange, int durationToRange);
        List<CourseDetailsResponse> GetAll();
        List<CourseDetailsResponse> Info(string technology);
    }
}