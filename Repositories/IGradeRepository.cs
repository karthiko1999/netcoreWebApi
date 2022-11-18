using StudentManagement.Models.Domain;

namespace StudentManagement.Repositories
{
    public interface IGradeRepository
    {
         List<Grade> GetAll();
         Grade Get(Guid id);

         Grade Delete(Guid id);

         Grade Add(Grade newGrade);

         Grade Update(Guid id,Grade updateGrade);
    }
}