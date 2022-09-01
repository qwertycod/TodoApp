using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    public class ToDoDatabaseSettings : IToDoDatabaseSettings
    {
        public string ToDoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IToDoDatabaseSettings : ICommonDatabaseSettings
    {
        public string ToDoCollectionName { get; set; }
    }
}
