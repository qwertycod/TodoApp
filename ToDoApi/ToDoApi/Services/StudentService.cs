using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApi;
using ToDoApi.Entities;

namespace Services
{  
    public class StudentService
    {
        private readonly IMongoCollection<StudentItem> StudentItems;

        public StudentService(IStudentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            StudentItems = database.GetCollection<StudentItem>(settings.StudentCollectionName);
        }

        public StudentItem Create(StudentItem StudentItem)
        {
            StudentItems.InsertOne(StudentItem);
            return StudentItem;
        }

        public StudentItem Update(StudentItem StudentItem)
        {
            StudentItems.ReplaceOne(item => item.Id == StudentItem.Id, StudentItem);
            return StudentItem;
        }

        public List<StudentItem> Get()
        {
            List<StudentItem> Students;
            Students = StudentItems.Find(emp => true).ToList();
            return Students;
        }

        public StudentItem Get(string id) =>
            StudentItems.Find<StudentItem>(item => item.Id == id).FirstOrDefault();

        public List<StudentItem> GetByUserId(string userId) =>
           StudentItems.Find<StudentItem>(item => item.UserId == userId).ToList();

        internal void Delete(string id)
        {
            StudentItems.DeleteOne<StudentItem>(item => item.Id == id);
        }
    }
}
