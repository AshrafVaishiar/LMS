using AutoMapper;
using lms.Application.Services.Authentication;
using lms.Contracts.Courses;
using lms.Domain.Entities;
using lms.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lms.Application.Services.Courses
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository _courseRepository;
        private readonly IMapper _mapper;

        public CoursesService(ICoursesRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public List<CourseDetailsResponse> Get(string technology, int durationFromRange, int durationToRange)
        {
            var courses = _courseRepository.Get(technology, durationFromRange, durationToRange);
            List<CourseDetailsResponse> CourseDetailsResponse = _mapper.Map<List<CourseDetailsResponse>>(courses.Result);
            return CourseDetailsResponse;
        }

        public List<CourseDetailsResponse> GetAll()
        {
            var courses = _courseRepository.GetAll();
            List<CourseDetailsResponse> courseDetailsResponses = new();
            CourseDetailsResponse courseDetailsResponse = new();
            foreach (var course in courses.Result)
            {
                courseDetailsResponse = new CourseDetailsResponse()
                {
                    CourseName = course.CourseName,
                    CourseDuration = course.CourseDuration,
                    CourseDescription = course.CourseDescription,
                    CourseTechnology = course.CourseTechnology
                };
                
                courseDetailsResponses.Add(courseDetailsResponse);
            }
            return courseDetailsResponses;
        }

        public List<CourseDetailsResponse> Info(string technology)
        {
            var courses = _courseRepository.GetCourseByTechnology(technology);
            List<CourseDetailsResponse> CourseDetailsResponse = _mapper.Map<List<CourseDetailsResponse>>(courses.Result);
            return CourseDetailsResponse;
        }

        public CourseDetailsResponse Add(AddCourseRequest request)
        {
            var course = new Course
            {
                CourseName = request.CourseName,
                CourseDescription = request.CourseDescription,
                CourseTechnology = request.CourseTechnology,
                CourseLaunchURL = request.CourseLaunchURL,
                CourseDuration = request.CourseDuration
            };

            _courseRepository.Create(course);
            CourseDetailsResponse CourseDetailsResponse = _mapper.Map<CourseDetailsResponse>(course);
            return CourseDetailsResponse;
        }

        public CourseDetailsResponse Delete(string CourseName)
        {
            var course = new Course
            {
                CourseName = CourseName
            };

            _courseRepository.Delete(CourseName);
            CourseDetailsResponse CourseDetailsResponse = _mapper.Map<CourseDetailsResponse>(course);
            return CourseDetailsResponse;
        }
    }
}
