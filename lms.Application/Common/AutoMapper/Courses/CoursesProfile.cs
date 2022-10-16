using AutoMapper;
using lms.Contracts.Courses;
using lms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lms.Application.Common.AutoMapper.Courses
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            //CreateMap<Course, CourseDetailsResponse>().ForMember(dest =>
            //dest.CourseName,
            //opt => opt.MapFrom(src => src.CourseName))
            //.ForMember(dest =>
            //dest.CourseDuration,
            //opt => opt.MapFrom(src => src.CourseDuration))
            //.ForMember(dest =>
            //dest.CourseDescription,
            //opt => opt.MapFrom(src => src.CourseDescription))
            //.ForMember(dest =>
            //dest.CourseTechnology,
            //opt => opt.MapFrom(src => src.CourseTechnology));

            CreateMap<Course, CourseDetailsResponse>();

        }
    }
}
