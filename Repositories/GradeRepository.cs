using StudentManagement.Models.Domain;
using StudentManagement.Data;
using System.Data.Entity;

namespace StudentManagement.Repositories
{
    public class GradeRepository : IGradeRepository 
    {
        public StudentDbContext _studentDbContext;
       public GradeRepository(StudentDbContext studentDbContext)
       {
           this._studentDbContext = studentDbContext;
       }

        public List<Grade> GetAll()
       {
           return _studentDbContext.Grades.ToList();
       }


        public Grade Get(Guid id)
        {
            var grade = _studentDbContext.Grades.FirstOrDefault(grade=> grade.GradeId == id);

            if(grade == null)
             return null;
             
            return grade;
        }

        public Grade Delete(Guid id)
        {
            var grade = _studentDbContext.Grades.FirstOrDefault(grade=> grade.GradeId == id);

            // check the student with id exist in DB or not if exit delete else return null
            if(grade == null)
             return null;
            
            _studentDbContext.Grades.Remove(grade);
            _studentDbContext.SaveChanges();
            return grade;

        }

        public Grade Add(Grade newGrade)
        {
            newGrade.GradeId = Guid.NewGuid();
            _studentDbContext.Grades.Add(newGrade);
            _studentDbContext.SaveChanges();
            return newGrade;
        }

        public Grade Update(Guid id,Grade updateGrade)
        {
            var grade = _studentDbContext.Grades.FirstOrDefault(grade=> grade.GradeId == id);

            if(grade == null)
            return null;

            grade.GradeName = updateGrade.GradeName;
            grade.Section = updateGrade.Section;

            _studentDbContext.SaveChanges();

            return grade;
        }

        
    }
}