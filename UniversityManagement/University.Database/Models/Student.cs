using HotChocolate;
using HotChocolate.Data.Neo4J;
using HotChocolate.Types;
using University.Management.BusinessLogic;

namespace University.Database.Models
{
    public class Student
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public string? Identification { get; set; }

        public string? id { get; set; }

        public string? name { get; set; }

        [Neo4JRelationship("TAUGHT_BY", RelationshipDirection.Outgoing)]
        public List<Teacher>? Teachers { get; set; }
    }

    public class StudentType : ObjectType<Student>
    {
        protected override void Configure(IObjectTypeDescriptor<Student> descriptor)
        {
            descriptor.Field(s => s.Teachers)
                .Name("teachers")
                .ResolveWith<Resolvers>(r => r.GetTeachers(default!, default!))
                .Type<ListType<TeacherType>>();
        }
    }
}
