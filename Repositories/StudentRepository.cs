using StudentManagement.Models.Domain;
using StudentManagement.Data;
using System.Data.Entity;

namespace StudentManagement.Repositories
{
    public class StudentRepository : IStudentRepository 
    {
        public StudentDbContext _studentDbContext;
       public StudentRepository(StudentDbContext studentDbContext)
       {
           this._studentDbContext = studentDbContext;
       }

        public List<Student> GetAll()
       {
           return _studentDbContext.Students.Include(stu=>stu.GradeId).Include(stu=>stu.StudentAddressId).ToList();
       }


        public Student Get(Guid id)
        {
            var student = _studentDbContext.Students.FirstOrDefault(student=> student.StudentID == id);

            if(student == null)
             return null;
             
            return student;
        }

        public Student Delete(Guid id)
        {
            var student = _studentDbContext.Students.FirstOrDefault(student=> student.StudentID == id);

            // check the student with id exist in DB or not if exit delete else return null
            if(student == null)
             return null;
            
            _studentDbContext.Students.Remove(student);
            _studentDbContext.SaveChanges();
            return student;

        }

        public Student Add(Student newStudent)
        {
            newStudent.StudentID = Guid.NewGuid();
            _studentDbContext.Students.Add(newStudent);
            _studentDbContext.SaveChanges();
            return newStudent;
        }

        public Student Update(Guid id, Student updateStudent)
        {
            var student = _studentDbContext.Students.FirstOrDefault(student=> student.StudentID == id);

            if(student == null)
            return null;

            student.StudentName = updateStudent.StudentName;
            student.DateOfBirth = updateStudent.DateOfBirth;
            student.GradeId = updateStudent.GradeId;
            student.StudentAddressId = updateStudent.StudentAddressId;

            _studentDbContext.SaveChanges();

            return student;
        }
    }
}