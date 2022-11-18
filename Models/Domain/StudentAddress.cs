namespace StudentManagement.Models.Domain
{
    public class StudentAddress
    {
        public Guid StudentAddressId { get; set; }
        public string Address{get;set;}
        public string City { get; set; }    

        public string State { get; set; }
        public string Country { get; set; }

        // Collection Navigation Propert
        public IList<Student> Students { get; set; }

    }
}