using University.Database;
using University.Database.Models;

namespace University.Management.Service
{
    public class StudentService : IStudentService
    {
        private readonly Neo4jDbContext _neo4JDbContext;

        public StudentService(Neo4jDbContext neo4JDbContext)
        {
           _neo4JDbContext = neo4JDbContext;
        }

        public async Task AddStudent(Student student)
        {
            using var session =  _neo4JDbContext.Session;
            await session.ExecuteWriteAsync(async tx =>
            {
                var parameters = new Dictionary<string, object>
            {
                { "id", student.id },
                { "name", student.name }
            };
                await tx.RunAsync(@"
                CREATE (s:Student {id: $id, name: $name})
                RETURN s", parameters).ConfigureAwait(false);
            });
        }

        public void DeleteStudent()
        {

        }

        public void DeleteStudentRelationship()
        {
        }

        public void DeleteStudents()
        {

        }

        public void DeleteStudentRelationships()
        {
        }
    }
}
