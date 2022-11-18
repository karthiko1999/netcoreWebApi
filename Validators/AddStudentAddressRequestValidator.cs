using FluentValidation;


namespace Validators
{
    public class AddStudentAddressRequestValidator : AbstractValidator<StudentManagement.Models.DTOs.AddStudentAddressRequest>
    {
        public AddStudentAddressRequestValidator()
        {
            RuleFor(x=>x.Address).NotEmpty();
            RuleFor(x=>x.City).NotEmpty();
            RuleFor(x=>x.State).NotEmpty();
            RuleFor(x=>x.Country).NotEmpty();
        }
    }
    
}