using University.Database.Models;

namespace University.Management.Service
{
    public interface IStudentService
    {
        Task AddStudent(Student student);
        void DeleteStudent();
        void DeleteStudentRelationship();
        void DeleteStudentRelationships();
        void DeleteStudents();
    }
}