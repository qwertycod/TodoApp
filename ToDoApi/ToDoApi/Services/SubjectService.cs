using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApi;
using ToDoApi.Entities;

namespace Services
{  
    public class SubjectService
    {
        private readonly IMongoCollection<SubjectItem> SubjectItems;

        public SubjectService(ISubjectDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            SubjectItems = database.GetCollection<SubjectItem>(settings.SubjectCollectionName);
        }

        public SubjectItem Create(SubjectItem SubjectItem)
        {
            SubjectItems.InsertOne(SubjectItem);
            return SubjectItem;
        }

        public SubjectItem Update(SubjectItem SubjectItem)
        {
            SubjectItems.ReplaceOne(item => item.Id == SubjectItem.Id, SubjectItem);
            return SubjectItem;
        }

        public List<SubjectItem> Get()
        {
            List<SubjectItem> Subjects;
            Subjects = SubjectItems.Find(emp => true).ToList();
            return Subjects;
        }

        public SubjectItem Get(string id) =>
            SubjectItems.Find<SubjectItem>(item => item.Id == id).FirstOrDefault();

        public List<SubjectItem> GetByName(string name) =>
           SubjectItems.Find<SubjectItem>(item => item.Name == name).ToList();

        internal void Delete(string id)
        {
            SubjectItems.DeleteOne<SubjectItem>(item => item.Id == id);
        }
    }
}
