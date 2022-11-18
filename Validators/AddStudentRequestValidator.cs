using FluentValidation;


namespace Validators
{
    public class AddStudentRequestValidator : AbstractValidator<StudentManagement.Models.DTOs.AddStudentRequest>
    {
        public AddStudentRequestValidator()
        {
            RuleFor(x=>x.StudentName).NotEmpty();
            RuleFor(x=>x.DateOfBirth).NotEmpty().WithMessage("Date Cannot Be Empty..")
            .LessThan(p => DateTime.Now).WithMessage("Date Can be less than present date..");

        }
    }
    
}