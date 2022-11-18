namespace StudentManagement.Models.DTOs
{
    public class AddStudentAddressRequest
    {

        public string Address{get;set;}
        public string City { get; set; }    

        public string State { get; set; }
        public string Country { get; set; }
    }
}