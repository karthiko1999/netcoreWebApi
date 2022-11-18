namespace StudentManagement.Models.Domain
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    

        // Navigation Property - Collection
        public IList<User_Role> roleUsers { get; set; }   

    }
}