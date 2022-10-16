using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lms.Domain.Entities
{
    public class Course
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("course_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string CourseName { get; set; } = string.Empty;

        [BsonElement("course_duration"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public int CourseDuration { get; set; }

        [BsonElement("course_description"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string CourseDescription { get; set; } = string.Empty;

        [BsonElement("course_technology"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string CourseTechnology { get; set; } = string.Empty;

        [BsonElement("course_url"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string CourseLaunchURL { get; set; } = string.Empty; 
    }
}