using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApi;
using ToDoApi.Entities;

namespace Services
{  
    public class CourseService
    {
        private readonly IMongoCollection<CourseItem> CourseItems;

        public CourseService(ICourseDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            CourseItems = database.GetCollection<CourseItem>(settings.CourseCollectionName);
        }

        public CourseItem Create(CourseItem CourseItem)
        {
            CourseItems.InsertOne(CourseItem);
            return CourseItem;
        }

        public CourseItem Update(CourseItem CourseItem)
        {
            CourseItems.ReplaceOne(item => item.Id == CourseItem.Id, CourseItem);
            return CourseItem;
        }

        public List<CourseItem> Get()
        {
            List<CourseItem> Courses;
            Courses = CourseItems.Find(emp => true).ToList();
            return Courses;
        }

        public CourseItem Get(string id) =>
            CourseItems.Find<CourseItem>(item => item.Id == id).FirstOrDefault();

        public List<CourseItem> GetByName(string name) =>
           CourseItems.Find<CourseItem>(item => item.Name == name).ToList();

        internal void Delete(string id)
        {
            CourseItems.DeleteOne<CourseItem>(item => item.Id == id);
        }
    }
}
