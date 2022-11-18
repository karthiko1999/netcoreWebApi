using FluentValidation;


namespace Validators
{
    public class UpdateStudentAddressRequestValidator : AbstractValidator<StudentManagement.Models.DTOs.UpdateStudentAddressRequest>
    {
        public UpdateStudentAddressRequestValidator()
        {
            RuleFor(x=>x.Address).NotEmpty();
            RuleFor(x=>x.City).NotEmpty();
            RuleFor(x=>x.State).NotEmpty();
            RuleFor(x=>x.Country).NotEmpty();
        }
    }
    
}