namespace StudentManagement.Models.DTOs
{
    public class StudentAddress
    {
        public Guid IdOfStudentAddress { get; set; }

        public string Address{get;set;}
        public string City { get; set; }    

        public string State { get; set; }
        public string Country { get; set; }
        
    }
}