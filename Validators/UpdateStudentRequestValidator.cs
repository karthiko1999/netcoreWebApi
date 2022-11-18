using FluentValidation;


namespace Validators
{
    public class UpdateStudentRequestValidator : AbstractValidator<StudentManagement.Models.DTOs.UpdateStudentRequest>
    {
        public UpdateStudentRequestValidator()
        {
            RuleFor(x=>x.StudentName).NotEmpty();
            RuleFor(x=>x.DateOfBirth).NotEmpty().WithMessage("Date Cannot Be Empty..")
            .LessThan(p => DateTime.Now).WithMessage("Date Can be less than present date..");

        }
    }
}    
    