using StudentManagement.Models.Domain;
namespace StudentManagement.Repositories
{
    public interface IStudentRepository
    {
         List<Student> GetAll();
         Student Get(Guid id);

         Student Delete(Guid id);

         Student Add(Student newStudent);

         Student Update(Guid id,Student updateStudent);
    }
}