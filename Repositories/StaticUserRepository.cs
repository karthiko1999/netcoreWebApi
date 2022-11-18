using StudentManagement.Models.Domain;

namespace StudentManagement.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> _users;

        public StaticUserRepository()
        {
            _users = new List<User>(){
                new User(){
                    Id = Guid.NewGuid(),
                    UserName = "readonly",
                    FirstName = "read",
                    LastName ="only",
                    EmailAddress = "readonly@user.com",
                    Password ="readonly@user123",
                    Roles = new List<string>(){"reader"}
                },
                new User(){
                    Id = Guid.NewGuid(),
                    UserName = "readwrite",
                    FirstName = "read",
                    LastName ="write",
                    EmailAddress = "readwrite@user.com",
                    Password ="readwrite@user123",
                    Roles = new List<string>(){"reader","writer"}
                }
            };
        }
        public User Authenticate(string username,string password)
        {
            var user = _users.Find(x => 
            {
                 return x.UserName.Equals(username,StringComparison.InvariantCultureIgnoreCase)  && x.Password.Equals(password);
            });
            return user;
        }
    }
}