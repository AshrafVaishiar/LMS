using lms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lms.Contracts.Courses
{
    public class CourseDetailsResponse
    {
        private lms.Domain.Entities.Course course;

        public CourseDetailsResponse(Course course)
        {
            this.course = course;
        }

        public CourseDetailsResponse()
        {

        }

        public string CourseName { get; set; } = string.Empty; 

        public int CourseDuration { get; set; }

        public string CourseDescription { get; set; } = string.Empty;

        public string CourseTechnology { get; set; } = string.Empty;
    }
}
