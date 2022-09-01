namespace ToDoApi
{
    public class SubjectDatabaseSettings : ISubjectDatabaseSettings
    {
        public string SubjectCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISubjectDatabaseSettings : ICommonDatabaseSettings
    {
        public string SubjectCollectionName { get; set; }
    }

    public class StudentDatabaseSettings : IStudentDatabaseSettings
    {
        public string StudentCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStudentDatabaseSettings : ICommonDatabaseSettings
    {
        public string StudentCollectionName { get; set; }
    }

    public class CourseDatabaseSettings : ICourseDatabaseSettings
    {
        public string CourseCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ICourseDatabaseSettings : ICommonDatabaseSettings
    {
        public string CourseCollectionName { get; set; }
    }
}
