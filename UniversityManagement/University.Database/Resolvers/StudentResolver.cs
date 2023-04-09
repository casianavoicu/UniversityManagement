using HotChocolate;
using Neo4j.Driver;
using University.Database;
using University.Database.Models;

namespace University.Management.BusinessLogic
{

    public class Resolvers
    {
        private readonly IDriver _driver;

        public Resolvers(IDriver driver)
        {
            _driver = driver;
        }

        public async Task<IList<Teacher>> GetTeachers(Student student, [ScopedService] Neo4jDbContext context)
        {
            var query = @"
            MATCH (s:Student)-[:TEACHES_BY]->(t:Teacher)
            WHERE s.id = $id
            RETURN t.id AS id, t.name AS name
        ";

            var result = await context.Session.RunAsync(query, new { id = student.id });

            return await result.ToListAsync(r => new Teacher
            {
                id = r["id"].As<string>(),
                name = r["name"].As<string>()
            });
        }

        public async Task<IList<Student>> GetStudents(Teacher teacher, [ScopedService] Neo4jDbContext context)
        {
            var query = @"
            MATCH (t:Teacher)-[:TEACHES_BY]->(s:Student)
            WHERE t.id = $id
            RETURN s.id AS id, s.name AS name
        ";

            var result = await context.Session.RunAsync(query, new { id = teacher.id });

            return await result.ToListAsync(r => new Student
            {
                id = r["id"].As<string>(),
                name = r["name"].As<string>()
            });
        }
    }


}
