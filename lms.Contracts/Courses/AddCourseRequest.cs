using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lms.Contracts.Courses
{
    public class AddCourseRequest
    {
        public string CourseName { get; set; } = string.Empty;
        public int CourseDuration { get; set; }
        public string CourseDescription { get; set; } = string.Empty;
        public string CourseTechnology { get; set; } = string.Empty;
        public string CourseLaunchURL { get; set; } = string.Empty;
    }
}
