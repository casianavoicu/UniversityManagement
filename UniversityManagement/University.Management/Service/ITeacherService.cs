using University.Database.Models;

namespace University.Management.Service
{
    public interface ITeacherService
    {
        Task AddTeacher(Teacher teacher);

        Task AddTeacherToStudentRelationShip(string studentId, string teacherId);
        void DeleteTeacher();
        void DeleteTeacherRelationship();
        void DeleteTeacherRelationships();
        void DeleteTeachers();
    }
}