using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName {get;set;}
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string EmailAddress { get; set; }    
        public string Password { get; set; }

         // Navigation Property - Collection
        public IList<User_Role> userRoles { get; set; }   

        [NotMapped]
        public IList<String> Roles { get; set; } 

    }
}