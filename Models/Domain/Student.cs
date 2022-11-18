using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models.Domain
{
    public class Student
    {
        public Guid StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }


        public Guid GradeId { get; set; }

        public Guid StudentAddressId { get; set; }

        // This is the Reference Navagitaion Property
        public Grade Grade { get; set; }
        public StudentAddress Address {get;set;}
        

    }

}