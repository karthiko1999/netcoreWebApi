using StudentManagement.Models.Domain;

namespace StudentManagement.Repositories
{
    public interface IUserRepository 
    {
        User Authenticate(string username,string password);
    }
}