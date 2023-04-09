using HotChocolate.Data.Neo4J;
using HotChocolate.Types;

namespace University.Database.Models
{
    public class Teacher
    {
        public string? id { get; set; }

        public string? name { get; set; }

        public string? Identification { get; set; }

        public int MyProperty { get; set; }

        [Neo4JRelationship("TAUGHT_BY", RelationshipDirection.Incoming)]
        public List<Student>? Students { get; set; }
    }
    public class TeacherType : ObjectType<Teacher>
    {
        protected override void Configure(IObjectTypeDescriptor<Teacher> descriptor)
        {
           // descriptor.Field(t => t.Students)
           //     .Name("students")
           //     .ResolveWith<Resolvers>(r => r.GetStudents(default!, default!))
           //     .Type<ListType<StudentType>>();

           // descriptor.Field(t => t.Students)
           //.Name("students")
           //.Resolver<Resolvers>(r => r.GetStudents(default!, default!))
           //.Type<ListType<StudentType>>();
        }
    }

}
