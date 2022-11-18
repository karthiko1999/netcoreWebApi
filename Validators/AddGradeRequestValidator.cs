using FluentValidation;


namespace Validators
{
    public class AddGradeRequestValidator : AbstractValidator<StudentManagement.Models.DTOs.AddGradeRequest>
    {
        public AddGradeRequestValidator()
        {
            RuleFor(x=>x.GradeName).NotEmpty();
            RuleFor(x=>x.Section).NotEmpty();
        }
    }
    
}