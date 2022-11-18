using FluentValidation;

namespace StudentManagement.Validators
{
    public class UserRequest : AbstractValidator<Models.DTOs.UserRequest>
    {
        public UserRequest()
        {
            RuleFor(x=>x.UserName).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
        }
    }
}