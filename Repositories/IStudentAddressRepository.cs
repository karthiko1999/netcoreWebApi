using StudentManagement.Models.Domain;

namespace StudentManagement.Repositories
{
    public interface IStudentAddressRepository
    {
         List<StudentAddress> GetAll();
         StudentAddress Get(Guid id);

         StudentAddress Delete(Guid id);

         StudentAddress Add(StudentAddress newStudentAddress);

         StudentAddress Update(Guid id,StudentAddress updateStudentAddress);
    }
}