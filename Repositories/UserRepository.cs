using StudentManagement.Data;
using StudentManagement.Models.Domain;

namespace StudentManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        public StudentDbContext _studentDbContext;
        public UserRepository(StudentDbContext studentDbContext)
        {
            this._studentDbContext = studentDbContext;
        }

        public User Authenticate(string username, string password)
        {
            var user = _studentDbContext.Users.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower() && x.     Password==password);

            if (user == null)
            {
                return null;
            }
            var userRoles = _studentDbContext.Users_Roles.Where(x => x.UserId == user.Id).ToList();
            if (userRoles.Any())
            {
                user.Roles = new List<String>();
                foreach (var userrole in userRoles)
                {
                    var role = _studentDbContext.Roles.FirstOrDefault(x => x.Id == userrole.RoleId);
                    if (role != null)
                        user.Roles.Add(role.Name);
                }
            }
            // user.Password = null;
            return user;
        }
    }
}