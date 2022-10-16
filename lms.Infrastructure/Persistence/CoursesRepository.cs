using Abp.Linq.Expressions;
using lms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lms.Infrastructure.Persistence
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly IMongoCollection<Course> _courses;

        public CoursesRepository()
        {
            var dbHost = "localhost";
            var dbName = "lms";
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";

            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            var dataBase = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            _courses = dataBase.GetCollection<Course>("course");
        }

        public async Task<List<Course>> GetCourseByTechnology(string technology)
        {
            var filterDefinition = Builders<Course>.Filter.Eq(x => x.CourseTechnology, technology);
            return await _courses.Find(filterDefinition).ToListAsync();
        }
        public async Task<List<Course>> GetAll()
        {
            return await _courses.Find(Builders<Course>.Filter.Empty).ToListAsync();
        }

        public async Task<List<Course>> Get(string technology, int durationFromRange, int durationToRange)
        {
            var filterDefinition = Builders<Course>.Filter.Eq(x => x.CourseTechnology, technology);

            if(durationToRange>0 && durationFromRange>0)
            {
                filterDefinition &= Builders<Course>.Filter.Gte(x => x.CourseDuration, durationFromRange);
                filterDefinition &= Builders<Course>.Filter.Lte(x => x.CourseDuration, durationToRange);
            }
            return await _courses.Find(filterDefinition).ToListAsync();
        }

        public async Task Create(Course course)
        {
            await _courses.InsertOneAsync(course);
        }

        public async Task Delete(string CourseName)
        {
            //var filterDefinition = Builders<Course>.Filter.Eq(x => x.Id, orderId);
            var filterDefinition = Builders<Course>.Filter.Eq(x => x.CourseName, CourseName);
            await _courses.DeleteManyAsync(filterDefinition);
        }
    }
}
