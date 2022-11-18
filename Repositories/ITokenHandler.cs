using StudentManagement.Models.Domain;

namespace StudentManagement.Repositories
{
    public interface ITokenHandler 
    {
        string CreateToken(User user);
    }
}