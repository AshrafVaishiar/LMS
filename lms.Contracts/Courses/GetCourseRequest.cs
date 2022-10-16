using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lms.Contracts.Courses
{
    public class GetCourseRequest
    {
        public string CourseTechnology { get; set; } = String.Empty;

        public int durationFromRange { get; set; }

        public int durationToRange { get; set; }
    }
}
