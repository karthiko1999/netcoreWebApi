namespace StudentManagement.Models.DTOs
{
    public class Student
    {
        public Guid IdOfStudent { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid GradeId { get; set; }
        public Guid StudentAddressId { get; set; }

        // This is the Reference Navagitaion Property
        public Grade Grade { get; set; }
        public StudentAddress Address {get;set;}
        

    }

}