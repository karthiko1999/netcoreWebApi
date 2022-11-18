namespace StudentManagement.Models.DTOs
{
    public class AddStudentRequest
    {
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid GradeId { get; set; }
        public Guid StudentAddressId { get; set; }

    }
}