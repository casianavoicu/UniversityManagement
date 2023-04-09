using Neo4j.Driver;
using University.Database.Models;
using University.Management.Service;

namespace UniversityManagement.GraphQlQueries
{
    public class Mutation
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public Mutation(IStudentService studentService, ITeacherService teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }

        public async Task<Student> AddStudent(Student student)
        {
            await _studentService.AddStudent(student);
            return student;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            await _teacherService.AddTeacher(teacher);
            return teacher;
        }

        public async Task<int> AddTeacherToStudentRelationShip(string studentId, string teacherId)
        {
            await _teacherService.AddTeacherToStudentRelationShip(studentId, teacherId);
            return 1;
        }
    }
}
