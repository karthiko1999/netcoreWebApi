using StudentManagement.Models.Domain;
using StudentManagement.Data;
using System.Data.Entity;

namespace StudentManagement.Repositories
{
    public class StudentAddressRepository : IStudentAddressRepository 
    {
        public StudentDbContext _studentDbContext;
       public StudentAddressRepository(StudentDbContext studentDbContext)
       {
           this._studentDbContext = studentDbContext;
       }

        public List<StudentAddress> GetAll()
       {
           return _studentDbContext.StudentAddresses.ToList();
       }


        public StudentAddress Get(Guid id)
        {
            var studentAddress = _studentDbContext.StudentAddresses.FirstOrDefault(adr=> adr.StudentAddressId == id);

            if(studentAddress == null)
             return null;
             
            return studentAddress;
        }

        public StudentAddress Delete(Guid id)
        {
            var studentAddress = _studentDbContext.StudentAddresses.FirstOrDefault(adr=> adr.StudentAddressId == id);

            // check the student with id exist in DB or not if exit delete else return null
            if(studentAddress == null)
             return null;
            
            _studentDbContext.StudentAddresses.Remove(studentAddress);
            _studentDbContext.SaveChanges();
            return studentAddress;

        }

        public StudentAddress Add(StudentAddress newStudentAddress)
        {
            newStudentAddress.StudentAddressId = Guid.NewGuid();
            _studentDbContext.StudentAddresses.Add(newStudentAddress);
            _studentDbContext.SaveChanges();
            return newStudentAddress;
        }

        public StudentAddress Update(Guid id, StudentAddress updateStudentAddress)
        {
            var studentAddress = _studentDbContext.StudentAddresses.FirstOrDefault(adr=> adr.StudentAddressId == id);

            if(studentAddress == null)
            return null;

            studentAddress.Address = updateStudentAddress.Address;
            studentAddress.City= updateStudentAddress.City;
            studentAddress.State = updateStudentAddress.State;
            studentAddress.Country = updateStudentAddress.Country;

            _studentDbContext.SaveChanges();

            return studentAddress;
        }
    }
}