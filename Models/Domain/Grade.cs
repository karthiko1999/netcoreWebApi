namespace StudentManagement.Models.Domain
{
    public class Grade
    {
        public Guid GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        // Collection Navigation Propert
        public IList<Student> Students { get; set; }
    }

}