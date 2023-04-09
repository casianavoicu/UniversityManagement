
using HotChocolate.Data.Neo4J;
using Neo4j.Driver;
using University.Database;
using University.Management.BusinessLogic;
using University.Management.Service;
using UniversityManagement.GraphQlQueries;

namespace UniversityManagement
{
    public static class Composition
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                   .AddQueryType<UserQuery>()
                   .AddMutationType<Mutation>()
                .AddNeo4JFiltering()
                .AddNeo4JSorting()
                .AddNeo4JProjections();

            services.AddSingleton<Neo4jDbContext>();
            services.AddSingleton<Resolvers>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddSingleton<ITeacherService, TeacherService>();
            return services;
        }
    }
}
