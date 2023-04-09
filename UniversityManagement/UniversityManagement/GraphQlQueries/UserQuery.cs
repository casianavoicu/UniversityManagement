using HotChocolate.Data.Neo4J;
using HotChocolate.Data.Neo4J.Execution;
using Neo4j.Driver;
using University.Database.Models;

namespace UniversityManagement.GraphQlQueries
{
    public class UserQuery
    {
        [GraphQLName("students")]
        [UseNeo4JDatabase(databaseName: "neo4j")]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IExecutable<Student> GetStudents([ScopedService] IAsyncSession session)
        {
            return new Neo4JExecutable<Student>(session);
        }

        [GraphQLName("teachers")]
        [UseNeo4JDatabase(databaseName: "neo4j")]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IExecutable<Teacher>> GetTeachers([ScopedService] IAsyncSession session)
        {
            return new Neo4JExecutable<Teacher>(session);
        }
    }
}
