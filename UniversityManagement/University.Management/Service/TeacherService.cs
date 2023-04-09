using ServiceStack.Text;
using University.Database;
using University.Database.Models;

namespace University.Management.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly Neo4jDbContext _neo4JDbContext;
        public TeacherService(Neo4jDbContext neo4JDbContext)
        {
            _neo4JDbContext = neo4JDbContext;
        }

        public async Task AddTeacher(Teacher teacher)
        {
            using var session = _neo4JDbContext.Session;
            await session.ExecuteWriteAsync(async tx =>
            {
                var parameters = new Dictionary<string, object>
            {
                { "id", teacher.id },
                { "name", teacher.name }
            };
                await tx.RunAsync(@"
                CREATE (t:Teacher {id: $id, name: $name})
                RETURN t", parameters).ConfigureAwait(false);
            });
        }

        public void DeleteTeacher()
        {

        }

        public void DeleteTeacherRelationship()
        {
        }

        public void DeleteTeachers()
        {

        }

        public void DeleteTeacherRelationships()
        {
        }

        public async Task AddTeacherToStudentRelationShip(string studentId, string teacherId)
        {
            using var session = _neo4JDbContext.Session;
            await session.ExecuteWriteAsync(async tx =>
            {
                var parameters = new Dictionary<string, object>
                {
                    { "studentId", studentId },
                    { "teacherId", teacherId }
            };
                await tx.RunAsync(@"
                MATCH (s: Student),(t: Teacher)
                WHERE s.name = $studentId AND t.name = $teacherId
                CREATE (s)-[:TAUGHT_BY]->(t)", parameters).ConfigureAwait(false);
            });
        }
    }
}
